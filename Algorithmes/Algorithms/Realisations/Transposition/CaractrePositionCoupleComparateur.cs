using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CryptoClient.Algorithmes.Algorithms.Realisations.Transposition
{
    public class CaractrePositionCoupleComparateur : IComparer<CaracterePositionCouple>
    {
        public int Compare(CaracterePositionCouple x, CaracterePositionCouple y)
        {
            int r = 0;

            if (x.Caractere == y.Caractere && x.Position == y.Position)
            {
                r = 0;
            }
            else if (x.Caractere < y.Caractere && x.Position < y.Position)
            {
                r = -1;
            }
            else if (x.Caractere > y.Caractere && x.Position > y.Position)
            {
                r = 1;
            }


            return r;
        }
    }
}
