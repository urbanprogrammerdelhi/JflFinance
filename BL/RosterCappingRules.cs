// ***********************************************************************
// Assembly         : BL
// Author           : Administrator
// Created          : 09-13-2013
//
// Last Modified By : Administrator
// Last Modified On : 04-29-2015
// ***********************************************************************
// <copyright file="RosterCappingRules.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Linq;
using System.Data;


/// <summary>
/// The BL namespace.
/// </summary>
namespace BL
{
    /// <summary>
    /// Class RosterCappingRules.
    /// </summary>
    [CLSCompliantAttribute(false)]
    public static class RosterCappingRules
    {
        /// <summary>
        /// Find Duplicate
        /// </summary>
        /// <param name="myDataTable1">My data table1.</param>
        /// <param name="myDataTable2">My data table2.</param>
        /// <returns>DataSet.</returns>
        public static DataSet FindDuplicateSchedule(DataTable myDataTable1, DataTable myDataTable2)
        {
            DataTable dtResult = MyDataTable();

            var NewRoster = myDataTable1.AsEnumerable();
            var ExistingRoster = myDataTable2.AsEnumerable();

            var query =
            from R in NewRoster
            join R1 in ExistingRoster
            on R.Field<string>("EmployeeNumber")
            equals R1.Field<string>("EmployeeNumber")
            where ((R.Field<System.DateTime>("TimeFrom") > R1.Field<System.DateTime>("TimeFrom")
                    && R.Field<System.DateTime>("TimeFrom") < R1.Field<System.DateTime>("TimeTo")
                    )
                    ||
                    (R.Field<System.DateTime>("TimeFrom") == R1.Field<System.DateTime>("TimeFrom")
                    && R.Field<System.DateTime>("TimeTo") == R1.Field<System.DateTime>("TimeTo")
                    )
                    ||
                    (R.Field<System.DateTime>("TimeFrom") < R1.Field<System.DateTime>("TimeFrom")
                    && R.Field<System.DateTime>("TimeTo") > R1.Field<System.DateTime>("TimeTo")
                    )
                    ||
                    (R.Field<System.DateTime>("TimeFrom") == R1.Field<System.DateTime>("TimeFrom")
                    && R.Field<System.DateTime>("TimeTo") > R1.Field<System.DateTime>("TimeTo")
                    )
                    ||
                    (R.Field<System.DateTime>("TimeFrom") < R1.Field<System.DateTime>("TimeFrom")
                    && R.Field<System.DateTime>("TimeTo") > R1.Field<System.DateTime>("TimeTo")
                    )
            )
            && R.Field<string>("ShiftCode") != "0"
            && R1.Field<string>("ShiftCode") != "0"
            && R1.Field<Int16>("SchRosterAutoId") != R1.Field<Int16>("SchRosterAutoId")
            select new
                        {
                            LocationCode = R1.Field<string>("LocationCode"),
                            EmployeeNumber = R1.Field<string>("EmployeeNumber"),
                            AsmtCode = R1.Field<string>("AsmtCode"),
                            DutyDate = R1.Field<System.DateTime>("DutyDate"),
                            TimeFrom = R1.Field<System.DateTime>("TimeFrom"),
                            TimeTo = R1.Field<System.DateTime>("TimeTo"),
                            SchRosterAutoId = R1.Field<Int16>("SchRosterAutoId"),
                            PdLineNo = R1.Field<int>("PdLineNo")
                        };

            if (query.Any())
            {
                foreach (var result in query)
                {
                    dtResult.Rows.Add(new object[] { 5,"Duplicate_san", result.EmployeeNumber, "", result.DutyDate.ToString(),result.TimeFrom.ToString(),result.TimeTo.ToString(),result.AsmtCode,
                            "","","","","","","",result.PdLineNo,result.SchRosterAutoId,result.DutyDate.ToString(),1,1,""
                            });

                }

            }


            DataSet ds = new DataSet();
            ds.Tables.Add(dtResult);
            return ds;

        }

