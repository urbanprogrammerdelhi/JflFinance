// ***********************************************************************
// Assembly         :
// Author           : 
// Created          : 09-13-2013
//
// Last Modified By : 
// Last Modified On : 03-14-2014
// ***********************************************************************
// <copyright file="DynamicTemplate.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Collections;
/// <summary>
/// Summary description for DynamicTemplate
/// </summary>
public class DynamicTemplate : System.Web.UI.ITemplate
{

    /// <summary>
    /// The template type
    /// </summary>
    System.Web.UI.WebControls.ListItemType templateType;
    /// <summary>
    /// The ht controls
    /// </summary>
    System.Collections.Hashtable htControls = new System.Collections.Hashtable();
    /// <summary>
    /// The ht bind properties names
    /// </summary>
    System.Collections.Hashtable htBindPropertiesNames = new System.Collections.Hashtable();
    /// <summary>
    /// The ht bind expression
    /// </summary>
    System.Collections.Hashtable htBindExpression = new System.Collections.Hashtable();

    /// <summary>
    /// Initializes a new instance of the <see cref="DynamicTemplate"/> class.
    /// </summary>
    /// <param name="type">The type.</param>
    public DynamicTemplate(System.Web.UI.WebControls.ListItemType type)
    {
        templateType = type;
    }

    /// <summary>
    /// Adds the control.
    /// </summary>
    /// <param name="wbControl">The wb control.</param>
    /// <param name="BindPropertyName">Name of the bind property.</param>
    /// <param name="BindExpression">The bind expression.</param>
    public void AddControl(WebControl wbControl, String BindPropertyName, String BindExpression)
    {
        htControls.Add(htControls.Count, wbControl);
        htBindPropertiesNames.Add(htBindPropertiesNames.Count, BindPropertyName);
        htBindExpression.Add(htBindExpression.Count, BindExpression);

    }

    /// <summary>
    /// When implemented by a class, defines the <see cref="T:System.Web.UI.Control" /> object that child controls and templates belong to. These child controls are in turn defined within an inline template.
    /// </summary>
    /// <param name="container">The <see cref="T:System.Web.UI.Control" /> object to contain the instances of controls from the inline template.</param>
    public void InstantiateIn(System.Web.UI.Control container)
    {
        PlaceHolder ph = new PlaceHolder();

        for (int i = 0; i < htControls.Count; i++)
        {

            //clone control 
            Control cntrl = CloneControl((Control)htControls[i]);

            switch (templateType)
            {
                case ListItemType.Header:
                    break;
                case ListItemType.Item:
                    ph.Controls.Add(cntrl);
                    break;
                case ListItemType.AlternatingItem:
                    ph.Controls.Add(cntrl);
                    ph.DataBinding += new EventHandler(Item_DataBinding);
                    break;
                case ListItemType.Footer:
                    break;
            }
        }
        ph.DataBinding += new EventHandler(Item_DataBinding);

        container.Controls.Add(ph);

    }
    /// <summary>
    /// Handles the DataBinding event of the Item control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    public void Item_DataBinding(object sender, System.EventArgs e)
    {
        PlaceHolder ph = (PlaceHolder)sender;
        GridViewRow ri = (GridViewRow)ph.NamingContainer;
        for (int i = 0; i < htControls.Count; i++)
        {
            if (htBindPropertiesNames[i].ToString().Length > 0)
            {
                Control tmpCtrl = (Control)htControls[i];
                String item1Value = DataBinder.Eval(ri.DataItem, htBindExpression[i].ToString()).ToString();
                Control ctrl = ph.FindControl(tmpCtrl.ID);
                Type t = ctrl.GetType();
                System.Reflection.PropertyInfo pi = t.GetProperty(htBindPropertiesNames[i].ToString());

                pi.SetValue(ctrl, item1Value.ToString().Trim(), null);
            }

        }
    }

    /// <summary>
    /// Clones the control.
    /// </summary>
    /// <param name="src_ctl">The SRC_CTL.</param>
    /// <returns>Control.</returns>
    private Control CloneControl(System.Web.UI.Control src_ctl)
    {
        Type t = src_ctl.GetType();
        Object obj = Activator.CreateInstance(t);
        Control dst_ctl = (Control)obj;
        PropertyDescriptorCollection src_pdc = TypeDescriptor.GetProperties(src_ctl);
        PropertyDescriptorCollection dst_pdc = TypeDescriptor.GetProperties(dst_ctl);

        for (int i = 0; i < src_pdc.Count; i++)
        {

            if (src_pdc[i].Attributes.Contains(DesignerSerializationVisibilityAttribute.Content))
            {

                object collection_val = src_pdc[i].GetValue(src_ctl);
                if ((collection_val is IList) == true)
                {
                    foreach (object child in (IList)collection_val)
                    {
                        Control new_child = CloneControl(child as Control);
                        object dst_collection_val = dst_pdc[i].GetValue(dst_ctl);
                        ((IList)dst_collection_val).Add(new_child);
                    }
                }
            }
            else
            {
                dst_pdc[src_pdc[i].Name].SetValue(dst_ctl, src_pdc[i].GetValue(src_ctl));
            }
        }

        return dst_ctl;

    }
}