using System.Security.Cryptography;

namespace lumos_asp.net_core_angular.Server.Services.Auth
{
    public class RsaKeyService
    {
        private readonly string _privateKeyPath;
        private readonly string _publicKeyPath;

        public RsaKeyService(string privateKeyPath, string publicKeyPath)
        {
            _privateKeyPath = privateKeyPath;
            _publicKeyPath = publicKeyPath;
        }

        public RSA LoadPrivateKey()
        {
            // Get value key in string
            var privateKeyString = File.ReadAllText(_privateKeyPath);
            // convert to bytes from base64 string
            var privateKeyBytes = Convert.FromBase64String(privateKeyString);

            var rsa = new RSACryptoServiceProvider();
            rsa.ImportParameters(new RSAParameters { D =  privateKeyBytes });
            
            return rsa;
        }

        public RSA LoadPublicKey()
        {
            var publicKeyString  = File.ReadAllText(_publicKeyPath);
            publicKeyString = publicKeyString
                .Replace("-----BEGIN PUBLIC KEY-----", "")
                .Replace("-----END PUBLIC KEY-----", "")
                .Replace("\n", "")
                .Replace("\r", "");
            var publicKeyBytes = Convert.FromBase64String(publicKeyString);

            var rsa = new RSACryptoServiceProvider();
            rsa.ImportSubjectPublicKeyInfo(publicKeyBytes, out _);
            //rsa.ImportParameters(new RSAParameters { Modulus = publicKeyBytes });

            return rsa;
        }
    }
}
