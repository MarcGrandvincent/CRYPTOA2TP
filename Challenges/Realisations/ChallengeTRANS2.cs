using CryptoClient.Algorithmes.Algorithms.Realisations;
using CryptoClient.Reseau;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoClient.Challenges.Realisations
{
    public class ChallengeTRANS2 : IChallenge
    {
        private string cle;
        public void Executer()
        {

            Connexion.EnvoyerMessage("OK");

            bool stop = false;
            int i = 0;
            // On continue tant qu'on reçoit pas END
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
                        // On récupère le message à chiffrer avec le premier message
                        if (i == 0)
                        {
                            cle = message;
                            i += 2;
                        }
                        // On récupère la hauteur du tableau
                        else if (i == 2)
                        {

                            string s = "";
                            foreach (int j in AlgorithmeTransposition.CleToOrdre(cle))
                            {
                                s += j + " ";
                            }

                            Connexion.EnvoyerMessage(s);
                            i = 0;

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
