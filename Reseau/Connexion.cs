using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace CryptoClient.Reseau
{
    public class Connexion
    {
        //Singleton interne
        private static Connexion instance;
        //Get du singleton
        private static Connexion Instance
        {
            get => null;
        }


        private TcpClient client;
        /// <summary>Le flux entrant depuis le serveur</summary>
        private StreamReader fluxEntrant;
        /// <summary>Le flux sortant vers le serveur</summary>
        private StreamWriter fluxSortant;

        /// <summary>
        /// Constructeur naturel
        /// </summary>
        private Connexion()
        {
        }

        /// <summary>
        /// Envoi d'un message au serveur
        /// </summary>
        /// <param name="message">Le message à envoyer</param>
        public static void EnvoyerMessage(string message)
        {
            Console.WriteLine(">> " + message);
            Connexion.instance.fluxSortant.WriteLine(message);
        }

        /// <summary>
        /// Réception d'un message du serveur
        /// </summary>
        /// <returns>Message reçu</returns>
        public static string RecevoirMessage()
        {
            String message = Connexion.instance.fluxEntrant.ReadLine();
            Console.WriteLine("<< " + message);
            return message;
        }

        public static void OuvrirConnexion()
        {
            if (instance != null) FermerConnexion();
            instance = new Connexion();
            instance.client = new TcpClient("127.0.0.1", 1234);
            instance.fluxEntrant = new StreamReader(instance.client.GetStream());
            instance.fluxSortant = new StreamWriter(instance.client.GetStream())
            {
                AutoFlush = true
            };
        }

        //Ferme la connexion
        public static void FermerConnexion()
        {
            instance.client.Close();
            instance = null;
        }

    }
}
