using System;
using System.IO;

namespace MyNeuralNetwork
{
    [Serializable]
    public class NeuralNetwork
    {
        private Layer[] neuralLayers;

        public NeuralNetwork(int layers, int hiddenNeurons, int innerNeurons, int outNeurons)
        {
            Random rand = new Random();
            neuralLayers = new Layer[layers];
            for (int i = 0; i < layers; i++)
            {
                if (i == 0)
                {
                    neuralLayers[i] = new Layer(rand, innerNeurons, 0);
                }
                else if (i == layers - 1)
                {
                    neuralLayers[i] = new Layer(rand, outNeurons, hiddenNeurons);
                }
                else
                {
                    neuralLayers[i] = new Layer(rand, hiddenNeurons, neuralLayers[i-1].Length);
                }
            }
        }

        private void SetInputs(float[] inner)
        {
            Layer innerLayer = neuralLayers[0];
            for (int i = 0; i < innerLayer.Length; i++)
            {
                innerLayer.Set(i, inner[i]);
            }
        }

        private void Recalculate()
        {
            for (int i = 1; i < neuralLayers.Length; i++)
            {
                neuralLayers[i].With(neuralLayers[i-1]);
            }
        }

        public float[] GetOutput()
        {
            Layer outPut = neuralLayers[neuralLayers.Length - 1];
            float[] outPutValues = new float[outPut.Length];

            for (int i = 0; i < outPut.Length; i++)
            {
                outPutValues[i] = outPut.Get(i).value;
            }

            return outPutValues;
        }

        public void CalculateErrors()
        {
            for (int i = neuralLayers.Length - 1; i > 0; i--)
            {
                Layer prevLayer = neuralLayers[i - 1];
                for (int pn = 0; pn < prevLayer.Length; pn++)
                {
                    Neuron neuron = prevLayer.Get(pn);
                    neuron.error = 0;
                    Layer curLayer = neuralLayers[i];
                    for (int n = 0; n < curLayer.Length; n++)
                    {
                        Neuron cur = curLayer.Get(n);
                        neuron.error += cur.weights[pn] * cur.error;
                    }
                }
            }
        }

        private float LearningRate = 0.1f;
        public void GetErrorGradient()
        {
            for (int i = neuralLayers.Length - 1; i > 0; i--)
            {
                Layer layerI1 = neuralLayers[i - 1];
                for (int pn = 0; pn < layerI1.Length; pn++)
                {
                    Neuron prevNeuron = layerI1.Get(pn);
                    Layer layerI = neuralLayers[i];
                    for (int n = 0; n < layerI.Length; n++)
                    {
                        Neuron neuron = layerI.Get(n);
                        float sig = neuron.value;
                        float dw = -Utils.Round(neuron.error);
                        dw *= Utils.Round(sig * (1 - sig));
                        dw *= Utils.Round(prevNeuron.value);
                        float newW = -LearningRate * dw;
                        neuron.weights[pn] += newW;
                    }
                }
            }
        }

        public void Work(float[][] inner)
        {
            for (int i = 0; i < inner.Length; i++)
            {
                SetInputs(inner[i]);
                Recalculate();
                float[] outPut = GetOutput();

                for (int o = 0; o < outPut.Length; o++)
                {
                    Console.WriteLine(o + ": " + outPut[o] + "A: " + GetAnswer());
                }
                Console.WriteLine("==========");
            }
        }

        public void Learn(float[][] inner, float[][] answers)
        {
            float errorSum = 0f;
            for (int i = 0; i < inner.Length; i++)
            {
                SetInputs(inner[i]);
                Recalculate();
                float[] outPut = GetOutput();
                Layer outPutLayer = neuralLayers[neuralLayers.Length - 1];

                for (int o = 0; o < outPut.Length; o++)
                {
                    outPutLayer.Get(o).error = Utils.Error(outPut[o], answers[i][o]);
                    errorSum += Utils.Derivative.Error(outPut[o], answers[i][o]);
                }
            }

            FileStream Dic = new FileStream("result.txt", FileMode.Append);
            StreamWriter writer = new StreamWriter(Dic);
            writer.WriteLine(errorSum.ToString() + "\n");
            writer.Close();

            CalculateErrors();
            GetErrorGradient();
        }

        private int GetAnswer()
        {
            Layer outPut = neuralLayers[neuralLayers.Length - 1];
            int index = 0;
            float max = 0f;
            for (int i = 0; i < outPut.Length; i++)
            {
                if (outPut.Get(i).value > max)
                {
                    index = i;
                    max = outPut.Get(i).value;
                }
            }
            return index;
        }

        public int Test(float[][] inner, float[][] answers)
        {
            int success = 0;
            int fail = 0;
            for (int i = 0; i < inner.Length; i++)
            {
                SetInputs(inner[i]);
                Recalculate();

                int answer = GetAnswer();
                if (answers[i][answer] == 1)
                {
                    success++;
                }
                else
                {
                    fail++;
                }
            }
            return success / ((success + fail) / 100);
        }
    }
}