        /// <summary>
        /// Finds the invalid records.
        /// </summary>
        /// <param name="myDataTable1">My data table1.</param>
        /// <param name="myDataTable2">My data table2.</param>
        /// <returns>DataSet.</returns>
        public static DataSet FindInvalidRecords(DataTable myDataTable1, DataTable myDataTable2)
        {
            DataTable dtResult = MyDataTable1();

            var NewRoster = myDataTable1.AsEnumerable();
            var ExistingRoster = myDataTable2.AsEnumerable();

            //// Gap between two shifts
            var query =
            from R in NewRoster
            join R1 in ExistingRoster
            on R.Field<string>("EmployeeNumber")
            equals R1.Field<string>("EmployeeNumber")
            where (R.Field<System.DateTime>("TimeFrom") > R1.Field<System.DateTime>("TimeTo")
            && (R1.Field<System.DateTime>("TimeTo") - R.Field<System.DateTime>("TimeFrom")).Hours < 480)
            ||
            (R.Field<System.DateTime>("TimeTo") < R1.Field<System.DateTime>("TimeFrom")
            && (R1.Field<System.DateTime>("TimeFrom") - R.Field<System.DateTime>("TimeTo")).Hours < 480)
            && R.Field<string>("ShiftCode") != "0"
            && R1.Field<string>("ShiftCode") != "0"
            select new
            {
                LocationCode = R1.Field<string>("LocationCode"),
                EmployeeNumber = R1.Field<string>("EmployeeNumber"),
                AsmtCode = R1.Field<string>("AsmtCode"),
                DutyDate = R1.Field<System.DateTime>("DutyDate"),
                TimeFrom = R1.Field<System.DateTime>("TimeFrom"),
                TimeTo = R1.Field<System.DateTime>("TimeTo"),
                SchRosterAutoId = R1.Field<Int16>("SchRosterAutoId"),
                PdLineNo = R1.Field<int>("PdLineNo")
            };

            if (query.Any())
            {
                foreach (var result in query)
                {
                    dtResult.Rows.Add(new object[] { 5,"GapBetweenShiftIsNotGreaterThanNHours", result.EmployeeNumber, "", result.DutyDate.ToString(),result.TimeFrom.ToString(),result.TimeTo.ToString(),result.AsmtCode,
                            result.SchRosterAutoId
                            });
                }
            }

            //// Gap between two shifts if weekly off exists

            DataTable dtWo = new DataTable();
            dtWo.Columns.Add(new DataColumn("EmployeeNumber", typeof(string)));
            dtWo.Columns.Add(new DataColumn("DutyDate", typeof(System.DateTime)));
            dtWo.Columns.Add(new DataColumn("TimeFrom", typeof(System.DateTime)));
            dtWo.Columns.Add(new DataColumn("TimeTo", typeof(System.DateTime)));

            var query2 =
            from R in ExistingRoster
            where R.Field<string>("ShiftCode") == "0"
            select new
            {
                EmployeeNumber = R.Field<string>("EmployeeNumber"),
                DutyDate = R.Field<System.DateTime>("DutyDate"),
                TimeFrom = R.Field<System.DateTime>("TimeFrom"),
                TimeTo = R.Field<System.DateTime>("TimeTo")
            };

            if (query2.Any())
            {
                foreach (var result in query2)
                {
                    dtWo.Rows.Add(new object[] { result.EmployeeNumber,  result.DutyDate,result.TimeFrom,result.TimeTo
                            });

                }
            }

            var WO = dtWo.AsEnumerable();

            var query1 =
            from R in NewRoster
            join R1 in ExistingRoster
            on R.Field<string>("EmployeeNumber")
            equals R1.Field<string>("EmployeeNumber")
            join W in WO
            on R1.Field<string>("EmployeeNumber")
            equals W.Field<string>("EmployeeNumber")
            where R.Field<System.DateTime>("TimeFrom") > R1.Field<System.DateTime>("TimeTo")
            && R.Field<System.DateTime>("TimeFrom") > W.Field<System.DateTime>("TimeTo")
            && W.Field<System.DateTime>("TimeTo") > R1.Field<System.DateTime>("TimeTo")
            && (R1.Field<System.DateTime>("TimeTo") - R.Field<System.DateTime>("TimeFrom")).Hours < 2160
            select new
            {
                LocationCode = R1.Field<string>("LocationCode"),
                EmployeeNumber = R1.Field<string>("EmployeeNumber"),
                AsmtCode = R1.Field<string>("AsmtCode"),
                DutyDate = R1.Field<System.DateTime>("DutyDate"),
                TimeFrom = R1.Field<System.DateTime>("TimeFrom"),
                TimeTo = R1.Field<System.DateTime>("TimeTo"),
                SchRosterAutoId = R1.Field<Int16>("SchRosterAutoId"),
                PdLineNo = R1.Field<int>("PdLineNo")
            };

            if (query1.Any())
            {
                foreach (var result in query1)
                {
                    dtResult.Rows.Add(new object[] { 5,"GapBetweenShiftIsNotGreaterThanNHours", result.EmployeeNumber, "", result.DutyDate.ToString(),result.TimeFrom.ToString(),result.TimeTo.ToString(),result.AsmtCode,
                            result.SchRosterAutoId
                            });

                }

            }

            
            DataSet ds = new DataSet();
            ds.Tables.Add(dtResult);
            return ds;

        }



