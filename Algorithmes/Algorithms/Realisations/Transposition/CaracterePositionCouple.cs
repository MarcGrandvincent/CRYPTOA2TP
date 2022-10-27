using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoClient.Algorithmes.Algorithms.Realisations.Transposition
{
    public class CaracterePositionCouple
    {
        private char caractere;
        public char Caractere { get => caractere; set => caractere = value; }
        
        private int position; 
        public int Position { get => position; set => position = value; }

        public CaracterePositionCouple(char caractere, int position)
        {
            this.caractere = caractere;
            this.position = position;
        }
    }
}
