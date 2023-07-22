//---------------------------------------------------
//     Copyright (c) 2007 Jeffrey Bazinet, VWD-CMS 
//     http://www.vwd-cms.com/  All rights reserved.
//---------------------------------------------------

using System;
using System.Collections.Specialized;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace VwdCms
{
    // this enum tells ths SplitterBar what technique to 
    // use when hiding IFrames. IFrames capture mouse 
    // events which prevent the SplitterBar from functioning
    // properly
    public enum SplitterBarIFrameHiding
    {
        DoNotHide, // don't hide IFrames, this is really for testing, debugging
        UseVisibility, // use iframe.style.visibility = "hidden"
        UseDisplay // use iframe.style.display = "none"
    }

    public enum SplitterBarOrientations
    {
        Vertical,
        Horizontal
    }

    public class SplitterBar : Panel, INamingContainer, IPostBackDataHandler
    {
        private string _backgroundColor;
        private string _bottomResizeTargets = string.Empty; // semi-colon delimited
        private SplitterBarIFrameHiding _iframeHiding = SplitterBarIFrameHiding.UseVisibility;
        private string _leftResizeTargets = string.Empty; // semi-colon delimited
        private SplitterBarOrientations _orientation = SplitterBarOrientations.Vertical;
        private string _rightResizeTargets = string.Empty; // semi-colon delimited
        private int _splitterHeight = 6;
        //private int _maxWidth = 0; // pixels, max size of LeftResizeTarget
        //private int _minWidth = 0; // pixels, min size of LeftResizeTarget
        //private int _maxHeight = 0; // pixels, max size of TopResizeTarget
        //private int _minHeight = 0; // pixels, min size of TopResizeTarget
        private int _splitterWidth = 6;
        private string _topResizeTargets = string.Empty; // semi-colon delimited
        protected HtmlInputHidden hdnHeight;
        protected HtmlInputHidden hdnMaxHeight;
        protected HtmlInputHidden hdnMaxWidth;
        protected HtmlInputHidden hdnMinHeight;
        protected HtmlInputHidden hdnMinWidth;
        protected HtmlInputHidden hdnWidth;

        public SplitterBar()
        {
            TotalHeight = 0;
            TotalWidth = 0;
            DebugElement = null;
            OnDoubleClick = null;
            OnResizeComplete = null;
            OnResize = null;
            OnResizeStart = null;
            BackgroundColorLimit = null;
            BackgroundColorResizing = null;
            BackgroundColorHilite = null;
            DynamicResizing = false;
            SaveHeightToElement = null;
            SaveWidthToElement = null;
        }

        public SplitterBarOrientations Orientation
        {
            get { return _orientation; }
            set { _orientation = value; }
        }

        public string LeftColumnWidth
        {
            get
            {
                AddCompositeControls();
                return hdnWidth.Value;
            }
            set
            {
                AddCompositeControls();
                hdnWidth.Value = value;
                ResizeTargetControls();
            }
        }

        public string RightColumnWidth
        {
            get
            {
                var rcWidth = string.Empty;
                var total = TotalWidth;
                if (total != 0)
                {
                    var width = 0;
                    if (!string.IsNullOrEmpty(LeftColumnWidth))
                    {
                        width = Convert.ToInt32(LeftColumnWidth.Replace("px", string.Empty));
                        width = total - width;
                        width = (width < 1) ? 1 : width;
                        rcWidth = width + "px";
                    }
                }
                return rcWidth;
            }
        }

        public string SaveWidthToElement { get; set; }

        public string TopRowHeight
        {
            get
            {
                AddCompositeControls();
                return hdnHeight.Value;
                //string height = "100px"; // default value
                //if(!string.IsNullOrEmpty(this.hdnHeight.Value))
                //{
                //    height = this.hdnHeight.Value;
                //}
                //else if (this.MinHeight > 0)
                //{
                //    height = this.MinHeight.ToString() + "px";
                //}
                //return height;
            }
            set
            {
                AddCompositeControls();
                hdnHeight.Value = value;
                ResizeTargetControls();
            }
        }

        public string BottomRowHeight
        {
            get
            {
                var rcHeight = string.Empty;
                var total = TotalHeight;
                if (total != 0)
                {
                    var height = 0;
                    if (!string.IsNullOrEmpty(TopRowHeight))
                    {
                        height = Convert.ToInt32(TopRowHeight.Replace("px", string.Empty));
                        height = total - height;
                        height = (height < 1) ? 1 : height;
                        rcHeight = height + "px";
                    }
                }
                return rcHeight;
            }
        }

        public string SaveHeightToElement { get; set; }

        public string LeftResizeTargets
        {
            get { return _leftResizeTargets; }
            set { _leftResizeTargets = value; }
        }

        public string RightResizeTargets
        {
            get { return _rightResizeTargets; }
            set { _rightResizeTargets = value; }
        }

        public string TopResizeTargets
        {
            get { return _topResizeTargets; }
            set { _topResizeTargets = value; }
        }

        public string BottomResizeTargets
        {
            get { return _bottomResizeTargets; }
            set { _bottomResizeTargets = value; }
        }

        public bool DynamicResizing { get; set; }

        public string BackgroundColor
        {
            get { return _backgroundColor; }
            set
            {
                _backgroundColor = value;
                Style.Add("background-color", _backgroundColor);
            }
        }

        public string BackgroundColorHilite { get; set; }
        public string BackgroundColorResizing { get; set; }
        public string BackgroundColorLimit { get; set; }
        public string OnResizeStart { get; set; }
        public string OnResize { get; set; }
        public string OnResizeComplete { get; set; }
        public string OnDoubleClick { get; set; }
        public string DebugElement { get; set; }

        public int MinWidth
        {
            //get { return _minWidth; }
            //set { _minWidth = value; }
            get
            {
                AddCompositeControls();
                return GetInt32(hdnMinWidth.Value);
            }
            set
            {
                AddCompositeControls();
                hdnMinWidth.Value = Convert.ToString(value) + "px";
            }
        }

        public int MaxWidth
        {
            //get { return _maxWidth; }
            //set { _maxWidth = value; }
            get
            {
                AddCompositeControls();
                return GetInt32(hdnMaxWidth.Value);
            }
            set
            {
                AddCompositeControls();
                hdnMaxWidth.Value = Convert.ToString(value) + "px";
            }
        }

        public int TotalWidth { get; set; }

        public int SplitterWidth
        {
            get { return _splitterWidth; }
            set { _splitterWidth = value; }
        }

        public int MinHeight
        {
            //get { return _minHeight; }
            //set { _minHeight = value; }
            get
            {
                AddCompositeControls();
                return GetInt32(hdnMinHeight.Value);
            }
            set
            {
                AddCompositeControls();
                hdnMinHeight.Value = Convert.ToString(value) + "px";
            }
        }

        public int MaxHeight
        {
            //get { return _maxHeight; }
            //set { _maxHeight = value; }
            get
            {
                AddCompositeControls();
                return GetInt32(hdnMaxHeight.Value);
            }
            set
            {
                AddCompositeControls();
                hdnMaxHeight.Value = Convert.ToString(value) + "px";
            }
        }

        public int TotalHeight { get; set; }

        public int SplitterHeight
        {
            get { return _splitterHeight; }
            set { _splitterHeight = value; }
        }

        public SplitterBarIFrameHiding IFrameHiding
        {
            get { return _iframeHiding; }
            set { _iframeHiding = value; }
        }

        // IPostBackDataHandler Members

        bool IPostBackDataHandler.LoadPostData(string postDataKey, NameValueCollection postCollection)
        {
            return LoadPostData(postDataKey, postCollection);
        }

        void IPostBackDataHandler.RaisePostDataChangedEvent()
        {
            //not implemented
        }

        protected override void OnLoad(EventArgs e)
        {
            Page.RegisterRequiresPostBack(this);
            AddCompositeControls();
            RegisterPageStartupScript();
            ResizeTargetControls();

            base.OnLoad(e);
        }

        public void ResizeTargetControls()
        {
            if (Orientation == SplitterBarOrientations.Vertical)
            {
                SetTargetControlWidths();
            }
            else if (Orientation == SplitterBarOrientations.Horizontal)
            {
                SetTargetControlHeights();
            }
        }

        private void SetTargetControlWidths()
        {
            if (Page.IsPostBack)
            {
                Control[] targets = null;
                string width = null;

                // set the width of the controls in the 
                // LeftResizeTargets
                width = LeftColumnWidth;
                if (!string.IsNullOrEmpty(width))
                {
                    targets = GetTargetControls(LeftResizeTargets);
                    if (targets != null && targets.Length > 0)
                    {
                        foreach (var c in targets)
                        {
                            SetControlWidth(c, width);
                        }
                    }
                }

                // set the width of the controls in the 
                // RightResizeTargets
                width = RightColumnWidth;
                if (!string.IsNullOrEmpty(width))
                {
                    targets = GetTargetControls(RightResizeTargets);
                    if (targets != null && targets.Length > 0)
                    {
                        foreach (var c in targets)
                        {
                            SetControlWidth(c, width);
                        }
                    }
                }
            }
        }

        private void SetControlWidth(Control control, string width)
        {
            if (control != null)
            {
                if (control is WebControl)
                {
                    var wc = (WebControl) control;
                    wc.Style.Add("width", width);
                }
                else if (control is HtmlControl)
                {
                    var hc = (HtmlControl) control;
                    hc.Style.Add("width", width);
                }
            }
        }

        private void SetTargetControlHeights()
        {
            if (Page.IsPostBack)
            {
                Control[] targets = null;
                string height = null;

                // set the height of the controls in the 
                // LeftResizeTargets
                height = TopRowHeight;
                if (!string.IsNullOrEmpty(height))
                {
                    targets = GetTargetControls(TopResizeTargets);
                    if (targets != null && targets.Length > 0)
                    {
                        foreach (var c in targets)
                        {
                            SetControlHeight(c, height);
                        }
                    }
                }

                // set the height of the controls in the 
                // BottomResizeTargets
                height = BottomRowHeight;
                if (!string.IsNullOrEmpty(height))
                {
                    targets = GetTargetControls(BottomResizeTargets);
                    if (targets != null && targets.Length > 0)
                    {
                        foreach (var c in targets)
                        {
                            SetControlHeight(c, height);
                        }
                    }
                }
            }
        }

        private void SetControlHeight(Control control, string height)
        {
            if (control != null)
            {
                if (control is WebControl)
                {
                    var wc = (WebControl) control;
                    wc.Style.Add("height", height);
                }
                else if (control is HtmlControl)
                {
                    var hc = (HtmlControl) control;
                    hc.Style.Add("height", height);
                }
            }
        }

        private Control[] GetTargetControls(string controlIds)
        {
            // warning: the controls array that this method returns
            // may contain null values if a control is not found
            Control[] controls = null;
            var ids = GetTargetControlIds(controlIds);

            Control container = Page;
            if (NamingContainer != null && NamingContainer != Page)
            {
                container = NamingContainer;
            }

            if (ids != null && ids.Length > 0)
            {
                var i = 0;
                Control c = null;
                string id = null;
                controls = new Control[ids.Length];
                for (i = 0; i < ids.Length; i++)
                {
                    id = ids[i];
                    if (!string.IsNullOrEmpty(id))
                    {
                        c = container.FindControl(id);
                        if (c != null)
                        {
                            controls[i] = c;
                        }
                    }
                }
            }
            return controls;
        }

        private string[] GetTargetControlIds(string controlIds)
        {
            string[] ids = null;
            if (!string.IsNullOrEmpty(controlIds))
            {
                ids = controlIds.Split(';');
            }
            return ids;
        }

        private void AddCompositeControls()
        {
            // save the width to a hidden field so that
            // on PostBacks the width will be available
            if (Orientation == SplitterBarOrientations.Vertical)
            {
                if (hdnWidth == null)
                {
                    hdnWidth = new HtmlInputHidden();
                    hdnWidth.ID = "hdnWidth";
                }
                Controls.Add(hdnWidth);

                if (hdnMinWidth == null)
                {
                    hdnMinWidth = new HtmlInputHidden();
                    hdnMinWidth.ID = "hdnMinWidth";
                }
                Controls.Add(hdnMinWidth);

                if (hdnMaxWidth == null)
                {
                    hdnMaxWidth = new HtmlInputHidden();
                    hdnMaxWidth.ID = "hdnMaxWidth";
                }
                Controls.Add(hdnMaxWidth);
            }
            else if (Orientation == SplitterBarOrientations.Horizontal)
            {
                if (hdnHeight == null)
                {
                    hdnHeight = new HtmlInputHidden();
                    hdnHeight.ID = "hdnHeight";
                }
                Controls.Add(hdnHeight);

                if (hdnMinHeight == null)
                {
                    hdnMinHeight = new HtmlInputHidden();
                    hdnMinHeight.ID = "hdnMinHeight";
                }
                Controls.Add(hdnMinHeight);

                if (hdnMaxHeight == null)
                {
                    hdnMaxHeight = new HtmlInputHidden();
                    hdnMaxHeight.ID = "hdnMaxHeight";
                }
                Controls.Add(hdnMaxHeight);
            }
        }

        protected virtual bool LoadPostData(string postDataKey, NameValueCollection postCollection)
        {
            AddCompositeControls();

            if (Orientation == SplitterBarOrientations.Vertical)
            {
                hdnWidth.Value = postCollection[hdnWidth.UniqueID];
                hdnMinWidth.Value = postCollection[hdnMinWidth.UniqueID];
                hdnMaxWidth.Value = postCollection[hdnMaxWidth.UniqueID];
            }
            else if (Orientation == SplitterBarOrientations.Horizontal)
            {
                hdnHeight.Value = postCollection[hdnHeight.UniqueID];
                ;
                hdnMinHeight.Value = postCollection[hdnMinHeight.UniqueID];
                ;
                hdnMaxHeight.Value = postCollection[hdnMaxHeight.UniqueID];
                ;
            }

            return true;
        }

        public int GetInt32(string size)
        {
            var intsize = 0;
            if (!string.IsNullOrEmpty(size))
            {
                try
                {
                    size = size.Replace("px", string.Empty);
                    if (!string.IsNullOrEmpty(size))
                    {
                        intsize = Convert.ToInt32(size);
                    }
                }
                catch
                {
                    intsize = 0;
                }
            }
            return intsize;
        }

        private void RegisterPageStartupScript()
        {
            var sb = new StringBuilder();
            const string newline = "\r\n";

            sb.Append("<script type=\"text/javascript\"> <!-- ");
            sb.Append(newline);

            var id = "sbar_" + ClientID;

            // createNew / constructor
            sb.Append("var ");
            sb.Append(id);
            sb.Append("= VwdCmsSplitterBar.createNew(\"");
            sb.Append(ClientID);
            sb.Append("\",");
            if (DebugElement == null)
            {
                sb.Append(" null);");
            }
            else
            {
                sb.Append("\"");
                sb.Append(DebugElement);
                sb.Append("\");");
            }
            sb.Append(newline);

            // set the namingContainerId
            if (NamingContainer != null && NamingContainer != Page)
            {
                var prefix = NamingContainer.ClientID
                             + ClientIDSeparator;

                sb.Append(id);
                sb.Append(".namingContainerId = \"");
                sb.Append(prefix);
                sb.Append("\";");
                sb.Append(newline);
            }

            // set the orientation
            sb.Append(id);
            sb.Append(".orientation = \"");
            sb.Append(Orientation.ToString().ToLower());
            sb.Append("\";");
            sb.Append(newline);

            // set the debugElementId
            if (!string.IsNullOrEmpty(DebugElement))
            {
                sb.Append(id);
                sb.Append(".debugElementId = \"");
                sb.Append(DebugElement);
                sb.Append("\";");
                sb.Append(newline);
            }

            if (Orientation == SplitterBarOrientations.Vertical)
            {
                // set the left resize target Ids
                sb.Append(id);
                sb.Append(".leftResizeTargetIds = \"");
                sb.Append(LeftResizeTargets);
                sb.Append("\";");
                sb.Append(newline);

                // set the right resize target Ids
                sb.Append(id);
                sb.Append(".rightResizeTargetIds = \"");
                sb.Append(RightResizeTargets);
                sb.Append("\";");
                sb.Append(newline);

                if (SplitterWidth != 6)
                {
                    sb.Append(id);
                    sb.Append(".splitterWidth = new Number(");
                    sb.Append(SplitterWidth.ToString());
                    sb.Append(");");
                    sb.Append(newline);
                }

                if (!string.IsNullOrEmpty(SaveWidthToElement))
                {
                    sb.Append(id);
                    sb.Append(".saveWidthToElement = \"");
                    sb.Append(SaveWidthToElement);
                    sb.Append("\";");
                    sb.Append(newline);
                }

                if (MinWidth > 0)
                {
                    sb.Append(id);
                    sb.Append(".minWidth = ");
                    sb.Append(MinWidth.ToString());
                    sb.Append(";");
                    sb.Append(newline);
                }

                if (MaxWidth > 0)
                {
                    sb.Append(id);
                    sb.Append(".maxWidth = ");
                    sb.Append(MaxWidth.ToString());
                    sb.Append(";");
                    sb.Append(newline);
                }

                if (TotalWidth > 0)
                {
                    sb.Append(id);
                    sb.Append(".totalWidth = ");
                    sb.Append(TotalWidth.ToString());
                    sb.Append(";");
                    sb.Append(newline);
                }
            }
            else if (Orientation == SplitterBarOrientations.Horizontal)
            {
                // set the top resize target Ids
                sb.Append(id);
                sb.Append(".topResizeTargetIds = \"");
                sb.Append(TopResizeTargets);
                sb.Append("\";");
                sb.Append(newline);

                // set the bottom resize target Ids
                sb.Append(id);
                sb.Append(".bottomResizeTargetIds = \"");
                sb.Append(BottomResizeTargets);
                sb.Append("\";");
                sb.Append(newline);

                if (SplitterHeight != 6)
                {
                    sb.Append(id);
                    sb.Append(".splitterHeight = new Number(");
                    sb.Append(SplitterHeight.ToString());
                    sb.Append(");");
                    sb.Append(newline);
                }

                if (!string.IsNullOrEmpty(SaveHeightToElement))
                {
                    sb.Append(id);
                    sb.Append(".saveHeightToElement = \"");
                    sb.Append(SaveHeightToElement);
                    sb.Append("\";");
                    sb.Append(newline);
                }

                if (MinHeight > 0)
                {
                    sb.Append(id);
                    sb.Append(".minHeight = ");
                    sb.Append(MinHeight.ToString());
                    sb.Append(";");
                    sb.Append(newline);
                }

                if (MaxHeight > 0)
                {
                    sb.Append(id);
                    sb.Append(".maxHeight = ");
                    sb.Append(MaxHeight.ToString());
                    sb.Append(";");
                    sb.Append(newline);
                }

                if (TotalHeight > 0)
                {
                    sb.Append(id);
                    sb.Append(".totalHeight = ");
                    sb.Append(TotalHeight.ToString());
                    sb.Append(";");
                    sb.Append(newline);
                }
            }

            // IFrameHiding
            sb.Append(id);
            sb.Append(".iframeHiding = \"");
            sb.Append(IFrameHiding);
            sb.Append("\";");
            sb.Append(newline);


            if (!string.IsNullOrEmpty(OnResizeStart))
            {
                sb.Append(id);
                sb.Append(".onResizeStart = ");
                sb.Append(OnResizeStart);
                sb.Append(";");
                sb.Append(newline);
            }

            if (!string.IsNullOrEmpty(OnResize))
            {
                sb.Append(id);
                sb.Append(".onResize = ");
                sb.Append(OnResize);
                sb.Append(";");
                sb.Append(newline);
            }

            if (!string.IsNullOrEmpty(OnResizeComplete))
            {
                sb.Append(id);
                sb.Append(".onResizeComplete = ");
                sb.Append(OnResizeComplete);
                sb.Append(";");
                sb.Append(newline);
            }

            if (!string.IsNullOrEmpty(OnDoubleClick))
            {
                sb.Append(id);
                sb.Append(".OnDoubleClick = ");
                sb.Append(OnDoubleClick);
                sb.Append(";");
                sb.Append(newline);
            }

            if (DynamicResizing)
            {
                sb.Append(id);
                sb.Append(".liveResize = true;");
                sb.Append(newline);
            }
            if (!string.IsNullOrEmpty(BackgroundColor))
            {
                sb.Append(id);
                sb.Append(".SetBackgroundColor(\"");
                sb.Append(BackgroundColor);
                sb.Append("\");");
                sb.Append(newline);
            }

            if (!string.IsNullOrEmpty(BackgroundColorHilite))
            {
                sb.Append(id);
                sb.Append(".backgroundColorHilite = \"");
                sb.Append(BackgroundColorHilite);
                sb.Append("\";");
                sb.Append(newline);
            }
            if (!string.IsNullOrEmpty(BackgroundColorResizing))
            {
                sb.Append(id);
                sb.Append(".backgroundColorResizing = \"");
                sb.Append(BackgroundColorResizing);
                sb.Append("\";");
                sb.Append(newline);
            }
            if (!string.IsNullOrEmpty(BackgroundColorLimit))
            {
                sb.Append(id);
                sb.Append(".backgroundColorLimit = \"");
                sb.Append(BackgroundColorLimit);
                sb.Append("\";");
                sb.Append(newline);
            }


            // do this last...
            // be sure to call configure after all of the 
            // configuration properties have been set
            sb.Append(id);
            sb.Append(".configure();");
            sb.Append(newline);

            sb.Append("// -->");
            sb.Append(newline);
            sb.Append("</script>");
            sb.Append(newline);

            Page.ClientScript.RegisterStartupScript(GetType(),
                ClientID + "_VwdCmsSplitterBarStartupScript", sb.ToString());
        }
    }
}