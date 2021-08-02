using System;
using System.Collections.Generic;
using System.Text;

namespace MyNeuralNetwork
{
    [Serializable]
    class Neuron
    {
        public float value;
        public float[] weights;
        public float bias;
        public float error = 0;

        public Neuron(Random rand, int prevLayerNeurons)
        {
            weights = new float[prevLayerNeurons];
            for(int i = 0; i < prevLayerNeurons; i++)
            {
                weights[i] = 0.5f;
            }
            bias = (float)rand.NextDouble();
        }
    }
}
