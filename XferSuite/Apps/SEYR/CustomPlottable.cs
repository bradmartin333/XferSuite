namespace XferSuite
{
    public class CustomPlottable
    {
        public string Name { get; set; }
        public OxyPlot.OxyColor OxyColor { get; set; }
        public OxyPlot.MarkerType MarkerType { get; set; }
        public int Size { get; set; }
        public System.Drawing.PointF Offset { get; set; }
        public System.Collections.Generic.List<string[]> Filters { get; set; }
        public CustomPlottable(CreateCustom form, System.Collections.Generic.List<string[]> list)
        {
            Name = form.txtName.Text;
            OxyColor = OxyPlot.OxyColor.FromArgb(form.lblColor.BackColor.A, form.lblColor.BackColor.R, form.lblColor.BackColor.G, form.lblColor.BackColor.B);
            MarkerType = (OxyPlot.MarkerType)form.comboBoxShape.SelectedItem;
            Size = (int)form.numSize.Value;
            Offset = new System.Drawing.PointF((float)form.numOffsetX.Value, (float)form.numOffsetY.Value);
            Filters = list;
        }
    }
}
