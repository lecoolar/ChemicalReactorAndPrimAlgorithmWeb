using ChemicalReactorAndPrimAlgorithmWeb.Models;
using ChemicalReactorAndPrimAlgorithmWeb.Services;
using Microsoft.AspNetCore.Mvc;

namespace ChemicalReactorAndPrimAlgorithmWeb.Controllers
{
    public class PrimController : Controller
    {
        private readonly PrimAlgorithmService _primAlgorithmService = new PrimAlgorithmService();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(int vertices, List<string> weightMatrix)
        {
            try
            {
                var graph = new Graph(vertices);
                graph.WeightMatrix = ParseWeightMatrix(weightMatrix, vertices);

                var result = _primAlgorithmService.RunPrimAlgorithm(graph);
                return View("Result", result);
            }
            catch (Exception ex)
            {
                return View("Error", ex.Message);
            }
        }

        private int[,] ParseWeightMatrix(List<string> weightMatrix, int vertices)
        {
            var parsedMatrix = new int[vertices, vertices];

            for (int i = 0; i < vertices; i++)
            {
                for (int j = 0; j < vertices; j++)
                {
                    var value = weightMatrix[i * vertices + j];
                    if (value == "-" || value == "∞" || value == null)
                    {
                        parsedMatrix[i, j] = int.MaxValue;
                    }
                    else
                    {
                        parsedMatrix[i, j] = int.Parse(value);
                    }
                }
            }

            return parsedMatrix;
        }
    }
}
