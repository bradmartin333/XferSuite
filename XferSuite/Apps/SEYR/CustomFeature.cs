using System;
using System.ComponentModel;
using System.Drawing;
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

        private Color _Color;
        public Color Color
        {
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

        private PointF _Offset;
        public PointF Offset
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

        private System.Collections.Generic.List<(string, Report.State)> _Filters = new System.Collections.Generic.List<(string, Report.State)>();
        public System.Collections.Generic.List<(string, Report.State)> Filters
        {
            get => _Filters;
            set
            {
                if (value != _Filters)
                {
                    _Filters = value;
                    NotifyPropertyChanged();
                }
            }
        }

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

        public Color ContrastColor
        {
            get => (((0.299 * _Color.R) + (0.587 * _Color.G) + (0.114 * _Color.B)) / 255) > 0.5 ? Color.Black : Color.White;
        }

        public CustomFeature() 
        { 
            _Name = Guid.NewGuid().ToString().Substring(0, 8).ToUpper(); // Random string
            _Color = Color.Blue;
            _Size = 1;
            _Type = Report.State.Pass;
            _Offset = PointF.Empty;
            _Filters = new System.Collections.Generic.List<(string, Report.State)>();
        }

        public CustomFeature(string path)
        {
            string[] lines = System.IO.File.ReadAllLines(path);
            for (int i = 0; i < lines.Length; i++)
            {
                string[] cols = lines[i].Split('\t');
                if (i == 0)
                {
                    _Name = cols[0];
                    _Color = Color.FromArgb(int.Parse(cols[1]));
                    _Size = int.Parse(cols[2]);
                    _Type = (Report.State)Enum.Parse(typeof(Report.State), cols[3]);
                    _Offset = new PointF(float.Parse(cols[4]), float.Parse(cols[5]));
                }
                else
                    Filters.Add((cols[0], (Report.State)Enum.Parse(typeof(Report.State), cols[1])));
            }
        }

        public void Update(CreateCustom form, System.Collections.Generic.List<(string, Report.State)> filters)
        {
            _Name = form.txtName.Text;
            _Color = form.panelColor.BackColor;
            _Size = (int)form.numSize.Value;
            _Type = (Report.State)form.comboBoxType.SelectedIndex;
            _Offset = new PointF((float)form.numOffsetX.Value, (float)form.numOffsetY.Value);
            _Filters = filters;
        }
    }
}
