using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using System.Configuration;

namespace Wings.Common
{
    public class DESEncrypt
    {

        //默认密钥向量
        private static byte[] Keys = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
        private static string KEY = "loveyingying";//密钥
        private byte[] sKey;
        private byte[] sIV;
        public DESEncrypt()
        {
        }

        /// <summary>
        /// 加密方法 
        /// </summary>
        /// <param name="pToEncrypt">加密字符串</param>
        /// <param name="keyStr">密钥可以为空，默认密钥为＂ferryQuery2012＂</param>
        /// <returns></returns>
        public string Encrypt(string pToEncrypt, string keyStr)
        {
            MemoryStream ms = null;
            CryptoStream cs = null;
            StringBuilder ret = null;
            try
            {
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                if (keyStr == null || keyStr == "")
                    keyStr = DESEncrypt.KEY;
                //把字符串放到byte数组中   
                //原来使用的UTF8编码，我改成Unicode编码了，不行   
                byte[] inputByteArray = Encoding.Default.GetBytes(pToEncrypt);
                byte[] keyByteArray = Encoding.Default.GetBytes(keyStr);
                SHA1 ha = new SHA1Managed();
                byte[] hb = ha.ComputeHash(keyByteArray);

                sKey = new byte[8];
                sIV = new byte[8];

                for (int i = 0; i < 8; i++)
                    sKey[i] = hb[i];
                for (int i = 8; i < 16; i++)
                    sIV[i - 8] = hb[i];
                des.Key = sKey;
                des.IV = sIV;

                ms = new MemoryStream();
                cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                ret = new StringBuilder();
                foreach (byte b in ms.ToArray())
                {
                    ret.AppendFormat("{0:X2}", b);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                if (null != cs) cs.Close();
                if (null != ms) ms.Close();
            }
            return ret.ToString();
        }

        /// <summary>
        /// 解密方法  
        /// </summary>
        /// <param name="pToDecrypt">解密字符串</param>
        /// <param name="keyStr">密钥可以为空，默认密钥为＂123321＂</param>
        /// <returns></returns>
        public string Decrypt(string pToDecrypt, string keyStr)
        {
            MemoryStream ms = null;
            CryptoStream cs = null;
            sKey = new byte[8];
            sIV = new byte[8];
            string values = "";

            DESCryptoServiceProvider des = new DESCryptoServiceProvider();

            if (keyStr == null || keyStr == "")
                keyStr = DESEncrypt.KEY;

            byte[] inputByteArray = new byte[pToDecrypt.Length / 2];
            for (int x = 0; x < pToDecrypt.Length / 2; x++)
            {
                int i = (Convert.ToInt32(pToDecrypt.Substring(x * 2, 2), 16));
                inputByteArray[x] = (byte)i;
            }
            try
            {
                byte[] keyByteArray = Encoding.Default.GetBytes(keyStr);
                SHA1 ha = new SHA1Managed();
                byte[] hb = ha.ComputeHash(keyByteArray);

                for (int i = 0; i < 8; i++)
                    sKey[i] = hb[i];
                for (int i = 8; i < 16; i++)
                    sIV[i - 8] = hb[i];
                des.Key = sKey;
                des.IV = sIV;
                ms = new MemoryStream();
                cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                //建立StringBuild对象，CreateDecrypt使用的是流对象，必须把解密后的文本变成流对象   
                values = System.Text.Encoding.Default.GetString(ms.ToArray());
            }
            catch (Exception ex)
            {
                throw new Exception("文件格式出错");
            }
            finally
            {
                cs.Close();
                ms.Close();
            }
            return values;
        }

        #region DES加密
        /// <summary>
        /// DES加密字符串
        /// </summary>
        /// <param name="encryptString">待加密的字符串</param>
        /// <param name="encryptKey">加密密钥,要求为8位</param>
        /// <returns>加密成功返回加密后的字符串，失败返回源串</returns>
        public static string EncryptDES(string encryptString, string encryptKey)
        {
            try
            {
                if (encryptKey == null || encryptKey == "")
                    encryptKey = DESEncrypt.KEY;
                byte[] rgbKey = Encoding.UTF8.GetBytes(encryptKey.Substring(0, 8));
                byte[] rgbIV = Keys;
                byte[] inputByteArray = Encoding.UTF8.GetBytes(encryptString);
                DESCryptoServiceProvider dCSP = new DESCryptoServiceProvider();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, dCSP.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Convert.ToBase64String(mStream.ToArray()).Replace('+', '@').Replace('=', '!');
            }
            catch (Exception ex)
            {
                return "";
            }
        }
        #endregion

        #region DES解密
        /// <summary>
        /// DES解密字符串
        /// </summary>
        /// <param name="decryptString">待解密的字符串</param>
        /// <param name="decryptKey">解密密钥,要求为8位,和加密密钥相同</param>
        /// <returns>解密成功返回解密后的字符串，失败返源串</returns>
        public static string DecryptDES(string decryptString, string decryptKey)
        {
            try
            {
                if (decryptKey == null || decryptKey == "")
                    decryptKey = DESEncrypt.KEY;
                byte[] rgbKey = Encoding.UTF8.GetBytes(decryptKey);
                byte[] rgbIV = Keys;
                byte[] inputByteArray = Convert.FromBase64String(decryptString.Replace('@', '+').Replace('!', '='));
                DESCryptoServiceProvider DCSP = new DESCryptoServiceProvider();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, DCSP.CreateDecryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Encoding.UTF8.GetString(mStream.ToArray());
            }
            catch (Exception ex)
            {
                return "";
            }
        }
        #endregion
    }
}
