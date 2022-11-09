using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;

namespace CryptoClient.Algorithmes.Algorithms.Realisations
{
    public class AlgorithmeFeistel : IAlgorithm
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

        public string Add32(string nb1, string nb2)
        {
            Int64 uint1 = Convert.ToInt64(nb1, 2);
            Int64 uint2 = Convert.ToInt64(nb2, 2);
            return Convert.ToString((uint1 + uint2) % (1L << 32), 2).PadLeft(32, '0');
        }

        public string F(string message, string cle)
        {
            string result = "";
            string huit = "";
            string vingtquatre = "";
            AlgorithmeTransposition t = new AlgorithmeTransposition();
            result = t.Chiffrer(message, cle);
            for (int i = 0; i < 8; i++)
            {
                huit += result[i];
            }
            for (int i = 8; i < 32; i++)
            {
                vingtquatre += result[i];
            }
            huit = SBox(huit);
            vingtquatre = EBox(vingtquatre);
            result = Add32(huit, vingtquatre);
            return PBox(result);
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
            string[] M = message.Split(message, 32);
            string K = ClePartielle(cle,numTour);
            string fm = F(M[0], K);
            string res = Add32(fm, M[1]);
            return res;
        }

        public string Chiffrer(string message, string cle)
        {
            throw new NotImplementedException();
        }

        public string Dechiffre(string message, string cle)
        {
            string res = "";

            res = TourDechiffrement(message, cle, 2);
            res = TourDechiffrement(res, cle, 1);

            return res;
               
        }
    }
}
