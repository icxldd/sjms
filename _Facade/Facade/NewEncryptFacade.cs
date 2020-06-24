using sjms._Facade.Subsystem;
using System;
using System.Collections.Generic;
using System.Text;

namespace sjms._Facade.Facade
{
    public class NewEncryptFacade : AbstractEncryptFacade
    {
        private NewCipherMachine cipher;

        public NewEncryptFacade()
        {
            cipher = new NewCipherMachine();
        }

        public override string DataEncrypt(string data)
        {
            return cipher.Encrypt(data);
        }
    }
}
