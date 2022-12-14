using CryptoClient.Algorithmes.Algorithms.Realisations;
using CryptoClient.Reseau;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoClient.Challenges.Realisations
{
    public class ChallengeFEISTEL4 : IChallenge
    {
        public void Executer()
        {
            AlgorithmeFeistel  algorithmeFeistel  = new AlgorithmeFeistel();
            Connexion.EnvoyerMessage("OK");
            string ligne;
            while ((ligne = Connexion.RecevoirMessage()) != "END")
            {
                Connexion.EnvoyerMessage(algorithmeFeistel.ClePartielle(ligne, (Int32.Parse(Connexion.RecevoirMessage()))));
                Connexion.RecevoirMessage();
            }
        }
    }
}
