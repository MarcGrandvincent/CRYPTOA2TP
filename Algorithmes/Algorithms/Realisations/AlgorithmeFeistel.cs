﻿using System;
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