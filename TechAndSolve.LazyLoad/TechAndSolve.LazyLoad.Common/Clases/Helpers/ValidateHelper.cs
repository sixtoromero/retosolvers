using System;
using System.Collections.Generic;
using System.Text;
using TechAndSolve.LazyLoad.Common.Resources;

namespace TechAndSolve.LazyLoad.Common.Clases.Helpers
{
    public static class ValidateHelper
    {
        /// <summary>
        /// Validación de los pesos
        /// </summary>
        /// <param name="valid">T, N, Wi</param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool Validate(string valid, int value)
        {
            switch (valid)
            {
                case "T":
                    return value >= 1 && value <= int.Parse(RanksResources.T);
                case "N":
                    return value >= 1 && value <= int.Parse(RanksResources.N);
                case "Wi":
                    return value >= 1 && value <= int.Parse(RanksResources.Wi);
                default:
                    return false;
            }
        }

        public static bool IsPair(int Number)
        {
            return Convert.ToBoolean((Number % 2 == 0 ? true : false));
        }

    }
}
