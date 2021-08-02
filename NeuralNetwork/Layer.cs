using System;
using System.Collections.Generic;
using System.Text;

namespace MyNeuralNetwork
{
    [Serializable]
    class Layer
    {
        Neuron[] neurons;

        public Layer(Random rand, int Neurons, int prevLayerNeurons)
        {
            neurons = new Neuron[Neurons];
            for (int i = 0; i < Neurons; i++)
            {
                neurons[i] = new Neuron(rand, prevLayerNeurons);
            }
        }

        public int Length
        {
            get { return neurons.Length; }
        }

        public void Set(int index, float value)
        {
            neurons[index].value = value;
        }

        public Neuron Get(int index)
        {
            return neurons[index];
        }

        public void With(Layer prevLayer)
        {
            for (int n = 0; n < neurons.Length; n++)
            {
                neurons[n].value = 0;
                for (int i = 0; i < prevLayer.Length; i++)
                {
                    neurons[n].value += neurons[n].weights[i] * prevLayer.Get(i).value;
                }
                //neurons[n].value += neurons[n].bias;
                neurons[n].value = Utils.Sigmoid(neurons[n].value);
            }
        }
    }
}
