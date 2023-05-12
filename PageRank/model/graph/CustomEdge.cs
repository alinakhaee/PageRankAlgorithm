using QuickGraph;

namespace model.graph
{
    public class CustomEdge : IEdge<CustomVertex>
    {
        public double Weight { get; set; }
        public CustomVertex Source { get; set; }
        public CustomVertex Target { get; set; }

        public CustomEdge(CustomVertex source, CustomVertex target, double weight)
        {
            Source = source;
            Target = target;
            Weight = weight;
        }

        public CustomEdge(CustomVertex source, CustomVertex target)
        {
            Source = source;
            Target = target;
            Weight = 1.0;
        }

        public override string ToString()
        {
            return $"{Source} - {Target} - {Weight}";
        }
    }
}
