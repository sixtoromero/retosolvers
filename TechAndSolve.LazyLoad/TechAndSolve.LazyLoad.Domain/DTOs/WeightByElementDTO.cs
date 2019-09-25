using System;
using System.Collections.Generic;
using System.Text;

namespace TechAndSolve.LazyLoad.Domain.DTOs
{
    /// <summary>
    /// Peso de cada elemento
    /// </summary>
    public class WeightByElementDTO
    {
        public int IdWeight { get; set; }
        /// <summary>
        /// Wi Equivale al peso del elemento
        /// </summary>
        public int Weight { get; set; }
        /// <summary>
        /// Valida el requesito de que cada elemento pese "1<=Wi<=100"
        /// </summary>
        public bool IsValidate { get; set; }
        /// <summary>
        /// Valida si acepta la cantidad máxima permitda
        /// </summary>
        public bool IsValidateWeight { get; set; }

    }
}
