using System.Security.Cryptography;
using System.Text;

namespace aplicaciones_lib.nucleo
{
    public class Cifrado
    {
       
        public static string Sha256(string texto)
        {
            var bytes = SHA256.HashData(Encoding.UTF8.GetBytes(texto));
            return Convert.ToHexString(bytes);
        }

        
        public static bool EstaCifrado(string? texto)
        {
            return texto != null &&
                texto.Length == 64 &&
                texto.All(c => Uri.IsHexDigit(c));
        }
    }
}

