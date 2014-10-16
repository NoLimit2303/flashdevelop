﻿using PluginCore.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Text;

namespace PluginCore.Helpers
{
    public class ScaleHelper
    {
        private static double curScale = double.MinValue;

        /// <summary>
        /// Gets the display scale. Ideally would probably keep separate scales for X and Y.
        /// </summary>
        private static double GetScale()
        {
            if (curScale != double.MinValue) return curScale;
            using (var g = Graphics.FromHwnd(PluginBase.MainForm.Handle))
            {
                curScale = g.DpiX / 96f;
            }
            return curScale;
        }

        /// <summary>
        /// Resizes based on display scale.
        /// </summary>
        public static int Scale(int value)
        {
            return (int)(value * GetScale());
        }

        /// <summary>
        /// Resizes based on display scale.
        /// </summary>
        public static long Scale(long value)
        {
            return (long)(value * GetScale());
        }

        /// <summary>
        /// Resizes based on display scale.
        /// </summary>
        public static float Scale(float value)
        {
            return (float)(value * GetScale());
        }

        /// <summary>
        /// Resizes based on display scale.
        /// </summary>
        public static double Scale(double value)
        {
            return value * GetScale();
        }

        /// <summary>
        /// Resizes based on display scale.
        /// </summary>
        public static Size Scale(Size value)
        {
            return new Size(Scale(value.Width), Scale(value.Height));
        }

        /// <summary>
        /// Resizes based on display scale.
        /// </summary>
        public static SizeF Scale(SizeF value)
        {
            return new SizeF(Scale(value.Width), Scale(value.Height));
        }

        /// <summary>
        /// Resizes the image based on the display scale. Uses high quality settings.
        /// </summary>
        public static Bitmap Scale(Bitmap image)
        {
            if (GetScale() == 1) return image;
            int width = Scale(image.Width);
            int height = Scale(image.Height);
            return (Bitmap)ImageKonverter.ImageResize(image, width, height);
        }

    }

}
