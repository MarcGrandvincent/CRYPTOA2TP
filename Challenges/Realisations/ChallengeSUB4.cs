using CryptoClient.Algorithmes.Algorithms.Realisations;
using CryptoClient.Reseau;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoClient.Challenges.Realisations
{
    public class ChallengeSUB4 : IChallenge
    {
        private string cle;
        private char[] n;
        public void Executer()
        {
            Connexion.EnvoyerMessage("OK");

            bool stop = false;
            int i = 0;
            // On arrête pas le programme tant qu'on reçoit pas END
            while (!stop)
            {
                string message = "";
                // On récupère les 2 premiers messages
                if (i < 2)
                {
                    message = Connexion.RecevoirMessage();
                }

                if (message != "END")
                {
                    // On ignore le message qui valide la bonne réponse
                    if (message != "Correct !" && message != "Wrong !")
                    {
                        // On récupère le message à chiffrer lors du premier message
                        if (i == 0)
                        {
                            n = message.ToCharArray();
                            i += 1;
                        }
                        // On récupère la clé lors du deuxième message
                        else if (i == 1)
                        {
                            cle = message;
                            i += 1;
                        }
                        // On dechiffre le caractère
                        else if (i == 2)
                        {
                            AlgorithmeSubstitution t = new AlgorithmeSubstitution();
                            Connexion.EnvoyerMessage(t.Swap(n[0], cle).ToString());
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
