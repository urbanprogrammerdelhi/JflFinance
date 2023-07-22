// ***********************************************************************
// Assembly         : DL
// Author           : Administrator
// Created          : 09-13-2013
//
// Last Modified By : Administrator
// Last Modified On : 04-29-2015
// ***********************************************************************
// <copyright file="ConnectionString.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Web.Configuration;
using System.Xml;
using System.IO;
using System.Data;
using System.Globalization;

/// <summary>
/// The DL namespace.
/// </summary>
namespace DL
{
    /// <summary>
    /// Class ConnectionString.
    /// </summary>
    [CLSCompliantAttribute(false)]
    public class ConnectionString
    {

        //private string _connectionString;
        //public string connectionString
        //{
        //    get
        //    {
        //        _connectionString = GetConnectionString();
        //        return _connectionString;
        //    }

        //}

        /// <summary>
        /// Gets the connection string.
        /// </summary>
        /// <returns>System.String.</returns>
        public string GetConnectionString()
        {
            string myConnection = string.Empty;

            var uInfo = new CommonLibrary.Session.UserInformation();
            if(!string.IsNullOrEmpty(uInfo.CountryCode))
            {
                myConnection = ConnectionStringGet(uInfo.CountryCode);

                Guard.ArgumentNotNull(myConnection, "myConnection");
                return myConnection;
            }
            else
            {
                Guard.ArgumentNotNullOrEmptyString(myConnection,"myConnectionString");
                return "";
            }
        }

        /// <summary>
        /// 14/oct/2011
        /// This function Returns the dataview .
        /// Filtering the data on the basis of Country selected.
        /// </summary>
        /// <param name="connectionKey">The connection key.</param>
        /// <returns>DataView.</returns>
        public DataView ConnectionDataViewGet(string connectionKey)
        {
            DataSet ds = CountryConnectionsGet();
            DataView dv = new DataView();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                dv = new DataView(ds.Tables[0]);
                dv.RowFilter = "Key = '" + connectionKey + @"'";
            }
            return dv;
        }
        /// <summary>
        /// Read the value from Dataview  and create a connection string .
        /// </summary>
        /// <param name="connectionKey">The connection key.</param>
        /// <returns>System.String.</returns>
        public string ConnectionStringGet(string connectionKey)
        {
            string strConnectionString = string.Empty;
            DataView dv = ConnectionDataViewGet(connectionKey);
            strConnectionString = dv.Table.Columns[2].ColumnName.ToString() + @"=" + dv[0][2].ToString() + @";";
            strConnectionString = strConnectionString + dv.Table.Columns[3].ColumnName.ToString() + @"=" + dv[0][3].ToString() + @";";
            strConnectionString = strConnectionString + dv.Table.Columns[4].ColumnName.ToString() + @"=" + dv[0][4].ToString() + @";";
            strConnectionString = strConnectionString + dv.Table.Columns[5].ColumnName.ToString() + @"=" + dv[0][5].ToString() + @";";
            strConnectionString = strConnectionString + @"Max Pool size=600; pooling=true; Connection Lifetime=60";
            return strConnectionString;
        }

        /// <summary>
        /// Read the value from Dataview  returns in DataTable format and create a connection string .
        /// </summary>
        /// <param name="connectionKey">The connection key.</param>
        /// <param name="val">The value.</param>
        /// <returns>DataTable.</returns>
        public DataTable ConnectionStringGet(string connectionKey,string val)
        {
            //string strConnectionString = string.Empty;
            DataView dv = ConnectionDataViewGet(connectionKey);
            //strConnectionString = dv.Table.Columns[2].ColumnName.ToString() + @"=" + dv[0][2].ToString() + @";";
            //strConnectionString = strConnectionString + dv.Table.Columns[3].ColumnName.ToString() + @"=" + dv[0][3].ToString() + @";";
            //strConnectionString = strConnectionString + dv.Table.Columns[4].ColumnName.ToString() + @"=" + dv[0][4].ToString() + @";";
            //strConnectionString = strConnectionString + dv.Table.Columns[5].ColumnName.ToString() + @"=" + dv[0][5].ToString() + @";";
            //strConnectionString = strConnectionString + @"Max Pool size=600; pooling=true; Connection Lifetime=60";
            DataTable dt = new DataTable();
            dt = dv.ToTable();
            return dt;
        }

