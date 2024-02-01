using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace ManagerFile
{
    public class Sha256
    {
        public string KeyAES = ConfigurationManager.AppSettings["KeyAES"];

        public string GenerateAESKey()
        {
            using (AesCryptoServiceProvider aesProvider = new AesCryptoServiceProvider())
            {
                aesProvider.GenerateKey();
                return Convert.ToBase64String(aesProvider.Key);
            }   
        }

        public void EncryptFile(string inputFile, string outputFile)
        {
            using (FileStream inputStream = new FileStream(inputFile, FileMode.Open, FileAccess.Read))
            using (FileStream outputStream = new FileStream(outputFile, FileMode.Create, FileAccess.Write))
            {
                using (Aes aesAlg = Aes.Create())
                {
                    aesAlg.Key = Convert.FromBase64String(KeyAES);
                    aesAlg.IV = aesAlg.Key.Take(16).ToArray(); // Use the first 16 bytes of the key as IV

                    using (ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV))
                    using (CryptoStream cryptoStream = new CryptoStream(outputStream, encryptor, CryptoStreamMode.Write))
                    {
                        inputStream.CopyTo(cryptoStream);
                    }
                }
            }
        }

        public void DecryptFile(string inputFile, string outputFile)
        {
            using (FileStream inputStream = new FileStream(inputFile, FileMode.Open, FileAccess.Read))
            using (FileStream outputStream = new FileStream(outputFile, FileMode.Create, FileAccess.Write))
            {
                using (Aes aesAlg = Aes.Create())
                {
                    aesAlg.Key = Convert.FromBase64String(KeyAES);
                    aesAlg.IV = aesAlg.Key.Take(16).ToArray(); // Use the first 16 bytes of the key as IV

                    using (ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV))
                    using (CryptoStream cryptoStream = new CryptoStream(inputStream, decryptor, CryptoStreamMode.Read))
                    {
                        cryptoStream.CopyTo(outputStream);
                    }
                }
            }
        }

        public void EncryptDirectory(string inputDirectory, string outputDirectory)
        {
            // Tạo thư mục đích nếu nó không tồn tại
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            // Lặp qua tất cả các tệp và thư mục bên trong thư mục nguồn
            foreach (string filePath in Directory.GetFiles(inputDirectory))
            {
                string fileName = Path.GetFileName(filePath);
                string encryptedFilePath = Path.Combine(outputDirectory, fileName);

                // Mã hóa từng tệp
                EncryptFile(filePath, encryptedFilePath);
            }

            // Lặp qua tất cả các thư mục bên trong thư mục nguồn và thực hiện đệ quy
            foreach (string subdirectory in Directory.GetDirectories(inputDirectory))
            {
                string directoryName = Path.GetFileName(subdirectory);
                string encryptedSubdirectory = Path.Combine(outputDirectory, directoryName);

                // Đệ quy để mã hóa thư mục con
                EncryptDirectory(subdirectory, encryptedSubdirectory);
            }
        }

        public void DecryptDirectory(string inputDirectory, string outputDirectory)
        {
            // Tạo thư mục đích nếu nó không tồn tại
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            // Lặp qua tất cả các tệp và thư mục bên trong thư mục nguồn
            foreach (string filePath in Directory.GetFiles(inputDirectory))
            {
                string fileName = Path.GetFileName(filePath);
                string decryptedFilePath = Path.Combine(outputDirectory, fileName);

                // Giải mã từng tệp
                DecryptFile(filePath, decryptedFilePath);
            }

            // Lặp qua tất cả các thư mục bên trong thư mục nguồn và thực hiện đệ quy
            foreach (string subdirectory in Directory.GetDirectories(inputDirectory))
            {
                string directoryName = Path.GetFileNameWithoutExtension(subdirectory);
                string decryptedSubdirectory = Path.Combine(outputDirectory, directoryName);

                // Đệ quy để giải mã thư mục con
                DecryptDirectory(subdirectory, decryptedSubdirectory);
            }
        }
    }
}
