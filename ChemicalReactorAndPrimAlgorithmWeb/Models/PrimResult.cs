namespace ChemicalReactorAndPrimAlgorithmWeb.Models
{
    public class PrimResult
    {
        public int TotalWeight { get; set; }
        public List<Tuple<int, int, int>> Edges { get; set; }
    }
}
