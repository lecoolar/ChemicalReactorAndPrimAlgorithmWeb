using ChemicalReactorAndPrimAlgorithmWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChemicalReactorAndPrimAlgorithmWeb.Controllers
{
    public class ChemicalReactorController : Controller
    {
        public ActionResult Index()
        {
            return View(new ChemicalReactorModel());
        }

        [HttpPost]
        public ActionResult Solve(ChemicalReactorModel model)
        {
            // Начальные условия
            double[] initialValues = { 1.0, 0.0, 0.0 };

            // Временной интервал
            double t0 = 0;
            int steps = 100;
            double dt = model.T / steps;

            double[][] result = SolveEuler(t0, initialValues, model.T, steps, model);

            // Получение значений x3 в конечный момент времени
            double x3_final = result[steps][2];

            ViewBag.X3Final = x3_final;
            return View("Index", model);
        }

        // Метод Эйлера для решения системы ОДУ
        private double[][] SolveEuler(double t0, double[] initialValues, double T, int steps, ChemicalReactorModel model)
        {
            double[][] result = new double[steps + 1][];
            result[0] = initialValues;
            double dt = T / steps;

            for (int i = 0; i < steps; i++)
            {
                double t = t0 + i * dt;
                result[i + 1] = StepEuler(t, result[i], dt, model);
            }

            return result;
        }

        // Один шаг метода Эйлера
        private double[] StepEuler(double t, double[] values, double dt, ChemicalReactorModel model)
        {
            double k1 = model.K1(model.U);
            double k2 = model.K2(model.U);
            double k3 = model.K3(model.U);
            double k4 = model.K4(model.U);
            double k5 = model.K5(model.U);

            double dx1 = -(k1 + k2 + k3) * values[0];
            double dx2 = k1 * values[0] - k4 * values[1];
            double dx3 = k4 * values[1] - k5 * values[2];

            return new[]
            {
                values[0] + dx1 * dt,
                values[1] + dx2 * dt,
                values[2] + dx3 * dt
            };
        }
    }
}
