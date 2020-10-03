﻿using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using ImageMagick;
using UnityEditor;
using UnityEngine;

namespace KRTQuestTools
{
    public class ImgProcTests
    {
        [Test]
        public void TestAlphaChannel()
        {
            using (var image = new MagickImage(TestUtils.LoadMagickImage("alpha_test.png")))
            using (var dest = new MagickImage(image))
            using (var emission = new MagickImage(MagickColors.Black, image.Width, image.Height))
            {
                Assert.True(image.HasAlpha);

                dest.HasAlpha = false;
                dest.Composite(emission, CompositeOperator.Screen);
                dest.HasAlpha = true;
                dest.CopyPixels(image, Channels.Alpha);

                var result = image.Compare(dest, ErrorMetric.MeanErrorPerPixel, Channels.All);
                Assert.AreEqual(0.0, result);
            }
        }
    }
}