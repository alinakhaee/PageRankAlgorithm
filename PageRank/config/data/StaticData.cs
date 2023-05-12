namespace config.data
{
    public static class StaticData
    {
        // public attributes used by PageRank
        // attributes are taken from Mihalcea et al.

        public static double SignificanceThreshold = 0.0001;
        public const int WindowSize = 2;

        public const double EdgeWeightThreshold = 0.25;
        public const double InitialVertexScore = 0.25;
        public const double DampingFactor = 0.85;
        public const int MaxIteration = 100;
    }
}
