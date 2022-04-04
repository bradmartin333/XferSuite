using XferHelper;

namespace XferSuite
{
    public class CustomFeature
    {
        public string Name { get; set; }
        public Report.State Type { get; set; }
        public System.Drawing.PointF Offset { get; set; }
        public System.Collections.Generic.List<(string, Report.State)> Filters { get; set; }
        public CustomFeature(CreateCustom form, System.Collections.Generic.List<(string, Report.State)> filters)
        {
            Name = form.txtName.Text;
            Type = (Report.State)form.comboBoxType.SelectedIndex;
            Offset = new System.Drawing.PointF((float)form.numOffsetX.Value, (float)form.numOffsetY.Value);
            Filters = filters;
        }
    }
}
