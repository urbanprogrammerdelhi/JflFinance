using System;
using System.Data;
using System.Data.SqlClient;
using Saturn.Common.POP;
using System.Configuration;
using G4S.SaturnPOP.EncryptDecrypt;
using Saturn.Common.POP;


namespace DL
{
    public class POPRepository
    {
        private string _ConnectionString = string.Empty;
        
        public POPRepository(string clientCode)
        {
            _ConnectionString = ConfigurationManager.ConnectionStrings["CY_CONSTRING"].ConnectionString;
            var enService = new G4SEncryptDecrypt(ConfigurationManager.AppSettings["Saltkey"]);
            _ConnectionString = enService.Decrypt(_ConnectionString);
        }
        
        public bool Panic(string IMEI, string swipeDate, string IPaddress)//string EmpTag,
        {
            var result = 0;
            using (var con = new SqlConnection(_ConnectionString))
            {

                var command = new SqlCommand("udp_mstOpsPanicNFC", con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue(DL.Properties.Resources.NFCAsmtTagId, IMEI).Direction=ParameterDirection.Input  ;
                command.Parameters.AddWithValue(DL.Properties.Resources.DutyDate, swipeDate).Direction = ParameterDirection.Input;
                command.Parameters.AddWithValue(DL.Properties.Resources.IPaddress, IPaddress).Direction = ParameterDirection.Input;
                con.Open();
                result = command.ExecuteNonQuery();
            }
            return result > 0;
        }
        public bool Incident(string IncidentType, string IMEI, string EmpTag, string Attachment, string swipeDate, string LocTag, string SmsMessage, string IPaddress)
        {
            var result = 0;
            using (var con = new SqlConnection(_ConnectionString))
            {
                var command = new SqlCommand("udp_mstOpsIncidentNFC", con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue(DL.Properties.Resources.IncidentType, IncidentType);
                command.Parameters.AddWithValue(DL.Properties.Resources.NFCAsmtTagId, IMEI);
                command.Parameters.AddWithValue(DL.Properties.Resources.EmpTag, EmpTag);
                command.Parameters.AddWithValue(DL.Properties.Resources.LocationTagID, LocTag);
                command.Parameters.AddWithValue(DL.Properties.Resources.Attachment, Attachment);
                command.Parameters.AddWithValue(DL.Properties.Resources.DutyDate, swipeDate);
                command.Parameters.AddWithValue(DL.Properties.Resources.IPaddress, IPaddress);
                command.Parameters.AddWithValue(DL.Properties.Resources.SmsMessage, SmsMessage);
                command.CommandType = CommandType.StoredProcedure;
                con.Open();
                result=command.ExecuteNonQuery(); 
            }
            return result > 0;
        }
        public bool AttendanceNFC(string IMEI, string EmpTag, string SwipeType, string swipeDate, string IPaddress)
        {
            var result = 0;
            using (var con = new SqlConnection(_ConnectionString))
            {

                var command = new SqlCommand("udp_trnEmployeeAttendanceNFC", con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue(DL.Properties.Resources.NFCAsmtTagId, IMEI);
                command.Parameters.AddWithValue(DL.Properties.Resources.EmployeeTagID, EmpTag);
                command.Parameters.AddWithValue(DL.Properties.Resources.StatusINOUT, SwipeType);
                command.Parameters.AddWithValue(DL.Properties.Resources.DutyDate, swipeDate);
                command.Parameters.AddWithValue(DL.Properties.Resources.Time, swipeDate);
                command.Parameters.AddWithValue(DL.Properties.Resources.IPaddress, IPaddress);
                con.Open();
                result = command.ExecuteNonQuery();

            }
            return result > 0;
        }
        public bool POP(string SpID, string EmpTag, string LocTag, string IMEI, string swipeDate, string swipeType, string IPaddress)
        {
             var result = 0;
             using (var con = new SqlConnection(_ConnectionString))
             {

                 var command = new SqlCommand("udp_trnNFCPop", con);
                 command.CommandType = CommandType.StoredProcedure;
                 command.Parameters.AddWithValue(DL.Properties.Resources.SupervisorID, SpID);
                 command.Parameters.AddWithValue(DL.Properties.Resources.EmployeeTagID, EmpTag);
                command.Parameters.AddWithValue(DL.Properties.Resources.NFCAsmtTagId, IMEI);
                command.Parameters.AddWithValue(DL.Properties.Resources.DutyDate, DateTime.Parse(swipeDate));
                command.Parameters.AddWithValue(DL.Properties.Resources.SwipeType, swipeType);
                command.Parameters.AddWithValue(DL.Properties.Resources.IPaddress, IPaddress);
                command.Parameters.AddWithValue(DL.Properties.Resources.LocationTagID, LocTag);
                con.Open();
                result = command.ExecuteNonQuery();
             }
            return result > 0;

        }
        public bool GuardTour(string IMEI, string EmpTag, string postTag, string swipeDate, string IPaddress)
        {
            var result = 0;
            using (var con = new SqlConnection(_ConnectionString))
            {

                var command = new SqlCommand("udp_trnNFCGuardTour", con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue(DL.Properties.Resources.NFCAsmtTagId, IMEI);
                command.Parameters.AddWithValue(DL.Properties.Resources.EmployeeTagID, EmpTag);
                command.Parameters.AddWithValue(DL.Properties.Resources.PostTagID, postTag);
                command.Parameters.AddWithValue(DL.Properties.Resources.DutyDate, swipeDate);
                command.Parameters.AddWithValue(DL.Properties.Resources.IPaddress, IPaddress);
                con.Open();
                result = command.ExecuteNonQuery();
            }
            return result > 0;


        }
        public DataSet IncidentType()
        {
            DataSet ds = new DataSet();
            using (var con = new SqlConnection(_ConnectionString))
             {

                 var command = new SqlCommand("udp_mstIncidentTypeGet", con);
                 command.CommandType = CommandType.StoredProcedure;
                 con.Open();
                 SqlDataAdapter adapter = new SqlDataAdapter(command);
                
                 adapter.Fill(ds);
             }
            return ds;
        }
        public bool LoanWorker(string SpID, string EmpTag, string LocTag, string IMEI, string swipeDate, string swipeType, string IPaddress)
        {
            var result = 0;
            using (var con = new SqlConnection(_ConnectionString))
            {

                var command = new SqlCommand("udp_trnNFCPop", con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue(DL.Properties.Resources.SupervisorID, SpID);
                command.Parameters.AddWithValue(DL.Properties.Resources.EmployeeTagID, EmpTag);
                command.Parameters.AddWithValue(DL.Properties.Resources.NFCAsmtTagId, IMEI);
                command.Parameters.AddWithValue(DL.Properties.Resources.DutyDate, swipeDate);
                command.Parameters.AddWithValue(DL.Properties.Resources.SwipeType, swipeType);
                command.Parameters.AddWithValue(DL.Properties.Resources.IPaddress, IPaddress);
                command.Parameters.AddWithValue(DL.Properties.Resources.LocationTagID, LocTag);
                con.Open();
                result = command.ExecuteNonQuery();
            }
            return result > 0;

        }

    }
}
