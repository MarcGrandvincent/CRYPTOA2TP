using CryptoClient.Algorithmes.Algorithms.Realisations;
using CryptoClient.Reseau;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoClient.Challenges.Realisations
{
    public class ChallengeSUB1 : IChallenge
    {
        private char[] n;
        private int cle;
        /// <summary>
        /// Execute 
        /// </summary>
        public void Executer()
        {
            Connexion.EnvoyerMessage("OK");

            bool stop = false;
            int i = 0;

            // On stop l'algorithme quand on reçoit end
            while (!stop)
            {
                string message = "";

                // On lit les deux premiers messages
                if (i < 2)
                {
                    message = Connexion.RecevoirMessage();
                }

                if (message != "END")
                {
                    // On ignore le message qui valide la bonne réponse
                    if (message != "Correct !" && message != "Wrong !")
                    {
                        // On récupère le caractère avec le premier message
                        if (i == 0)
                        {
                            n = message.ToCharArray();
                            i += 1;
                        }
                        // On récupère la clé avec le deuxième message
                        else if (i == 1)
                        {
                            cle = int.Parse(message);
                            i += 1;
                        }
                        // On décale la lettre en fonction de la clé
                        else if (i == 2)
                        {
                            AlgorithmeCesar t = new AlgorithmeCesar();
                            Connexion.EnvoyerMessage(t.Decalage(n[0], cle).ToString());
                            i = 0;
                            Array.Clear(n, 0, n.Length);
                        }
                    }
                }
                else
                {
                    // On arrête la boucle 
                    stop = true;
                }

            }
        }
    }
}