        /// <summary>
        /// return table structure for exceptional message
        /// </summary>
        /// <returns>DataTable.</returns>
        private static DataTable MyDataTable1() //// for exceptional msg
        {

            DataTable dtResult = new DataTable();
            dtResult.Columns.Add(new DataColumn("MessageID", typeof(int)));
            dtResult.Columns.Add(new DataColumn("MessageString", typeof(string)));
            dtResult.Columns.Add(new DataColumn("EmployeeNumber", typeof(string)));
            dtResult.Columns.Add(new DataColumn("Shiftcode", typeof(string)));
            dtResult.Columns.Add(new DataColumn("DutyDate", typeof(string)));
            dtResult.Columns.Add(new DataColumn("TimeFrom", typeof(string)));
            dtResult.Columns.Add(new DataColumn("TimeTo", typeof(string)));
            dtResult.Columns.Add(new DataColumn("AsmtCode", typeof(string)));
            dtResult.Columns.Add(new DataColumn("SchRosterAutoID", typeof(Int16)));

            return dtResult;

        }

        /// <summary>
        /// retuern table structure for duplicate message
        /// </summary>
        /// <returns>DataTable.</returns>
        private static DataTable MyDataTable()
        {

            DataTable dtResult = new DataTable();
            dtResult.Columns.Add(new DataColumn("MessageID", typeof(int)));
            dtResult.Columns.Add(new DataColumn("MessageString", typeof(string)));
            dtResult.Columns.Add(new DataColumn("EmployeeNumber", typeof(string)));
            dtResult.Columns.Add(new DataColumn("Shiftcode", typeof(string)));
            dtResult.Columns.Add(new DataColumn("DutyDate", typeof(string)));
            dtResult.Columns.Add(new DataColumn("TimeFrom", typeof(string)));
            dtResult.Columns.Add(new DataColumn("TimeTo", typeof(string)));
            dtResult.Columns.Add(new DataColumn("AsmtCode", typeof(string)));
            dtResult.Columns.Add(new DataColumn("RoleCode", typeof(string)));
            dtResult.Columns.Add(new DataColumn("DutyTypeCode", typeof(string)));
            dtResult.Columns.Add(new DataColumn("TimeFromToOverwrite", typeof(string)));
            dtResult.Columns.Add(new DataColumn("ToTimeToOverwrite", typeof(string)));
            dtResult.Columns.Add(new DataColumn("AsmtCodeToOverwrite", typeof(string)));
            dtResult.Columns.Add(new DataColumn("RoleCodeToOverWrite", typeof(string)));
            dtResult.Columns.Add(new DataColumn("DutyTypeCodeToOverWrite", typeof(string)));
            dtResult.Columns.Add(new DataColumn("PDlineNoToOverwrite", typeof(int)));
            dtResult.Columns.Add(new DataColumn("SchRosterAutoID", typeof(Int16)));
            dtResult.Columns.Add(new DataColumn("DutyDateToOverWrite", typeof(string)));
            dtResult.Columns.Add(new DataColumn("PatternPosition", typeof(int)));
            dtResult.Columns.Add(new DataColumn("RowNumber", typeof(int)));
            dtResult.Columns.Add(new DataColumn("PostDesc", typeof(string)));

            return dtResult;

        }


    }
}
