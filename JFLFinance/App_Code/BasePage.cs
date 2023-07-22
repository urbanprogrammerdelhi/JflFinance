// ***********************************************************************
// Assembly         : 
// Author           : 
// Created          : 09-13-2013
//
// Last Modified By : 
// Last Modified On : 04-30-2015
// ***********************************************************************
// <copyright file="BasePage.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Drawing;
using System.Globalization;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;
using Resources;
using CommonLibrary.Session;


/// <summary>
/// BasePage for the common functionality in all
/// the web pages of the site.
/// </summary>
public class BasePage : Page
{

    /// <summary>
    /// Default constructor
    /// </summary>
    public BasePage()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    #region Function to Read resource Files
    /// <summary>
    /// Resources the value of key_ get.
    /// </summary>
    /// <param name="strKey">The STR key.</param>
    /// <returns>System.String.</returns>
    protected string ResourceValueOfKey_Get(string strKey)
    {
        if (Resource.ResourceManager.GetString(strKey) != null && Resource.ResourceManager.GetString(strKey) != string.Empty)
        {
            return Resource.ResourceManager.GetString(strKey);
        }
        return strKey;
    }

    /// <summary>
    /// Resources the value of key_ get.
    /// </summary>
    /// <param name="strKey">The STR key.</param>
    /// <returns>System.String.</returns>
    protected string ResourceValueOfKey_Get(string strKey, string strValue)
    {
        if (Resource.ResourceManager.GetString(strKey) != null && Resource.ResourceManager.GetString(strKey) != string.Empty)
        {
            return Resource.ResourceManager.GetString(strKey);
        }
        return strValue;
    }

    /// <summary>
    /// Resources the value of key onlyfor status_ get.
    /// </summary>
    /// <param name="strStatusKey">The STR status key.</param>
    /// <returns>System.String.</returns>
    protected string ResourceValueOfKeyOnlyforStatus_Get(string strStatusKey)
    {
        string strNewStatusKey = strStatusKey.Substring(0, 1) + strStatusKey.Substring(1, strStatusKey.Length - 1).ToLower();
        if (Resource.ResourceManager.GetString(strNewStatusKey) != null && Resource.ResourceManager.GetString(strNewStatusKey) != string.Empty)
        {
            return Resource.ResourceManager.GetString(strNewStatusKey);
        }
        return strStatusKey;
    }
    #endregion

    #region Diffrent fixed string Status
    /// <summary>
    /// The STR status fresh
    /// </summary>
    protected string strStatusFresh = "FRESH";
    /// <summary>
    /// The STR status amend
    /// </summary>
    protected string strStatusAmend = "AMEND";
    /// <summary>
    /// The STR status authorized
    /// </summary>
    protected string strStatusAuthorized = "AUTHORIZED";
    /// <summary>
    /// The STR status short closed
    /// </summary>
    protected string strStatusShortClosed = "SHORTCLOSED";
    /// <summary>
    /// The STR status terminated
    /// </summary>
    protected string strStatusTerminated = "TERMINATED";
    /// <summary>
    /// The STR status reversal
    /// </summary>
    protected string strStatusReversal = "REVERSAL";
    /// <summary>
    /// The STR status delete
    /// </summary>
    protected string strStatusDelete = "DELETED";
    /// <summary>
    /// The STR status new
    /// </summary>
    protected string strStatusNew = "NEW";
    /// <summary>
    /// The STR status approved
    /// </summary>
    protected string strStatusApproved = "APPROVED";
    /// <summary>
    /// The STR status rejected
    /// </summary>
    protected string strStatusRejected = "REJECTED";
    /// <summary>
    /// The STR status sent
    /// </summary>
    protected string strStatusSent = "SEND";
    /// <summary>
    /// The STR status correction
    /// </summary>
    protected string strStatusCorrection = "Correction";
    #endregion

