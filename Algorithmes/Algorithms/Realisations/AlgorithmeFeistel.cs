using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;

namespace CryptoClient.Algorithmes.Algorithms.Realisations
{
    public class AlgorithmeFeistel
    {
        string[] sbox;

        private string HexToBin32(string hex)
        {
            return "";
        }

        public string PBox(string message)
        {
            return "";
        }

        public string SBox(string message)
        {
            return "";
        }

        public string EBox(string message)
        {
            string result = "";
            for(int i = 0; i < message.Length; i++)
            {
                if (i % 3 == 0)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        result += message[i];
                    }
                }
                else
                {
                    result += message[i];
                }
            }
            return result;
        }

        private string Add32(string nb1, string nb2)
        {
            return "";
        }

        public string F(string message, string cle)
        {
            return "";
        }

        public string ClePartielle(string cle, int numTour)
        {
            AlgorithmeCesar algoc = new AlgorithmeCesar();
            AlgorithmeVigenere algov = new AlgorithmeVigenere();
            string result = cle;
            result = algov.Chiffrer(result,algoc.Chiffrer(result,numTour.ToString()));
            return result;
        }

        private string TourDechiffrement(string message, string cle, int numTour)
        {
            return "";
        }

    }
}
