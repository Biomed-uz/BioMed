﻿namespace BioMed.Domain.ResourceParameters
{
    public class PatientResourceParameters : ResourceParametersBase
    {
        public override string OrderBy { get; set; } = "firstname";
    }
}
