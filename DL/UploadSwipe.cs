// ***********************************************************************
// Assembly         : DL
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
using System.Data.SqlClient;
using System.Globalization;

/// <summary>
/// The DL namespace.
/// </summary>
namespace DL
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
            using (DataSet dsFileExist = new DataSet())
            {
                dsFileExist.Locale = CultureInfo.InvariantCulture;
                SqlParameter[] objParmFileExist = new SqlParameter[2];

                objParmFileExist[0] = new SqlParameter(DL.Properties.Resources.FileName, fileName);
                objParmFileExist[1] = new SqlParameter(DL.Properties.Resources.FilePath, filePath);

                DataTable dtFileExist = SqlHelper.ExecuteDatatable("udp_FileName_Get", objParmFileExist);

                dsFileExist.Tables.Add(dtFileExist);
                return dsFileExist;
            }
        }

        /// <summary>
        /// Replaces the name of the server file.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="filePath">The file path.</param>
        /// <returns>DataSet.</returns>
        public DataSet ReplaceServerFileName(string fileName, string filePath)
        {
            using (DataSet dsFileExist = new DataSet())
            {
                dsFileExist.Locale = CultureInfo.InvariantCulture;
                SqlParameter[] objParmFileExist = new SqlParameter[2];


                objParmFileExist[0] = new SqlParameter(DL.Properties.Resources.FileName, fileName);
                objParmFileExist[1] = new SqlParameter(DL.Properties.Resources.FilePath, filePath);
                DataTable dtFileExist = SqlHelper.ExecuteDatatable("udp_ReplaceFile", objParmFileExist);

                dsFileExist.Tables.Add(dtFileExist);
                return dsFileExist;
            }
        }

        /// <summary>
        /// Fills the name of the grid data file.
        /// </summary>
        /// <returns>DataSet.</returns>
        public DataSet FillGridDataFileName()
        {
            using (DataSet dsFillgrid = new DataSet())
            {
                dsFillgrid.Locale = CultureInfo.InvariantCulture;

                DataTable dtFillGrid = SqlHelper.ExecuteDatatable("udp_FilesToUpload");
                dsFillgrid.Tables.Add(dtFillGrid);
                return dsFillgrid;
            }
        }

        /// <summary>
        /// Uploads the name of the grid data file.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="onlyFileName">Name of the only file.</param>
        /// <returns>DataSet.</returns>
        public DataSet UploadGridDataFileName(string fileName, string onlyFileName)
        {
            using (DataSet dsFillgrid = new DataSet())
            {
                dsFillgrid.Locale = CultureInfo.InvariantCulture;
                SqlParameter[] objParmFileExist = new SqlParameter[2];

                objParmFileExist[0] = new SqlParameter(DL.Properties.Resources.FileName, fileName);
                objParmFileExist[1] = new SqlParameter(DL.Properties.Resources.onlyFilename, onlyFileName);
                DataTable dtFillGrid = SqlHelper.ExecuteDatatable("udp_DataToUpload", objParmFileExist);
                dtFillGrid = SqlHelper.ExecuteDatatable("udp_FilesToUpload");
                dsFillgrid.Tables.Add(dtFillGrid);
                return dsFillgrid;
            }

        }

        /// <summary>
        /// Pops the data upload.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="filePath">The file path.</param>
        /// <returns>DataSet.</returns>
        public DataSet PopDataUpload(string fileName, string filePath)
        {
            SqlParameter[] objParm = new SqlParameter[2];
            objParm[0] = new SqlParameter(DL.Properties.Resources.FileName, fileName);
            objParm[1] = new SqlParameter(DL.Properties.Resources.FilePath, filePath);
            using (DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_POP_DataUpload", objParm))
            {
                return ds;
            }
        }
        /// <summary>
        /// Pops the data delete.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>DataSet.</returns>
        public DataSet PopDataDelete(string fileName)
        {
            using (DataSet dsDltFile = new DataSet())
            {
                dsDltFile.Locale = CultureInfo.InvariantCulture;
                SqlParameter[] objParmFileExist = new SqlParameter[1];

                objParmFileExist[0] = new SqlParameter(DL.Properties.Resources.FileName, fileName);

                DataTable dtDltFile = SqlHelper.ExecuteDatatable("udp_DataToDelete", objParmFileExist);
                dtDltFile = SqlHelper.ExecuteDatatable("udp_FilesToUpload");

                dsDltFile.Tables.Add(dtDltFile);
                return dsDltFile;
            }
        }


        /// <summary>
        /// Pops the client data get.
        /// </summary>
        /// <param name="popWefDate">The pop wef date.</param>
        /// <returns>DataSet.</returns>
        public DataSet PopClientDataGet(string popWefDate)
        {
            SqlParameter[] objParm = new SqlParameter[1];
            objParm[0] = new SqlParameter(DL.Properties.Resources.POPWefDate, DL.Common.DateFormat(popWefDate));
            using (DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_POP_GetClientData", objParm))
            {
                return ds;
            }
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
            SqlParameter[] objParm = new SqlParameter[3];
            objParm[0] = new SqlParameter(DL.Properties.Resources.POPWefDate, DL.Common.DateFormat(popWefDate));
            objParm[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[2] = new SqlParameter(DL.Properties.Resources.AsmtCode, asmtCode);
            using (DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_POP_GetEmployeeDetail", objParm))
            {
                return ds;
            }
        }


        // to sync Secure trax 16-10-2012

        /// <summary>
        /// Dls the pop get client data.
        /// </summary>
        /// <param name="popWefDate">The pop wef date.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="popWetDate">The pop wet date.</param>
        /// <param name="locationAutoID">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet DlPOPGetClientData(string popWefDate, string clientCode, string popWetDate, string locationAutoID)
        {
            DataSet ds = new DataSet();

            SqlParameter[] objParm = new SqlParameter[4];
            objParm[0] = new SqlParameter("@POPWefDate", DL.Common.DateFormat(popWefDate));
            objParm[1] = new SqlParameter("@ClientCode", clientCode);
            objParm[2] = new SqlParameter("@POPWetDate", DL.Common.DateFormat(popWetDate));
            objParm[3] = new SqlParameter("@LocationAutoID", locationAutoID);
            ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_POP_GetClientData", objParm);

            return ds;
        }

        /// <summary>
        /// Dls the pop get employee detail.
        /// </summary>
        /// <param name="popWefDate">The pop wef date.</param>
        /// <param name="locationAutoID">The location automatic identifier.</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="popWet">The pop wet.</param>
        /// <param name="postAutoID">The post automatic identifier.</param>
        /// <param name="locationTagID">The location tag identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet DlPOPGetEmployeeDetail(string popWefDate, string locationAutoID, string asmtCode, string popWet,string postAutoID, string locationTagID)
        {
            DataSet ds = new DataSet();
            SqlParameter[] objParm = new SqlParameter[6];
            objParm[0] = new SqlParameter("@POPWefDate", DL.Common.DateFormat(popWefDate));
            objParm[1] = new SqlParameter("@LocationAutoID", locationAutoID);
            objParm[2] = new SqlParameter("@AsmtCode", asmtCode);
            objParm[3] = new SqlParameter("@POPWETDate", popWet);
            objParm[4] = new SqlParameter("@PostAutoID", postAutoID);
            objParm[5] = new SqlParameter("@LocationTagID", locationTagID);

            ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_POP_GetEmployeeDetail", objParm);
            return ds;
        }
    }
}
