using System;
using System.Web;

namespace MagnonCommon.Session
{
    [Serializable]
    public class AccessInformation
    {
        private const string SessionName = "AccessInformation";
        private string loginCompanyCode;
        private string loginCompanyDesc;
        private string loginHrLocationCode;
        private string loginHrLocationDesc;
        private string loginLocationCode;
        private string loginLocationDesc;
        private string loginLocationAutoId;

        private void CheckExisting()
        {
            if (HttpContext.Current.Session[SessionName] == null)
            {
                //Save this instance to the session
                HttpContext.Current.Session[SessionName] = this;
                CompanyCode = string.Empty;
                CompanyDesc = string.Empty;
                HrLocationCode = string.Empty;
                HrLocationDesc = string.Empty;
                LocationCode = string.Empty;
                LocationDesc = string.Empty;
                LocationAutoId = string.Empty;
            }
            else
            {
                //Initialize our object based on existing session
                var accessInfo = (AccessInformation)HttpContext.Current.Session[SessionName];
                this.CompanyCode = accessInfo.CompanyCode;
                this.CompanyDesc = accessInfo.CompanyDesc;
                this.HrLocationCode = accessInfo.HrLocationCode;
                this.HrLocationDesc = accessInfo.HrLocationDesc;
                this.LocationCode = accessInfo.LocationCode;
                this.LocationDesc = accessInfo.LocationDesc;
                this.LocationAutoId = accessInfo.LocationAutoId;

                accessInfo = null;
            }
        }

        private void Save()
        {
            //Save our object to the session
            HttpContext.Current.Session[SessionName] = this;
        }

        public AccessInformation()
        {
            CheckExisting();
        }

        public string CompanyCode
        {
            get { return this.loginCompanyCode; }
            set { this.loginCompanyCode = value; Save(); }
        }

        public string CompanyDesc
        {
            get { return this.loginCompanyDesc; }
            set { this.loginCompanyDesc = value; Save(); }
        }

        public string HrLocationCode
        {
            get { return this.loginHrLocationCode; }
            set { this.loginHrLocationCode = value; Save(); }
        }

        public string HrLocationDesc
        {
            get { return this.loginHrLocationDesc; }
            set { this.loginHrLocationDesc = value; Save(); }
        }

        public string LocationCode
        {
            get { return this.loginLocationCode; }
            set { this.loginLocationCode = value; Save(); }
        }

        public string LocationDesc
        {
            get { return this.loginLocationDesc; }
            set { this.loginLocationDesc = value; Save(); }
        }

        public string LocationAutoId
        {
            get { return this.loginLocationAutoId; }
            set { this.loginLocationAutoId = value; Save(); }
        }
    }
}
