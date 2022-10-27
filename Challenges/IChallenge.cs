using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoClient.Challenges
{
    /// <summary>
    /// Interface générale d'un challenge
    /// </summary>
    public interface IChallenge
    {
        /// <summary>
        /// Lancer le challenge
        /// </summary>
        void Executer();
    }
}
