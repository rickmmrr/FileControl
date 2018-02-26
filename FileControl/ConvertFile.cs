using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Security.Cryptography;

namespace FileControl {
    public class ConvertFile {


        /// <summary>
        /// Keep the same extension and file size 
        /// simply place the header at the bottom of the folder
        /// 
        /// </summary>
        public static void ConvertFileByMovingAround( string fullPath, string newPath ) {

            try {

                using(var fs = new FileStream(fullPath, FileMode.Open, FileAccess.Read))
                using(var br = new BinaryReader(fs, Encoding.Default))
                using(var fsOut = new FileStream(newPath, FileMode.CreateNew, FileAccess.Write))
                using(var bw = new BinaryWriter(fsOut, Encoding.Default)) {

                    //read either half of the file size or 1000 longs whatever is shorter
                    FileInfo inputFileInfo = new FileInfo(fullPath);
                    long headerSize = 1000;
                    if((inputFileInfo.Length / sizeof(long)) < 1000)
                        headerSize = inputFileInfo.Length / sizeof(long);

                    var headerHolder = new List<UInt64>();


                    //save the header in a list
                    for(int x = 0; x < headerSize; x++)
                        headerHolder.Add(br.ReadUInt64());

                    //copy the rest of the file into the new file
                    while(true) {

                        try {
                            bw.Write(br.ReadUInt64());
                        }
                        catch(EndOfStreamException es) {
                            break;
                        }
                    }
                    //copy the header into the end
                    for(int x = 0; x < headerSize; x++)
                        bw.Write(headerHolder[x]);

                    //close streams
                    bw.Close();
                    fsOut.Close();
                    br.Close();
                    fs.Close();

                }
            }
            catch(Exception p) {
                Debug.WriteLine(p.Message);

            }
        }

        public static void convertFile(string FullPath, string NewPath) {

            try {

                //Get the length of the file
                FileInfo fi = new FileInfo(FullPath);
                long fileLength = fi.Length;
                long loopCount = fileLength / sizeof(UInt64);

                UInt64 halfLarge = 0xFFFFFFFFFFFFFFFF / 2;

                //test
                List<bool> flip = new List<bool>();

                using(var fsr = new FileStream(FullPath, FileMode.Open, FileAccess.Read))
                using(var ascWriter = new StreamWriter(NewPath))
                using(var br = new BinaryReader(fsr)) {

                    int columns = 52;
                    for(long x = 0; x < loopCount; x++) {

                        ulong data = br.ReadUInt64();
                        if(data > halfLarge) {

                            data = ~data;
                            flip.Add(true);

                        }
                        else
                            flip.Add(false);


                        ascWriter.Write(Convert.ToString(data));
                        ascWriter.Write(",");

                        if((x % 52) == 0)
                            ascWriter.WriteLine();




                    }

                    if(fileLength%sizeof(UInt64) > 0) {

                        for(int left = 0; left < fileLength % sizeof(UInt64); left++) {
                            byte b = br.ReadByte();
                            ascWriter.Write(Convert.ToString(b));
                            ascWriter.Write(",");
                        }

                    }

                    ascWriter.Close();
                    br.Close();
                    fsr.Close();

                }

            }
            catch(Exception e) {
                Debug.WriteLine(e.Message);
            }


        }
        public class EncryptedFile {

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
            private static string _vector = "";
            public static string vector {
                get
                {
                    _vector = "g";
                    _vector += "Q";
                    _vector += "u";
                    _vector += "z";
                    return _vector;
                }
            }
            /// <summary>
            /// The Save() function will only write out the license file if ContentsChanged is true.
            /// </summary>