        /// <summary>
        /// 14/0ct/2011
        /// Function Return the EncryptKey value.The key value we are using to decrypt the string.
        /// Each data base having same or diffrent key.
        /// </summary>
        /// <param name="connectionKey">The connection key.</param>
        /// <returns>System.String.</returns>
        public string DecryptKeyGet(string connectionKey)
        {
            string strDecryptionKey = string.Empty;
            DataView dv = ConnectionDataViewGet(connectionKey);
            strDecryptionKey = dv[0][6].ToString();
            return strDecryptionKey;
        }
        /// <summary>
        /// 14/oct/2011
        /// function Identify the path of file on the basis of extension.Extension is stored in web config.
        /// Read the Encrypted file from the path and decrypt it and return a data set.
        /// We consider the file name as key(with out Extension) for decrypt the file.
        /// Example. We  created Encrypted File with extension .abcd,First program find the extension file of extention .abcd in
        /// ~/App_Data folder.
        /// Note: If in case encrypted file is not avilable in this folder then we should not able to login in  application
        /// </summary>
        /// <returns>DataSet.</returns>
        public DataSet CountryConnectionsGet()
        {
            string[] filePaths = Directory.GetFiles(System.Web.HttpContext.Current.Server.MapPath(@"~/App_Data"), WebConfigurationManager.AppSettings["ext"]); //ConfigurationSettings.AppSettings["ext"]);
            string[] spliteFile;
            string localVar = string.Empty, fileName = string.Empty, strDecriptkey = string.Empty;
            string[] keySplit;
            foreach (string vlaue in filePaths)
            {
                localVar = vlaue;
                spliteFile = localVar.Split('\\');
                fileName = spliteFile[spliteFile.Length - 1].ToString();
                keySplit = fileName.Split('.');
                strDecriptkey = keySplit[keySplit.Length - keySplit.Length];
            }

            XmlDocument myXmlDocument = new XmlDocument();

            DataSet dsCredentials = new DataSet();
            dsCredentials.Locale = CultureInfo.InvariantCulture;

            string strEncriptedXMLFile = string.Empty;
            string strDecriptedXMLFile = string.Empty;
            if (localVar != "")
            {
                StreamReader strReader = new StreamReader(localVar);
                strEncriptedXMLFile = strReader.ReadToEnd();
                Algorithm objAlgo = new Algorithm();
                strDecriptedXMLFile = objAlgo.Decryption(strDecriptkey, strEncriptedXMLFile);
                myXmlDocument.LoadXml(strDecriptedXMLFile);
                dsCredentials.ReadXml(new XmlNodeReader(myXmlDocument));
            }
            return dsCredentials;
        }
        /// <summary>
        /// 14/oct/2011
        /// The function return a data base name of selected country.
        /// We are using this funtion on default.aspx page to store data base in Session
        /// </summary>
        /// <param name="countryKey">The country key.</param>
        /// <returns>System.String.</returns>
        public string DatabaseNameGet(string countryKey)
        {
            string strDataBase = string.Empty;
            DataView dv = ConnectionDataViewGet(countryKey);
            strDataBase = dv[0][3].ToString();
            return strDataBase;
        }

        /// <summary>
        /// the function return a server name of selected country.
        /// </summary>
        /// <param name="countryKey">The country key.</param>
        /// <returns>System.String.</returns>
        public string ServerNameGet(string countryKey)
        {
            string strDataBase = string.Empty;
            DataView dv = ConnectionDataViewGet(countryKey);
            strDataBase = dv[0][2].ToString();
            return strDataBase;
        }



        /// <summary>
        /// The function return a UserID of selected country.
        /// </summary>
        /// <param name="countryKey">The country key.</param>
        /// <returns>System.String.</returns>
        public string UserIdGet(string countryKey)
        {
            string strDataBase = string.Empty;
            DataView dv = ConnectionDataViewGet(countryKey);
            strDataBase = dv[0][4].ToString();
            return strDataBase;
        }

        /// <summary>
        /// The function return a UserID of selected country.
        /// </summary>
        /// <param name="countryKey">The country key.</param>
        /// <returns>System.String.</returns>
        public string PasswordGet(string countryKey)
        {
            string strDataBase = string.Empty;
            DataView dv = ConnectionDataViewGet(countryKey);
            strDataBase = dv[0][5].ToString();
            return strDataBase;
        }

    }
}
