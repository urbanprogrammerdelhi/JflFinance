using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;


public partial class MultipleSelection : System.Web.UI.UserControl
{

    protected void Page_Load(object sender, EventArgs e)
    {
        LoadJScript();
        LoadCss();

        //add attributes
        CheckBoxListExCtrl1.Attributes.Add("onclick", "readCheckBoxList('" +
                    CheckBoxListExCtrl1.ClientID + "','" + MultiSelectDDL.ClientID + "','" +
                    hf_checkBoxText.ClientID + "','" +
                    hf_checkBoxValue.ClientID + "','" + hf_checkBoxSelIndex.ClientID + "');");

        //PanelPopUp.Attributes.Add("onmouseout", "san('" + PanelPopUp.ClientID + "');");
        //MultiSelectDDL.Attributes.Add("onmousemove", "showIE6Tooltip();");
        //MultiSelectDDL.Attributes.Add("onmouseout", "hideIE6Tooltip();");

        if (!string.IsNullOrEmpty(hf_checkBoxValue.Value))
        {
            SetDropDownListText(hf_checkBoxValue.Value);
        }

        if (!string.IsNullOrEmpty(hf_checkBoxText.Value))
        {
            SetToolTip(hf_checkBoxText.Value);
        }
    }

    //selected checkbox value
    public string sValue
    {
        get { return hf_checkBoxValue.Value; }
    }

    //selected checkbox text
    public string sText
    {
        get { return hf_checkBoxText.Value; }
    }

    //selected checkbox text
    public string selectedIndex
    {
        get { return hf_checkBoxSelIndex.Value; }
        set { SetCheckBoxList(value); }
    }

    //load style css
    internal void LoadCss()
    {
        //prevent loading multiple css style sheet
        HtmlControl css = null;
        if (Session["MultipleSelectionDDLCSSID"] != null)
        {
            css = Page.Header.FindControl(Session["MultipleSelectionDDLCSSID"] as string) as HtmlControl;
        }

        if (css == null)
        {
            //load the style sheet
            HtmlLink cssLink = new HtmlLink();
            cssLink.ID = "MultipleSelectionDDLCSSID";
            cssLink.Href = ResolveUrl("~/MS_Control/MultipleSelectionDDLCSS.css");

            cssLink.Attributes.Add("rel", "stylesheet");
            cssLink.Attributes.Add("type", "text/css");

            // Add the HtmlLink to the Head section of the page.
            Page.Header.Controls.Add(cssLink);

            Session["MultipleSelectionDDLCSSID"] = cssLink.ID;
        }
    }

    //load the javascript
    internal void LoadJScript()
    {
        ClientScriptManager script = Page.ClientScript;
        //prevent duplicate script
        if (!script.IsStartupScriptRegistered(this.GetType(), "MultipleSelectionDDLJS"))
        {
            script.RegisterStartupScript(this.GetType(), "MultipleSelectionDDLJS",
            "<script type='text/javascript' src='" + ResolveUrl("~/MS_Control/MultipleSelectionDDLJS.js") + "'></script>");
        }
    }

    //bind the checkboxlist
    public void CreateCheckBox(DataTable dt, string dataTextField, string dataValueField)
    {
        CheckBoxListExCtrl1.DataSource = dt;
        CheckBoxListExCtrl1.DataTextField = dataTextField; // "Text";
        CheckBoxListExCtrl1.DataValueField = dataValueField;// "Value";
        CheckBoxListExCtrl1.DataBind();

        SetDropDownListText("Select");
    }
    
    internal void SetDropDownListText(string txt)
    {
        MultiSelectDDL.Items.Clear();
        MultiSelectDDL.Items.Add(new ListItem(txt));
    }

    internal void SetToolTip(string title)
    {
        MultiSelectDDL.Attributes.Add("title", title);
    }

    //check the checkboxlist
    public void SetCheckBoxList(string index)
    {
        string[] strArray;
        strArray = index.Split(@",".ToCharArray());
        string chkBoxIndex = string.Empty;
        string chkBoxValue = string.Empty;
        string chkBoxText = string.Empty;

        if (strArray.Length > 0)
        {
            int result;
            foreach (string s in strArray)
            {
                result = 0;

                if (int.TryParse(s, out result))
                {
                    CheckBoxListExCtrl1.Items[result].Selected = true;

                    //index
                    if (chkBoxIndex.Length > 0)
                        chkBoxIndex += ", ";

                    chkBoxIndex += result.ToString();

                    //value
                    if (chkBoxValue.Length > 0)
                        chkBoxValue += ", ";

                    chkBoxValue += CheckBoxListExCtrl1.Items[result].Value;

                    //text
                    if (chkBoxText.Length > 0)
                        chkBoxText += ", ";

                    chkBoxText += CheckBoxListExCtrl1.Items[result].Text;

                }
            }

            SetDropDownListText(chkBoxValue);
            SetToolTip(chkBoxText);
            hf_checkBoxSelIndex.Value = chkBoxIndex;
            hf_checkBoxText.Value = chkBoxText;
            hf_checkBoxValue.Value = chkBoxValue;
        }
    }

    public event EventHandler LostFosus; // public event

    private void OnTextChanged(Object sender, EventArgs e)
    {
        LostFosus(this, EventArgs.Empty); // Trigger event!
    }
}