            /*
            public static string DecryptTextFromFile( String FileName ) {
                //try
                //{
                FileStream fStream = File.OpenRead(FileName);
                return EncryptedFile.DecryptFromStream(fStream);
                //}
                //catch (UnauthorizedAccessException e)
                //{
                //    Error = true;
                //    ErrorException = e;
                //    ErrorMessage = "Unable to open file: UnauthorizedAccessException.";
                //    //Console.WriteLine("A file access error occurred: {0}", e.Message);
                //    return null;
                //}
            }
            */
            /*
            public static string EncryptTextFileToFile(string source, string destination ) {
                //try
                //{
                FileStream fStream = File.OpenRead(source);
                return EncryptedFile.DecryptFromStream(fStream);
                //}
                //catch (UnauthorizedAccessException e)
                //{
                //    Error = true;
                //    ErrorException = e;
                //    ErrorMessage = "Unable to open file: UnauthorizedAccessException.";
                //    //Console.WriteLine("A file access error occurred: {0}", e.Message);
                //    return null;
                //}
            }
            */
            public static void DecryptFromFileToFile( string source, string destination) {
                CryptoStream cStream = null;
                StreamReader sReader = null;
                FileStream strm = null;
                Stream outStream = null;
                //string rc = "";
                try {

                    strm = File.Open(source, FileMode.Open);
                    outStream = File.Open(destination, FileMode.OpenOrCreate);

                    UnicodeEncoding u = new UnicodeEncoding();
                    byte[] Key = u.GetBytes(key);
                    byte[] IV = u.GetBytes(vector);

                    // Create a CryptoStream using the FileStream 
                    // and the passed key and initialization vector (IV).

                    cStream = new CryptoStream(strm,
                        new TripleDESCryptoServiceProvider().CreateDecryptor(Key, IV),
                        CryptoStreamMode.Read);

                    // Create a StreamReader using the CryptoStream.
                    sReader = new StreamReader(cStream);


                    char[] buffer = new char[0xFFFF];
                    while(true) {

                        int result = sReader.Read(buffer, 0, buffer.Length);
                        if(result == 0)
                            break;

                        for(int x = 0; x < result; x++)
                            outStream.WriteByte(Convert.ToByte(buffer[x]));

                        if(result < 0xFFFF)
                            break;


                    }



                }
                finally {
                    try { outStream.Flush(); outStream.Close(); outStream.Dispose(); }
                    catch { }
                    try { sReader.Close(); sReader.Dispose(); }
                    catch { }
                    try { cStream.Close(); cStream.Dispose(); }
                    catch { }
                    try { strm.Close(); strm.Dispose(); }
                    catch { }
                }
                //return rc;
                //catch (CryptographicException e)
                //{
                //    try { sReader.Close(); }
                //    catch { }
                //    try { cStream.Close(); }
                //    catch { }
                //    try { strm.Close(); }
                //    catch { }
                //    Error = true;
                //    ErrorException = e;
                //    ErrorMessage = "Unable to open file: CryptographicException.";
                //    //Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
                //    return "";
                //}
                //catch (UnauthorizedAccessException e)
                //{
                //    try { sReader.Close(); }
                //    catch { }
                //    try { cStream.Close(); }
                //    catch { }
                //    try { strm.Close(); }
                //    catch { }
                //    Error = true;
                //    ErrorException = e;
                //    ErrorMessage = "Unable to open file: UnauthorizedAccessException.";
                //    //Console.WriteLine("A file access error occurred: {0}", e.Message);
                //    return "";
                //}
            }
            /*
            protected void WriteLicenseFile( DataSet ds ) {
                if(EncryptFile) {
                    TextWriter stringWriter = new StringWriter();
                    ds.WriteXml(stringWriter, XmlWriteMode.WriteSchema);
                    EncryptTextToFile(stringWriter.ToString(), FilePath);
                    stringWriter.Close();
                }
                else
                    ds.WriteXml(FilePath, XmlWriteMode.WriteSchema);
            }
            
            /// <summary>
            /// This assumes the file contents is text and needs to be encrypted.
            /// The original contents still needs to be a valid xml that can be loaded into a DataSet.
            /// </summary>
            public void EncryptFileContents() {
                DataSet ds = new DataSet("ImsLicense");
                //try
                //{
                ds.ReadXml(FilePath, XmlReadMode.ReadSchema);
                TextWriter stringWriter = new StringWriter();
                ds.WriteXml(stringWriter, XmlWriteMode.WriteSchema);
                EncryptTextToFile(stringWriter.ToString(), FilePath);
                stringWriter.Close();
                //}
                //catch (Exception ex)
                //{
                //    Error = true;
                //    ErrorException = ex;
                //    ErrorMessage = "Problem reading xml from file.";
                //}
            }
            */
            //public void EncryptTextToFile(String Data, String FileName, byte[] Key, byte[] IV)
            /*
            public static void EncryptTextToFile( String Data, String FileName ) {
                //try
                //{
                FileStream fStream = File.Open(FileName, FileMode.Create);
                EncryptedFile.EncryptToStream(Data, (Stream)fStream);
                //}
                //catch (UnauthorizedAccessException e)
                //{
                //    Error = true;
                //    ErrorException = e;
                //    ErrorMessage = "Unable to open file: UnauthorizedAccessException.";
                //    //Console.WriteLine("A file access error occurred: {0}", e.Message);
                //    return;
                //}

            }
            */
            /*
            public static void EncryptBinaryToFile( String Data, String FileName ) {
                //try
                //{
                FileStream fStream = File.Open(FileName, FileMode.Create);
                EncryptedFile.EncryptToStream(Data, (Stream)fStream);
                //}
                //catch (UnauthorizedAccessException e)
                //{
                //    Error = true;
                //    ErrorException = e;
                //    ErrorMessage = "Unable to open file: UnauthorizedAccessException.";
                //    //Console.WriteLine("A file access error occurred: {0}", e.Message);
                //    return;
                //}

            }
            */
            public static void EncryptFileToFile( string source, string destination ) {
                StreamWriter sWriter = null;
                CryptoStream cStream = null;
                Stream fStream = null;
                FileStream iStream = null;
                try {

                    fStream = File.Open(destination, FileMode.Create);
                    iStream = File.Open(source, FileMode.Open);


                    UnicodeEncoding u = new UnicodeEncoding();
                    byte[] Key = u.GetBytes(key);
                    byte[] IV = u.GetBytes(vector);

                    cStream = new CryptoStream(fStream,
                        new TripleDESCryptoServiceProvider().CreateEncryptor(Key, IV),
                        CryptoStreamMode.Write);

                    // Create a StreamWriter using the CryptoStream.
                    sWriter = new StreamWriter(cStream);



                    var buffer = new byte[0xFFFF];
                    while(true) {
                        var result = iStream.Read(buffer, 0, 0xFFFF);
                        if(result == 0)
                            break;

                        for(int x = 0; x < result; x++)
                            sWriter.Write(Convert.ToChar(buffer[x]));

                        if(result < 0xFFFF)
                            break;

                    }



                }
                finally {
                    try { fStream.Flush(); fStream.Close(); fStream.Dispose(); }
                    catch { }
                    try { cStream.Close(); cStream.Dispose(); }
                    catch { }
                    try { iStream.Close(); iStream.Dispose(); }
                    catch { }
                }
                //catch (CryptographicException e)
                //{
                //    try { sWriter.Close(); }
                //    catch { }
                //    try { cStream.Close(); }
                //    catch { }
                //    try { strm.Close(); }
                //    catch { }
                //    Error = true;
                //    ErrorException = e;
                //    ErrorMessage = "Unable to write file: CryptographicException.";
                //    //Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
                //    return;
                //}
                //catch (UnauthorizedAccessException e)
                //{
                //    try { sWriter.Close(); }
                //    catch { }
                //    try { cStream.Close(); }
                //    catch { }
                //    try { strm.Close(); }
                //    catch { }
                //    Error = true;
                //    ErrorException = e;
                //    ErrorMessage = "Unable to write file: UnauthorizedAccessException.";
                //    //Console.WriteLine("A file access error occurred: {0}", e.Message);
                //    return;
                //}
            }
            /*
            private static void EncryptToStream( byte[] data, Stream strm ) {
                BinaryWriter bWriter = null;
                CryptoStream cStream = null;
                try {
                    UnicodeEncoding u = new UnicodeEncoding();
                    byte[] Key = u.GetBytes(key);
                    byte[] IV = u.GetBytes(vector);

                    cStream = new CryptoStream(strm,
                        new TripleDESCryptoServiceProvider().CreateEncryptor(Key, IV),
                        CryptoStreamMode.Write);

                    // Create a StreamWriter using the CryptoStream.
                    bWriter = new BinaryWriter(cStream);

                    // Write the data to the stream 
                    // to encrypt it.
                    //sWriter.WriteLine(Data);
                    bWriter.Write(data);

                    // Close the streams and
                    // close the file.
                    bWriter.Close();
                    cStream.Close();
                    //fStream.Close();
                    strm.Close();
                }
                finally {
                    try { bWriter.Close(); }
                    catch { }
                    try { cStream.Close(); }
                    catch { }
                    try { strm.Close(); }
                    catch { }
                }
                //catch (CryptographicException e)
                //{
                //    try { sWriter.Close(); }
                //    catch { }
                //    try { cStream.Close(); }
                //    catch { }
                //    try { strm.Close(); }
                //    catch { }
                //    Error = true;
                //    ErrorException = e;
                //    ErrorMessage = "Unable to write file: CryptographicException.";
                //    //Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
                //    return;
                //}
                //catch (UnauthorizedAccessException e)
                //{
                //    try { sWriter.Close(); }
                //    catch { }
                //    try { cStream.Close(); }
                //    catch { }
                //    try { strm.Close(); }
                //    catch { }
                //    Error = true;
                //    ErrorException = e;
                //    ErrorMessage = "Unable to write file: UnauthorizedAccessException.";
                //    //Console.WriteLine("A file access error occurred: {0}", e.Message);
                //    return;
                //}
            }
            */
        }

    }
}
