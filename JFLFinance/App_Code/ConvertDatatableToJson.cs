// ***********************************************************************
// <copyright file="ConvertDatatableToJson.cs" company="Corefield Technologies Pvt. Ltd.">
//     Copyright (c) 2015 Corefield Technologies Pvt. Ltd. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Data;
using System.Text;

/// <summary>
/// Summary description for convert data table To Json
/// </summary>
public class ConvertDatatableToJson
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ConvertDatatableToJson"/> class.
    /// </summary>
	public ConvertDatatableToJson()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    /// <summary>
    /// Data table to json.
    /// </summary>
    /// <param name="dt">The dt.</param>
    /// <returns>System.String.</returns>
    public string DataTableToJson(DataTable dt)
    {
        DataSet ds = new DataSet();
        ds.Merge(dt);
        StringBuilder jsonStr = new StringBuilder();
        if (ds.Tables[0].Rows.Count > 0)
        {
            jsonStr.Append("[");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                jsonStr.Append("{");
                for (int j = 0; j < ds.Tables[0].Columns.Count; j++)
                {
                    if (j < ds.Tables[0].Columns.Count - 1)
                    {
                        jsonStr.Append("\"" + ds.Tables[0].Columns[j].ColumnName + "\":" + "\"" + ds.Tables[0].Rows[i][j] + "\",");
                    }
                    else if (j == ds.Tables[0].Columns.Count - 1)
                    {
                        jsonStr.Append("\"" + ds.Tables[0].Columns[j].ColumnName + "\":" + "\"" + ds.Tables[0].Rows[i][j] + "\"");
                    }
                }
                jsonStr.Append(i == ds.Tables[0].Rows.Count - 1 ? "}" : "},");
            }
            jsonStr.Append("]");
            return jsonStr.ToString();
        }
        else
        {
            return null;
        }
    }
}