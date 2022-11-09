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
        private string[] sbox;

        public AlgorithmeFeistel()
        {
            FileStream f = new FileStream(".\\Resources\\sbox.txt", FileMode.Open);
            StreamReader sr = new StreamReader(f);

            this.sbox = new string[256];
            int position = 0;
            while (!sr.EndOfStream)
            {
                foreach (string line in sr.ReadLine().Split(',').SkipLast(1))
                {
                    sbox.SetValue(line, position);
                    position++;

                }
            }

            foreach (var val in sbox)
            {
                Console.WriteLine(val);
            }

            sr.Close();
            f.Close();

        }
        public string HexToBin32(string hex)
        {
            return Convert.ToString(Convert.ToInt32(hex, 16), 2).PadLeft(32, '0');
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
            int index = Convert.ToInt32(message, 2);
            Console.WriteLine($"Index : {index}");
            string sboxd = sbox[index];
            Console.WriteLine($"Valeur SBOX : {sboxd}");
            return HexToBin32(sboxd);
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
