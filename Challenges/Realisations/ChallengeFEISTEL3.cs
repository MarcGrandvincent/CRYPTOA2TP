using CryptoClient.Algorithmes.Algorithms.Realisations;
using CryptoClient.Reseau;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoClient.Challenges.Realisations
{
    public class ChallengeFEISTEL3 : IChallenge
    {
        private string n;
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
                            n = message;
                            i += 2;
                        }
                        // On récupère la clé avec le deuxième message
                        else if (i == 1)
                        {
                            cle = message;
                            i += 1;
                        }
                        // On dechiffre le message
                        else if (i == 2)
                        {
                            AlgorithmeFeistel t = new AlgorithmeFeistel();
                            Connexion.EnvoyerMessage(t.EBox(n));
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
