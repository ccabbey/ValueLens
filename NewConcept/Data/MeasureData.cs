using System;

using System.Collections.Generic;

namespace ValueLens.NewConcept
{
    internal class MeasureData
    {
        public string SerialNumber { get; set; }

        public DateTime EntryTime { get; set; }

        public Dictionary<string, double> Measures { get; set; }

        public MeasureData()
        {

        }
    }
}
