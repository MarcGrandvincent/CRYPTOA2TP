using CryptoClient.Algorithmes.Algorithms.Realisations;
using CryptoClient.Reseau;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoClient.Challenges.Realisations
{
    internal class ChallengeFEISTEL6 : IChallenge
    {
        public void Executer()
        {
            
            AlgorithmeFeistel feistel = new AlgorithmeFeistel();
            Connexion.EnvoyerMessage("OK");
            string message = "";
            string cle = "";
            string res = "";

            message = Connexion.RecevoirMessage();
            cle = Connexion.RecevoirMessage();

            while (message != "END")
            {
                res = feistel.Dechiffre(message,cle);
                Connexion.EnvoyerMessage(res);
                Console.WriteLine(">>" + res);

                message = Connexion.RecevoirMessage();
                

                message = Connexion.RecevoirMessage();
                cle = Connexion.RecevoirMessage();
            }
        }
    }
}
