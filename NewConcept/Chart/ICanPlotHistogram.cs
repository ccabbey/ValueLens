namespace ValueLens.NewConcept
{
    internal interface ICanPlotHistogram
    {
        (double[] hist, double[] binEdges) ProvideData();
    }
}
