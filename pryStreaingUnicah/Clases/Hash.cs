using System;
using System.Text;
using System.Security.Cryptography;

namespace pryStreaingUnicah.Clases
{
    class Hash
    {
        public string obtenerHash256(string text)
        {

            byte[] bytes = Encoding.Unicode.GetBytes(text);
            SHA256Managed hashString = new SHA256Managed();

            byte[] hash = hashString.ComputeHash(bytes);
            string hashStr = string.Empty;

            foreach (byte x in hash)
            {
                hashStr += String.Format("{0:x2}", x);
            }

            return hashStr;

        }
    }
}
