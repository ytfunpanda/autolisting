using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace Auto.Web.Infrastucture.Helpers
{
    public class CookieUtil
    {
        #region SET COOKIE FUNCTIONS

        /// <summary>
        /// SetTripleDESEncryptedCookie - key & value only
        /// </summary>
        /// <param name="key">key of cookie name</param>
        /// <param name="val">value of accociated cookie name</param>
        public static void SetTripleDESEncryptedCookie(string key, string val)
        {
            key = CryptoUtil.EncryptTripleDES(key);
            val = CryptoUtil.EncryptTripleDES(val);

            SetCookie(key, val);
        }


        /// <summary>
        /// SetTripleDESEncryptedCookie - overloaded method with expires parameter
        /// </summary>
        /// <param name="key">key of cookie name</param>
        /// <param name="val">value of accociated cookie name</param>
        /// <param name="expires">datetime of cookie expiration</param>
        public static void SetTripleDESEncryptedCookie(string key, string val, DateTime expires)
        {
            key = CryptoUtil.EncryptTripleDES(key);
            val = CryptoUtil.EncryptTripleDES(val);

            SetCookie(key, val, expires);
        }


        /// <summary>
        /// Set encrypted cookie with key & value
        /// </summary>
        /// <param name="key">key of cookie name</param>
        /// <param name="val">value of accociated cookie name</param>
        public static void SetEncryptedCookie(string key, string val)
        {
            key = CryptoUtil.Encrypt(key);
            val = CryptoUtil.Encrypt(val);

            SetCookie(key, val);
        }


        /// <summary>
        /// SetEncryptedCookie - overloaded method with expires parameter
        /// </summary>
        /// <param name="key">key of cookie name</param>
        /// <param name="val">value of accociated cookie name</param>
        /// <param name="expires">datetime of cookie expiration</param>
        public static void SetEncryptedCookie(string key, string val, DateTime expires)
        {
            key = CryptoUtil.Encrypt(key);
            val = CryptoUtil.Encrypt(val);

            SetCookie(key, val, expires);
        }


        /// <summary>
        ///  SetCookie - key & value only
        /// </summary>
        /// <param name="key">key of cookie name</param>
        /// <param name="val">value of accociated cookie name</param>
        public static void SetCookie(string key, string val)
        {
            key = HttpContext.Current.Server.UrlEncode(key);
            val = HttpContext.Current.Server.UrlEncode(val);

            HttpCookie cookie = new HttpCookie(key, val);
            SetCookie(cookie);
        }


        /// <summary>
        /// SetCookie - overloaded with expires parameter
        /// </summary>
        /// <param name="key">key of cookie name</param>
        /// <param name="val">value of accociated cookie name</param>
        /// <param name="expires">datetime of cookie expiration</param>
        public static void SetCookie(string key, string val, DateTime expires)
        {
            if (HttpContext.Current != null)
            {
                key = HttpContext.Current.Server.UrlEncode(key);
                val = HttpContext.Current.Server.UrlEncode(val);

                HttpCookie cookie = new HttpCookie(key, val);
                cookie.Expires = expires;
                SetCookie(cookie);
            }
        }


        /// <summary>
        /// SetCookie - HttpCookie only
        /// final step to set the cookie to the response clause
        /// </summary>
        /// <param name="cookie">complete cookie assembled with key, value, expiry date</param>
        public static void SetCookie(HttpCookie cookie)
        {
            //HttpContext.Current.Response.Cookies.Set(cookie);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }


        #endregion
        #region GET COOKIE FUNCTION

        public static string GetTripleDESEncryptedCookieValue(string key)
        {
            //encrypt key only - encoding done in GetCookieValue
            key = CryptoUtil.EncryptTripleDES(key);

            //get value 
            string val = GetCookieValue(key);

            //decrypt value
            val = CryptoUtil.DecryptTripleDES(val);
            return val;
        }

        public static string GetEncryptedCookieValue(string key)
        {
            //encrypt key only - encoding done in GetCookieValue
            key = CryptoUtil.Encrypt(key);

            //get value
            string val = GetCookieValue(key);

            //decrypt value
            val = CryptoUtil.Decrypt(val);
            return val;

        }

        public static HttpCookie GetCookie(string key)
        {
            //encode key for retrieval
            key = HttpContext.Current.Server.UrlEncode(key);
            return HttpContext.Current.Request.Cookies.Get(key);
        }

        public static string GetCookieValue(string key)
        {
            //don't encode key for retrieval here
            //done in the GetCookie function
            string val = "";
            try
            {
                HttpCookie requestedCookie = GetCookie(key);
                //get value 
                if (requestedCookie != null && requestedCookie.Value != null)
                    val = GetCookie(key).Value;

                //decode stored value
                val = HttpContext.Current.Server.UrlDecode(val);

            }
            catch
            {
            }
            return val;
        }


        #endregion
    }

    public class CryptoUtil
    {
        #region Variable Declaration

        //8 bytes randomly selected for both the Key and the Initialization Vector
        //the IV is used to encrypt the first block of text so that any repetitive 
        //patterns are not apparent
        private static byte[] KEY_64 = { 99, 16, 216, 156, 78, 4, 18, 92 };
        private static byte[] IV_64 = { 52, 203, 246, 179, 6, 79, 17, 203 };

        //24 byte or 192 bit key and IV for TripleDES
        private static byte[] KEY_192 = {12, 160, 93, 240, 78, 25, 218, 32, 15, 
											167, 44, 80, 126, 50, 155, 112, 
											2, 94, 11, 204, 119, 35, 184, 197};
        private static byte[] IV_192 = {55, 103, 26, 179, 36, 199, 167, 3, 42, 
										   250, 62, 83, 14, 17, 209, 13,145, 
										   123, 20, 58, 13, 10, 121, 202};

        #endregion
        #region Custom Methods

        /// <summary>
        /// Standard DES encryption
        /// </summary>
        /// <param name="val">Accepts value to be encrypted using DES</param>
        /// <returns>Returns value encrypted in DES</returns>
        public static string Encrypt(string val)
        {
            string encrypted = "";
            if (val != "")
            {
                DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, cryptoProvider.CreateEncryptor(KEY_64, IV_64), CryptoStreamMode.Write);
                StreamWriter sw = new StreamWriter(cs);

                sw.Write(val);
                sw.Flush();
                cs.FlushFinalBlock();
                ms.Flush();

                //convert back to string - added explicit conversion to int32
                encrypted = Convert.ToBase64String(ms.GetBuffer(), 0, Convert.ToInt32(ms.Length));
            }
            return encrypted;
        }


        /// <summary>
        /// Standard DES decryption
        /// </summary>
        /// <param name="val">Value of decrypted</param>
        /// <returns>Returns decrypted value as string</returns>
        public static string Decrypt(string val)
        {
            string decrpted = "";
            if (val != "")
            {
                DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();

                //convert from string to byte
                byte[] buffer = Convert.FromBase64String(val);
                MemoryStream ms = new MemoryStream(buffer);
                CryptoStream cs = new CryptoStream(ms, cryptoProvider.CreateDecryptor(KEY_64, IV_64), CryptoStreamMode.Read);
                StreamReader sr = new StreamReader(cs);
                decrpted = sr.ReadToEnd();
            }
            return decrpted;
        }


        /// <summary>
        /// Triple DES encryption
        /// </summary>
        /// <param name="val">Accepts value to be encrypted using Triple DES</param>
        /// <returns>Returns value encrypted in Triple DES</returns>
        public static string EncryptTripleDES(string val)
        {
            string encrypted = "";
            if (val != "")
            {
                TripleDESCryptoServiceProvider cryptoProvider = new TripleDESCryptoServiceProvider();
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, cryptoProvider.CreateEncryptor(KEY_192, IV_192), CryptoStreamMode.Write);
                StreamWriter sw = new StreamWriter(cs);

                sw.Write(val);
                sw.Flush();
                cs.FlushFinalBlock();
                ms.Flush();

                //convert back to string
                encrypted = Convert.ToBase64String(ms.GetBuffer(), 0, Convert.ToInt32(ms.Length));
            }
            return encrypted;
        }


        /// <summary>
        /// Triple DES decryption
        /// </summary>
        /// <param name="val">Value of decrypted</param>
        /// <returns>Returns decrypted value as string<</returns>
        public static string DecryptTripleDES(string val)
        {
            string decrtypted = "";
            if (val != "")
            {
                TripleDESCryptoServiceProvider cryptoProvider = new TripleDESCryptoServiceProvider();

                //convert from string to byte
                byte[] buffer = Convert.FromBase64String(val);
                MemoryStream ms = new MemoryStream(buffer);
                CryptoStream cs = new CryptoStream(ms, cryptoProvider.CreateDecryptor(KEY_192, IV_192), CryptoStreamMode.Read);
                StreamReader sr = new StreamReader(cs);
                decrtypted = sr.ReadToEnd();
            }
            return decrtypted;
        }


        #endregion
    }
}
