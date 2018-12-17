using System;

namespace Aproximator.Std
{
    /// <summary>
    /// Апроксимация данных
    /// </summary>
    public static class Aproximation
    {
        /// <summary>
        /// Применение коэффициентов полинома
        /// </summary>
        /// <param name="input">Входное значение (сырые данные)</param>
        /// <param name="rates">Коэффициенты полинома</param>
        /// <returns>Результат применения коэффициентов</returns>
        public static double Polynomial(double input, double[] rates)
        {
            double Ti = 1, Ex = 0;
            for (int i = 0; i < rates.Length; i++)
            {
                if (i != 0) Ti *= input;
                Ex += (rates[i] * Ti);
            }
            return Ex;
        }

        /// <summary>
        /// Расчёт линейных коэффициентов
        /// </summary>
        /// <param name="x">Входные данные</param>
        /// <param name="y">Эталонные значения</param>
        /// <returns>Результат расчёта коэффициентов</returns>
        public static AproximationInfo Linear(double[] x, double[] y)
        {
            if (x == null || y == null) return null;
            if (x.Length != y.Length) return null;
            if (x.Length < 2) return null;

            double XY = 0, Sum_X = 0,                   //Суммы различных степеней
                   Sum_Y = 0, Sum_X2 = 0, Sum_XY = 0,   //
                   Sigma = 0,                           //Сумма квадратов отклонений
                   Tmp;                                 //Отклонение

            double[] A = new double[2];
            int N = x.Length;
            double Err = 0;
            //Предварительные рассчеты
            for (int i = 0; i < N; i++)
            {
                //Накопление данных для вычисления результатов
                XY = x[i] * y[i];
                Sum_X += x[i]; Sum_X2 += x[i] * x[i];
                Sum_Y += y[i]; Sum_XY += XY;
            }

            A[1] = (N * Sum_XY - Sum_X * Sum_Y) / (N * Sum_X2 - Sum_X * Sum_X);
            A[0] = (Sum_Y - A[1] * Sum_X) / N;

            for (int i = 0; i < N; i++)
            {
                Tmp = Math.Abs(y[i] - Polynomial(x[i], A)); //Отклонение
                if (Err < Tmp) Err = Tmp;                   //Макс. отклонение
                Sigma += Tmp * Tmp;                         //Сумма квадратов отклонений
            }

            return new AproximationInfo(A, Err, Math.Sqrt(Sigma / (N - 1)));
        }

        /// <summary>
        /// Расчёт коэффициентов квадратичного полинома
        /// </summary>
        /// <param name="x">Входные данные</param>
        /// <param name="y">Эталонные значения</param>
        /// <returns>Результат расчёта коэффициентов</returns>
        public static AproximationInfo Parabolic(double[] x, double[] y)
        {
            if (x == null || y == null) return null;
            if (x.Length != y.Length) return null;
            if (x.Length < 3) return null;

            double X, Y, X2, X3, X4, XY, X2Y,
                   Sum_X = 0, Sum_X2 = 0, Sum_X3 = 0,
                   Sum_X4 = 0,
                   Sum_Y = 0, Sum_XY = 0, Sum_X2Y = 0,
                   Sigma = 0,                       //Сумма квадратов отклонений
                   Tmp;                             //Отклонение

            int N = x.Length;
            double[] A = new double[3];
            double Err = 0;

            //Предварительные рассчеты
            for (int i = 0; i < N; i++)
            {
                Y = y[i];
                X = x[i];
                //Накопление данных для вычисления результатов
                X2 = X * X; X3 = X * X * X; X4 = X2 * X2; XY = X * Y; X2Y = X2 * Y;
                Sum_X += X; Sum_X2 += X2; Sum_X3 += X3; Sum_X4 += X4;
                Sum_Y += Y; Sum_XY += XY; Sum_X2Y += X2Y;
            }

            A[0] = (Sum_X2Y - Sum_Y * Sum_X4 / Sum_X2
                 + (Sum_Y * Sum_X3 / Sum_X2 - Sum_XY) / (Sum_X2 - Sum_X * Sum_X3 / Sum_X2) * (Sum_X3 - Sum_X * Sum_X4 / Sum_X2))
                 / (Sum_X2 - N * Sum_X4 / Sum_X2
                 - (Sum_X - N * Sum_X3 / Sum_X2) / (Sum_X2 - Sum_X * Sum_X3 / Sum_X2) * (Sum_X3 - Sum_X * Sum_X4 / Sum_X2));
            A[1] = (Sum_XY - Sum_Y * Sum_X3 / Sum_X2 - A[0] * (Sum_X - N * Sum_X3 / Sum_X2)) / (Sum_X2 - Sum_X * Sum_X3 / Sum_X2);
            A[2] = (Sum_Y - A[0] * N - A[1] * Sum_X) / Sum_X2;

            for (int i = 0; i < N; i++)
            {
                Tmp = Math.Abs(y[i] - Polynomial(x[i], A)); //Отклонение
                if (Err < Tmp) Err = Tmp;                   //Макс. отклонение
                Sigma += Tmp * Tmp;                         //Сумма квадратов отклонений
            }

            return new AproximationInfo(A, Err, Math.Sqrt(Sigma / (N - 1)));
        }

