﻿using System;
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

        private OxyPlot.OxyColor _OxyColor;
        public OxyPlot.OxyColor OxyColor {
            get => _OxyColor;
            set
            {
                if (value != _OxyColor)
                {
                    _OxyColor = value;
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

        public System.Collections.Generic.List<(string, Report.State)> _Filters;
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

        public CustomFeature(CreateCustom form, System.Collections.Generic.List<(string, Report.State)> filters)
        {
            _Name = form.txtName.Text;
            _Color = form.panelColor.BackColor;
            _OxyColor = OxyPlot.OxyColor.FromArgb(_Color.A, _Color.R, _Color.G, _Color.B);
            _Size = (int)form.numSize.Value;
            _Type = (Report.State)form.comboBoxType.SelectedIndex;
            _Offset = new PointF((float)form.numOffsetX.Value, (float)form.numOffsetY.Value);
            _Filters = filters;
        }
    }
}
