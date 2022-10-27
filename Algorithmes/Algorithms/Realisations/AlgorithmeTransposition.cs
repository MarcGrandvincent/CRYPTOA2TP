using CryptoClient.Algorithmes.Algorithms.Realisations.Transposition;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CryptoClient.Algorithmes.Algorithms.Realisations
{
    public class AlgorithmeTransposition : IAlgorithm
    {
        
        public int HauteurTableau(string message, string cle)
        {
            return Convert.ToInt32(MathF.Ceiling((float)message.Length / cle.Length));
        }

        public List<int> CleToOrdre(string cle)
        {
            List<int> resultat = new List<int>();
            SortedList<CaracterePositionCouple, CaracterePositionCouple> listeTriee = new SortedList<CaracterePositionCouple, CaracterePositionCouple>(new CaractrePositionCoupleComparateur());


            for (int i = 0; i < cle.Length; i++)
            {
                CaracterePositionCouple cpc = new CaracterePositionCouple(cle[i], i);
                listeTriee.Add(cpc, cpc);
            }


            foreach (KeyValuePair<CaracterePositionCouple,CaracterePositionCouple> entry  in listeTriee)
            {
                resultat.Add(entry.Key.Position);
            }

            return resultat;
        }

        public string Chiffrer(string message, string cle)
        {
            throw new NotImplementedException();
        }
        
        public string Dechiffre(string message, string cle)
        {
            throw new NotImplementedException();
        }
    }
}