        /// <summary>
        /// Расчёт коэффициентов кубического полинома
        /// </summary>
        /// <param name="x">Входные данные</param>
        /// <param name="y">Эталонные значения</param>
        /// <returns>Результат расчёта коэффициентов</returns>
        public static AproximationInfo Cube(double[] x, double[] y)
        {
            if (x == null || y == null) return null;
            if (x.Length != y.Length) return null;
            if (x.Length < 4) return null;

            double X, Y, X2, X3, X4, X5, X6, XY, X2Y, X3Y,
                   Sum_X = 0, Sum_X2 = 0, Sum_X3 = 0,
                   Sum_X4 = 0, Sum_X5 = 0, Sum_X6 = 0,
                   Sum_Y = 0, Sum_XY = 0, Sum_X2Y = 0, Sum_X3Y = 0,
                   Sigma = 0,                           //Сумма квадратов отклонений
                   Tmp;                                 //Отклонение

            int N = x.Length;
            double[] A = new double[4];
            double Err = 0;

            //Предварительные рассчеты
            for (int i = 0; i < N; i++)
            {
                Y = y[i];
                X = x[i];
                //Накопление данных для вычисления результатов
                X2 = X * X; X3 = X * X * X; X4 = X2 * X2; X5 = X4 * X; X6 = X4 * X2;
                XY = X * Y; X2Y = X2 * Y; X3Y = X3 * Y;
                Sum_X += X; Sum_X2 += X2; Sum_X3 += X3;
                Sum_X4 += X4; Sum_X5 += X5; Sum_X6 += X6;
                Sum_Y += Y; Sum_XY += XY; Sum_X2Y += X2Y; Sum_X3Y += X3Y;
            }

            Tmp = (Sum_X3 * Sum_X6 - Sum_X4 * Sum_X5); Tmp = (Sum_X2 * Sum_X6 - Sum_X4 * Sum_X4) * (Sum_X4 * Sum_X6 - Sum_X5 * Sum_X5) - Tmp * Tmp;  //Временное число
            A[0] = (((Sum_X6 * Sum_Y - Sum_X3 * Sum_X3Y) * (Sum_X4 * Sum_X6 - Sum_X5 * Sum_X5) - (Sum_X2 * Sum_X6 - Sum_X3 * Sum_X5) * (Sum_X6 * Sum_X2Y - Sum_X5 * Sum_X3Y)) * Tmp -
               ((Sum_X6 * Sum_XY - Sum_X4 * Sum_X3Y) * (Sum_X4 * Sum_X6 - Sum_X5 * Sum_X5) - (Sum_X3 * Sum_X6 - Sum_X4 * Sum_X5) * (Sum_X6 * Sum_X2Y - Sum_X5 * Sum_X3Y)) * ((Sum_X * Sum_X6 - Sum_X3 * Sum_X4) * (Sum_X4 * Sum_X6 - Sum_X5 * Sum_X5) - (Sum_X3 * Sum_X6 - Sum_X4 * Sum_X5) * (Sum_X2 * Sum_X6 - Sum_X3 * Sum_X5)))
               /
               (((N * Sum_X6 - Sum_X3 * Sum_X3) * (Sum_X4 * Sum_X6 - Sum_X5 * Sum_X5) - (Sum_X2 * Sum_X6 - Sum_X3 * Sum_X5) * (Sum_X2 * Sum_X6 - Sum_X3 * Sum_X5)) * Tmp -
               ((Sum_X * Sum_X6 - Sum_X3 * Sum_X4) * (Sum_X4 * Sum_X6 - Sum_X5 * Sum_X5) - (Sum_X2 * Sum_X6 - Sum_X3 * Sum_X5) * (Sum_X3 * Sum_X6 - Sum_X4 * Sum_X5)) * ((Sum_X * Sum_X6 - Sum_X3 * Sum_X4) * (Sum_X4 * Sum_X6 - Sum_X5 * Sum_X5) - (Sum_X3 * Sum_X6 - Sum_X4 * Sum_X5) * (Sum_X2 * Sum_X6 - Sum_X3 * Sum_X5)));

            A[1] = ((Sum_XY * Sum_X6 - Sum_X3Y * Sum_X4) * (Sum_X4 * Sum_X6 - Sum_X5 * Sum_X5) - (Sum_X3 * Sum_X6 - Sum_X4 * Sum_X5) * (Sum_X6 * Sum_X2Y - Sum_X5 * Sum_X3Y) - A[0] * ((Sum_X * Sum_X6 - Sum_X3 * Sum_X4) * (Sum_X4 * Sum_X6 - Sum_X5 * Sum_X5) - (Sum_X2 * Sum_X6 - Sum_X3 * Sum_X5) * (Sum_X3 * Sum_X6 - Sum_X4 * Sum_X5))) /
               ((Sum_X2 * Sum_X6 - Sum_X4 * Sum_X4) * (Sum_X4 * Sum_X6 - Sum_X5 * Sum_X5) - (Sum_X3 * Sum_X6 - Sum_X4 * Sum_X5) * (Sum_X3 * Sum_X6 - Sum_X4 * Sum_X5));
            A[2] = (Sum_X2Y * Sum_X6 - Sum_X5 * Sum_X3Y + (Sum_X3 * Sum_X5 - Sum_X2 * Sum_X6) * A[0] + (Sum_X4 * Sum_X5 - Sum_X3 * Sum_X6) * A[1]) /
               (Sum_X4 * Sum_X6 - Sum_X5 * Sum_X5);
            A[3] = (Sum_X3Y - Sum_X3 * A[0] - Sum_X4 * A[1] - Sum_X5 * A[2]) / Sum_X6;

            for (int i = 0; i < N; i++)
            {
                Tmp = Math.Abs(y[i] - Polynomial(x[i], A)); //Отклонение
                if (Err < Tmp) Err = Tmp;                   //Макс. отклонение
                Sigma += Tmp * Tmp;                         //Сумма квадратов отклонений
            }

            return new AproximationInfo(A, Err, Math.Sqrt(Sigma / (N - 1)));
        }
    }
}
