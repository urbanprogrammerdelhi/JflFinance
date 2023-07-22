// ***********************************************************************
// Assembly         : DL
// Author           : Administrator
// Created          : 09-13-2013
//
// Last Modified By : Administrator
// Last Modified On : 04-29-2015
// ***********************************************************************
// <copyright file="Algorithm.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************


/// <summary>
/// The DL namespace.
/// </summary>
namespace DL
{
    using System;
    using System.Text;
    using System.Security.Cryptography;

    /// <summary>
    /// Class Algorithm.
    /// </summary>
    [CLSCompliantAttribute(false)]
    public class Algorithm
    {
        /// <summary>
        /// Decryption algorithm
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <returns>System.String.</returns>
        /// key on which we decrypt the encrypt string.We can use the same key for decrypt and encrypt the string
        /// Encrypted string which we have to  decrypt.


        public string Decryption(string key, string value)
        {
            using (TripleDESCryptoServiceProvider objDESCrypto = new TripleDESCryptoServiceProvider())
            {
                using (MD5CryptoServiceProvider objHashMD5 = new MD5CryptoServiceProvider())
                {
                    byte[] byteHash, byteBuff;
                    // string strTempKey = "strKey";
                    byteHash = objHashMD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(key));
                    //objHashMD5 = null;
                    // set the secret key for the tripleDES algorithm
                    objDESCrypto.Key = byteHash;
                    //mode of operation. there are other 4 modes.
                    //We choose ECB(Electronic code Book)
                    objDESCrypto.Mode = CipherMode.ECB; //CBC, CFB
                    byteBuff = Convert.FromBase64String(value);
                    string strDecrypted = ASCIIEncoding.ASCII.GetString(objDESCrypto.CreateDecryptor().
                                                                        TransformFinalBlock(byteBuff, 0,
                                                                        byteBuff.Length));
                    //objDESCrypto.Dispose();
                    return (strDecrypted);
                }
            }
        }


        /// <summary>
        /// Encrypt Algorithm
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <returns>System.String.</returns>
        /// key on which we encrypt string.
        /// String which we have to decrypt.


        public string Encryption(string key, string value)
        {
            using (TripleDESCryptoServiceProvider objDESCrypto = new TripleDESCryptoServiceProvider())
            {
                using (MD5CryptoServiceProvider objHashMD5 = new MD5CryptoServiceProvider())
                {
                    byte[] byteHash, byteBuff;
                    byteHash = objHashMD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(key));
                    //objHashMD5.Dispose();
                    objDESCrypto.Key = byteHash;
                    objDESCrypto.Mode = CipherMode.ECB; //CBC, CFB
                    byteBuff = ASCIIEncoding.ASCII.GetBytes(value);
                    string result = Convert.ToBase64String(objDESCrypto.CreateEncryptor().TransformFinalBlock(byteBuff, 0, byteBuff.Length));

                    //objDESCrypto.Dispose();
                    return result;
                }
            }

        }

    }

}
