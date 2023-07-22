using System;
using System.Web;

namespace MagnonCommon.Session
{
    [Serializable]
    public class SystemParameters
    {
        private const string SessionName = "SystemParameters";
        private string sysPayPeriodMonthRange;
        private string sysPayPeriodFromDay;
        private string sysPayPeriodToDay;
        private string sysDigitsAfterDecimalPlaces;
        private string sysCommaAfterPlace;
        private string sysRoundOffCheck;
        private string sysDefaultCurrency;
        private string sysFirstDayOfWeek;

        private string sysRotaTimeShow;
        private string sysScheduleStartDay;
        private string sysScheduleEndDay;
        private string sysDefaultScheduleType;
        
        private void CheckExisting()
        {
            if (HttpContext.Current.Session[SessionName] == null)
            {
                //Save this instance to the session
                HttpContext.Current.Session[SessionName] = this;
                PayPeriodMonthRange = string.Empty;
                PayPeriodFromDay = string.Empty;
                PayPeriodToDay = string.Empty;
                DigitsAfterDecimalPlaces = string.Empty;
                CommaAfterPlace = string.Empty;
                RoundOffCheck = string.Empty;
                DefaultCurrency = string.Empty;
                FirstDayOfWeek = string.Empty;
                RotaTimeShow = string.Empty;
                ScheduleStartDay = string.Empty;
                ScheduleEndDay = string.Empty;
                DefaultScheduleType = string.Empty;
            }
            else
            {
                //Initialize our object based on existing session
                var uInfo = (SystemParameters)HttpContext.Current.Session[SessionName];
                this.PayPeriodMonthRange = uInfo.PayPeriodMonthRange;
                this.PayPeriodFromDay = uInfo.PayPeriodFromDay;
                this.PayPeriodToDay = uInfo.PayPeriodToDay;
                this.DigitsAfterDecimalPlaces = uInfo.DigitsAfterDecimalPlaces;
                this.CommaAfterPlace = uInfo.CommaAfterPlace;
                this.RoundOffCheck = uInfo.RoundOffCheck;
                this.DefaultCurrency = uInfo.DefaultCurrency;
                this.FirstDayOfWeek = uInfo.FirstDayOfWeek;
                this.RotaTimeShow = uInfo.RotaTimeShow;
                this.ScheduleStartDay = uInfo.ScheduleStartDay;
                this.ScheduleEndDay = uInfo.ScheduleEndDay;
                this.DefaultScheduleType = uInfo.DefaultScheduleType;
                uInfo = null;
            }
        }
        private void Save()
        {
            //Save our object to the session
            HttpContext.Current.Session[SessionName] = this;
        }
        public SystemParameters()
        {
            CheckExisting();
        }
        public string PayPeriodMonthRange
        {
            get { return this.sysPayPeriodMonthRange; }
            set { this.sysPayPeriodMonthRange = value; Save(); }
        }
        public string PayPeriodFromDay
        {
            get { return this.sysPayPeriodFromDay; }
            set { this.sysPayPeriodFromDay = value; Save(); }
        }
        public string PayPeriodToDay
        {
            get { return this.sysPayPeriodToDay; }
            set { this.sysPayPeriodToDay = value; Save(); }
        }
        public string DigitsAfterDecimalPlaces
        {
            get { return this.sysDigitsAfterDecimalPlaces; }
            set { this.sysDigitsAfterDecimalPlaces = value; Save(); }
        }
        public string CommaAfterPlace
        {
            get { return this.sysCommaAfterPlace; }
            set { this.sysCommaAfterPlace = value; Save(); }
        }
        public string RoundOffCheck
        {
            get { return this.sysRoundOffCheck; }
            set { this.sysRoundOffCheck = value; Save(); }
        }
        public string DefaultCurrency
        {
            get { return this.sysDefaultCurrency; }
            set { this.sysDefaultCurrency = value; Save(); }
        }
        public string FirstDayOfWeek
        {
            get { return this.sysFirstDayOfWeek; }
            set { this.sysFirstDayOfWeek = value; Save(); }
        }

        public string RotaTimeShow
        {
            get { return this.sysRotaTimeShow; }
            set { this.sysRotaTimeShow = value; Save(); }
        }
        public string ScheduleStartDay
        {
            get { return this.sysScheduleStartDay; }
            set { this.sysScheduleStartDay = value; Save(); }
        }
        public string ScheduleEndDay
        {
            get { return this.sysScheduleEndDay; }
            set { this.sysScheduleEndDay = value; Save(); }
        }
        public string DefaultScheduleType
        {
            get { return this.sysDefaultScheduleType; }
            set { this.sysDefaultScheduleType = value; Save(); }
        }
    }
}
