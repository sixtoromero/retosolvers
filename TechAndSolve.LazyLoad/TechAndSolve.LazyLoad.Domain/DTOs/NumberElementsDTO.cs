using System;
using System.Collections.Generic;
using System.Text;

namespace TechAndSolve.LazyLoad.Domain.DTOs
{
    /// <summary>
    /// Lista los elementos que debe cargar por cada peso del elemento
    /// </summary>
    public class NumberElementsDTO
    {
        /// <summary>
        /// Número de elementos a cargar.
        /// </summary>
        public int CountElements { get; set; }
        /// <summary>
        /// Peso por cada elemento
        /// </summary>
        public List<WeightByElementDTO> WeightByElement { get; set; }
    }
}
