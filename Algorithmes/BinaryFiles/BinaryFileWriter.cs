using System;
using System.IO;

namespace CryptoClient.Algorithmes.BinaryFiles
{
    public class BinaryFileWriter
    {
        /// <summary>
        /// Name of the file
        /// </summary>
        private string name;
        private FileStream stream;

        /// <summary>
        /// Natural constructor
        /// </summary>
        /// <param name="_name">Name of the file</param>
        public BinaryFileWriter(string _name)
        {
            this.name = _name;
            this.stream = File.Create(@"Resources\" + this.name);
        }

        public void Write(string binaryString)
        {
            int numOfBytes = binaryString.Length / 8;
            byte[] bytes = new byte[numOfBytes];
            for (int i = 0; i < numOfBytes; i++)
            {
                this.stream.WriteByte(Convert.ToByte(binaryString.Substring(8 * i, 8), 2));
            }
        }

        public void Close()
        {
            stream.Close();
            stream = null;
        }
    }
}
