using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoClient.Algorithmes.Algorithms.Realisations
{
    public class AlgorithmeCesar : IAlgorithm
    {
        /// <summary>
        /// On décale c de cle en fonction de l'alphabet
        /// </summary>
        /// <param name="c"></param>
        /// <param name="cle"></param>
        /// <returns></returns>
        public char Decalage(char c, int cle)
        {
            // Variable qui prend temporairement le char 
            char ctemp = c;
            // Code ASCII à envoyer
            int temp = 0;
            
            // On vérifie si c'est une lettre
            if (char.IsLetter(ctemp))
            {

                // En fonction de la clé, on regarde si nous devons prendre la première ou dernière lettre
                // de l'alphabet
                char firstLetter = ' ';
                if (cle >= 0)
                {
                    // On vérifie s'il est en majuscule ou miniscule 
                    if (char.IsUpper(ctemp))
                    {
                        firstLetter = 'A';
                    }
                    else
                    {
                        firstLetter = 'a';
                    }
                }
                else
                {
                    // On vérifie s'il est en majuscule ou miniscule 
                    if (char.IsUpper(ctemp))
                    {
                        firstLetter = 'Z';
                    }
                    else
                    {
                        firstLetter = 'z';
                    }
                }

                // On calcule le décallage
                temp = (((ctemp + cle) - firstLetter) % 26) + firstLetter;

            }
            else
            {
                // C'est un symbole, on le renvoie sans modifier
                temp = (int)ctemp;
            }

            return (char)(temp);
        }

        /// <summary>
        /// Chiffre le message donner grâce au décallage
        /// </summary>
        /// <param name="message"></param>
        /// <param name="cle"></param>
        /// <returns></returns>
        public string Chiffrer(string message, string cle)
        {
            string messageChiffrer = "";
            char[] leMessage = message.ToCharArray();

            foreach (char c in leMessage)
            {
                messageChiffrer += Decalage(c, int.Parse(cle));
            }

            return messageChiffrer;

        }

        /// <summary>
        /// Dechiffre le message donner grâce au décallage
        /// </summary>
        /// <param name="message"></param>
        /// <param name="cle"></param>
        /// <returns></returns>
        public string Dechiffre(string message, string cle)
        {
            string messageDechiffrer = "";
            char[] leMessage = message.ToCharArray();

            foreach (char c in leMessage)
            {
                messageDechiffrer += Decalage(c, 26 - int.Parse(cle));
            }

            return messageDechiffrer;

        }
    }
}
