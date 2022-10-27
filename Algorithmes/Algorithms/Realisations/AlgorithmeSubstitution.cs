using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CryptoClient.Algorithmes.Algorithms.Realisations
{
    public class AlgorithmeSubstitution : IAlgorithm
    {

        /// <summary>
        /// On permute le caractère reçu en fonction de la clé
        /// </summary>
        /// <param name="c">caractère à permutrer</param>
        /// <param name="cle">cle à utiliser</param>
        /// <returns></returns>
        public char Swap(char c, string cle)
        {
            int temp = (int)c;
            // on convertie la cle en tableau
            char[] newAlphabet = cle.ToCharArray();

            // On regarde si c'est une lettre
            if (char.IsLetter(c))
            {
                // On regarde s'il est en majuscule
                if (char.IsUpper(c))
                {
                    // On prend sa position dans l'alphabet pour récupérer la lettre
                    temp = (int)newAlphabet[mod((temp - 91), 26)];
                }
                else
                {
                    // On prend sa position dans l'alphabet pour récupérer la lettre et on la met en minuscule
                    temp = (int)char.ToLower(newAlphabet[mod((temp - 123), 26)]);
                }

            }


            return (char)temp;

        }

        /// <summary>
        /// On dépermute le caractère reçu en fonction de la clé
        /// </summary>
        /// <param name="c">caractère à dépermuter</param>
        /// <param name="cle">cle à utiliser</param>
        /// <returns></returns>
        public char UnSwap(char c, string cle)
        {
            int temp = (int)c;
            int j = 0;
            char[] newAlphabet = cle.ToCharArray();
            // On regarde si c'est une lettre
            if (char.IsLetter(c))
            {

                // On regarde si c'est en majuscule
                if (char.IsUpper(c))
                {
                    // On regarde dans l'alphabet si une lettre est identique, si c'est le cas on lui donne la position 
                    for (int i = 0; i < newAlphabet.Length; i++)
                    {
                        if ((int)newAlphabet[i] == (int)temp)
                        {
                            j = 65 + i;
                        }
                    }
                    temp = j;
                }
                else
                {
                    // On met le caractère en majuscule
                    temp = (int)char.ToUpper((char)temp);
                    // On regarde dans l'alphabet si une lettre est identique, si c'est le cas on lui donne la position 
                    for (int i = 0; i < newAlphabet.Length; i++)
                    {
                        if ((int)newAlphabet[i] == (int)temp)
                        {
                            j = 65 + i;
                        }
                    }
                    // On donne la lettre à envoyer en la mettant en minuscule
                    temp = j;
                    temp = (int)char.ToLower((char)temp);
                }

            }
            return (char)temp;
        }
        /// <summary>
        /// Chiffre le message reçu avec la méthode Swap
        /// </summary>
        /// <param name="message">message à chiffrer</param>
        /// <param name="cle">cle pour le chiffrer</param>
        /// <returns></returns>
        public string Chiffrer(string message, string cle)
        {
            string messageChiffrer = "";
            char[] leMessage = message.ToCharArray();

            foreach (char c in leMessage)
            {
                messageChiffrer += Swap(c, cle);
            }

            return messageChiffrer;
        }

        /// <summary>
        /// Dechiffre le message reçu avec la méthode UnSwap
        /// </summary>
        /// <param name="message">message à déchiffrer</param>
        /// <param name="cle">cle à utiliser</param>
        /// <returns></returns>
        public string Dechiffre(string message, string cle)
        {
            string messageChiffrer = "";
            char[] leMessage = message.ToCharArray();

            foreach (char c in leMessage)
            {
                messageChiffrer += UnSwap(c, cle);
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
