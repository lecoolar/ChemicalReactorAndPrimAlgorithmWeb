namespace ChemicalReactorAndPrimAlgorithmWeb.Models
{
    public class ChemicalReactorModel
    {
        public double C1 { get; set; } = 1.02;
        public double C2 { get; set; } = 0.93;
        public double C3 { get; set; } = 0.386;
        public double C4 { get; set; } = 3.28;
        public double C5 { get; set; } = 0.084;
        public double R { get; set; } = 1.9865;

        public double E1 { get; set; } = 16000;
        public double E2 { get; set; } = 14000;
        public double E3 { get; set; } = 15000;
        public double E4 { get; set; } = 10000;
        public double E5 { get; set; } = 15000;

        public double T { get; set; } // Конечное время
        public double U { get; set; } // Температура (управление)

        // Функции для вычисления k_i(u)
        public double K1(double u) => C1 * Math.Exp(E1 / R * (1 / 658.0 - 1 / u));
        public double K2(double u) => C2 * Math.Exp(E2 / R * (1 / 658.0 - 1 / u));
        public double K3(double u) => C3 * Math.Exp(E3 / R * (1 / 658.0 - 1 / u));
        public double K4(double u) => C4 * Math.Exp(E4 / R * (1 / 658.0 - 1 / u));
        public double K5(double u) => C5 * Math.Exp(E5 / R * (1 / 658.0 - 1 / u));

    }
}
