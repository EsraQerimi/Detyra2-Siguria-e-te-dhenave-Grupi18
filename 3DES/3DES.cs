﻿using System;
using System.Security.Cryptography;
using System.Text;

namespace _3DES
{
    public class TripleDes
    {
        private const string securityKey = "DataSecurity3DES";
        public static string Encrypt(string TextToEncrypt)
        {
            string encryptedText = "";
            byte[] MyEncryptedArray = UTF8Encoding.UTF8.GetBytes(TextToEncrypt);
            MD5CryptoServiceProvider MyMD5CryptoService = new MD5CryptoServiceProvider();

            byte[] MysecurityKeyArray = MyMD5CryptoService.ComputeHash
                (UTF8Encoding.UTF8.GetBytes(securityKey));
            MyMD5CryptoService.Clear();

            var MyTripleDESCryptoService = new
                TripleDESCryptoServiceProvider();

            MyTripleDESCryptoService.Key = MysecurityKeyArray;

            MyTripleDESCryptoService.Mode = CipherMode.ECB;

            MyTripleDESCryptoService.Padding = PaddingMode.PKCS7;

            var MyCryptoTransform = MyTripleDESCryptoService
                .CreateEncryptor();

            byte[] MyresultArray = MyCryptoTransform
                .TransformFinalBlock(MyEncryptedArray, 0,
                MyEncryptedArray.Length);

            MyTripleDESCryptoService.Clear();

            return Convert.ToBase64String(MyresultArray, 0,MyresultArray.Length); ;

        }


    }
}