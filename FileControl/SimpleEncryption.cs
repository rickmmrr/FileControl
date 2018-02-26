using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security.Cryptography;

namespace FileControl {
    public class SimpleEncryption {

        private static string _key = string.Empty;
        public static string key {
            get
            {
                _key = "t";
                _key += "W";
                _key += ";";
                _key += "(";
                _key += "m";
                _key += "8";
                _key += "q";
                _key += "&";
                _key += "1";
                _key += "P";
                _key += ":";
                _key += "-";
                return _key;
            }
        }

        public static void EncryptFile( string source, string destination, string encryptionKey, bool actuallyEncrypt) {

            if(actuallyEncrypt == false)
                return;

            try {


                using(SymmetricAlgorithm cipher = Aes.Create())
                using(FileStream fileStream = File.OpenRead(source))
                using(FileStream tempFile = File.Create(destination)) {

                    //added by rick
                    UnicodeEncoding u = new UnicodeEncoding();
                    cipher.Key = u.GetBytes(encryptionKey);

                    // aes.IV will be automatically populated with a secure random value
                    byte[] iv = cipher.IV;

                    // Write a marker header so we can identify how to read this file in the future
                    tempFile.WriteByte(66);
                    tempFile.WriteByte(108);
                    tempFile.WriteByte(117);
                    tempFile.WriteByte(101);
                    tempFile.WriteByte(98);
                    tempFile.WriteByte(101);
                    tempFile.WriteByte(97);
                    tempFile.WriteByte(114);

                    tempFile.Write(iv, 0, iv.Length);

                    //Create a hash
                    HashAlgorithm hasher = SHA256.Create();

                    using(var cryptoStream =
                        new CryptoStream(tempFile, cipher.CreateEncryptor(), CryptoStreamMode.Write)) {

                       
                        fileStream.CopyTo(cryptoStream);
                    }
                }
            }
            catch(Exception ex) {
                throw new Exception("Error while Encrypting file = " + source,ex);
            }
        }

        public static void DecryptFile( string filePath, string destination, string encryptionKey, bool actuallyDycrypt ) {

            if(actuallyDycrypt == false)
                return;

            try {

                string tempFileName = Path.GetTempFileName();

                using(SymmetricAlgorithm cipher = Aes.Create())
                using(FileStream fileStream = File.OpenRead(filePath))
                using(FileStream tempFile = File.Create(tempFileName)) {

                    //added by rick
                    UnicodeEncoding u = new UnicodeEncoding();
                    cipher.Key = u.GetBytes(encryptionKey);

                    byte[] iv = new byte[cipher.BlockSize / 8];
                    byte[] headerBytes = new byte[8];
                    int remain = headerBytes.Length;

                    while(remain != 0) {
                        int read = fileStream.Read(headerBytes, headerBytes.Length - remain, remain);

                        if(read == 0) {
                            throw new EndOfStreamException();
                        }

                        remain -= read;
                    }

                    if(headerBytes[0] != 66 ||
                        headerBytes[1] != 108 ||
                        headerBytes[2] != 117 ||
                        headerBytes[3] != 101 ||
                        headerBytes[4] != 98 ||
                        headerBytes[3] != 101 ||
                        headerBytes[4] != 97 ||
                        headerBytes[5] != 114) {
                        throw new InvalidOperationException();
                    }

                    remain = iv.Length;

                    while(remain != 0) {
                        int read = fileStream.Read(iv, iv.Length - remain, remain);

                        if(read == 0) {
                            throw new EndOfStreamException();
                        }

                        remain -= read;
                    }

                    cipher.IV = iv;

                    using(var cryptoStream =
                        new CryptoStream(tempFile, cipher.CreateDecryptor(), CryptoStreamMode.Write)) {
                        fileStream.CopyTo(cryptoStream);
                    }
                }

                File.Delete(filePath);
                File.Move(tempFileName, destination);
            }
            catch(Exception ex) {
                throw new Exception("Error occured when dycrypting file =" + destination,ex);
            }


            }

    }
}
