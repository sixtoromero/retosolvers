using System;
using System.Collections.Generic;
using System.Text;
using TechAndSolve.LazyLoad.Common.Clases.Helpers;
using TechAndSolve.LazyLoad.Common.Resources;
using TechAndSolve.LazyLoad.Domain.DTOs;

namespace TechAndSolve.LazyLoad.Domain.Services.DataFile
{
    public class DataFile
    {
        string path = string.Empty;
        public DataFile(string _path)
        {
            path = _path;
        }

        public DataFileDTO GetResult()
        {
            try
            {
                DataFileDTO iDataFile = new DataFileDTO();
                NumberElementsDTO iNumberElements = new NumberElementsDTO();
                WeightByElementDTO iWeightByElement = new WeightByElementDTO();
                int IdWeight = 0;
                int pos = 0;

                var liFile = FileHelper.getFile(path);
                if (liFile.Count > 0)
                {

                    //Se agregan las primeras 2 posiciones 0 para el número de días y 1 para la cantidad de elementos a cargar
                    iDataFile.NumberDay = liFile[pos];
                    iDataFile.NumberElements = new List<NumberElementsDTO>();
                    //Validamos que la cantidad de día si sea correcta
                    if (ValidateHelper.Validate("T", iDataFile.NumberDay))
                    {
                        //Se recorren los días de trabajo de Wilson
                        for (int x = 0; x < iDataFile.NumberDay; x++)
                        {
                            pos++;
                            IdWeight++;

                            iNumberElements = new NumberElementsDTO();
                            iNumberElements.CountElements = liFile[pos];
                            iNumberElements.WeightByElement = new List<WeightByElementDTO>();

                            //Validación de el número de elementos permitidos
                            if (iNumberElements.CountElements <= int.Parse(RanksResources.N))
                            {
                                for (int i = 0; i < iNumberElements.CountElements; i++)
                                {
                                    pos++;

                                    iWeightByElement = new WeightByElementDTO();
                                    iWeightByElement.IdWeight = IdWeight;
                                    iWeightByElement.Weight = liFile[pos];
                                    //Validación peso máximo permitido.
                                    iWeightByElement.IsValidate = ValidateHelper.Validate("Wi", liFile[pos]);
                                    iWeightByElement.IsValidateWeight = liFile[pos] >= int.Parse(RanksResources.MaxWeight);
                                    iNumberElements.WeightByElement.Add(iWeightByElement);

                                    IdWeight++;
                                }

                                iNumberElements.WeightByElement = iNumberElements.WeightByElement.OrderByDescending(ord => ord.Weight).ToList();
                                iDataFile.NumberElements.Add(iNumberElements);
                            }
                        }
                    }
                }

                return iDataFile;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
