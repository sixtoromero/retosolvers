using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechAndSolve.LazyLoad.Common.Clases.Helpers;
using TechAndSolve.LazyLoad.Common.Resources;
using TechAndSolve.LazyLoad.Domain.DTOs;

namespace TechAndSolve.LazyLoad.Domain.Services.Bag
{
    public class Bag
    {
        DataFileDTO iDataFile;
        int day = 0;
        public Bag(DataFileDTO _iDataFile)
        {
            iDataFile = _iDataFile;
        }

        public List<BagDTO> BagTravels()
        {
            var iBag = new BagDTO();
            var liBag = new List<BagDTO>();
            int IdWeight = 0;

            foreach (var item in iDataFile.NumberElements)
            {
                day++;
                switch (day)
                {
                    case 1:
                        for (int x = 0; x < item.WeightByElement.Count / 2; x++)
                        {
                            iBag = new BagDTO();
                            iBag.Day = day;
                            iBag.MaxWeight = item.WeightByElement[0].Weight;
                            iBag.MinWeight = item.WeightByElement[item.WeightByElement.Count - (x + 1)].Weight;
                            iBag.IsValidate = ValidateHelper.Validate("Wi", iBag.MaxWeight);
                            iBag.CountTravels = item.WeightByElement.Count / 2;
                            liBag.Add(iBag);
                        }
                        break;
                    case 2:

                        iBag = new BagDTO();
                        iBag.Day = day;
                        iBag.MaxWeight = item.WeightByElement.Sum(s => s.Weight);
                        iBag.MinWeight = 0;
                        iBag.CountTravels = 1;
                        iBag.IsValidate = ValidateHelper.Validate("Wi", iBag.MaxWeight);
                        liBag.Add(iBag);

                        break;

                    case 3:
                        for (int x = 0; x < item.WeightByElement.Count; x++)
                        {
                            iBag = new BagDTO();
                            iBag.IdWeightMax = item.WeightByElement[x].IdWeight;
                            iBag.IdWeightMin = 0;
                            iBag.Day = day;
                            iBag.MaxWeight = item.WeightByElement[x].Weight;
                            iBag.MinWeight = 0;
                            iBag.CountTravels = liBag.GroupBy(g => g.IsPair).ToList().Count; 
                            iBag.IsValidate = ValidateHelper.Validate("Wi", iBag.MaxWeight);
                            iBag.IsPair = ValidateHelper.IsPair(item.WeightByElement[x].Weight);

                            liBag.Add(iBag);
                        }
                        break;
                    case 4:
                    case 5:
                        for (int i = 0; i < item.WeightByElement.Count; i++)
                        {
                            if (item.WeightByElement[i].Weight >= int.Parse(RanksResources.MaxWeight))
                            {
                                iBag = new BagDTO();
                                iBag.IdWeightMax = item.WeightByElement[i].IdWeight;
                                iBag.IdWeightMin = 0;
                                iBag.Day = day;
                                iBag.MaxWeight = item.WeightByElement[i].Weight;
                                iBag.MinWeight = item.WeightByElement[item.WeightByElement.Count - (i + 1)].Weight;
                                iBag.IsValidate = ValidateHelper.Validate("Wi", iBag.MaxWeight);

                                if (liBag.Where(w => w.IdWeightMax == iBag.IdWeightMax && w.IdWeightMin == iBag.IdWeightMin).ToList().Count == 0)
                                {
                                    liBag.Add(iBag);
                                }
                            }
                            else
                            {
                                iBag = new BagDTO();
                                iBag.IdWeightMax = item.WeightByElement[i].IdWeight;
                                iBag.Day = day;
                                iBag.MaxWeight = item.WeightByElement[i].Weight;
                                iBag.MinWeight = item.WeightByElement[item.WeightByElement.Count - i].Weight;
                                iBag.IdWeightMin = item.WeightByElement[item.WeightByElement.Count - i].IdWeight;
                                iBag.IsValidate = ValidateHelper.Validate("Wi", iBag.MaxWeight);

                                //if (liBag.Where(w => w.IdWeightMax == iBag.IdWeightMax || w.IdWeightMin == iBag.IdWeightMax).ToList().Count == 0)
                                if (liBag.Where(w => w.IdWeightMax == iBag.IdWeightMax).ToList().Count == 0)
                                {
                                    //if (liBag.Where(w => w.IdWeightMin == iBag.IdWeightMin || w.IdWeightMax == iBag.IdWeightMin).ToList().Count == 0)
                                    if (liBag.Where(w => w.IdWeightMin == iBag.IdWeightMin).ToList().Count == 0)
                                    {
                                        liBag.Add(iBag);
                                    }
                                }
                            }
                        }
                        break;
                }
            }

            return liBag;
        }


    }
}
