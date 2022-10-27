using CryptoClient.Reseau;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoClient.Challenges.Realisations
{
    public class ChallengeCOM1 : IChallenge
    {


        /// <summary>
        /// On éxecute le challenge
        /// Ici on ouvre la connexion, on envoie ok 
        /// puis on la ferme.
        /// </summary>
        public void Executer()
        {
            Connexion.EnvoyerMessage("OK");
        }
    }
}
