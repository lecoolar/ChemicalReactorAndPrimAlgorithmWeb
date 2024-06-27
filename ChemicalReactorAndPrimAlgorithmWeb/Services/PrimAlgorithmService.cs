using ChemicalReactorAndPrimAlgorithmWeb.Models;

namespace ChemicalReactorAndPrimAlgorithmWeb.Services
{
    public class PrimAlgorithmService
    {
        public PrimResult RunPrimAlgorithm(Graph graph)
        {
            int vertices = graph.Vertices;
            int[,] weightMatrix = graph.WeightMatrix;

            bool[] selected = new bool[vertices];
            int[] keys = new int[vertices];
            int[] parents = new int[vertices];

            for (int i = 0; i < vertices; i++)
            {
                keys[i] = int.MaxValue;
                selected[i] = false;
            }

            keys[0] = 0;
            parents[0] = -1;

            for (int count = 0; count < vertices - 1; count++)
            {
                int u = MinKey(keys, selected, vertices);
                selected[u] = true;

                for (int v = 0; v < vertices; v++)
                {
                    if (weightMatrix[u, v] != 0 && !selected[v] && weightMatrix[u, v] < keys[v])
                    {
                        parents[v] = u;
                        keys[v] = weightMatrix[u, v];
                    }
                }
            }

            return ConstructResult(parents, weightMatrix, vertices);
        }

        private int MinKey(int[] keys, bool[] selected, int vertices)
        {
            int min = int.MaxValue, minIndex = -1;

            for (int v = 0; v < vertices; v++)
                if (selected[v] == false && keys[v] < min)
                {
                    min = keys[v];
                    minIndex = v;
                }

            return minIndex;
        }

        private PrimResult ConstructResult(int[] parents, int[,] weightMatrix, int vertices)
        {
            var result = new PrimResult
            {
                TotalWeight = 0,
                Edges = new List<Tuple<int, int, int>>()
            };

            for (int i = 1; i < vertices; i++)
            {
                result.TotalWeight += weightMatrix[i, parents[i]];
                result.Edges.Add(new Tuple<int, int, int>(parents[i], i, weightMatrix[i, parents[i]]));
            }

            return result;
        }
    }
}
