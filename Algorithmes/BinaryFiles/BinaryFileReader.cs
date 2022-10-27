using System;
using System.IO;

namespace CryptoClient.Algorithmes.BinaryFiles
{
    /// <summary>
    /// Binary file reader
    /// </summary>
    public class BinaryFileReader
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
        public BinaryFileReader(string _name)
        {
            this.name = _name;
            this.stream = new FileStream(@"Resources\"+this.name, FileMode.Open, FileAccess.Read);
        }

        public string NextString()
        {
            string res = null;
            byte[] block = new byte[8];
            if(stream != null && stream.Read(block, 0, 8)>0)
            {
                res = "";
                for(int i=0;i<8;i++)
                {
                    res += Convert.ToString(block[i], 2).PadLeft(8, '0');
                }
            }
            return res;
        }

        public void Close()
        {
            stream.Close();
            stream = null;
        }
    }
}
