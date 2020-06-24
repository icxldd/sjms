using sjms._Facade.Subsystem;
using System;
using System.Collections.Generic;
using System.Text;

namespace sjms._Facade.Facade
{
    public class EncryptFacade : AbstractEncryptFacade
    {
        private CipherMachine cipher;

        public EncryptFacade()
        {
            cipher = new CipherMachine();
        }

        public override string DataEncrypt(string data)
        {
            return cipher.Encrypt(data);
        }
    }
}
