using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;

namespace CryptoClient.Algorithmes.Algorithms.Realisations
{
    public class AlgorithmeFeistel
    {
        string[] sbox;

        public AlgorithmeFeistel()
        {
            FileStream f = new FileStream(".\\Resources\\sbox.txt", FileMode.Open);
            StreamReader sr = new StreamReader(f);

            while (sr.EndOfStream)
            {
                string[] line = sr.ReadLine().Split(',');
                foreach (string s in line)
                {
                    sbox.SetValue(s, sbox.Count());
                }
            }

            sr.Close();
            f.Close();

        }
        private string HexToBin32(string hex)
        {
            return Convert.ToString(Convert.ToInt32(hex, 16), 2);
        }

        public string PBox(string message)
        {
            


            int index;
            char[] charRes = new char[32];
            string strRes= "";
            
            int[] ints = new int[32] {9,17,23,31,13,28,2,18,24,16,30,6,26,20,10,1,8,14,25, 3, 4, 29, 11, 19, 32, 12, 22, 7, 5, 27, 15, 21 };
            
            
            for (int i = 0; i < ints.Length; i++)
            {
                charRes[i] = '0';
            }

            for (int i = 0; i < ints.Length; i++)
            {
                index = ints[i];

                if (message[i] != '0')
                {
                    charRes[index - 1] = '1';
                }
            }

            foreach(char c in charRes)
            {
                 strRes += c; 
            }
            return strRes;
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
