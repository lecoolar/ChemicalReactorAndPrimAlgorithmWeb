namespace ChemicalReactorAndPrimAlgorithmWeb.Models
{
    public class Graph
    {
        public int Vertices { get; set; }
        public int[,] WeightMatrix { get; set; }

        public Graph(int vertices)
        {
            Vertices = vertices;
            WeightMatrix = new int[vertices, vertices];
        }
    }
}

