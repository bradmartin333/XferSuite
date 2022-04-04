namespace XferSuite
{
    public class CustomFeature
    {
        public string Name { get; set; }
        public XferHelper.Report.State Type { get; set; }
        public int Size { get; set; }
        public System.Drawing.PointF Offset { get; set; }
        public System.Collections.Generic.List<string[]> Filters { get; set; }
        public CustomFeature(CreateCustom form, System.Collections.Generic.List<string[]> list)
        {
            Name = form.txtName.Text;
            Type = (XferHelper.Report.State)form.comboBoxType.SelectedIndex;
            Offset = new System.Drawing.PointF((float)form.numOffsetX.Value, (float)form.numOffsetY.Value);
            Filters = list;
        }
    }
}
