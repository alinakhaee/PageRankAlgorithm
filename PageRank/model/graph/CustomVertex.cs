namespace model.graph
{
    public class CustomVertex
    {
        public string Name { get; set; }

        public CustomVertex(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
