
namespace CryptoClient.Algorithmes.Algorithms
{
    /// <summary>
    /// Interface pour un algorithme
    /// </summary>
    public interface IAlgorithm
    {
        /// <summary>
        /// Chiffre le message donné avec la clé donnée
        /// </summary>
        /// <param name="message">Message à chiffrer</param>
        /// <param name="cle">Clé</param>
        /// <returns>Message chiffré</returns>
        string Chiffrer(string message, string cle);


        /// <summary>
        /// Déchiffre le message donné avec la clé donnée
        /// </summary>
        /// <param name="message">Message à chiffrer</param>
        /// <param name="cle">Clé</param>
        /// <returns>Message déchiffré</returns>
        string Dechiffre(string message, string cle);
    }
}
