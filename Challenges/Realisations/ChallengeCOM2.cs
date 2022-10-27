using CryptoClient.Reseau;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoClient.Challenges.Realisations
{
    public class ChallengeCOM2 : IChallenge
    {

        /// <summary>
        /// Tant que le serveur n'envoie pas END, on répond a son entier en ajoutant 1.
        /// </summary>
        public void Executer()
        {

            // On communique que la communication est validée
            Connexion.EnvoyerMessage("OK");

            bool stop = false;

            // Tant que le serveur n'envoie pas stop, on continue
            while(!stop)
            {
                string message = Connexion.RecevoirMessage();
               
                if (message != "END")
                {
                    // On ignore le message qui valide la bonne réponse
                    if (message != "Correct !")
                    {
                        int n;
                        n = int.Parse(message);
                        Connexion.EnvoyerMessage("" + (n + 1));
                    }  
                    else
                    {

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
