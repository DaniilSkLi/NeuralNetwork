using System;
using System.Collections.Generic;
using System.Text;

namespace MyNeuralNetwork
{
    class Utils
    {
        public static float Sigmoid(float value)
        {
            if (value > 10)
            {
                return 1f;
            }
            else if (value < -10)
            {
                return 0f;
            }
            else
            {
                return (float)(1f / (1f + Math.Exp(-value)));
            }
        }

        public static float Error(float value, float answer)
        {
            return (float)Math.Pow(answer - value, 2);
            //return answer - value;
        }

        public static float Round(float value)
        {
            value = value * 1000000f;
            value = (float)Math.Round(value);
            return value / 1000000f;
        }

        public class Derivative
        {
            public static float Sigmoid(float value)
            {
                float sigmoid = Utils.Sigmoid(value);
                return sigmoid * (1 - sigmoid);
            }
            
            public static float Error(float value, float answer)
            {
                return 2f * (value - answer);
            }
        }
    }
}
