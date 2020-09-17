﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ImageMagick;
using UnityEditor;
using UnityEngine;

namespace KRTQuestTools
{
    public class GenericMaterial : IMaterialWrapper
    {
        protected readonly Material material;

        internal GenericMaterial(Material material)
        {
            this.material = material;
        }

        public Layer GetMainLayer()
        {
            return new Layer
            {
                image = MaterialUtils.GetMagickImage(material.mainTexture),
                color = material.color
            };
        }

        public bool HasEmission()
        {
            return material.shaderKeywords.Contains("_EMISSION");
        }

        public Layer GetEmissionLayer()
        {
            if (!HasEmission()) return null;
            return new Layer
            {
                image = MaterialUtils.GetMagickImage(material, "_EmissionMap"),
                color = material.GetColor("_EmissionColor")
            };
        }

        public MagickImage CompositeLayers()
        {
            using (var main = GetMainLayer())
            using (var emission = GetEmissionLayer())
            {
                var (width, height) = DecideCompositionSize(main, emission);
                var newImage = new MagickImage(MagickColors.Black, width, height);
                using (var mainImage = main.GetMagickImage())
                {
                    mainImage.Resize(width, height);
                    newImage.Composite(mainImage, CompositeOperator.Plus);
                }
                if (HasEmission())
                {
                    using (var emissionImage = emission.GetMagickImage())
                    {
                        emissionImage.Resize(width, height);
                        newImage.Composite(emissionImage, CompositeOperator.Screen);
                    }
                }
                return newImage;
            }
        }

        private Tuple<int, int> DecideCompositionSize(Layer main, Layer emission)
        {
            var layers = new List<Layer>
            {
                main,
                emission
            };
            foreach (var l in layers)
            {
                if (l == null) continue;
                if (l.image != null)
                {
                    return new Tuple<int, int>(l.image.Width, l.image.Height);
                }
            }
            return new Tuple<int, int>(1, 1);
        }
    }
}
