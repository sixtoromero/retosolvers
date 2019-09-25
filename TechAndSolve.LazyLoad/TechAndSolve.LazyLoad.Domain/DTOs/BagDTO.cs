using System;
using System.Collections.Generic;
using System.Text;

namespace TechAndSolve.LazyLoad.Domain.DTOs
{
    public class BagDTO
    {
        /// <summary>
        /// Día en que se hace la carga en la bolsa
        /// </summary>
        public int Day { get; set; }
        /// <summary>
        /// Id del peso del elemento agregado Max
        /// </summary>
        public int IdWeightMax { get; set; }
        /// <summary>
        /// Id del peso del elemento agregado Min
        /// </summary>
        public int IdWeightMin { get; set; }
        /// <summary>
        /// Wi Equivale al peso del elemento
        /// </summary>
        public int MaxWeight { get; set; }
        public int MinWeight { get; set; }
        /// <summary>
        /// Valida que el peso está entre 50 y 60 libras.
        /// </summary>
        public bool IsValidate { get; set; }
        /// <summary>
        /// Valida si es par o no
        /// </summary>
        public bool IsPair { get; set; }

        public int CountTravels { get; set; }
    }
}
