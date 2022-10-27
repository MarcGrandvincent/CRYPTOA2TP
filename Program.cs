using CryptoClient.Challenges;
using CryptoClient.Reseau;
using System;

namespace CryptoClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Connexion.OuvrirConnexion();
            FabriqueChallenge.Creer(Connexion.RecevoirMessage()).Executer();
            Connexion.FermerConnexion();
        }
    }
}