    #region Function Related to Culture
    /// <summary>
    /// Sets the <see cref="P:System.Web.UI.Page.Culture" /> and <see cref="P:System.Web.UI.Page.UICulture" /> for the current thread of the page.
    /// </summary>
    /// <SUMMARY>
    /// Overriding the InitializeCulture method to set the user selected
    /// option in the current thread. Note that this method is called much
    /// earlier in the Page lifecycle and we don't have access to any controls
    /// in this stage, so have to use Form collection.
    /// </SUMMARY>
    protected override void InitializeCulture()
    {
        if (!string.IsNullOrEmpty(BaseLanguageCode))
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(BaseLanguageCode);
            Thread.CurrentThread.CurrentCulture = new CultureInfo(BaseLanguageCode);
            Thread.CurrentThread.CurrentCulture.DateTimeFormat.Calendar = new GregorianCalendar();
        }
        base.InitializeCulture();
    }

    /// <summary>
    /// Sets the culture.
    /// </summary>
    /// <param name="name">The name.</param>
    /// <param name="locale">The locale.</param>
    /// <Summary>
    /// Sets the current UICulture and CurrentCulture based on
    /// the arguments
    /// </Summary>
    /// <PARAM name="name"></PARAM>
    /// <PARAM name="locale"></PARAM>
    protected void SetCulture(string name, string locale)
    {
        Thread.CurrentThread.CurrentUICulture = new CultureInfo(name);
        Thread.CurrentThread.CurrentCulture = new CultureInfo(locale);
        //Saving the current thread's culture set by the User in the Session
        //so that it can be used across the pages in the current application.
        
        BaseUserInformation.LanguageCode = Thread.CurrentThread.CurrentUICulture.ToString();
        BaseUserInformation.LanguageCode = Thread.CurrentThread.CurrentCulture.ToString();
        Thread.CurrentThread.CurrentCulture.DateTimeFormat.Calendar = new GregorianCalendar();
        Thread.CurrentThread.CurrentCulture.NumberFormat.NumberGroupSeparator = ",";
        Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator = ".";

        var aCookie = new HttpCookie("language") {Value = name};
        HttpContext.Current.Response.Cookies.Add(aCookie);

    }
    #endregion

    #region Function Related to MessageBox

    /// <summary>
    /// Bases the messagestring_ get.
    /// </summary>
    /// <param name="messageId">The message ID.</param>
    /// <returns>System.String.</returns>
    protected string BaseMessagestring_Get(int messageId)
    {
       // PlayMediaMessage(MessageID);
        return MessageString_Get(messageId);
    }
    /// <summary>
    /// Messages the string_ get.
    /// </summary>
    /// <param name="messageId">The message ID.</param>
    /// <returns>System.String.</returns>
    protected string MessageString_Get(int messageId)
    {
        switch (messageId)
        {
            case 0: return Resource.MsgInsertSuccessfully;
            case 1: return Resource.MsgDeleteSuccessfully;
            case 2: return Resource.MsgUpdateSuccessfully;
            case 3: return Resource.MsgAlreadyExists;
            case 4: return Resource.MsgNotFound;
            case 5: return Resource.MsgInsertFail;
            case 6: return Resource.MsgDeleteFail;
            case 7: return Resource.MsgUpdateFail;
            case 8: return Resource.MsgDeleteFailRefExists;
            case 11: return Resource.MsgDuplicateRecordFound;
            case 12: return Resource.MsgShiftNotdefined;
            case 14: return Resource.MsgFileNameAlreadyExists;
            case 15: return Resource.MsgSuccessfullyAmend;
            case 16: return Resource.MsgFailedToAmend;
            case 17: return Resource.MsgSuccessfullyAuthorized;
            case 18: return Resource.MsgFailedToAuthorized;
            case 19: return Resource.AlreadyAuthorized;
            case 20: return Resource.SuccessfullyAuthorized;
            case 21: return Resource.MsgCopiedSuccessfully;
            case 22: return Resource.MsgSuccessfullyReverse;
            case 23: return Resource.MsgInvalidDate;
            case 24: return Resource.MsgFailedToAuthorizedNoActiveSoLineExists;
            case 25: return Resource.MsgFailedToAuthorizedDeploymentIsNotDefined;
            case 50: return Resource.ErrMsgExceedLicense;
            case 51: return Resource.MsgUserIDNotAvailable;
            case 52: return Resource.MsgSequenceIDnotexists;
            case 53: return Resource.MsgNoAuthorizedContractNumberFound;
            case 54: return Resource.MsgProcessSuccessfullyCompleted;
            case 55: return Resource.msgInvalidShift;
            case 57: return Resource.MsgUpdateFailRefExists;
            case 58: return Resource.AdjustmentInsertFailed;
            case 59: return Resource.AnyoperationisnotallowedonAuthorizedRota;
            case 60: return Resource.Userhasbeencreatedsuccessfully;
            case 61: return Resource.NoAuthorizedContractExists;
            case 62: return Resource.ScheduleExistsForTheEmp;
            case 63: return Resource.NothingToUnAuthorize;
            case 64: return Resource.SuccessfullyUnAuthorized;
            case 65: return Resource.MsgInValidDateDatecannotBeGreaterThanCurrentDate;
            case 66: return Resource.MsgRecordsAlreadyLocked;
            case 67: return Resource.MsgCanNotLockedScheduleIsAuthorized;
            case 68: return Resource.MsgRotaIsAuthorized;
            case 69: return Resource.MsgSuccessfullyLocked;
            case 70: return Resource.MsgAssignmentSuccessfullyCreated;
            case 71: return Resource.MsgAssignmentStartDateShouldBeBetweenMinSOLineStartDateAndMaxSOLineEndDate;
            case 72: return Resource.MsgAssignmentAlreadyHasBeenCreatedForThisClientOnThisAsmtIdOnThisLocation;
            case 73: return Resource.MsgPleaseDeleteTheExistingRecordsFromScheduleAndExceptions;
            case 74: return Resource.MsgSuccessfullyTerminated;
            case 75: return Resource.MsgNothingToSave;
            case 76: return Resource.MsgDeployedHoursExceedsTheTotalHoursDefinedInsales;
            case 77: return Resource.MsgAssignmentStatusIsNotInFreshOrAmendementModeOrAssignmentIsNotCreated;
            case 78: return Resource.MsgNoOfShiftAreGreaterThanPersonAllocated;
            case 79: return Resource.MsgDeployedHoursExceedsTheTotalHoursDefinedInsales;
            case 80: return Resource.MsgMaximumNumberOfShiftYouCanDefineOnPDLineShouldNotBeGreaterThanPersonsAllocated;
            case 81: return Resource.MsgDuplicateShiftForWeekIsDefined;
            case 82: return Resource.msgInvalidShift;
            case 83: return Resource.MsgRotaAlreadyExistsOnThisShift;
            case 84: return Resource.MsgSchedeuleAlreadyExistsOnThisShift;
            case 85: return Resource.MsgTotalHoursExceedContractualHrsonPDLine;
            case 86: return Resource.MsgInvalidShiftOnPDLine;
            case 87: return Resource.MsgInsertSuccessfullyWithInvalidShiftOnPDLine;
            case 88: return Resource.MsgInsertSuccessfullyWithHoursExceedContractualHoursOnPDLine;
            case 89: return Resource.MsgUpdateSuccessfullyWithInvalidShiftonPDLine;
            case 90: return Resource.MsgUpdateSuccessfullyWithHoursExceedContractualHoursOnPDLine;

            case 91: return Resource.EmployeeDoesnotBelongTothisLocation;
            case 92: return Resource.EmployeeCategoryDoesNotBelongtothisCalender;
            case 93: return Resource.EmployeeJoiningDateisGreaterThanLeaveCalendarDate;
            case 94: return Resource.EntitlementhasAlreadybeendoneforthisEmployee;
            case 95: return Resource.LeaveDescriptionAlreadyExists;
            case 96: return Resource.LeaveUnitsShouldMoreThanZero;
            case 97: return Resource.LeaveExitsForTheEmployee;
            case 98: return Resource.WeekOFFWithReasonExitsForTheEmployee;
            case 99: return Resource.SalesORAssignmentHasBeenChanged;

            case 101: return Resource.RotaExists;
            case 102: return Resource.ScheduleExists;
            case 103: return Resource.LocationUpdatedOn;
            case 104: return Resource.CategoryUpdatedOn;
            case 105: return Resource.JoiningDateUpdatedOn;
            case 106: return Resource.DesignationUpdatedOn;
            case 107: return Resource.CompensationUpdatedOn;
            case 108: return Resource.JobTypeUpdatedON;
            case 109: return Resource.JobClassUpdatedOn;
            case 110: return Resource.DepartmentUpdatedOn;
            case 113: return Resource.AuthorizedScheduleCannotbeDeleted;
            case 114: return Resource.AuthorizedRotaCannotbeDeleted;
            case 115: return Resource.LeaveCalenderDoesNotExists;
            case 116: return Resource.InvaidLeaveCodeAccordingToGender;
            case 117: return Resource.InvalidEmployee;
            case 118: return Resource.PatternSeqCodeReq;
            //To be used in Scheduling Screen
            case 119: return Resource.SelectedEmployeepreferenceisDayShift;
            case 120: return Resource.Mondayisnotapreferedday;
            case 121: return Resource.Tuesdayisnotapreferedday;
            case 122: return Resource.Wednesdayisnotapreferedday;
            case 123: return Resource.Thursdayisnotapreferedday;
            case 124: return Resource.Fridayisnotapreferedday;
            case 125: return Resource.Saturdayisnotapreferedday;
            case 126: return Resource.Sundayisnotapreferedday;
            case 127: return Resource.SelectedEmployeepreferenceisNightShift;
            case 128: return Resource.EmployeeContractDaysIsLessThanNoOfDuty;
            case 129: return Resource.ShiftPatternInUseInSequence;
            case 130: return Resource.SeqInUse;
            case 131: return Resource.DeleteSeq;
            case 132: return Resource.DeleteSequence;
            case 311: return Resource.validityTrainingNotExpired;
            //END To be used in Scheduling Screen

            case 140: return Resource.SaleOrderNotAuthorized;
            case 141: return Resource.AssignmentNotAuthorized;
            // to display message can not reuse the password
            case 142: return Resource.Cannotreusethepassword;
            // to display message Error in processing
            case 143: return Resource.MsgErrorInProcessing;
                // to display error message during addition of new record 24-Aug-2013.
            case 144: return Resource.MsgErrorInEstablishmentInsert;
            case 145: return Resource.MsgErrorShiftNameAlreadyExists;
            case 146: return Resource.MsgErrorDefaultShiftAlreadyExists;
            case 147: return Resource.MsgInvalidEffectiveFromDate;

            case 148: return Resource.MsgScheduleIsAuthorized;
            case 149: return Resource.MsgTerminationRollbackSucessfully;
            case 150: return Resource.MsgFailToTerminate;
            case 151: return Resource.InvalidHours;
            case 152: return Resource.InvalidateFromDate;
            case 153: return Resource.FromDateCannotbelessthanSystemDate;
            case 154: return Resource.MessageStrIDMobile;
            


            default: return Resource.MsgUnknownError;
        }
    }
    /// <summary>
    /// Bases the message settings.
    /// </summary>
    /// <param name="myMessageBox">My message box.</param>
    /// <param name="myMessageId">My message ID.</param>
    /// <param name="myMoreInformation">My more information.</param>
    /// <returns>MessageBox.MessageBox.</returns>
    protected MessageBox.MessageBox BaseMessageSettings(MessageBox.MessageBox myMessageBox, int myMessageId, string myMoreInformation)
    {
        myMessageBox.ImageFolder = "../Images";
        myMessageBox.Heading = Resource.AppTitle;
        myMessageBox.HeadingBackColor = Color.Red;
        myMessageBox.AutoHide = false;
        myMessageBox.Visible = true;
        myMessageBox.Message = BaseMessagestring_Get(myMessageId);
        myMessageBox.MoreInformation = myMoreInformation;
        return myMessageBox;
    }
    /// <summary>
    /// Displays the message string.
    /// </summary>
    /// <param name="objMessage">The obj message.</param>
    /// <param name="strMessage">The STR message.</param>
    protected void DisplayMessageString(Label objMessage, string strMessage)
    {
        objMessage.Text = strMessage;
    }
    /// <summary>
    /// Displays the message.
    /// </summary>
    /// <param name="objMessage">The obj message.</param>
    /// <param name="strMessageId">The STR message ID.</param>
    protected void DisplayMessage(Label objMessage, string strMessageId)
    {
        objMessage.Text = BaseMessagestring_Get(int.Parse(strMessageId));
    }
    /// <summary>
    /// Displays the message for resource key.
    /// </summary>
    /// <param name="objMessage">The obj message.</param>
    /// <param name="strResourceKey">The STR resource key.</param>
    protected void DisplayMessageForResourceKey(Label objMessage, string strResourceKey)
    {
        objMessage.Text = ResourceValueOfKey_Get(strResourceKey);
    }
    /// <summary>
    /// Gets the success result.
    /// </summary>
    /// <param name="messageId">The message ID.</param>
    /// <returns><c>true</c> if XXXX, <c>false</c> otherwise</returns>
    protected bool GetSuccessResult(int messageId)
    {
        switch (messageId)
        {
            case 0: return true;
            case 1: return true;
            case 2: return true;
            case 3: return false;
            case 4: return false;
            case 5: return false;
            case 6: return false;
            case 7: return false;
            case 8: return false;
            case 11: return false;
            case 15: return true;
            case 17: return true;
            case 18: return false;
            case 19: return true;
            case 20: return true;
            case 21: return true;
            case 23: return false;
            case 58: return false;
            case 59: return false;
            case 61: return false;
            case 62: return false;
            case 63: return false;
            case 64: return false;
            default: return false;
        }
    }

    #endregion

    #region Function Related to Session Variable
    /// <summary>
    /// Gets or sets the base user information.
    /// </summary>
    /// <value>The base user information.</value>
    public UserInformation BaseUserInformation
    {
        get
        {
            if (HttpContext.Current.Session["UserInformation"] == null)
            {
                var userInfo = new UserInformation();
                //return null;
            }
            return (UserInformation)HttpContext.Current.Session["UserInformation"];
        }
        set
        {
            HttpContext.Current.Session["UserInformation"] = value;
        }
    }
    /// <summary>
    /// Gets or sets the base access information.
    /// </summary>
    /// <value>The base access information.</value>
    public AccessInformation BaseAccessInformation
    {
        get
        {
            if (HttpContext.Current.Session["AccessInformation"] == null)
            {
                var accessInfo = new AccessInformation();
                //return null;
            }
            return (AccessInformation)HttpContext.Current.Session["AccessInformation"];
        }
        set
        {
            HttpContext.Current.Session["AccessInformation"] = value;
        }
    }
    /// <summary>
    /// Gets or sets the base system parameters.
    /// </summary>
    /// <value>The base system parameters.</value>
    public SystemParameters BaseSystemParameters
    {
        get
        {
            if (HttpContext.Current.Session["SystemParameters"] == null)
            {
                var sysParam = new SystemParameters();
                //return null;
            }
            return (SystemParameters)HttpContext.Current.Session["SystemParameters"];
        }
        set
        {
            HttpContext.Current.Session["SystemParameters"] = value;
        }
    }

    //UserInformation
    /// <summary>
    /// Gets the base user identifier.
    /// </summary>
    /// <value>The base user identifier.</value>
    /// <exception cref="System.Exception">Session has expired! Login again</exception>
    protected string BaseUserID
    {
        get
        {
            try
            {
                if (BaseUserInformation != null && BaseUserInformation.UserId != string.Empty)
                { return BaseUserInformation.UserId; }
                else
                {
                    RedirectToDefaultPage();
                    return string.Empty;
                }
            }
            catch (Exception ex)
            { throw new Exception("Session has expired! Login again", ex); }
        }
    }
    /// <summary>
    /// Gets the name of the base user.
    /// </summary>
    /// <value>The name of the base user.</value>
    /// <exception cref="System.Exception">Session has expired! Login again</exception>
    protected string BaseUserName
    {
        get
        {
            try
            {
                if (BaseUserInformation != null && BaseUserInformation.UserName != string.Empty)
                { return BaseUserInformation.UserName; }
                else
                {
                    RedirectToDefaultPage();
                    return string.Empty;
                }
            }
            catch (Exception ex)
            { throw new Exception("Session has expired! Login again", ex); }
        }
    }
    /// <summary>
    /// Gets the base is admin.
    /// </summary>
    /// <value>The base is admin.</value>
    /// <exception cref="System.Exception">Session has expired! Login again.</exception>
    protected string BaseIsAdmin
    {
        get
        {
            try
            {
                if (BaseUserInformation != null && BaseUserInformation.UserRole != string.Empty)
                { return BaseUserInformation.UserRole; }
                else
                {
                    RedirectToDefaultPage();
                    return string.Empty;
                }
            }
            catch (Exception ex)
            { throw new Exception("Session has expired! Login again.", ex); }
        }
    }
    /// <summary>
    /// Gets the base user mobile no.
    /// </summary>
    /// <value>The base user mobile no.</value>
    /// <exception cref="System.Exception">Session has expired! Login again.</exception>
    protected string BaseUserMobileNo
    {
        get
        {
            try
            {
                if (BaseUserInformation != null && BaseUserInformation.UserMobileNo != string.Empty)
                { return BaseUserInformation.UserMobileNo; }
                else
                {
                    RedirectToDefaultPage();
                    return string.Empty;
                }
            }
            catch (Exception ex)
            { throw new Exception("Session has expired! Login again.", ex); }
        }
    }
    /// <summary>
    /// Gets the base user email identifier.
    /// </summary>
    /// <value>The base user email identifier.</value>
    /// <exception cref="System.Exception">Session has expired! Login again.</exception>
    protected string BaseUserEmailId
    {
        get
        {
            try
            {
                if (BaseUserInformation != null && BaseUserInformation.UserEmailId != string.Empty)
                { return BaseUserInformation.UserEmailId; }
                else
                {
                    RedirectToDefaultPage();
                    return string.Empty;
                }
            }
            catch (Exception ex)
            { throw new Exception("Session has expired! Login again.", ex); }
        }
    }
    /// <summary>
    /// Gets the base user employee number.
    /// </summary>
    /// <value>The base user employee number.</value>
    /// <exception cref="System.Exception">Session has expired! Login again</exception>
    protected string BaseUserEmployeeNumber
    {
        get
        {
            try
            {
                if (BaseUserInformation != null)
                { return BaseUserInformation.EmployeeNumber; }
                else
                {
                    RedirectToDefaultPage();
                    return string.Empty;
                }
            }
            catch (Exception ex)
            { throw new Exception("Session has expired! Login again", ex); }
        }
    }
    /// <summary>
    /// Gets the base user is area incharge.
    /// </summary>
    /// <value>The base user is area incharge.</value>
    /// <exception cref="System.Exception">Session has expired! Login again</exception>
    protected string BaseUserIsAreaIncharge
    {
        get
        {
            try
            {
                if (BaseUserInformation != null && BaseUserInformation.IsAreaIncharge != string.Empty)
                { return BaseUserInformation.IsAreaIncharge; }
                else
                {
                    RedirectToDefaultPage();
                    return string.Empty;
                }
            }
            catch (Exception ex)
            { throw new Exception("Session has expired! Login again", ex); }
        }
    }
    /// <summary>
    /// Gets the base user ip.
    /// </summary>
    /// <value>The base user ip.</value>
    /// <exception cref="System.Exception">Session has expired! Login again</exception>
    protected string BaseUserIP
    {
        get
        {
            try
            {
                if (BaseUserInformation != null && BaseUserInformation.UserIp != string.Empty)
                { return BaseUserInformation.UserIp; }
                else
                {
                    RedirectToDefaultPage();
                    return string.Empty;
                }
            }
            catch (Exception ex)
            { throw new Exception("Session has expired! Login again", ex); }
        }
    }
    /// <summary>
    /// Gets the base login date time.
    /// </summary>
    /// <value>The base login date time.</value>
    /// <exception cref="System.Exception">Session has expired! Login again</exception>
    protected DateTime BaseLoginDateTime
    {
        get
        {
            try
            {
                if (BaseUserInformation != null && BaseUserInformation.CurrentLoginDateTime.ToString() != string.Empty)
                { return BaseUserInformation.CurrentLoginDateTime; }
                else
                {
                    RedirectToDefaultPage();
                    return DateTime.Now;
                }
            }
            catch (Exception ex)
            { throw new Exception("Session has expired! Login again", ex); }
        }
    }
    /// <summary>
    /// Gets the base country code.
    /// </summary>
    /// <value>The base country code.</value>
    /// <exception cref="System.Exception">Session has expired! Login again</exception>
    protected string BaseCountryCode
    {
        get
        {
            try
            {
                if (BaseUserInformation != null && BaseUserInformation.CountryCode != string.Empty)
                { return BaseUserInformation.CountryCode; }
                else
                {
                    RedirectToDefaultPage();
                    return string.Empty;
                }
            }
            catch (Exception ex)
            { throw new Exception("Session has expired! Login again", ex); }
        }
    }
    /// <summary>
    /// Gets the name of the base country.
    /// </summary>
    /// <value>The name of the base country.</value>
    /// <exception cref="System.Exception">Session has expired! Login again</exception>
    protected string BaseCountryName
    {
        get
        {
            try
            {
                if (BaseUserInformation != null && BaseUserInformation.CountryName != string.Empty)
                { return BaseUserInformation.CountryName; }
                else
                {
                    RedirectToDefaultPage();
                    return string.Empty;
                }
            }
            catch (Exception ex)
            { throw new Exception("Session has expired! Login again", ex); }
        }
    }
    /// <summary>
    /// Gets the base language code.
    /// </summary>
    /// <value>The base language code.</value>
    /// <exception cref="System.Exception">Session has expired! Login again</exception>
    protected string BaseLanguageCode
    {
        get
        {
            try
            {
                if (BaseUserInformation != null && BaseUserInformation.LanguageCode != string.Empty)
                { return BaseUserInformation.LanguageCode; }
                else
                {
                    RedirectToDefaultPage();
                    return string.Empty;
                }
            }
            catch (Exception ex)
            { throw new Exception("Session has expired! Login again", ex); }
        }
    }
    /// <summary>
    /// Gets the name of the base language.
    /// </summary>
    /// <value>The name of the base language.</value>
    /// <exception cref="System.Exception">Session has expired! Login again</exception>
    protected string BaseLanguageName
    {
        get
        {
            try
            {
                if (BaseUserInformation != null && BaseUserInformation.LanguageName != string.Empty)
                { return BaseUserInformation.LanguageName; }
                else
                {
                    RedirectToDefaultPage();
                    return string.Empty;
                }
            }
            catch (Exception ex)
            { throw new Exception("Session has expired! Login again", ex); }
        }
    }
    /// <summary>
    /// Gets the name of the base database.
    /// </summary>
    /// <value>The name of the base database.</value>
    /// <exception cref="System.Exception">Session has expired! Login again</exception>
    protected string BaseDatabaseName
    {
        get
        {
            try
            {
                if (BaseUserInformation != null && BaseUserInformation.DatabaseName != string.Empty)
                { return BaseUserInformation.DatabaseName; }
                else
                {
                    RedirectToDefaultPage();
                    return string.Empty;
                }
            }
            catch (Exception ex)
            { throw new Exception("Session has expired! Login again", ex); }
        }
    }
    //AccessInformation
    /// <summary>
    /// Gets the base company code.
    /// </summary>
    /// <value>The base company code.</value>
    /// <exception cref="System.Exception">Session has expired! Login again</exception>
    protected string BaseCompanyCode
    {
        get
        {
            try
            {
                if (BaseAccessInformation != null && BaseAccessInformation.CompanyCode != string.Empty)
                { return BaseAccessInformation.CompanyCode; }
                else
                {
                    RedirectToDefaultPage();
                    return string.Empty;
                }
            }
            catch (Exception ex)
            { throw new Exception("Session has expired! Login again", ex); }
        }
    }
    /// <summary>
    /// Gets the base company desc.
    /// </summary>
    /// <value>The base company desc.</value>
    /// <exception cref="System.Exception">Session has expired! Login again</exception>
    protected string BaseCompanyDesc
    {
        get
        {
            try
            {
                if (BaseAccessInformation != null && BaseAccessInformation.CompanyDesc != string.Empty)
                { return BaseAccessInformation.CompanyDesc; }
                else
                {
                    RedirectToDefaultPage();
                    return string.Empty;
                }
            }
            catch (Exception ex)
            { throw new Exception("Session has expired! Login again", ex); }
        }
    }
    /// <summary>
    /// Gets the base hr location code.
    /// </summary>
    /// <value>The base hr location code.</value>
    /// <exception cref="System.Exception">Session has expired! Login again</exception>
    protected string BaseHrLocationCode
    {
        get
        {
            try
            {
                if (BaseAccessInformation != null && BaseAccessInformation.HrLocationCode != string.Empty)
                { return BaseAccessInformation.HrLocationCode; }
                else
                {
                    RedirectToDefaultPage();
                    return string.Empty;
                }
            }
            catch (Exception ex)
            { throw new Exception("Session has expired! Login again", ex); }
        }
    }
    /// <summary>
    /// Gets the base location code.
    /// </summary>
    /// <value>The base location code.</value>
    /// <exception cref="System.Exception">Session has expired! Login again</exception>
    protected string BaseLocationCode
    {
        get
        {
            try
            {
                if (BaseAccessInformation != null && BaseAccessInformation.LocationCode != string.Empty)
                { return BaseAccessInformation.LocationCode; }
                else
                {
                    RedirectToDefaultPage();
                    return string.Empty;
                }
            }
            catch (Exception ex)
            { throw new Exception("Session has expired! Login again", ex); }
        }
    }
    /// <summary>
    /// Gets the base location automatic identifier.
    /// </summary>
    /// <value>The base location automatic identifier.</value>
    /// <exception cref="System.Exception">Session has expired! Login again</exception>
    protected string BaseLocationAutoID
    {
        get
        {
            try
            {
                if (BaseAccessInformation != null && BaseAccessInformation.LocationAutoId != string.Empty)
                { return BaseAccessInformation.LocationAutoId; }
                else
                {
                    RedirectToDefaultPage();
                    return string.Empty;
                }
            }
            catch (Exception ex)
            { throw new Exception("Session has expired! Login again", ex); }
        }
    }
    //SystemParameters
    /// <summary>
    /// Gets the base pay period month range.
    /// </summary>
    /// <value>The base pay period month range.</value>
    /// <exception cref="System.Exception">Session has expired! Login again</exception>
    protected string BasePayPeriodMonthRange
    {
        get
        {
            try
            {
                if (BaseSystemParameters != null && BaseSystemParameters.PayPeriodMonthRange != string.Empty)
                { return BaseSystemParameters.PayPeriodMonthRange; }
                else
                {
                    RedirectToDefaultPage();
                    return string.Empty;
                }
            }
            catch (Exception ex)
            { throw new Exception("Session has expired! Login again", ex); }
        }
    }
    /// <summary>
    /// Gets the base pay period from day.
    /// </summary>
    /// <value>The base pay period from day.</value>
    /// <exception cref="System.Exception">Session has expired! Login again</exception>
    protected string BasePayPeriodFromDay
    {
        get
        {
            try
            {
                if (BaseSystemParameters != null && BaseSystemParameters.PayPeriodFromDay != string.Empty)
                { return BaseSystemParameters.PayPeriodFromDay; }
                else
                {
                    RedirectToDefaultPage();
                    return string.Empty;
                }
            }
            catch (Exception ex)
            { throw new Exception("Session has expired! Login again", ex); }
        }
    }
    /// <summary>
    /// Gets the base pay period to day.
    /// </summary>
    /// <value>The base pay period to day.</value>
    /// <exception cref="System.Exception">Session has expired! Login again</exception>
    protected string BasePayPeriodToDay
    {
        get
        {
            try
            {
                if (BaseSystemParameters != null && BaseSystemParameters.PayPeriodToDay != string.Empty)
                { return BaseSystemParameters.PayPeriodToDay; }
                else
                {
                    RedirectToDefaultPage();
                    return string.Empty;
                }
            }
            catch (Exception ex)
            { throw new Exception("Session has expired! Login again", ex); }
        }
    }
    /// <summary>
    /// Gets the base digits after decimal places.
    /// </summary>
    /// <value>The base digits after decimal places.</value>
    /// <exception cref="System.Exception">Session has expired! Login again</exception>
    protected string BaseDigitsAfterDecimalPlaces
    {
        get
        {
            try
            {
                if (BaseSystemParameters != null && BaseSystemParameters.DigitsAfterDecimalPlaces != string.Empty)
                { return BaseSystemParameters.DigitsAfterDecimalPlaces; }
                else
                {
                    RedirectToDefaultPage();
                    return string.Empty;
                }
            }
            catch (Exception ex)
            { throw new Exception("Session has expired! Login again", ex); }
        }
    }
    /// <summary>
    /// Gets the base comma after place.
    /// </summary>
    /// <value>The base comma after place.</value>
    /// <exception cref="System.Exception">Session has expired! Login again</exception>
    protected string BaseCommaAfterPlace
    {
        get
        {
            try
            {
                if (BaseSystemParameters != null && BaseSystemParameters.CommaAfterPlace != string.Empty)
                { return BaseSystemParameters.CommaAfterPlace; }
                else
                {
                    RedirectToDefaultPage();
                    return string.Empty;
                }
            }
            catch (Exception ex)
            { throw new Exception("Session has expired! Login again", ex); }
        }
    }
    /// <summary>
    /// Gets the base round off check.
    /// </summary>
    /// <value>The base round off check.</value>
    /// <exception cref="System.Exception">Session has expired! Login again</exception>
    protected string BaseRoundOffCheck
    {
        get
        {
            try
            {
                if (BaseSystemParameters != null && BaseSystemParameters.RoundOffCheck != string.Empty)
                { return BaseSystemParameters.RoundOffCheck; }
                else
                {
                    RedirectToDefaultPage();
                    return string.Empty;
                }
            }
            catch (Exception ex)
            { throw new Exception("Session has expired! Login again", ex); }
        }
    }
    /// <summary>
    /// Gets the base default currency.
    /// </summary>
    /// <value>The base default currency.</value>
    /// <exception cref="System.Exception">Session has expired! Login again</exception>
    protected string BaseDefaultCurrency
    {
        get
        {
            try
            {
                if (BaseSystemParameters != null && BaseSystemParameters.DefaultCurrency != string.Empty)
                { return BaseSystemParameters.DefaultCurrency; }
                else
                {
                    RedirectToDefaultPage();
                    return string.Empty;
                }
            }
            catch (Exception ex)
            { throw new Exception("Session has expired! Login again", ex); }
        }
    }
    /// <summary>
    /// Gets the base first day of week.
    /// </summary>
    /// <value>The base first day of week.</value>
    /// <exception cref="System.Exception">Session has expired! Login again</exception>
    protected string BaseFirstDayOfWeek
    {
        get
        {
            try
            {
                if (BaseSystemParameters != null && BaseSystemParameters.FirstDayOfWeek != string.Empty)
                { return BaseSystemParameters.FirstDayOfWeek; }
                else
                {
                    RedirectToDefaultPage();
                    return string.Empty;
                }
            }
            catch (Exception ex)
            { throw new Exception("Session has expired! Login again", ex); }
        }
    }
    /// <summary>
    /// Gets the base rota time show.
    /// </summary>
    /// <value>The base rota time show.</value>
    /// <exception cref="System.Exception">Session has expired! Login again</exception>
    protected string BaseRotaTimeShow
    {
        get
        {
            try
            {
                if (BaseSystemParameters != null && BaseSystemParameters.RotaTimeShow != string.Empty)
                { return BaseSystemParameters.RotaTimeShow; }
                else
                {
                    RedirectToDefaultPage();
                    return string.Empty;
                }
            }
            catch (Exception ex)
            { throw new Exception("Session has expired! Login again", ex); }
        }
    }
    /// <summary>
    /// Gets the base schedule start day.
    /// </summary>
    /// <value>The base schedule start day.</value>
    /// <exception cref="System.Exception">Session has expired! Login again</exception>
    protected string BaseScheduleStartDay
    {
        get
        {
            try
            {
                if (BaseSystemParameters != null && BaseSystemParameters.ScheduleStartDay != string.Empty)
                { return BaseSystemParameters.ScheduleStartDay; }
                else
                {
                    RedirectToDefaultPage();
                    return string.Empty;
                }
            }
            catch (Exception ex)
            { throw new Exception("Session has expired! Login again", ex); }
        }
    }
    /// <summary>
    /// Gets the base schedule end day.
    /// </summary>
    /// <value>The base schedule end day.</value>
    /// <exception cref="System.Exception">Session has expired! Login again</exception>
    protected string BaseScheduleEndDay
    {
        get
        {
            try
            {
                if (BaseSystemParameters != null && BaseSystemParameters.ScheduleEndDay != string.Empty)
                { return BaseSystemParameters.ScheduleEndDay; }
                else
                {
                    RedirectToDefaultPage();
                    return string.Empty;
                }
            }
            catch (Exception ex)
            { throw new Exception("Session has expired! Login again", ex); }
        }
    }
    /// <summary>
    /// Gets the type of the base default schedule.
    /// </summary>
    /// <value>The type of the base default schedule.</value>
    /// <exception cref="System.Exception">Session has expired! Login again</exception>
    protected string BaseDefaultScheduleType
    {
        get
        {
            try
            {
                if (BaseSystemParameters != null && BaseSystemParameters.DefaultScheduleType != string.Empty)
                { return BaseSystemParameters.DefaultScheduleType; }
                else
                {
                    RedirectToDefaultPage();
                    return string.Empty;
                }
            }
            catch (Exception ex)
            { throw new Exception("Session has expired! Login again", ex); }
        }
    }
    #endregion

    #region User Page Rights

    /// <summary>
    /// The read access
    /// </summary>
    private bool readAccess;
    /// <summary>
    /// The write access
    /// </summary>
    private bool writeAccess;
    /// <summary>
    /// The modify access
    /// </summary>
    private bool modifyAccess;
    /// <summary>
    /// The delete access
    /// </summary>
    private bool deleteAccess;
    /// <summary>
    /// The authorization access
    /// </summary>
    private bool authorizationAccess;

    /// <summary>
    /// Users the page rights_ get.
    /// </summary>
    /// <param name="strPageName">Name of the STR page.</param>
    /// <param name="strRWMDA">The STR RWMDA.</param>
    protected void UserPageRights_Get(string strPageName, string strRWMDA)
    {
        if (string.IsNullOrEmpty(BaseUserInformation.UserIp) || BaseUserInformation.UserIp != GetClientIpAddress(HttpContext.Current.Request))
        {
            RedirectToDefaultPage();
        }
        if (BaseIsAdmin == "SA")
            {
                readAccess = true;
                writeAccess = true;
                modifyAccess = true;
                deleteAccess = true;
                authorizationAccess = true;
            }
            else
            {
                string strUserId = BaseUserID;

                var objUserManagement = new UserManagement();
                if (strRWMDA == "R") { readAccess = objUserManagement.PageAccessRightGet(strPageName, strUserId, strRWMDA); }
                else if (strRWMDA == "W") { writeAccess = objUserManagement.PageAccessRightGet(strPageName, strUserId, strRWMDA); }
                else if (strRWMDA == "M") { modifyAccess = objUserManagement.PageAccessRightGet(strPageName, strUserId, strRWMDA); }
                else if (strRWMDA == "D") { deleteAccess = objUserManagement.PageAccessRightGet(strPageName, strUserId, strRWMDA); }
                else if (strRWMDA == "A") { authorizationAccess = objUserManagement.PageAccessRightGet(strPageName, strUserId, strRWMDA); }
            }
    }
    /// <summary>
    /// Determines whether [is read allowed] [the specified STR page name].
    /// </summary>
    /// <param name="strPageName">Name of the STR page.</param>
    /// <returns><c>true</c> if [is read allowed] [the specified STR page name]; otherwise, <c>false</c>.</returns>
    public bool IsReadAllowed(string strPageName)
    {
        UserPageRights_Get(strPageName, "R");
        return readAccess;
    }
    /// <summary>
    /// Determines whether [is write allowed] [the specified STR page name].
    /// </summary>
    /// <param name="strPageName">Name of the STR page.</param>
    /// <returns><c>true</c> if [is write allowed] [the specified STR page name]; otherwise, <c>false</c>.</returns>
    public bool IsWriteAllowed(string strPageName)
    {
        UserPageRights_Get(strPageName, "W");
        return writeAccess;
    }
    /// <summary>
    /// Determines whether [is modify allowed] [the specified STR page name].
    /// </summary>
    /// <param name="strPageName">Name of the STR page.</param>
    /// <returns><c>true</c> if [is modify allowed] [the specified STR page name]; otherwise, <c>false</c>.</returns>
    public bool IsModifyAllowed(string strPageName)
    {
        UserPageRights_Get(strPageName, "M");
        return modifyAccess;
    }
    /// <summary>
    /// Determines whether [is delete allowed] [the specified STR page name].
    /// </summary>
    /// <param name="strPageName">Name of the STR page.</param>
    /// <returns><c>true</c> if [is delete allowed] [the specified STR page name]; otherwise, <c>false</c>.</returns>
    public bool IsDeleteAllowed(string strPageName)
    {
        UserPageRights_Get(strPageName, "D");
        return deleteAccess;
    }
    /// <summary>
    /// Determines whether [is authorization allowed] [the specified STR page name].
    /// </summary>
    /// <param name="strPageName">Name of the STR page.</param>
    /// <returns><c>true</c> if [is authorization allowed] [the specified STR page name]; otherwise, <c>false</c>.</returns>
    public bool IsAuthorizationAllowed(string strPageName)
    {
        UserPageRights_Get(strPageName, "A");
        return authorizationAccess;
    }

    #endregion

    #region Common Date Functions

    #region Function To get GreaterDate
    /// <summary>
    /// True if Fromdate &gt; Todate else returns false
    /// </summary>
    /// <param name="fromDate">From date.</param>
    /// <param name="toDate">To date.</param>
    /// <returns>True if Fromdate &gt; Todate else returns false</returns>
    protected bool GetGreaterDate(DateTime fromDate, DateTime toDate)
    {
        return fromDate > toDate;
    }

    /// <summary>
    /// (0 if Fromdate = Todate) (1 if Fromdate is greater then Todate) (2 if Todate is greater then FromDate)
    /// </summary>
    /// <param name="fromDate">From date.</param>
    /// <param name="toDate">To date.</param>
    /// <returns>(0 if Fromdate = Todate) (1 if Fromdate is greater then Todate) (2 if Todate is greater then FromDate)</returns>
    protected int CompareDates(DateTime fromDate, DateTime toDate)
    {
        if (fromDate == toDate)
        { return 0; }
        else if (fromDate > toDate)
        { return 1; }
        else if (fromDate < toDate)
        { return 2; }
        else
        { return 3; }
    }
    #endregion

    #region Function To get Date Format(dd-MMM-yyyy)
    /// <summary>
    /// To get Date Format(dd-MMM-yyyy)
    /// </summary>
    /// <param name="strdate">The strdate.</param>
    /// <returns>date with format dd-MMM-yyyy</returns>
    protected string DateFormat(string strdate)
    {
        var dt = new DateTime();
        string formatedDate;
        if (strdate != string.Empty)
        {
            dt = DateTime.Parse(strdate);
            formatedDate = dt.ToString("dd-MMM-yyyy");
        }
        else
        {
            formatedDate = string.Empty;
        }
        return formatedDate;
    }
    /// <summary>
    /// To get Date Format(dd-MMM-yyyy)
    /// </summary>
    /// <param name="dtdate">The dtdate.</param>
    /// <returns>date with format dd-MMM-yyyy</returns>
    protected string DateFormat(DateTime dtdate)
    {
        var dt = new DateTime();
        string formatedDate;
        if (dtdate != null)
        {
            dt = dtdate;
            formatedDate = dt.ToString("dd-MMM-yyyy");
        }
        else
        {
            formatedDate = string.Empty;
        }

        return formatedDate;
    }
    #endregion

    #region Function to Convert date to null if date=01/01/0001
    /// <summary>
    /// Converts the date to standard.
    /// </summary>
    /// <param name="date">The date.</param>
    /// <returns>System.String.</returns>
    public string ConvertDateToStandard(string date)
    {
        const string strDate = "01/01/0001";
        if ((DateTime.Parse(date)) == (DateTime.Parse(strDate)))
        {
            return null;
        }
        DateTime dt = DateTime.Parse(date);

        return dt.Day + "-" + dt.Month.ToString("MMM") + "-" + dt.Year;
    }

    #endregion

    #region Function To get First date of the Current month and year
    /// <summary>
    /// To get First date of the Current month and year
    /// </summary>
    /// <returns>date(dd-MMM-yyy) dataType string (First date of the Current month and year)</returns>
    public string FirstDateOfCurrentMonth_Get()
    {
        string strFirstDate = "01" + "-" + DateTime.Now.ToString("MMM") + "-" + Convert.ToString(DateTime.Now.Year);
        return strFirstDate;
    }

    #endregion

    #region Function To get Last date of the Current month and year
    /// <summary>
    /// To get Last date of the Current month and year
    /// </summary>
    /// <returns>date(dd-MMM-yyy) dataType string (Last date of the Current month and year)</returns>
    public string LastDateOfCurrentMonth_Get()
    {
        string strLastDate = Convert.ToString(DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month)) + "-" + DateTime.Now.ToString("MMM") + "-" + Convert.ToString(DateTime.Now.Year);
        return strLastDate;
    }

    #endregion

    #region Function To get First date of the Previous month
    /// <summary>
    /// To get First date of the Previous month
    /// </summary>
    /// <returns>date(dd-MMM-yyy) dataType string (First date of the Previous month)</returns>
    public string FirstDateOfPreviousMonth_Get()
    {
        DateTime dtPreviousMonthDate = DateTime.Now.AddMonths(-1);
        string strFirstDate = "01" + "-" + dtPreviousMonthDate.ToString("MMM") + "-" + Convert.ToString(dtPreviousMonthDate.Year);
        return strFirstDate;
    }
    #endregion

    #region Function To get Last date of the Previous month
    /// <summary>
    /// To get Last date of the Previous month
    /// </summary>
    /// <returns>date(dd-MMM-yyy) dataType string (Last date of the Previous month)</returns>
    public string LastDateOfPreviousMonth_Get()
    {
        DateTime dtPreviousMonthDate = DateTime.Now.AddMonths(-1);
        string strLastDate = Convert.ToString(DateTime.DaysInMonth(dtPreviousMonthDate.Year, dtPreviousMonthDate.Month)) + "-" + dtPreviousMonthDate.ToString("MMM") + "-" + Convert.ToString(dtPreviousMonthDate.Year);
        return strLastDate;
    }
    #endregion

    #region Function To get Last date of the Month of a Given Date
    /// <summary>
    /// To get Last date of the month of given Date
    /// </summary>
    /// <param name="strDate">The STR date.</param>
    /// <returns>date(dd-MMM-yyy) dataType string (Last date of the month of a given Date)</returns>
    public string LastDateOfTheMonthOfGivenDate_Get(string strDate)
    {
        DateTime dtDate = DateTime.Parse(strDate);
        string strLastDate = Convert.ToString(DateTime.DaysInMonth(dtDate.Year, dtDate.Month)) + "-" + dtDate.ToString("MMM") + "-" + Convert.ToString(dtDate.Year);
        return strLastDate;
    }
    #endregion

    // Code added by  to Declare common function of Date Time  which take TextBox as input on 17 Oct 2011
    #region Function to convert string to Date Format
    /// <summary>
    /// To Convert String in Text Box To Date Format
    /// </summary>
    /// <param name="txtDate">The TXT date.</param>
    /// <param name="lblErrorMsg">The LBL error MSG.</param>
    /// <returns>Boolean value</returns>
    protected bool ConvertStringToDateFormat(TextBox txtDate, Label lblErrorMsg)
    {
        string date;
        txtDate.BackColor = Color.Empty;
        var objCommon = new Common();
        if (objCommon.IsValidDate(txtDate.Text))
        {
            txtDate.Text = DateTime.Parse(txtDate.Text).ToString("dd-MMM-yyyy");
            return true;
        }
        else
        {
            date = objCommon.ConvertToDate(txtDate.Text);
            if (date == "1")
            {
                lblErrorMsg.Text = Resource.Yearnotincorrectformat;
                txtDate.Text = txtDate.Text;
                txtDate.BackColor = Color.Red;
                return false;
            }
            else if (date == "2")
            {
                lblErrorMsg.Text = Resource.Monthnotincorrectformat;
                txtDate.Text = txtDate.Text;
                txtDate.BackColor = Color.Red;
                return false;
            }
            else if (date == "3")
            {
                lblErrorMsg.Text = Resource.Daynotincorrectformat;
                txtDate.Text = txtDate.Text;
                txtDate.BackColor = Color.Red;
                return false;
            }
            else if (date == "4")
            {
                lblErrorMsg.Text = Resource.Notaleapyear;
                txtDate.Text = txtDate.Text;
                txtDate.BackColor = Color.Red;
                return false;
            }
            else if (date == "5")
            {
                lblErrorMsg.Text = Resource.Numberofdaysnotcorrect; ;
                txtDate.Text = txtDate.Text;
                txtDate.BackColor = Color.Red;
                return false;
            }
            else if (date == "6")
            {
                lblErrorMsg.Text = Resource.Datenotincorrectformat;
                txtDate.Text = txtDate.Text;
                txtDate.BackColor = Color.Red;
                return false;
            }
            else
            {
                txtDate.Text = date;
                txtDate.BackColor = Color.Empty;
                return true;
            }
        }
    }
    // Code added by  to Declare common function of Date Time  which take TextBox as input on 17 Oct 2011
    #endregion

    #endregion

    #region Media Messages
    /// <summary>
    /// Gets the name of the media file.
    /// </summary>
    /// <param name="messageID">The message ID.</param>
    /// <returns>System.String.</returns>
    protected string GetMediaFileName(int messageID)
    {
        switch (messageID)
        {
            case 0: return "MsgInsertSuccessfully";
            case 1: return "MsgDeleteSuccessfully";
            case 2: return "MsgUpdateSuccessfully";
            case 3: return "MsgAlreadyExists";
            case 4: return "MsgNotFound";
            case 5: return "MsgInsertFail";
            case 6: return "MsgDeleteFail";
            case 7: return "MsgUpdateFail";
            case 8: return "MsgDeleteFailRefExists";
            case 11: return "MsgDuplicateRecordFound";
            case 12: return "MsgShiftNotdefined";
            case 14: return "MsgFileNameAlreadyExists";
            case 15: return "MsgSuccessfullyAmend";
            case 16: return "MsgFailedToAmend";
            case 17: return "MsgSuccessfullyAuthorized";
            case 18: return "MsgFailedToAuthorized";
            case 19: return "AlreadyAuthorized";
            case 20: return "SuccessfullyAuthorized";
            case 21: return "MsgCopiedSuccessfully";
            case 22: return "MsgSuccessfullyReverse";
            case 24: return "MsgFailedToAuthorized";
            case 25: return "MsgFailedToAuthorized";
            case 50: return "ErrMsgExceedLicense";
            case 51: return "MsgUserIDNotAvailable";
            case 52: return "MsgSequenceIDnotexists";
            case 53: return "MsgNoAuthorizedContractNumberFound";
            case 54: return "MsgProcessSuccessfullyCompleted";
            case 55: return "msgInvalidShift";
            case 57: return "MsgUpdateFailRefExists";
            //case 58: return "AdjustmentInsertFailed";
            case 59: return "AnyoperationisnotallowedonAuthorizedRota";
            case 60: return "Userhasbeencreatedsuccessfully";
            case 61: return "NoAuthorizedContractExists";
            case 62: return "ScheduleExistsForTheEmp";
            case 63: return "Welcome"; // "NothingToUnAuthorize";
            case 64: return "Welcome"; // "SuccessfullyUnAuthorized";
            case 100: return "Welcome";
            case 65: return "Welcome";//MsgInValidDateDatecannotBeGreaterThanCurrentDate
            case 66: return "Welcome";//MsgRecordsAlreadyLocked
            case 67: return "Welcome";//MsgCanNotLockedScheduleIsAuthorized
            case 68: return "Welcome";//MsgRotaIsAuthorized
            case 69: return "Welcome";//MsgSuccessfullyLocked
            case 70: return "Welcome";//MsgAssignmentSuccessfullyCreated
            case 71: return "Welcome";//MsgAssignmentStartDateShouldBeBetweenMinSOLineStartDateAndMaxSOLineEndDate
            case 72: return "Welcome";//MsgAssignmentAlreadyHasBeenCreatedForThisClientOnThisAsmtIdOnThisLocation
            case 73: return "Welcome";//MsgPleaseDeleteTheExistingRecordsFromScheduleAndExceptions
            case 74: return "Welcome";//MsgSuccessfullyTerminated
            case 75: return "Welcome";//MsgNothingToSave
            case 76: return "Welcome";//MsgDeployedHoursExceedsTheTotalHoursDefinedInsales
            case 77: return "Welcome";//MsgAssignmentStatusIsNotInFreshOrAmendementModeOrAssignmentIsNotCreated
            case 78: return "Welcome";//MsgNoOfShiftAreGreaterThanPersonAllocated
            case 79: return "Welcome";//MsgDeployedHoursExceedsTheTotalHoursDefinedInSales
            case 80: return "Welcome";//MsgMaximumNumberOfShiftYouCanDefineOnPDLineShouldNotBeGreaterThanPersonsAllocated
            case 81: return "Welcome";//MsgDuplicateShiftForWeekIsDefined
            case 82: return "Welcome";//msgInvalidShift;
            case 83: return "Welcome";//MsgRotaAlreadyExistsOnThisShift
            case 84: return "Welcome";//MsgSchedeuleAlreadyExistsOnThisShift
            case 85: return "Welcome";//MsgTotalHoursExceedContractualHrsonPDLine;
            case 86: return "Welcome";//MsgInvalidShiftOnPDLine;
            case 87: return "Welcome";//MsgInsertSuccessfullyWithInvalidShiftOnPDLine;
            case 88: return "Welcome";//MsgInsertSuccessfullyWithHoursExceedContractualHoursOnPDLine;
            case 89: return "Welcome";//MsgUpdateSuccessfullyWithInvalidShiftonPDLine;
            case 90: return "Welcome";//MsgUpdateSuccessfullyWithHoursExceedContractualHoursOnPDLine;
            case 91: return "Welcome"; //Resources.Resource.EmployeeDoesnotBelongTothisLocation;
            case 92: return "Welcome"; //Resources.Resource.EmployeeCategoryDoesNotBelongtothisCalender;
            case 93: return "Welcome"; //Resources.Resource.EmployeeJoiningDateisGreaterThanLeaveCalendarDate;
            case 94: return "Welcome"; //Resources.Resource.EntitlementhasAlreadybeendoneforthisEmployee;
            case 95: return "Welcome"; //Resources.Resource.LeaveDescriptionAlreadyExists;
            case 96: return "Welcome"; //Resources.Resource.LeaveUnitsShouldMoreThanZero;
            case 97: return "Welcome"; //Resources.Resource.LeaveUnitsShouldMoreThanZero;
            case 98: return "Welcome"; //Resources.Resource.LeaveUnitsShouldMoreThanZero;
            case 99: return "Welcome";// Resources.Resource.SalesORAssignmentHasBeenChanged;
            case 102: return "Welcome";// Resources.Resource.ScheduleExists;
            case 115: return "Welcome";// Resources.Resource.LeaveCalenderDoesNotExists;
            case 116: return "Welcome";// Resources.Resource.InvaidLeaveCodeAccordingToGender;
            case 117: return "Welcome";// Resources.Resource.InvalidEmployee;
            case 118: return "PatternSequenceCodeRequired";
            case 311: return "MsgUpdateFail";// Resources.Resource.validityTrainingNotExpired;
            default: return "Welcome";
        }
    }
    /// <summary>
    /// Plays the media message.
    /// </summary>
    /// <param name="MessageID">The message ID.</param>
    protected void PlayMediaMessage(int MessageID)
    {
        //string strMediaFileName;
        //strMediaFileName = GetMediaFileName(MessageID) + ".wav";
        //if (strMediaFileName != "")
        //{
        //    SoundPlayer objPlayer = new SoundPlayer();
        //    objPlayer.SoundLocation = HttpContext.Current.Request.PhysicalApplicationPath.ToString() + "/Media/English/" + strMediaFileName;
        //    objPlayer.Play();

        //    objPlayer = new SoundPlayer();
        //    //objPlayer.Stream = GetEmbeddedResourceStream();
        //    objPlayer.Play();
        //}
    }
    //protected void PlayTextMessage(int MessageID)
    //{
    //    string strMessage = MessageString_Get(MessageID);
    //    SpVoice s = new SpVoice();
    //    SpeechVoiceSpeakFlags f = new SpeechVoiceSpeakFlags();
    //    s.Speak(strMessage, f);
    //    //SpeechSynthesizer speaker = new SpeechSynthesizer();
    //    //speaker.Rate = 1;
    //    //speaker.Volume = 100;
    //    //speaker.Speak(strMessage);
    //}
    //protected void PlayText(string str)
    //{
    //    SpVoice s = new SpVoice();
    //    SpeechVoiceSpeakFlags f = new SpeechVoiceSpeakFlags();
    //    s.Speak(str, f);
    //    //SpeechSynthesizer speaker = new SpeechSynthesizer();
    //    //speaker.Rate = 1;
    //    //speaker.Volume = 100;
    //    //speaker.Speak(str);
    //}
    //protected Stream GetEmbeddedResourceStream()
    //{
    //    System.Reflection.Assembly objAssembly;
    //    Stream soundstream;
    //    objAssembly = System.Reflection.Assembly.LoadFrom(Application.ExecutablePath);
    //    soundstream = objAssembly.GetManifestResourceStream("/Medias/chimes.wav");
    //    return soundstream;
    //}
    #endregion

    #region Function related to payperiod dates
    /// <summary>
    /// Gets the pay periods.
    /// </summary>
    /// <param name="strFromDay">The STR from day.</param>
    /// <param name="strToDay">The STR to day.</param>
    /// <param name="intMonth">The int month.</param>
    /// <param name="intYear">The int year.</param>
    /// <returns>System.String[][].</returns>
    protected string[] GetPayPeriods(string strFromDay, string strToDay, int intMonth, int intYear)
    {
        string strNextMonth;
        string strFromDate;
        string strToDate;

        var date = new DateTime(1900, intMonth, 1);
        string strMonth = date.ToString("MMM");

        if (strFromDay == string.Empty || strToDay == string.Empty)
        {
            strFromDay = "1";
            strToDay = "31";

        }

        //if (int.Parse(strFromDay) > 1 && int.Parse(strFromDay) > int.Parse(strToDay))
        //{
        if (intMonth > 1)
        {
            if (BasePayPeriodMonthRange.Trim().ToLower() == "PreviousToCurrent".Trim().ToString().ToLower())
            {
                var date1 = new DateTime(1900, (intMonth - 1), 1);
                string strPrvMonth = date1.ToString("MMM");
                strFromDate = DateFormat(strFromDay + "-" + strPrvMonth + "-" + intYear.ToString());
                strToDate = DateFormat(strToDay + "-" + strMonth + "-" + intYear.ToString());
            }
            else if (BasePayPeriodMonthRange.Trim().ToLower() == "CurrentToNext".Trim().ToLower())
            {
                var date1 = new DateTime(1900, (intMonth + 1), 1);
                strNextMonth = date1.ToString("MMM");
                strFromDate = DateFormat(strFromDay + "-" + strMonth + "-" + intYear.ToString());
                strToDate = DateFormat(strToDay + "-" + strNextMonth + "-" + intYear.ToString());
            }
            else
            {
                strFromDate = DateFormat(strFromDay + "-" + strMonth + "-" + intYear.ToString());
                strToDate = int.Parse(strToDay) >= 30 ? DateFormat(LastDateOfMonth(strFromDate) + "-" + strMonth + "-" + intYear.ToString()) : DateFormat(strToDay + "-" + strMonth + "-" + intYear.ToString());
            }
        }
        else
        {
            if (BasePayPeriodMonthRange.Trim().ToString().ToLower() == "PreviousToCurrent".Trim().ToString().ToLower())
            {
                strFromDate = DateFormat(strFromDay + "-Dec-" + (intYear - 1).ToString());
                strToDate = DateFormat(strToDay + "-" + strMonth + "-" + intYear.ToString());
            }
            else if (BasePayPeriodMonthRange.Trim().ToLower() == "CurrentToNext".Trim().ToLower())
            {
                strFromDate = DateFormat(strFromDay + "-" + strMonth + "-" + (intYear).ToString());
                var date1 = new DateTime(1900, (intMonth + 1), 1);
                strNextMonth = date1.ToString("MMM");
                strToDate = DateFormat(strToDay + "-" + strNextMonth + "-" + intYear.ToString());
            }
            else
            {
                strFromDate = DateFormat(strFromDay + "-" + strMonth + "-" + (intYear).ToString());
                strToDate = DateFormat(strToDay + "-" + strMonth + "-" + intYear.ToString());
            }
        }

        // }
        //else if (int.Parse(strFromDay) < int.Parse(strToDay))
        //{

        //    strFromDate = DateFormat(strFromDay + "-" + strMonth + "-" + intYear.ToString());
        //if (int.Parse(strToDay) >= 30)
        //{
        //    strToDate = DateFormat(LastDateOfMonth(strFromDate) + "-" + strMonth + "-" + intYear.ToString());
        //}
        //else
        //{
        //    strToDate = DateFormat(strToDay + "-" + strMonth + "-" + intYear.ToString());
        //}

        //}

        var strArray = new string[2];
        strArray[0] = strFromDate;
        strArray[1] = strToDate;

        return strArray;
    }
    /// <summary>
    /// To Check if rota is authorized based on pay period
    /// </summary>
    /// <param name="strFromDate">The STR from date.</param>
    /// <param name="strTodate">The STR todate.</param>
    /// <returns>System.String.</returns>
    protected string GetMonthRangeFromDate(string strFromDate, string strTodate)
    {
        //int intMonth = int.Parse(DateTime.Parse(strFromDate).ToString("MM"));
        if (BasePayPeriodMonthRange.Trim().ToLower() == "CurrentToCurrent".Trim().ToLower())
        {
            return strFromDate;
        }
        if (BasePayPeriodMonthRange.Trim().ToLower() == "PreviousToCurrent".Trim().ToLower())
        {
            //  if (strFromDate != strTodate)
            // {
            return strTodate;
            // }
            //else
            //{
            //    DateTime date1 = new DateTime(1900, (intMonth + 1), 1);
            //    strNextMonth = date1.ToString("MMM");
            //    return strNextMonth;
            //}
        }
        return strTodate;
    }

    /// <summary>
    /// Lasts the date of month.
    /// </summary>
    /// <param name="date1">The date1.</param>
    /// <returns>String.</returns>
    protected String LastDateOfMonth(string date1)
    {
        TimeSpan ts = DateTime.Parse(date1).AddMonths(1) - DateTime.Parse(date1);
        String days = ts.Days.ToString();
        return days;
    }

    #endregion

    #region Function Related To System Parameters

    /// <summary>
    /// Gets the value as per system parameters.
    /// </summary>
    /// <param name="strValue">The STR value.</param>
    /// <param name="intDecimalPlaces">The int decimal places.</param>
    /// <param name="strRoundOffCheck">The STR round off check.</param>
    /// <returns>System.String.</returns>
    protected string GetValueAsPerSystemParameters(string strValue, int intDecimalPlaces, int strRoundOffCheck)
    {
        if (strValue == string.Empty)
        {
            strValue = "0.00";
        }

        string s1 = String.Format(@"{0:n" + strRoundOffCheck + @"}", decimal.Parse(strValue));
        int a = (s1.Length - (s1.IndexOf(".") + 1));
        if ((s1.Length - (s1.IndexOf(".") + 1)) < intDecimalPlaces)
        {
            while ((s1.Length - (s1.IndexOf(".") + 1)) < intDecimalPlaces)
            {
                s1 = s1 + "0";
            }
        }
        if (!string.IsNullOrEmpty(BaseDefaultCurrency))
        {
            s1 = s1.Substring(0, s1.IndexOf(".") + 1) + s1.Substring(s1.IndexOf(".") + 1, intDecimalPlaces);
        }
        else
        {
            s1 = s1.Substring(0, s1.IndexOf(".") + 1) + s1.Substring(s1.IndexOf(".") + 1, intDecimalPlaces);
        }

        return s1;

        //string[] strArray = new string[2];
        //string strReturnValue = string.Empty;
        //string strDecimalpart = string.Empty;
        //char[] splitter = { '.' };
        ////String s = new String(string.Empty);
        //strDecimalpart = Math.Round(decimal.Parse(strValue),strRoundOffCheck).ToString();
        //strArray = strDecimalpart.Split(splitter);

        //String s = String.Format("{0:n}", decimal.Parse(strValue));
        //if (strValue.Contains("."))
        //{
        //    if (strArray[1].Length > intDecimalPlaces)
        //    {
        //        strReturnValue = strArray[0]  + "." + strArray[1].Substring(0, intDecimalPlaces);
        //    }
        //    else
        //    {
        //        strReturnValue = strArray[0] + "." + strArray[1];
        //    }
        //}
        //else
        //{
        //    if (intDecimalPlaces == 2)
        //    {
        //        strReturnValue = strArray[0] + "." + "00";
        //    }
        //    else if (intDecimalPlaces == 3)
        //    {
        //        strReturnValue = strArray[0] + "." + "000";
        //    }
        //    else if (intDecimalPlaces == 4)
        //    {
        //        strReturnValue = strArray[0] + "." + "0000";
        //    }
        //    else 
        //    {
        //        strReturnValue = strArray[0] + "." + "00000";
        //    }

        //}
        //return strReturnValue;
    }

    #endregion


    /// <summary>
    /// Handles the PreInit event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected void Page_PreInit(object sender, EventArgs e)
    {
        if (Page.Request.ServerVariables["http_user_agent"].ToLower().Contains("safari"))
        {
            Page.ClientTarget = "uplevel";
        }
    }

    #region function for checking numeric value
    /// <summary>
    /// Determines whether the specified the value is integer.
    /// </summary>
    /// <param name="theValue">The value.</param>
    /// <returns><c>true</c> if the specified the value is integer; otherwise, <c>false</c>.</returns>
    public static bool IsInteger(string theValue)
    {
        try
        {
            int number;
            //Convert.ToInt32(theValue);
            return Int32.TryParse(theValue, out number);
        }
        catch
        {
            return false;
        }
    }
    #endregion


    /// <summary>
    /// Shows the specified message.
    /// </summary>
    /// <param name="message">The message.</param>
    public void Show(string message)
    {
        // Cleans the message to allow single quotation marks 
        string cleanMessage = message.Replace("'", "\\'");
        // string script = "<script type=\"text/javascript\">alert('" + cleanMessage + "');</script>";
        var page = HttpContext.Current.CurrentHandler as Page;
        if (page != null)
        {
            ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('" + cleanMessage + "');", true);
        }
    }

    /// <summary>
    /// Gets the name of the month.
    /// </summary>
    /// <param name="intMonth">The int month.</param>
    /// <returns>System.String.</returns>
    public string GetMonthName(int intMonth)
    {
        if (intMonth == 1 || intMonth == 01)
        {
            return "JAN";
        }
        else if (intMonth == 2 || intMonth == 02)
        {
            return "FEB";
        }
        else if (intMonth == 3 || intMonth == 03)
        {
            return "MAR";
        }
        else if (intMonth == 4 || intMonth == 04)
        {
            return "APR";
        }
        else if (intMonth == 5 || intMonth == 05)
        {
            return "MAY";
        }
        else if (intMonth == 6 || intMonth == 06)
        {
            return "JUN";
        }
        else if (intMonth == 7 || intMonth == 07)
        {
            return "JUL";
        }
        else if (intMonth == 8 || intMonth == 08)
        {
            return "AUG";
        }
        else if (intMonth == 9 || intMonth == 09)
        {
            return "SEP";
        }
        else if (intMonth == 10)
        {
            return "OCT";
        }
        else if (intMonth == 11)
        {
            return "NOV";
        }
        else
        {
            return "DEC";
        }
    }


    // sync Secure trax 


    /// <summary>
    /// Dates the time format.
    /// </summary>
    /// <param name="dtdate">The dtdate.</param>
    /// <returns>System.String.</returns>
    protected string DateTimeFormat(DateTime dtdate)
    {
        string formatedDate;
        {
            DateTime dt = dtdate;
            formatedDate = dt.ToString("dd-MMM-yyyy HH:mm:ss");
        }

        return formatedDate;
    }

    /// <summary>
    /// Gets the ClientIPAddress of the current PC.
    /// </summary>
    /// <param name="httpRequest">The HTTP request.</param>
    /// <returns>System.String.</returns>
    public string GetClientIpAddress(HttpRequest httpRequest)
    {
        string originalIp = httpRequest.ServerVariables["HTTP_X_FORWARDED_FOR"];
        string remoteIp = httpRequest.ServerVariables["REMOTE_ADDR"];
        if (originalIp != null && originalIp.Trim().Length > 0)
        {
            return originalIp + "(" + remoteIp + ")"; //Lets return both the IPs.
        }
        return remoteIp;
    }

    /// <summary>
    /// Redirects to default page.
    /// </summary>
    protected void RedirectToDefaultPage()
    {
      //  HttpContext.Current.Response.Redirect("~/default.aspx", true);
        if (!Request.Path.ToLower().Contains("default.aspx"))
        {
            HttpContext.Current.Response.Redirect("../default.aspx", true);
        }
        //return;
    }

    /// <summary>
    /// Exceptions the log.
    /// </summary>
    /// <param name="ex">The ex.</param>
    protected void ExceptionLog(Exception ex)
    {
        if (!string.IsNullOrEmpty(BaseUserID))
        {
            if (ex != null && ex.InnerException != null)
            {
                var objEx = new BL.ExceptionLogs();
                objEx.ExceptionLog(
                    ex.InnerException.ToString() + Environment.NewLine + "Stack Trace: " + ex.StackTrace, BaseUserID);
            }
        }
    }
   

}
