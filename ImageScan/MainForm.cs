using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MyNeuralNetwork;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace ImageScan
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        NeuralNetwork neural = new NeuralNetwork(4, 16, 784, 10);
        private void MainForm_Load(object sender, EventArgs e)
        {
            //NeuralNetwork neural = new NeuralNetwork(3, 1, 1, 1);

            //float[][] inputs = new float[1][];
            //inputs[0] = new float[1];
            //inputs[0][0] = 1;

            //float[][] answers = new float[1][];
            //answers[0] = new float[1];
            //answers[0][0] = 1;

            //for (int i = 0; i < 100000; i++)
            //{
            //    neural.Learn(inputs, answers);
            //}
            //neural.Work(inputs);
        }

        private void MNIST_LEARN_Click(object sender, EventArgs e)
        {
            string path = "mnist/training/";
            int packCount = 100;
            int files = Directory.GetFiles(path, "*.png", SearchOption.AllDirectories).Length;

            float[][][] inputs = new float[files][][];
            float[][][] answers = new float[files][][];

            Thread[] threads = new Thread[4];

            progressBar.Value = 0;
            progressBar.Minimum = 0;
            progressBar.Maximum = files / packCount;
            progressBarLabel.Text = progressBar.Value + "/" + progressBar.Maximum;

            for (int f = 0; f < files / packCount; f++)
            {

                status.Text = "Сбор картинок...";
                Application.DoEvents();

                for (int t = 0; t < threads.Length; t++)
                {
                    inputs[f] = new float[packCount][];
                    answers[f] = new float[packCount][];

                    threads[t] = new Thread(new ParameterizedThreadStart(ImgSet));
                    threads[t].Start(f);
                    if (f < files / packCount)
                    {
                        f++;
                    }
                    else
                    {
                        break;
                    }
                }

                for (int t = 0; t < threads.Length; t++)
                {
                    if (threads[t] != null)
                    {
                        threads[t].Join();
                    }
                }

                void ImgSet(object f)
                {
                    int i = (int)f;
                    for (int c = 0; c < packCount; c++)
                    {
                        string[] allFoundFiles = Directory.GetFiles(path, i + ".png", SearchOption.AllDirectories);
                        if (allFoundFiles.Length == 0)
                        {
                            BeginInvoke((Action)(() => {
                                status.Text = "Сбор картинок завершён.\nКартинок пройдено: " + c;
                            }));
                            break;
                        }
                        string file = allFoundFiles[0];
                        string tmp = Path.GetFileName(file);
                        file = file.Replace(tmp, "").Trim('\\');
                        string dir = file.Substring(file.Length - 1);

                        Bitmap bitmap = new Bitmap(allFoundFiles[0]);
                        inputs[i][c] = new float[bitmap.Width * bitmap.Height];

                        for (int y = 0; y < bitmap.Height; y++)
                        {
                            for (int x = 0; x < bitmap.Width; x++)
                            {
                                Color p = bitmap.GetPixel(x, y);
                                inputs[i][c][(bitmap.Width * y) + x] = p.GetBrightness();
                            }
                        }

                        answers[i][c] = new float[10];
                        for (int a = 0; a < answers[i][c].Length; a++)
                        {
                            if (a == Convert.ToInt32(dir))
                                answers[i][c][a] = 1f;
                            else
                                answers[i][c][a] = 0f;
                        }
                    }
                    BeginInvoke((Action)(() => {
                        if (progressBar.Value < progressBar.Maximum)
                        {
                            progressBar.Value++;
                            progressBarLabel.Text = progressBar.Value + "/" + progressBar.Maximum;
                        }
                    }));
                }
                f--;
            }
            


            status.Text = "Обучение...";

            progressBar.Value = 0;
            progressBar.Maximum = inputs.Length + 1;
            for (int i = 0; i < inputs.Length; i++)
            {
                if (inputs[i] != null)
                {
                    neural.Learn(inputs[i], answers[i]);
                }
                if (progressBar.Value < progressBar.Maximum)
                {
                    progressBar.Value++;
                    progressBarLabel.Text = progressBar.Value + "/" + progressBar.Maximum;
                }
                Application.DoEvents();
            }
        }

        private void saveNeural_Click(object sender, EventArgs e)
        {
            saveFileDialog.ShowDialog();
            string file = saveFileDialog.FileName;
            if (file != "")
            {
                BinaryFormatter binFormat = new BinaryFormatter();
                using (Stream fStream = new FileStream(file, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    binFormat.Serialize(fStream, neural);
                }
            }
        }

        private void loadNeural_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
            string file = saveFileDialog.FileName;
            if (file != "")
            {
                BinaryFormatter binFormat = new BinaryFormatter();
                using (Stream fStream = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    neural = (NeuralNetwork)binFormat.Deserialize(fStream);
                }
            }
        }

        private void MNIST_CHECK_Click(object sender, EventArgs e)
        {
            string path = "mnist/testing/";
            int files = Directory.GetFiles(path, "*.png", SearchOption.AllDirectories).Length;
            int packCount = files;

            float[][][] inputs = new float[files][][];
            float[][][] answers = new float[files][][];

            Thread[] threads = new Thread[4];

            progressBar.Value = 0;
            progressBar.Minimum = 0;
            progressBar.Maximum = files / packCount;
            progressBarLabel.Text = progressBar.Value + "/" + progressBar.Maximum;

            for (int f = 0; f < files / packCount; f++)
            {

                status.Text = "Сбор картинок...";
                Application.DoEvents();

                for (int t = 0; t < threads.Length; t++)
                {
                    inputs[f] = new float[packCount][];
                    answers[f] = new float[packCount][];

                    threads[t] = new Thread(new ParameterizedThreadStart(ImgSet));
                    threads[t].Start(f);
                    if (f < files / packCount)
                    {
                        f++;
                    }
                    else
                    {
                        break;
                    }
                }

                for (int t = 0; t < threads.Length; t++)
                {
                    if (threads[t] != null)
                    {
                        threads[t].Join();
                    }
                }

                void ImgSet(object f)
                {
                    int i = (int)f;
                    for (int c = 0; c < packCount; c++)
                    {
                        string[] allFoundFiles = Directory.GetFiles(path, i + ".png", SearchOption.AllDirectories);
                        if (allFoundFiles.Length == 0)
                        {
                            BeginInvoke((Action)(() => {
                                status.Text = "Сбор картинок завершён.\nКартинок пройдено: " + c;
                            }));
                            break;
                        }
                        string file = allFoundFiles[0];
                        string tmp = Path.GetFileName(file);
                        file = file.Replace(tmp, "").Trim('\\');
                        string dir = file.Substring(file.Length - 1);

                        Bitmap bitmap = new Bitmap(allFoundFiles[0]);
                        inputs[i][c] = new float[bitmap.Width * bitmap.Height];

                        for (int y = 0; y < bitmap.Height; y++)
                        {
                            for (int x = 0; x < bitmap.Width; x++)
                            {
                                Color p = bitmap.GetPixel(x, y);
                                inputs[i][c][(bitmap.Width * y) + x] = p.GetBrightness();
                            }
                        }

                        answers[i][c] = new float[10];
                        for (int a = 0; a < answers[i][c].Length; a++)
                        {
                            if (a == Convert.ToInt32(dir))
                                answers[i][c][a] = 1f;
                            else
                                answers[i][c][a] = 0f;
                        }
                    }
                    BeginInvoke((Action)(() => {
                        if (progressBar.Value < progressBar.Maximum)
                        {
                            progressBar.Value++;
                            progressBarLabel.Text = progressBar.Value + "/" + progressBar.Maximum;
                        }
                    }));
                }
                f--;
            }



            status.Text = "Тестирование...";

            progressBar.Value = 0;
            progressBar.Maximum = inputs.Length + 1;
            for (int i = 0; i < inputs.Length; i++)
            {
                if (inputs[i] != null)
                {
                    neural.Test(inputs[i], answers[i]);
                }
                if (progressBar.Value < progressBar.Maximum)
                {
                    progressBar.Value++;
                    progressBarLabel.Text = progressBar.Value + "/" + progressBar.Maximum;
                }
                Application.DoEvents();
            }
        }

        private void imageCheck_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();

            if (openFileDialog.FileName != "")
            {
                float[][] inputs = new float[1][];
                string file = openFileDialog.FileName;
                string tmp = Path.GetFileName(file);
                file = file.Replace(tmp, "").Trim('\\');
                string dir = file.Substring(file.Length - 1);

                Bitmap bitmap = new Bitmap(openFileDialog.FileName);
                inputs[0] = new float[bitmap.Width * bitmap.Height];

                for (int y = 0; y < bitmap.Height; y++)
                {
                    for (int x = 0; x < bitmap.Width; x++)
                    {
                        Color p = bitmap.GetPixel(x, y);
                        inputs[0][(bitmap.Width * y) + x] = p.GetBrightness();
                    }
                }

                neural.Work(inputs);
            }
        }
    }
}
