using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CryptoClient.Algorithmes.Algorithms.Realisations
{
    public class AlgorithmeTransposition : IAlgorithm
    {
        public string Chiffrer(string message, string cle)
        {
            char[,] tableau = new char[cle.Length, HauteurTableau(message, cle)];

            for (int col = 0; col < tableau.GetLength(0); col++)
            {
                for (int row = 0; row < tableau.GetLength(1); row++)
                {
                    int pos = col + row * tableau.GetLength(0);
                    if (pos < message.Length)
                    {
                        tableau[col, row] = message[pos];
                    }
                    else
                    {
                        tableau[col, row] = '!';
                    }
                }
            }

            String chiffre = String.Empty;

            foreach (int col in CleToOrdre(cle))
            {
                for (int row = 0; row < tableau.GetLength(1); row++)
                {
                    chiffre += tableau[col, row];
                }
            }

            return chiffre;
        }

        public string Dechiffre(string message, string cle)
        {
            char[,] tableau = new char[cle.Length, HauteurTableau(message, cle)];

            List<int> ordre = CleToOrdre(cle).ToList();

            for (int col = 0; col < tableau.GetLength(0); col++)
            {
                for (int row = 0; row < tableau.GetLength(1); row++)
                {
                    int pos = col * tableau.GetLength(1) + row;
                    tableau[ordre[col], row] = message[pos];
                }
            }

            String dechiffre = String.Empty;

            for (int row = 0; row < tableau.GetLength(1); row++)
            {
                for (int col = 0; col < tableau.GetLength(0); col++)
                {
                    dechiffre += tableau[col, row];
                }
            }

            return dechiffre;
        }

        public static int HauteurTableau(String message, String cle)
        {
            return (int)Math.Ceiling((float)message.Length / cle.Length);
        }

        public static IEnumerable<int> CleToOrdre(String cle)
        {
            // associe chaque caractère de la clé à un CPO équivalent
            var charPos = cle
                .Select((c, i) => new CaracterePosition {
                    Caractere = c,
                    Position = i
                })
                .ToList();


            // Trie la liste par caractère
            charPos.Sort(new CaracterePositionComparateur());

            // renvoie uniquement l'ordre
            return charPos.Select(cpo => cpo.Position);
        }
    }

    public class CaracterePosition
    {
        private char caractere;
        private int position;

        public char Caractere
        {
            get => this.caractere;
            set => this.caractere = value;
        }

        public int Position
        {
            get => this.position;
            set => this.position = value;
        }
    }

    public class CaracterePositionComparateur : Comparer<CaracterePosition>
    {
        public override int Compare(CaracterePosition a, CaracterePosition b)
        {
            if (a.Caractere == b.Caractere)
            {
                return a.Position - b.Position;
            }
            else
            {
                return a.Caractere - b.Caractere;
            }
        }
    }
}
