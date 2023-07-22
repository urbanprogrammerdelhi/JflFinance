// ***********************************************************************
// Assembly         : CommonLibrary
// Author           : Administrator
// Created          : 04-27-2015
//
// Last Modified By : Administrator
// Last Modified On : 04-27-2015
// ***********************************************************************
// <copyright file="SystemParameters.cs" company="Microsoft">
//     Copyright © Microsoft 2015
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Web;

/// <summary>
/// The Session namespace.
/// </summary>
namespace CommonLibrary.Session
{
    /// <summary>
    /// Class SystemParameters.
    /// </summary>
    [Serializable]
    public class SystemParameters
    {
        /// <summary>
        /// The session name
        /// </summary>
        private const string SessionName = "SystemParameters";
        /// <summary>
        /// The system pay period month range
        /// </summary>
        private string sysPayPeriodMonthRange;
        /// <summary>
        /// The system pay period from day
        /// </summary>
        private string sysPayPeriodFromDay;
        /// <summary>
        /// The system pay period to day
        /// </summary>
        private string sysPayPeriodToDay;
        /// <summary>
        /// The system digits after decimal places
        /// </summary>
        private string sysDigitsAfterDecimalPlaces;
        /// <summary>
        /// The system comma after place
        /// </summary>
        private string sysCommaAfterPlace;
        /// <summary>
        /// The system round off check
        /// </summary>
        private string sysRoundOffCheck;
        /// <summary>
        /// The system default currency
        /// </summary>
        private string sysDefaultCurrency;
        /// <summary>
        /// The system first day of week
        /// </summary>
        private string sysFirstDayOfWeek;

        /// <summary>
        /// The system rota time show
        /// </summary>
        private string sysRotaTimeShow;
        /// <summary>
        /// The system schedule start day
        /// </summary>
        private string sysScheduleStartDay;
        /// <summary>
        /// The system schedule end day
        /// </summary>
        private string sysScheduleEndDay;
        /// <summary>
        /// The system default schedule type
        /// </summary>
        private string sysDefaultScheduleType;

        /// <summary>
        /// Checks the existing.
        /// </summary>
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
        /// <summary>
        /// Saves this instance.
        /// </summary>
        private void Save()
        {
            //Save our object to the session
            HttpContext.Current.Session[SessionName] = this;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="SystemParameters"/> class.
        /// </summary>
        public SystemParameters()
        {
            CheckExisting();
        }
        /// <summary>
        /// Gets or sets the pay period month range.
        /// </summary>
        /// <value>The pay period month range.</value>
        public string PayPeriodMonthRange
        {
            get { return this.sysPayPeriodMonthRange; }
            set { this.sysPayPeriodMonthRange = value; Save(); }
        }
        /// <summary>
        /// Gets or sets the pay period from day.
        /// </summary>
        /// <value>The pay period from day.</value>
        public string PayPeriodFromDay
        {
            get { return this.sysPayPeriodFromDay; }
            set { this.sysPayPeriodFromDay = value; Save(); }
        }
        /// <summary>
        /// Gets or sets the pay period to day.
        /// </summary>
        /// <value>The pay period to day.</value>
        public string PayPeriodToDay
        {
            get { return this.sysPayPeriodToDay; }
            set { this.sysPayPeriodToDay = value; Save(); }
        }
        /// <summary>
        /// Gets or sets the digits after decimal places.
        /// </summary>
        /// <value>The digits after decimal places.</value>
        public string DigitsAfterDecimalPlaces
        {
            get { return this.sysDigitsAfterDecimalPlaces; }
            set { this.sysDigitsAfterDecimalPlaces = value; Save(); }
        }
        /// <summary>
        /// Gets or sets the comma after place.
        /// </summary>
        /// <value>The comma after place.</value>
        public string CommaAfterPlace
        {
            get { return this.sysCommaAfterPlace; }
            set { this.sysCommaAfterPlace = value; Save(); }
        }
        /// <summary>
        /// Gets or sets the round off check.
        /// </summary>
        /// <value>The round off check.</value>
        public string RoundOffCheck
        {
            get { return this.sysRoundOffCheck; }
            set { this.sysRoundOffCheck = value; Save(); }
        }
        /// <summary>
        /// Gets or sets the default currency.
        /// </summary>
        /// <value>The default currency.</value>
        public string DefaultCurrency
        {
            get { return this.sysDefaultCurrency; }
            set { this.sysDefaultCurrency = value; Save(); }
        }
        /// <summary>
        /// Gets or sets the first day of week.
        /// </summary>
        /// <value>The first day of week.</value>
        public string FirstDayOfWeek
        {
            get { return this.sysFirstDayOfWeek; }
            set { this.sysFirstDayOfWeek = value; Save(); }
        }

        /// <summary>
        /// Gets or sets the rota time show.
        /// </summary>
        /// <value>The rota time show.</value>
        public string RotaTimeShow
        {
            get { return this.sysRotaTimeShow; }
            set { this.sysRotaTimeShow = value; Save(); }
        }
        /// <summary>
        /// Gets or sets the schedule start day.
        /// </summary>
        /// <value>The schedule start day.</value>
        public string ScheduleStartDay
        {
            get { return this.sysScheduleStartDay; }
            set { this.sysScheduleStartDay = value; Save(); }
        }
        /// <summary>
        /// Gets or sets the schedule end day.
        /// </summary>
        /// <value>The schedule end day.</value>
        public string ScheduleEndDay
        {
            get { return this.sysScheduleEndDay; }
            set { this.sysScheduleEndDay = value; Save(); }
        }
        /// <summary>
        /// Gets or sets the default type of the schedule.
        /// </summary>
        /// <value>The default type of the schedule.</value>
        public string DefaultScheduleType
        {
            get { return this.sysDefaultScheduleType; }
            set { this.sysDefaultScheduleType = value; Save(); }
        }
    }
}
