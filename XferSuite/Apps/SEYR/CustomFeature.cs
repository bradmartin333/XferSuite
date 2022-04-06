using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using XferHelper;

namespace XferSuite.Apps.SEYR
{
    /// <summary>
    /// Object created via the CreateCustom form
    /// </summary>
    public class CustomFeature : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _Name;
        public string Name { 
            get => _Name;
            set
            {
                if (value != _Name)
                {
                    _Name = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private OxyPlot.OxyColor _Color;
        public OxyPlot.OxyColor Color {
            get => _Color;
            set
            {
                if (value != _Color)
                {
                    _Color = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private int _Size;
        public int Size
        {
            get => _Size;
            set
            {
                if (value != _Size)
                {
                    _Size = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private Report.State _Type;
        public Report.State Type
        {
            get => _Type;
            set
            {
                if (value != _Type)
                {
                    _Type = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private System.Drawing.PointF _Offset;
        public System.Drawing.PointF Offset
        {
            get => _Offset;
            set
            {
                if (value != _Offset)
                {
                    _Offset = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public System.Collections.Generic.List<(string, Report.State)> _Filters;
        public System.Collections.Generic.List<(string, Report.State)> Filters { get; set; }

        private bool _Visible = true;
        public bool Visible
        {
            get => _Visible;
            set
            {
                if (value != _Visible)
                {
                    _Visible = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public CustomFeature(CreateCustom form, System.Collections.Generic.List<(string, Report.State)> filters)
        {
            _Name = form.txtName.Text;
            System.Drawing.Color c = form.panelColor.BackColor;
            _Color = OxyPlot.OxyColor.FromArgb(c.A, c.R, c.G, c.B);
            _Size = (int)form.numSize.Value;
            _Type = (Report.State)form.comboBoxType.SelectedIndex;
            _Offset = new System.Drawing.PointF((float)form.numOffsetX.Value, (float)form.numOffsetY.Value);
            _Filters = filters;
        }
    }
}
