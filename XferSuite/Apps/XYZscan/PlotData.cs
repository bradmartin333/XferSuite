﻿using System;
using System.Linq;
using XferHelper;
using static XferSuite.Apps.XYZscan.Configuration;

namespace XferSuite.Apps.XYZscan
{
    public class PlotData
    {
        public string Name { get; set; }
        public double[] X { get; set; }
        public double[] Y { get; set; }
        public double[] Z { get; set; }

        public PlotData(Scan scan, Zed.Axes xAxis, Zed.Axes yAxis, Zed.Axes zAxis, bool compare = true)
        {
            Name = scan.Name;
            Zed.Position[] data = ApplyFilters((Zed.Position[])scan.Data.ToArray().Clone());
            X = Zed.getAxis(data, (int)xAxis, FlipX);
            Y = Zed.getAxis(data, (int)yAxis, FlipY);
            Z = Zed.getAxis(data, (int)zAxis, FlipZ);
            if (compare) CompareBounds();
        }

        private Zed.Position[] ApplyFilters(Zed.Position[] data)
        {
            if (RemoveAngle)
            {
                Zed.Plane plane = Zed.getPlane(data);
                for (int i = 0; i < data.Length; i++)
                {
                    Zed.Position p = data[i];
                    data[i] = new Zed.Position(p.Time, p.X, p.Y, p.Z, p.H - Zed.projectPlane(plane, Zed.posToVec3(data[i])).Z, p.I);
                }
            }
            if (Equalize)
            {
                double equalizer = Zed.getAxis(data, 4, false).Min();
                for (int i = 0; i < data.Length; i++)
                    data[i] = new Zed.Position(data[i].Time, data[i].X, data[i].Y, data[i].Z, data[i].H - equalizer, data[i].I);
            }
            return data;
        }

        public void CompareBounds()
        {
            (double xMin, double xMax) = Zed.getAxisMinMax(X);
            (double yMin, double yMax) = Zed.getAxisMinMax(Y);
            (double zMin, double zMax) = Zed.getAxisMinMax(Z);
            if (xMin < GroupBounds.XMin) GroupBounds.XMin = xMin;
            if (xMax > GroupBounds.XMax) GroupBounds.XMax = xMax;
            if (yMin < GroupBounds.YMin) GroupBounds.YMin = yMin;
            if (yMax > GroupBounds.YMax) GroupBounds.YMax = yMax;
            if (zMin < GroupBounds.ZMin) GroupBounds.ZMin = zMin;
            if (zMax > GroupBounds.ZMax) GroupBounds.ZMax = zMax;
        }
    }
}
