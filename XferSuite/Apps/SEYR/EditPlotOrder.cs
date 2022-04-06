using BrightIdeasSoftware;
using System.Collections.Generic;
using System.Windows.Forms;

namespace XferSuite.Apps.SEYR
{
    public partial class EditPlotOrder : Form
    {
        public List<PlotOrderElement> PlotOrder { get; set; } = new List<PlotOrderElement>();
        public EditPlotOrder(List<PlotOrderElement> plotOrder)
        {
            InitializeComponent();
            PlotOrder = plotOrder;
            SimpleDropSink sink = (SimpleDropSink)olv.DropSink;
            sink.AcceptExternal = false;
            sink.CanDropBetween = true;
            sink.CanDropOnBackground = false;
            sink.AcceptableLocations = DropTargetLocation.BetweenItems | DropTargetLocation.AboveItem | DropTargetLocation.BelowItem;
            olv.ModelCanDrop += Olv_ModelCanDrop;
            olv.ModelDropped += Olv_ModelDropped;
            olv.AddObjects(PlotOrder);
        }

        private void Olv_ModelCanDrop(object sender, ModelDropEventArgs e)
        {
            e.Handled = true;
            e.Effect = DragDropEffects.Move;
        }

        private void Olv_ModelDropped(object sender, ModelDropEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
            int index = e.DropTargetIndex;
            OLVListItem node = olv.GetItem(index);
            if (node != null && index != -1)
            {
                if (index != 0) index++;
                olv.MoveObjects(index, e.SourceModels);
                olv.Refresh();
            }
        }

        private void UpdatePlotOrder()
        {
            int count = PlotOrder.Count;
            PlotOrder.Clear();
            for (int i = 0; i < count; i++)
                PlotOrder.Add((PlotOrderElement)olv.GetModelObject(i));
        }

        private void BtnDone_Click(object sender, System.EventArgs e)
        {
            UpdatePlotOrder();
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
