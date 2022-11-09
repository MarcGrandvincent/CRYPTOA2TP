using CryptoClient.Algorithmes.Algorithms.Realisations;
using CryptoClient.Algorithmes.BinaryFiles;
using CryptoClient.Challenges;
using CryptoClient.Reseau;
using System;

namespace CryptoClient
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Connexion.OuvrirConnexion();
            FabriqueChallenge.Creer(Connexion.RecevoirMessage()).Executer();
            Connexion.FermerConnexion();*/

            BinaryFileReader binaryFileReader = new BinaryFileReader("PlanChiffre.dat");
            BinaryFileWriter binaryFileWriter = new BinaryFileWriter("Resultat.dat");
            AlgorithmeFeistel algorithmeFeistel = new AlgorithmeFeistel();
            string chunk;
            string res;

            while ((chunk = binaryFileReader.NextString()) != null)
            {
                res = algorithmeFeistel.Dechiffre(chunk, "ROGUEONE");
                binaryFileWriter.Write(res);
            }
            
            binaryFileReader.Close();
            binaryFileWriter.Close();

        }
    }
}
