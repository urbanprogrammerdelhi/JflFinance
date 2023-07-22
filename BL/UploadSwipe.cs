// ***********************************************************************
// Assembly         : BL
// Author           : Administrator
// Created          : 09-13-2013
//
// Last Modified By : Administrator
// Last Modified On : 04-29-2015
// ***********************************************************************
// <copyright file="UploadSwipe.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;


/// <summary>
/// The BL namespace.
/// </summary>
namespace BL
{
    /// <summary>
    /// Class UploadSwipe.
    /// </summary>
    [CLSCompliantAttribute(false)]
    public class UploadSwipe
    {
        /// <summary>
        /// Saves the name of the server file.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="filePath">The file path.</param>
        /// <returns>DataSet.</returns>
        public DataSet SaveServerFileName(string fileName, string filePath)
        {

            DL.UploadSwipe upSwipefile = new DL.UploadSwipe();

            DataSet dsFileExist = upSwipefile.SaveServerFileName(fileName, filePath);

            return dsFileExist;
        }

        /// <summary>
        /// Replaces the name of the server file.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="filePath">The file path.</param>
        /// <returns>DataSet.</returns>
        public DataSet ReplaceServerFileName(string fileName, string filePath)
        {
            DL.UploadSwipe upSwipefile = new DL.UploadSwipe();

            DataSet dsFileExist = upSwipefile.ReplaceServerFileName(fileName, filePath);

            return dsFileExist;
        }

        /// <summary>
        /// Fills the name of the grid data file.
        /// </summary>
        /// <returns>DataSet.</returns>
        public DataSet FillGridDataFileName()
        {
            DL.UploadSwipe dlFillgrid = new DL.UploadSwipe();

            DataSet dsFillGrid = dlFillgrid.FillGridDataFileName();
            return dsFillGrid;
        }

        /// <summary>
        /// Uploads the name of the grid data file.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="onlyFileName">Name of the only file.</param>
        /// <returns>DataSet.</returns>
        public DataSet UploadGridDataFileName(string fileName, string onlyFileName)
        {
            DL.UploadSwipe dlUploadgrid = new DL.UploadSwipe();

            DataSet dsUploadGrid = dlUploadgrid.UploadGridDataFileName(fileName, onlyFileName);
            return dsUploadGrid;
        }
        /// <summary>
        /// Pops the data upload.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="filePath">The file path.</param>
        /// <returns>DataSet.</returns>
        public DataSet PopDataUpload(string fileName, string filePath)
        {
            DL.UploadSwipe dlUploadgrid = new DL.UploadSwipe();
            DataSet dsUploadGrid = dlUploadgrid.PopDataUpload(fileName, filePath);
            return dsUploadGrid;
        }

        /// <summary>
        /// Pops the data delete.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>DataSet.</returns>
        public DataSet PopDataDelete(String fileName)
        {
            DL.UploadSwipe dlDltFile = new DL.UploadSwipe();

            DataSet dsDltFile = dlDltFile.PopDataDelete(fileName);
            return dsDltFile;
        }


        /// <summary>
        /// Pops the client data get.
        /// </summary>
        /// <param name="popWefDate">The pop wef date.</param>
        /// <returns>DataSet.</returns>
        public DataSet PopClientDataGet(string popWefDate)
        {
            DL.UploadSwipe objUploadSwipe = new DL.UploadSwipe();

            DataSet ds = objUploadSwipe.PopClientDataGet(popWefDate);
            return ds;
        }
        /// <summary>
        /// Pops the employee detail get.
        /// </summary>
        /// <param name="popWefDate">The pop wef date.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <returns>DataSet.</returns>
        public DataSet PopEmployeeDetailGet(string popWefDate, string locationAutoId, string asmtCode)
        {
            DL.UploadSwipe objUploadSwipe = new DL.UploadSwipe();
            DataSet ds = objUploadSwipe.PopEmployeeDetailGet(popWefDate, locationAutoId, asmtCode);
            return ds;
        }

        // to sync Secure trax 16-10-2012
        /// <summary>
        /// Bls the pop get client data.
        /// </summary>
        /// <param name="pOPWefDate">The p op wef date.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="pOPWetDate">The p op wet date.</param>
        /// <param name="locationAutoID">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet BlPOPGetClientData(string pOPWefDate, string clientCode, string pOPWetDate, string locationAutoID)
        {
            DL.UploadSwipe objUploadSwipe = new DL.UploadSwipe();
            DataSet ds = new DataSet();

            ds = objUploadSwipe.DlPOPGetClientData(pOPWefDate, clientCode, pOPWetDate, locationAutoID);
            return ds;
        }


        /// <summary>
        /// Bls the pop get employee detail.
        /// </summary>
        /// <param name="pOPWefDate">The p op wef date.</param>
        /// <param name="locationAutoID">The location automatic identifier.</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="popWet">The pop wet.</param>
        /// <param name="postAutoID">The post automatic identifier.</param>
        /// <param name="locationTagID">The location tag identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet BlPOPGetEmployeeDetail(string pOPWefDate, string locationAutoID, string asmtCode, string popWet,string postAutoID,string locationTagID)
        {
            DL.UploadSwipe objUploadSwipe = new DL.UploadSwipe();
            DataSet ds = new DataSet();
            ds = objUploadSwipe.DlPOPGetEmployeeDetail(pOPWefDate, locationAutoID, asmtCode, popWet,postAutoID, locationTagID);
            return ds;
        }

    }
}
