using CryptoClient.Challenges.Realisations;

namespace CryptoClient.Challenges
{
    public class FabriqueChallenge
    {
        /// <summary>
        /// Créer un challenge en fonction du code envoyer. 
        /// </summary>
        /// <param name="code"></param>
        public static IChallenge Creer(string code)
        {
            IChallenge challenge = null;

            switch (code)
            {
                case "COM1": { challenge = new ChallengeCOM1(); } break;
                case "COM2": { challenge = new ChallengeCOM2(); } break;
                case "SUB1": { challenge = new ChallengeSUB1(); } break;
                case "SUB2": { challenge = new ChallengeSUB2(); } break;
                case "SUB3": { challenge = new ChallengeSUB3(); } break;
                case "SUB4": { challenge = new ChallengeSUB4(); } break;
                case "SUB5": { challenge = new ChallengeSUB5(); } break;
                case "SUB6": { challenge = new ChallengeSUB6(); } break;
                case "VIG1": { challenge = new ChallengeVIG1(); } break;
                case "VIG2": { challenge = new ChallengeVIG2(); } break;
                case "VIG3": { challenge = new ChallengeVIG3(); } break;
                case "VIG4": { challenge = new ChallengeVIG4(); } break;
                case "XOR1": { challenge = new ChallengeXOR1(); } break;
                case "XOR2": { challenge = new ChallengeXOR2(); } break;
                case "XOR3": { challenge = new ChallengeXOR3(); } break;
                case "TRANS1": { challenge = new ChallengeTRANS1(); } break;
                case "TRANS2": { challenge = new ChallengeTRANS2(); } break;
                case "FEISTEL3": { challenge = new ChallengeFEISTEL3(); } break;
                case "FEISTEL4": { challenge = new ChallengeFEISTEL4(); } break;
                case "FEISTEL1": { challenge = new ChallengeFEISTEL1(); } break;
                case "FEISTEL2": { challenge = new ChallengeFEISTEL2(); } break;
            }
            return challenge;
        }
    }
}
