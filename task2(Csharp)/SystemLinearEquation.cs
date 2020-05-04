using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2_Csharp_
{
    public class SystemLinearEquation
    {
        LinearEquationClass[] equations;

        public SystemLinearEquation(int m)
        {
            if (m <= 0)
            {
                throw new ArgumentException();
            }
            this.equations = new LinearEquationClass[m];
            for (int i = 0; i < m; i++)
            {
                this.equations[i] = new LinearEquationClass(2);
            }
        }

        public LinearEquationClass this[int i]
        {
            get
            {
                if (i < 0 || i >= this.equations.Length)
                {
                    throw new ArgumentException();
                }
                return this.equations[i];
            }
            set
            {
                if (i < 0 || i >= this.equations.Length)
                {
                    throw new ArgumentException();
                }
                this.equations[i] = new LinearEquationClass(value);
            }
        }

        public void ToTriangular()
        {
            Array.Sort(this.equations, (x, y) => (-1 * x.Degree.CompareTo(y.Degree)));
            int maxDegree = this.equations[0].Degree,
                degreeLimit = Math.Max(maxDegree - this.equations.Length + 1, 1),
                numberOfEquation = 0;
            for (int d = maxDegree; d >= degreeLimit; d--)
            {
                if (this.equations[numberOfEquation].Degree < d)
                {
                    continue;
                }
                for (int i = numberOfEquation + 1; i < this.equations.Length; i++)
                {
                    if (this.equations[i].Degree >= d)
                    {
                        this.equations[i] = this.equations[i] - this.equations[numberOfEquation] * (this.equations[i][d] / this.equations[numberOfEquation][d]);
                    }
                }
                Array.Sort(this.equations, (x, y) => (-1 * x.Degree.CompareTo(y.Degree)));
                numberOfEquation += 1;
            }
        }

        public double[] Solve()
        {
            SystemLinearEquation sle = new SystemLinearEquation(this.equations.Length);
            for (int i = 0; i < sle.equations.Length; i++)
            {
                sle.equations[i] = new LinearEquationClass(this.equations[i]);
            }
            sle.ToTriangular();
            for (int i = 0; i < sle.equations.Length; i++)
            {
                if (sle.equations[i])
                {
                    continue;
                }
                else
                {
                    throw new ArithmeticException();
                }
            }
            double[] result = new double[sle.equations[0].Degree];
            result = Enumerable.Repeat(double.PositiveInfinity, result.Length).ToArray();
            for (int i = sle.equations.Length - 1; i >= 0; i--)
            {
                if (sle.equations[i].Degree == 0 || !double.IsInfinity(result[sle.equations[i].Degree - 1]))
                {
                    continue;
                }
                result[sle.equations[i].Degree - 1] = -sle.equations[i][0];
                for (int j = sle.equations[i].Degree - 1; j >= 1; j--)
                {
                    if (!double.IsInfinity(result[j - 1]))
                    {
                        result[sle.equations[i].Degree - 1] -= sle.equations[i][j] * result[j - 1];
                    }
                    else
                    {
                        result[sle.equations[i].Degree - 1] = double.PositiveInfinity;
                        break;
                    }
                }
                result[sle.equations[i].Degree - 1] /= sle.equations[i][sle.equations[i].Degree];
            }
            return result;
        }

        public override string ToString()
        {
            string result = "";
            for (int i = 0; i < this.equations.Length; i++)
            {
                result += this.equations[i] + "\n";
            }
            return result;
        }
    }
}
