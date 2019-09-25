using System;
using System.Collections.Generic;
using System.Text;

namespace TechAndSolve.LazyLoad.Domain.DTOs
{
    /// <summary>
    /// Información del archivo cargado.
    /// </summary>
    public class DataFileDTO
    {
        /// <summary>
        /// Número de días que Wilson trabaja
        /// </summary>
        public int NumberDay { get; set; }
        /// <summary>
        /// Lista de elementos a cargar
        /// </summary>
        public List<NumberElementsDTO> NumberElements { get; set; }

    }
}
