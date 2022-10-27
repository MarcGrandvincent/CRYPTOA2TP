using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CryptoClient.Algorithmes.Algorithms.Realisations
{
    public class AlgorithmeXOR : IAlgorithm
    {

        /// <summary>
        /// Algorithme XOR
        /// Si les deux chiffres sont identiques, on renvoie 0
        /// SI les deux chiffres sont différents, on renvoie 1.
        /// </summary>
        /// <param name="c1"></param>
        /// <param name="c2"></param>
        /// <returns></returns>
        public char Xor(char c1, char c2)
        {
            char c = ' ';
            if (c1 == '0' && c2 == '0' || c1 == '1' && c2 == '1')
            {
                c = '0';
            }
            else if (c1 == '0' && c2 == '1' || c1 == '1' && c2 == '0')
            {
                c = '1';
            }

            return c; 
        }

        /// <summary>
        /// On chiffre le message à l'aide de l'algorithme XOR
        /// </summary>
        /// <param name="message"></param>
        /// <param name="cle"></param>
        /// <returns></returns>
        public string Chiffrer(string message, string cle)
        {
            string messageChiffrer = "";

            for (int i = 0; i < message.Count(); i++)
            {
                messageChiffrer += Xor(message[i], cle[i]).ToString();
            }

            return messageChiffrer;
        }

        /// <summary>
        /// On Dechiffre le message à l'aide de l'algorithme XOR
        /// </summary>
        /// <param name="message"></param>
        /// <param name="cle"></param>
        /// <returns></returns>
        public string Dechiffre(string message, string cle)
        {
            return Chiffrer(message, cle);
        }
    }
}
