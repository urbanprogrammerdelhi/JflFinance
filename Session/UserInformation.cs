using System;
using System.Web;

namespace MagnonCommon.Session
{
   [Serializable]
   public class UserInformation
    {
        private const string SessionName = "UserInformation";
        private string loginUserId;
        private string loginUserName;
        private string loginUserRole;
        private string loginUserMobileNo;
        private string loginUserEmailId;
        private string loginUserEmployeeNumber;
        private string loginUserIsAreaIncharge;
        private string loginUserIp;
        private DateTime loginDateTime;
        private string loginCountryCode;
        private string loginCountryName;
        private string loginLanguageCode;
        private string loginLanguageName;
        private string loginDatabaseName;

        private void CheckExisting()
        {
            if (HttpContext.Current.Session[SessionName] == null)
            {
                //Save this instance to the session
                HttpContext.Current.Session[SessionName] = this;
                UserId = string.Empty;
                loginUserName = string.Empty;
                UserRole = string.Empty;
                UserMobileNo = string.Empty;
                UserEmailId = string.Empty;
                EmployeeNumber = string.Empty;
                IsAreaIncharge = string.Empty;
                UserIp = string.Empty;
                CurrentLoginDateTime = DateTime.Now;
                CountryCode = string.Empty;
                CountryName = string.Empty;
                LanguageCode = string.Empty;
                LanguageName = string.Empty;
                DatabaseName = string.Empty;
            }
            else
            {
                //Initialize our object based on existing session
                var uInfo = (UserInformation)HttpContext.Current.Session[SessionName];
                this.UserId = uInfo.UserId;
                this.loginUserName = uInfo.loginUserName;
                this.UserRole = uInfo.UserRole;
                this.UserMobileNo = uInfo.UserMobileNo;
                this.UserEmailId = uInfo.UserEmailId;
                this.EmployeeNumber = uInfo.EmployeeNumber;
                this.IsAreaIncharge = uInfo.IsAreaIncharge;
                this.UserIp = uInfo.UserIp;
                this.CurrentLoginDateTime = uInfo.CurrentLoginDateTime;
                this.CountryCode = uInfo.CountryCode;
                this.CountryName = uInfo.CountryName;
                this.LanguageCode = uInfo.LanguageCode;
                this.LanguageName = uInfo.LanguageName;
                this.DatabaseName = uInfo.DatabaseName;
                uInfo = null;
            }
        }
        private void Save()
        {
            //Save our object to the session
            HttpContext.Current.Session[SessionName] = this;
        }

        public UserInformation()
        {
            //userId = string.Empty;
            //loginUserName = string.Empty;
            //userRole = string.Empty;
            //employeeNumber = string.Empty;
            //isAreaIncharge = false;
            //userIP = string.Empty;
            //currentLoginDateTime = DateTime.Now;

            CheckExisting();
        }

        public string UserId
        {
            get { return this.loginUserId; }
            set { this.loginUserId = value; Save(); }
        }

        public string UserName
        {
            get { return this.loginUserName; }
            set { this.loginUserName = value; Save(); }
        }

        public string UserRole
        {
            get { return this.loginUserRole; }
            set { this.loginUserRole = value; Save(); }
        }

        public string UserMobileNo
        {
            get { return this.loginUserMobileNo; }
            set { this.loginUserMobileNo = value; Save(); }
        }

        public string UserEmailId
        {
            get { return this.loginUserEmailId; }
            set { this.loginUserEmailId = value; Save(); }
        }

        public string EmployeeNumber
        {
            get { return this.loginUserEmployeeNumber; }
            set { this.loginUserEmployeeNumber = value; Save(); }
        }

        public string IsAreaIncharge
        {
            get { return this.loginUserIsAreaIncharge; }
            set { this.loginUserIsAreaIncharge = value; Save(); }
        }

        public string UserIp
        {
            get { return this.loginUserIp; }
            set { this.loginUserIp = value; Save(); }
        }

        public DateTime CurrentLoginDateTime
        {
            get { return this.loginDateTime; }
            set { this.loginDateTime = value; Save(); }
        }

        public string CountryCode
        {
            get { return this.loginCountryCode; }
            set { this.loginCountryCode = value; Save(); }
        }

        public string CountryName
        {
            get { return this.loginCountryName; }
            set { this.loginCountryName = value; Save(); }
        }

        public string LanguageCode
        {
            get { return this.loginLanguageCode; }
            set { this.loginLanguageCode = value; Save(); }
        }

        public string LanguageName
        {
            get { return this.loginLanguageName; }
            set { this.loginLanguageName = value; Save(); }
        }

        public string DatabaseName
        {
            get { return this.loginDatabaseName; }
            set { this.loginDatabaseName = value; Save(); }
        }
    }
}
