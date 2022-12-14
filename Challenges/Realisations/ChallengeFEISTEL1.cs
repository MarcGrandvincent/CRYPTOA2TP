using CryptoClient.Algorithmes.Algorithms.Realisations;
using CryptoClient.Reseau;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoClient.Challenges.Realisations
{
    public class ChallengeFEISTEL1 : IChallenge
    {
        private string n;
        private string cle;
        public void Executer()
        {

            AlgorithmeFeistel feistel = new AlgorithmeFeistel();
            Connexion.EnvoyerMessage("OK");
            string message = "";
            string res = "";

            message = Connexion.RecevoirMessage();
            Console.WriteLine("<<" + message);

            while (message != "END")
            {
                res = feistel.PBox(message);
                Connexion.EnvoyerMessage(res);
                Console.WriteLine(">>" + res);

                message = Connexion.RecevoirMessage();
                Console.WriteLine("<<" + message);

                message = Connexion.RecevoirMessage();
                Console.WriteLine("<<" + message);
            }

        }
        
    }
}
