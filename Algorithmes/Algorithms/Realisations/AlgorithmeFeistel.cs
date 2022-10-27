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
            //fill the ints tab with int between 0 and 31
            //each number is present only once


            int index;
            int[] intsRes = new int[32];
            
            int[] ints = new int[32] {1,4,6,18,28,12,24,3,17,21,8,5,2,7,26,9,31,20,25, 14, 19, 13, 3, 10, 15, 16, 27, 30, 29, 11, 22, 23 };
            
            
            for (int i = 0; i < ints.Length; i++)
            {
                intsRes[i] = 0;
            }

            for (int i = 0; i < ints.Length; i++)
            {
                index = ints[i];

                if (intsRes[index] != message[i])
                {
                    intsRes[index] = message[i];
                }
            }
            return intsRes.ToString();
        }

        public string SBox(string message)
        {
            return "";
        }

        public string EBox(string message)
        {
            return "";
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
            return "";
        }

        private string TourDechiffrement(string message, string cle, int numTour)
        {
            return "";
        }

    }
}
