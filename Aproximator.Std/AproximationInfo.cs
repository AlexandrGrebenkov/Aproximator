namespace Aproximator.Std
{
    /// <summary>Результат апроксимации</summary>
    public class AproximationInfo
    {
        /// <summary>Коэффициенты</summary>
        public double[] Rates { get; }
        /// <summary>Максимальная ошибка</summary>
        public double Error { get; }
        /// <summary>Сумма квадратов отклонений</summary>
        public double Sigma { get; }

        public AproximationInfo(double[] rates, double error, double sigma)
        {
            Rates = rates;
            Error = error;
            Sigma = sigma;
        }
    }
}
