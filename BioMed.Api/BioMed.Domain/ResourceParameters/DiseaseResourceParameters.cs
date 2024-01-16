﻿namespace BioMed.Domain.ResourceParameters
{
    public class DiseaseResourceParameters : ResourceParametersBase
    {
        public int DiseaseCategoryId { get; set; }
        public override string OrderBy { get; set; } = "name";
    }
}
