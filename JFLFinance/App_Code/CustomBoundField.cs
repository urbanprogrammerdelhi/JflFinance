// ***********************************************************************
// Assembly         :
// Author           : 
// Created          : 09-13-2013
//
// Last Modified By : 
// Last Modified On : 02-17-2014
// ***********************************************************************
// <copyright file="CustomBoundField.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
/// <summary>
/// Custom Bound Field Class
/// </summary>
public class CustomBoundField : DataControlField
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CustomBoundField"/> class.
    /// </summary>
    public CustomBoundField()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    #region Public Properties

    /// <summary>
    /// This property describe weather the column should be an editable column or non editable column.
    /// </summary>
    /// <value><c>true</c> if editable; otherwise, <c>false</c>.</value>
    public bool Editable
    {
        get
        {
            object value = base.ViewState["Editable"];
            if (value != null)
            {
                return Convert.ToBoolean(value);
            }
            else
            {
                return true;
            }
        }
        set
        {
            base.ViewState["Editable"] = value;
            this.OnFieldChanged();
        }
    }

    /// <summary>
    /// This property is to describe weather to display a check box or not.
    /// This property works in association with Editable.
    /// </summary>
    /// <value><c>true</c> if [show check box]; otherwise, <c>false</c>.</value>
    public bool ShowCheckBox
    {
        get
        {
            object value = base.ViewState["ShowCheckBox"];
            if (value != null)
            {
                return Convert.ToBoolean(value);
            }
            else
            {
                return false;
            }
        }
        set
        {
            base.ViewState["ShowCheckBox"] = value;
            this.OnFieldChanged();
        }
    }

    /// <summary>
    /// This property describe column name, which acts as the primary data source for the column.
    /// The data that is displayed in the column will be retreived from the given column name.
    /// </summary>
    /// <value>The data field.</value>
    public string DataField
    {
        get
        {
            object value = base.ViewState["DataField"];
            if (value != null)
            {
                return value.ToString();
            }
            else
            {
                return string.Empty;
            }
        }
        set
        {
            base.ViewState["DataField"] = value;
            this.OnFieldChanged();
        }
    }
    #endregion

    #region Overriden Life Cycle Methods
    /// <summary>
    /// Overriding the CreateField method is mandatory if you derive from the DataControlField.
    /// </summary>
    /// <returns>An empty <see cref="T:System.Web.UI.WebControls.DataControlField" />-derived object.</returns>
    protected override DataControlField CreateField()
    {
        return new BoundField();
    }

    /// <summary>
    /// Adds text controls to a cell's controls collection. Base method of DataControlField is
    /// called to import much of the logic that deals with header and footer rendering.
    /// </summary>
    /// <param name="cell">A reference to the cell</param>
    /// <param name="cellType">The type of the cell</param>
    /// <param name="rowState">State of the row being rendered</param>
    /// <param name="rowIndex">Index of the row being rendered</param>
    public override void InitializeCell(DataControlFieldCell cell, DataControlCellType cellType, DataControlRowState rowState, int rowIndex)
    {
        //Call the base method.
        base.InitializeCell(cell, cellType, rowState, rowIndex);

        switch (cellType)
        {
            case DataControlCellType.DataCell:
                this.InitializeDataCell(cell, rowState);
                break;
            case DataControlCellType.Footer:
                this.InitializeFooterCell(cell, rowState);
                break;
            case DataControlCellType.Header:
                this.InitializeHeaderCell(cell, rowState);
                break;
        }
    }
    #endregion

    #region Custom Protected Methods
    /// <summary>
    /// Determines which control to bind to data. In this a hyperlink control is bound regardless
    /// of the row state. The hyperlink control is then attached to a DataBinding event handler
    /// to actually retrieve and display data.
    /// Note: This control was built with the assumption that it will not be used in a gridview
    /// control that uses inline editing. If you are building a custom data control field and
    /// using this code for reference purposes key in mind that if your control needs to support
    /// inline editing you must determine which control to bind to data based on the row state.
    /// </summary>
    /// <param name="cell">A reference to the cell</param>
    /// <param name="rowState">State of the row being rendered</param>
    protected void InitializeDataCell(DataControlFieldCell cell, DataControlRowState rowState)
    {
        //Check to see if the column is a editable and does not show the checkboxes.
        if (Editable & !ShowCheckBox)
        {
            string ID = Guid.NewGuid().ToString();
            TextBox txtBox = new TextBox();
            txtBox.Columns = 5;
            txtBox.ID = ID;
            txtBox.DataBinding += new EventHandler(txtBox_DataBinding);

            cell.Controls.Add(txtBox);
        }
        else
        {
            if (ShowCheckBox)
            {
                CheckBox chkBox = new CheckBox();
                chkBox.DataBinding += new EventHandler(chkBox_DataBinding);
                chkBox.CssClass = "cssCheckBox";
                cell.Controls.Add(chkBox);
            }
            else
            {
                Label lblText = new Label();
                lblText.DataBinding += new EventHandler(lblText_DataBinding);
                cell.Controls.Add(lblText);
            }
        }
    }

    /// <summary>
    /// Handles the DataBinding event of the lblText control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    void lblText_DataBinding(object sender, EventArgs e)
    {
        // get a reference to the control that raised the event
        Label target = (Label)sender;
        Control container = target.NamingContainer;

        // get a reference to the row object
        object dataItem = DataBinder.GetDataItem(container);

        // get the row's value for the named data field only use Eval when it is neccessary
        // to access child object values, otherwise use GetPropertyValue. GetPropertyValue
        // is faster because it does not use reflection
        object dataFieldValue = null;

        if (this.DataField.Contains("."))
        {
            dataFieldValue = DataBinder.Eval(dataItem, this.DataField);
        }
        else
        {
            dataFieldValue = DataBinder.GetPropertyValue(dataItem, this.DataField);
        }

        // set the table cell's text. check for null values to prevent ToString errors
        if (dataFieldValue != null)
        {
                target.Text = dataFieldValue.ToString();
        }
    }

    /// <summary>
    /// Handles the DataBinding event of the chkBox control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    void chkBox_DataBinding(object sender, EventArgs e)
    {
        // get a reference to the control that raised the event
        CheckBox target = (CheckBox)sender;
        Control container = target.NamingContainer;

        // get a reference to the row object
        object dataItem = DataBinder.GetDataItem(container);

        // get the row's value for the named data field only use Eval when it is neccessary
        // to access child object values, otherwise use GetPropertyValue. GetPropertyValue
        // is faster because it does not use reflection
        object dataFieldValue = null;


        BL.Common objCommon = new BL.Common();
        if (objCommon.IsValidDate(this.DataField))
        {
            dataFieldValue = DataBinder.GetPropertyValue(dataItem, this.DataField);
        }
        else
        {
            if (this.DataField.Contains("."))
            {
                dataFieldValue = DataBinder.Eval(dataItem, this.DataField);
            }
            else
            {
                dataFieldValue = DataBinder.GetPropertyValue(dataItem, this.DataField);
            }
        }

        // set the table cell's text. check for null values to prevent ToString errors
        if (dataFieldValue != null)
        {
            target.Checked = bool.Parse(dataFieldValue.ToString());
            target.ToolTip = this.DataField;
        }
    }

    /// <summary>
    /// Initializes the footer cell.
    /// </summary>
    /// <param name="cell">The cell.</param>
    /// <param name="rowState">State of the row.</param>
    protected void InitializeFooterCell(DataControlFieldCell cell, DataControlRowState rowState)
    {
        CheckBox chkBox = new CheckBox();
        cell.Controls.Add(chkBox);
    }

    /// <summary>
    /// Initializes the header cell.
    /// </summary>
    /// <param name="cell">The cell.</param>
    /// <param name="rowState">State of the row.</param>
    protected void InitializeHeaderCell(DataControlFieldCell cell, DataControlRowState rowState)
    {
        Label lbl = new Label();

        if (char.IsNumber(char.Parse(this.DataField.ToString().Substring(0, 1))))
        {
            lbl.Text = this.DataField.ToString().Substring(0, 2);
        }
        else
        {
            lbl.Text = this.DataField;
        }
        cell.Controls.Add(lbl);
    }

    /// <summary>
    /// Handles the DataBinding event of the txtBox control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    void txtBox_DataBinding(object sender, EventArgs e)
    {
        // get a reference to the control that raised the event
        TextBox target = (TextBox)sender;
        Control container = target.NamingContainer;

        // get a reference to the row object
        object dataItem = DataBinder.GetDataItem(container);

        // get the row's value for the named data field only use Eval when it is neccessary
        // to access child object values, otherwise use GetPropertyValue. GetPropertyValue
        // is faster because it does not use reflection
        object dataFieldValue = null;

        if (this.DataField.Contains("."))
        {
            dataFieldValue = DataBinder.Eval(dataItem, this.DataField);
        }
        else
        {
            dataFieldValue = DataBinder.GetPropertyValue(dataItem, this.DataField);
        }

        // set the table cell's text. check for null values to prevent ToString errors
        if (dataFieldValue != null)
        {
            target.Text = dataFieldValue.ToString();
        }
    }
    #endregion
}