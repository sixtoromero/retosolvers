using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TechAndSolve.LazyLoad.Common.Clases.Helpers;
using TechAndSolve.LazyLoad.Domain.DTOs;

namespace TechAndSolve.LazyLoad.Domain.Services.Process
{
    public class ProcessLazy
    {
        List<BagDTO> liBag = new List<BagDTO>();
        public ProcessLazy(List<BagDTO> result)
        {
            liBag = result;
        }

        public string GetResult()
        {
            StringBuilder sbResult = new StringBuilder();
            var result = liBag.GroupBy(g => g.Day).ToList();
            for (int i = 0; i < result.Count; i++)
            {
                var iresult = result[i];

                switch ((i + 1))
                {
                    case 1:    
                    case 2:
                        sbResult.AppendLine($"Case día#{i + 1} : { iresult.ToList().Count } ");
                        break;
                    case 3:
                        var iresispair = result[i].GroupBy(g => g.IsPair).ToList();
                        sbResult.AppendLine($"Case día#{i + 1} : { iresispair.Count } ");
                        break;
                    case 4:
                        sbResult.AppendLine($"Case día#{i + 1} : { iresult.ToList().Count / 2 } ");
                        break;
                    case 5:
                        sbResult.AppendLine($"Case día#{i + 1} : { iresult.ToList().Count - 2 } ");
                        break;
                }
            }

            return sbResult.ToString();
        }
    }
}
