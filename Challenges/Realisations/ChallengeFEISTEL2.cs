using CryptoClient.Algorithmes.Algorithms.Realisations;
using CryptoClient.Reseau;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoClient.Challenges.Realisations
{
    public class ChallengeFEISTEL2 : IChallenge
    {
        public void Executer()
        {
            AlgorithmeFeistel feistel = new AlgorithmeFeistel();
            Connexion.EnvoyerMessage("OK");
            string message = "";
            string res = "";

            message = Connexion.RecevoirMessage();

            while (message != "END")
            {
                res = feistel.SBox(message);
                Connexion.EnvoyerMessage(res);

                message = Connexion.RecevoirMessage();
                message = Connexion.RecevoirMessage();
            }

        }
    }
}
