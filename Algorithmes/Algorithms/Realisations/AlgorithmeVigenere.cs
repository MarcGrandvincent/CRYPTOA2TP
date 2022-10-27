using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CryptoClient.Algorithmes.Algorithms.Realisations
{
    public class AlgorithmeVigenere : IAlgorithm
    {

        /// <summary>
        /// Change le caractère en fonction de la cle grâce au tableau de Vigenere
        /// </summary>
        /// <param name="c"></param>
        /// <param name="cle"></param>
        /// <returns></returns>
        public char Shift(char c, char cle)
        {
            int temp = (int)c;
            char tempCle = cle;
            // On met la cle en majuscule
            tempCle = char.ToUpper(tempCle);

            // On vérifie que c'est une lettre
            if (char.IsLetter(c))
            {
                // On vérifie c'est c'est en majuscule
                if (char.IsUpper(c))
                {
                    // On change la lettre en fonction du tableau de vigenere
                    temp = 65 + mod((int)c + (int)tempCle, 26);
                }
                else
                {
                    // On met la lettre en majuscule
                    char ctemp = c;
                    ctemp = char.ToUpper(ctemp);
                    // On change la lettre en fonction du tableau de vigenere grâce à la cle
                    temp = 65 + mod((int)ctemp + (int)tempCle, 26);

                    // on la remet en minuscule
                    ctemp = (char)temp;
                    temp = (int)char.ToLower(ctemp);
                }
            }

            return (char)temp;
        }

        /// <summary>
        /// Redonne le caractère d'origine en fonction de la cle grâce au tableau de Vigenere
        /// </summary>
        /// <param name="c"></param>
        /// <param name="cle"></param>
        /// <returns></returns>
        public char UnShift(char c, char cle)
        {
            int temp = (int)c;
            char tempCle = cle;
            // On met la cle en majuscule
            tempCle = char.ToUpper(tempCle);

            // On vérifie si c'est une lettre
            if (char.IsLetter(c))
            {
                // On vérifie si c'est en majuscule
                if (char.IsUpper(c))
                {
                    // On remet le caractère d'origine en fonction du tableau de vigenere grâce à la cle
                    temp = 65 + mod((int)c - (int)tempCle + 26, 26);
                }
                else
                {
                    // On met la lettre en majuscule
                    char ctemp = c;
                    ctemp = char.ToUpper(ctemp);
                    // On remet le caractère d'origine en fonction du tableau de bigenere grâce à la cle d'origine
                    temp = 65 + mod((int)ctemp - (int)tempCle + 26, 26);
                    // On remet en minuscule
                    ctemp = (char)temp;
                    temp = (int)char.ToLower(ctemp);

                }
            }

            return (char)temp;
        }


        /// <summary>
        /// Chiffre le message
        /// </summary>
        /// <param name="message"></param>
        /// <param name="cle"></param>
        /// <returns></returns>
        public string Chiffrer(string message, string cle)
        {
            string messageChiffrer = "";
            string laCleS = cle;
            char[] leMessage = message.ToCharArray();
            char[] laCle = cle.ToCharArray();


            // On aggrandit la cle pour qu'elle soit plus longue que le message
            int i = laCle.Length;
            while (laCleS.Length < leMessage.Length + 1)
            {
                laCleS += cle[i % cle.Length];
                i++;
            }

            laCle = laCleS.ToCharArray();


            // On chiffre le message
            for (int j = 0; j < leMessage.Length; j++)
            {
                messageChiffrer += Shift(leMessage[j], laCle[j]);
            }

            return messageChiffrer;
        }

        /// <summary>
        /// Dechiffre le message
        /// </summary>
        /// <param name="message"></param>
        /// <param name="cle"></param>
        /// <returns></returns>
        public string Dechiffre(string message, string cle)
        {
            string messageChiffrer = "";
            string laCleS = cle;
            char[] leMessage = message.ToCharArray();
            char[] laCle = cle.ToCharArray();


            // On aggrant la cle pour qu'elle soit plus longue que le message
            int i = laCle.Length;
            while (laCleS.Length < leMessage.Length + 1)
            {
                laCleS += cle[i % cle.Length];
                i++;
            }

            laCle = laCleS.ToCharArray();


            // On chiffre le message 
            for (int j = 0; j < leMessage.Length; j++)
            {
                messageChiffrer += UnShift(leMessage[j], laCle[j]);
            }

            return messageChiffrer;
        }


        /// <summary>
        /// Le mod de C# ne permet pas de faire des mod négatif correctement, on fait donc notre propre fonction
        /// </summary>
        /// <param name="a">dividende</param>
        /// <param name="b">diviseur</param>
        /// <returns></returns>
        private int mod(float a, float b)
        {
            return Convert.ToInt32(a - b * Math.Floor(a / b));
        }
    }
}
