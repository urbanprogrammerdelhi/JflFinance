using System;
using System.Data;
using System.Data.SqlClient;
using Saturn.Common.POP;


namespace BL
{
   public  class POPComponent
    {
       readonly DL.POPRepository _POPRepository = null;
       readonly DL.POPSecurityRepository _POPSecurityRepository = null;
       public POPComponent(string clientCode)
       {
           _POPRepository = new DL.POPRepository(clientCode);
           _POPSecurityRepository = new DL.POPSecurityRepository(clientCode); 
       }
       public bool Panic(string IMEI, string swipeDate,string IpAddress)
       { 
           return _POPRepository.Panic(IMEI, swipeDate,IpAddress);
       }
       public string  ValidateUser(SecUser secUser)
       {
           return _POPSecurityRepository.ValidateUser(secUser);
       }
       public bool Incident(string IncidentType, string IMEI, string EmpTag, string Attachment, string swipeDate, string LocTag, string SmsMessage, string IPaddress)
       {

           return _POPRepository.Incident(IncidentType, IMEI, EmpTag, Attachment, swipeDate, LocTag, SmsMessage, IPaddress);

       }
       public bool AttendanceNFC(string IMEI, string EmpTag, string SwipeType, string swipeDate, string IPaddress)
       {
           return _POPRepository.AttendanceNFC(IMEI, EmpTag, SwipeType, swipeDate, IPaddress);
       }
       public bool POP(string SpID, string EmpTag, string LocTag, string IMEI, string swipeDate, string swipeType, string IPaddress)
       {
           return _POPRepository.POP(SpID, EmpTag, LocTag, IMEI, swipeDate, swipeType, IPaddress);
       }
       public bool GuardTour(string IMEI, string EmpTag, string postTag, string swipeDate, string IPaddress)
       {
           return _POPRepository.GuardTour(IMEI, EmpTag, postTag, swipeDate, IPaddress);
       
       }
       public bool LoanWorker(string SpID, string EmpTag, string LocTag, string IMEI, string swipeDate, string swipeType, string IPaddress)
       {
           return _POPRepository.LoanWorker(SpID, EmpTag, LocTag, IMEI, swipeDate, swipeType, IPaddress);

       }
       public DataSet IncidentType()
       {
           return _POPRepository.IncidentType();
       }


    }
}
