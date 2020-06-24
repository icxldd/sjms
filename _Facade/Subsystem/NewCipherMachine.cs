using System;
using System.Collections.Generic;
using System.Text;

namespace sjms._Facade.Subsystem
{
    public class NewCipherMachine
    {
        public string Encrypt(string plainText)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < plainText.Length; i++)
            {
                string ch = Convert.ToString(plainText[i] % 7);
                result.Append(ch);
            }
            string encryptedResult = result.ToString();
            return encryptedResult + " icxl";
        }
    }
}
