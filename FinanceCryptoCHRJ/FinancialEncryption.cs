using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Encodings;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Pkcs;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.X509;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace FinanceCrypto
{

    public class CryptoObject {

        public String CryptedData { get;private set; }
        public String CryptedPrivateKey { get;private set; }
        public String CryptedHash { get; private set; }
        public String PublicKey { get;private set; }

        private CryptoHelper.RSAForJava rsa = new CryptoHelper.RSAForJava();

        public CryptoObject() {
        }

        public void init(String password) {
            CryptoHelper.RSAForJava.RSAKEY keypair = rsa.GetKey();
            PublicKey = keypair.PublicKey;
            CryptedPrivateKey = CryptoHelper.AesEncrypt(keypair.PrivateKey, password);
            String initialData = randomMask()+"";
            String sha = CryptoHelper.Sha256Encrypt(initialData);
            CryptedHash = rsa.EncryptByPrivateKey(sha, keypair.PrivateKey);
            CryptedData = CryptoHelper.AesEncrypt(initialData, sha);
        }

        public void loadFromXml(String xml) {
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.LoadXml(xml);
            XmlElement root = xmldoc["CryptedData"];
            PublicKey = root["PublicKey"].InnerText;
            CryptedPrivateKey = root["PrivateKey"].InnerText;
            CryptedHash = root["HashKey"].InnerText;
            CryptedData = root["Data"].InnerText;
        }

        private const string pool = "1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private static Random rnd = new Random();
        public static String randomMask() {
            String mask = "";
            for (int i = 0; i < 16; i++)
            {
                mask += pool[rnd.Next() % pool.Length];
            }
            return mask;
        }

        public String exportToXml() {
            XmlDocument xmldoc = new XmlDocument();
            XmlDeclaration xmldec = xmldoc.CreateXmlDeclaration("1.0", "utf-8", null);
            xmldoc.AppendChild(xmldec);
            XmlElement root = xmldoc.CreateElement("CryptedData");
            xmldoc.AppendChild(root);
            
            XmlElement pk = xmldoc.CreateElement("PublicKey");
            pk.InnerText = PublicKey;

            XmlElement sk = xmldoc.CreateElement("PrivateKey");
            sk.InnerText = CryptedPrivateKey;

            XmlElement ha = xmldoc.CreateElement("HashKey");
            ha.InnerText = CryptedHash;

            XmlElement dt = xmldoc.CreateElement("Data");
            dt.InnerText = CryptedData;

            root.AppendChild(pk);
            root.AppendChild(sk);
            root.AppendChild(ha);
            root.AppendChild(dt);

            return ConvertXmlToString(xmldoc);
        }

        private string ConvertXmlToString(XmlDocument xmlDoc)
        {
            MemoryStream stream = new MemoryStream();
            XmlTextWriter writer = new XmlTextWriter(stream, null);
            writer.Formatting = Formatting.Indented;
            xmlDoc.Save(writer);
            StreamReader sr = new StreamReader(stream, System.Text.Encoding.UTF8);
            stream.Position = 0;
            string xmlString = sr.ReadToEnd();
            sr.Close();
            stream.Close();
            return xmlString;
        }


        public bool verifyPassword(String password) {
            try
            {
                String privkey = CryptoHelper.AesDecrypt(CryptedPrivateKey, password);
                return rsa.DecryptByPublicKey(rsa.EncryptByPrivateKey(password, privkey), PublicKey) == password;
            }
            catch (Exception ex) {
                return false;
            }
        }

        public String getData() {
            return CryptoHelper.AesDecrypt(CryptedData, rsa.DecryptByPublicKey(CryptedHash, PublicKey)).Substring(16);
        }

        public bool setData(String data, String password) {
            try
            {
                String privatekey = CryptoHelper.AesDecrypt(CryptedPrivateKey, password);
                String maskdata = randomMask() + data;
                String sha = CryptoHelper.Sha256Encrypt(maskdata);
                CryptedHash = rsa.EncryptByPrivateKey(sha, privatekey);
                CryptedData = CryptoHelper.AesEncrypt(maskdata, sha);
                return true;
            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public bool verifyData(String password) {
            try
            {
                bool flag1 = false, flag2 = false;
                String sha = rsa.DecryptByPublicKey(CryptedHash, PublicKey);
                String data = CryptoHelper.AesDecrypt(CryptedData, rsa.DecryptByPublicKey(CryptedHash, PublicKey));
                flag1 = sha == CryptoHelper.Sha256Encrypt(data);
                String privkey = CryptoHelper.AesDecrypt(CryptedPrivateKey, password);
                flag2 = rsa.DecryptByPublicKey(rsa.EncryptByPrivateKey(password, privkey), PublicKey) == password;
                return flag2 && flag1;
            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            }
            return false;
        }

    }

    static class CryptoHelper {
        #region AES

        private const string IVString = "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0";

        public static string AesEncrypt(string str, string key, string IVString = IVString)
        {
            Encoding encoder = Encoding.UTF8;
            byte[] toEncryptArray = Encoding.UTF8.GetBytes(str);
            RijndaelManaged rm = new RijndaelManaged
            {
                Key = encoder.GetBytes(Sha256Encrypt(key).Substring(0,16)),
                Mode = CipherMode.CBC,
                Padding = PaddingMode.PKCS7,
                IV = encoder.GetBytes(IVString),
            };
            ICryptoTransform cTransform = rm.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            return ToBCDStringLower(resultArray);
        }
        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="str"></param>
        /// <param name="key"></param>
        /// <param name="IVString"></param>
        /// <returns></returns>
        public static string AesDecrypt(string str, string key, string IVString = IVString)
        {
            Encoding encoder = Encoding.UTF8;
            using (AesCryptoServiceProvider aes = new AesCryptoServiceProvider())
            {
                aes.Key = encoder.GetBytes(Sha256Encrypt(key).Substring(0, 16));
                aes.IV = encoder.GetBytes(IVString);
                var enc = aes.CreateDecryptor(aes.Key, aes.IV);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, enc, CryptoStreamMode.Write))
                    {
                        var bts = FromBCDString(str);
                        cs.Write(bts, 0, bts.Length);
                    }
                    return encoder.GetString(ms.ToArray());
                }
            }
        }
        public static byte[] FromBCDString(string buffer)
        {
            if (buffer == null) return null;
            int start = 0;
            int count = buffer.Length;
            bool inCase = false;
            byte cur = 0;
            int dataEnd = start + count;
            List<byte> lst = new List<byte>(count / 2);
            while (start < dataEnd)
            {
                byte num = (byte)buffer[start++];
                if (num == ' ' || num == '\r' || num == '\n' || num == '\t')
                {
                    if (inCase)
                    {
                        lst.Add((byte)(cur / 16));
                        inCase = false;
                    }
                    continue;
                }
                byte tmp = 0;
                if (num >= '0' && num <= '9')
                    tmp = (byte)(num - '0');
                else if (num >= 'a' && num <= 'f')
                    tmp = (byte)(num - 'a' + 10);
                else if (num >= 'A' && num <= 'F')
                    tmp = (byte)(num - 'A' + 10);
                else
                    throw new ArgumentException("需要传入一个正确的BCD字符串，BCD字符串中只能包含 0-9 A-F a-f 和空格，回车 制表符!");
                if (!inCase)
                {
                    cur = (byte)(tmp * 16);
                    inCase = true;
                }
                else
                {
                    cur += tmp;
                    inCase = false;
                    lst.Add(cur);
                }
            }
            if (inCase)
            {
                lst.Add((byte)(cur / 16));
                inCase = false;
            }
            return lst.ToArray();
        }
        public static string ToBCDStringLower(byte[] buffer)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < buffer.Length; i++)
            {
                sb.Append(buffer[i].ToString("x2"));
            }
            return sb.ToString();//result;
        }

        #endregion

        #region SHA
        public static string Sha256Encrypt(string palinData)
        {
            if (string.IsNullOrWhiteSpace(palinData)) return null;
            using (SHA256 sha256 = new SHA256CryptoServiceProvider())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(palinData);
                byte[] sha256Bytes = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(sha256Bytes);
            }
        }
        #endregion

        public class RSAForJava
        {

            public RSAForJava()
            {

            }
            /// <summary>
            /// KEY 结构体
            /// </summary>
            public struct RSAKEY
            {
                /// <summary>
                /// 公钥
                /// </summary>
                public string PublicKey
                {
                    get;
                    set;
                }
                /// <summary>
                /// 私钥
                /// </summary>
                public string PrivateKey
                {
                    get;
                    set;
                }
            }
            public RSAKEY GetKey()
            {
                //RSA密钥对的构造器  
                RsaKeyPairGenerator keyGenerator = new RsaKeyPairGenerator();

                //RSA密钥构造器的参数  
                RsaKeyGenerationParameters param = new RsaKeyGenerationParameters(
                    Org.BouncyCastle.Math.BigInteger.ValueOf(3),
                    new Org.BouncyCastle.Security.SecureRandom(),
                    1024,   //密钥长度  
                    25);
                //用参数初始化密钥构造器  
                keyGenerator.Init(param);
                //产生密钥对  
                AsymmetricCipherKeyPair keyPair = keyGenerator.GenerateKeyPair();
                //获取公钥和密钥  
                AsymmetricKeyParameter publicKey = keyPair.Public;
                AsymmetricKeyParameter privateKey = keyPair.Private;

                SubjectPublicKeyInfo subjectPublicKeyInfo = SubjectPublicKeyInfoFactory.CreateSubjectPublicKeyInfo(publicKey);
                PrivateKeyInfo privateKeyInfo = PrivateKeyInfoFactory.CreatePrivateKeyInfo(privateKey);


                Asn1Object asn1ObjectPublic = subjectPublicKeyInfo.ToAsn1Object();

                byte[] publicInfoByte = asn1ObjectPublic.GetEncoded("UTF-8");
                Asn1Object asn1ObjectPrivate = privateKeyInfo.ToAsn1Object();
                byte[] privateInfoByte = asn1ObjectPrivate.GetEncoded("UTF-8");

                RSAKEY item = new RSAKEY()
                {
                    PublicKey = Convert.ToBase64String(publicInfoByte),
                    PrivateKey = Convert.ToBase64String(privateInfoByte)
                };
                return item;
            }
            private AsymmetricKeyParameter GetPublicKeyParameter(string s)
            {
                s = s.Replace("\r", "").Replace("\n", "").Replace(" ", "");
                byte[] publicInfoByte = Convert.FromBase64String(s);
                Asn1Object pubKeyObj = Asn1Object.FromByteArray(publicInfoByte);//这里也可以从流中读取，从本地导入   
                AsymmetricKeyParameter pubKey = PublicKeyFactory.CreateKey(publicInfoByte);
                return pubKey;
            }
            private AsymmetricKeyParameter GetPrivateKeyParameter(string s)
            {
                s = s.Replace("\r", "").Replace("\n", "").Replace(" ", "");
                byte[] privateInfoByte = Convert.FromBase64String(s);
                // Asn1Object priKeyObj = Asn1Object.FromByteArray(privateInfoByte);//这里也可以从流中读取，从本地导入   
                // PrivateKeyInfo privateKeyInfo = PrivateKeyInfoFactory.CreatePrivateKeyInfo(privateKey);
                AsymmetricKeyParameter priKey = PrivateKeyFactory.CreateKey(privateInfoByte);
                return priKey;
            }
            public string EncryptByPrivateKey(string s, string key)
            {
                //非对称加密算法，加解密用  
                IAsymmetricBlockCipher engine = new Pkcs1Encoding(new RsaEngine());


                //加密  

                try
                {
                    engine.Init(true, GetPrivateKeyParameter(key));
                    byte[] byteData = System.Text.Encoding.UTF8.GetBytes(s);
                    var ResultData = engine.ProcessBlock(byteData, 0, byteData.Length);
                    return Convert.ToBase64String(ResultData);
                    //Console.WriteLine("密文（base64编码）:" + Convert.ToBase64String(testData) + Environment.NewLine);
                }
                catch (Exception ex)
                {
                    return ex.Message;

                }
            }
            public string DecryptByPublicKey(string s, string key)
            {
                s = s.Replace("\r", "").Replace("\n", "").Replace(" ", "");
                //非对称加密算法，加解密用  
                IAsymmetricBlockCipher engine = new Pkcs1Encoding(new RsaEngine());


                //解密  

                try
                {
                    engine.Init(false, GetPublicKeyParameter(key));
                    byte[] byteData = Convert.FromBase64String(s);
                    var ResultData = engine.ProcessBlock(byteData, 0, byteData.Length);
                    return System.Text.Encoding.UTF8.GetString(ResultData);

                }
                catch (Exception ex)
                {
                    return ex.Message;

                }
            }
        }
    }
}
