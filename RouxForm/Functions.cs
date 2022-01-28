﻿using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;

namespace RouxForm
{
    public class Functions
    {
        [DllImport("roux.dll")]
        unsafe private static extern void open_window(uint len, byte* ptr, uint wid, uint hgt, uint x, uint y,
            [MarshalAs(UnmanagedType.LPUTF8Str)] string utf8Text);

        unsafe public static void OpenWindow(FileInfo file, SizeF size)
        {
            Bitmap bmp = new Bitmap(file.FullName);

            // Predict size after red channel extraction
            Size bmpSize = bmp.Width % 12 == 0 ? bmp.Size : new Size(bmp.Width / 12 * 12, bmp.Height);

            // Resize bitmap to fit a single screen
            bmp = new Bitmap((Bitmap)bmp.Clone(), new Size((int)(bmpSize.Width / (bmpSize.Height / size.Height)), (int)size.Height));

            // Extract red channel and resize to the predicted size
            byte[] data = GetRedChannelArr(ref bmp);

            string dataPath = file.FullName.Replace(file.Extension, ".txt");
            fixed (byte* p = &data[0])
            {
                open_window((uint)data.Length, p, (uint)bmp.Width, (uint)bmp.Height, 5, 5, dataPath);
            }
        }
        public static byte[] GetRedChannelArr(ref Bitmap bmp)
        {
            // Crop image down if it will create a border in BitmapData
            // Divisible by both 4 and 3 is the same as divisible by 12
            if (bmp.Width % 12 != 0)
                bmp = bmp.Clone(new Rectangle(Point.Empty, new Size(bmp.Width / 12 * 12, bmp.Height)), PixelFormat.Format24bppRgb);

            // Lock the bitmap's bits.  
            BitmapData bmpData = bmp.LockBits(new Rectangle(Point.Empty, bmp.Size), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            // Get the address of the first line.
            IntPtr ptr = bmpData.Scan0;

            // Declare an array to hold the bytes of the bitmap.
            int bytes = Math.Abs(bmpData.Stride) * bmp.Height;
            byte[] rgbValues = new byte[bytes];
            byte[] rValues = new byte[bytes / 3];

            // Copy the RGB values into the array.
            Marshal.Copy(ptr, rgbValues, 0, bytes);

            // Copy every red channel value
            for (int counter = 2; counter < rgbValues.Length; counter += 3)
                rValues[counter / 3] = rgbValues[counter];

            return rValues;
        }
    }
}
