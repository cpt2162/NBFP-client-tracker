using System.Security.Cryptography;
using System.Text;

namespace server.Services;

public class EncryptionService
{
    private readonly byte[] _key;
    private readonly byte[] _iv;

    public EncryptionService()
    {
        // Load the key and IV from the configuration
        string keyBase64 = Environment.GetEnvironmentVariable("ENCRYPTION_KEY")
            ?? throw new InvalidOperationException("ENCRYPTION_KEY environment variable not found.");
        string ivBase64 = Environment.GetEnvironmentVariable("ENCRYPTION_IV")
            ?? throw new InvalidOperationException("ENCRYPTION_IV environment variable not found.");

        _key = Convert.FromBase64String(keyBase64);
        _iv = Convert.FromBase64String(ivBase64);
    }

    public string Encrypt(string plainText)
    {
        if (string.IsNullOrEmpty(plainText)) return plainText;
        using var aes = Aes.Create();
        aes.Key = _key;
        aes.IV = _iv;
        using var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
        using var ms = new MemoryStream();
        using var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write);
        using (var sw = new StreamWriter(cs))
        {
            sw.Write(plainText);
        }
        return Convert.ToBase64String(ms.ToArray());
    }

    public string Decrypt(string cipherText)
    {
        if (string.IsNullOrEmpty(cipherText)) return cipherText;
        using var aes = Aes.Create();
        aes.Key = _key;
        aes.IV = _iv;
        using var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
        using var ms = new MemoryStream(Convert.FromBase64String(cipherText));
        using var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);
        using (var sr = new StreamReader(cs))
        {
            return sr.ReadToEnd();
        }
    }
}