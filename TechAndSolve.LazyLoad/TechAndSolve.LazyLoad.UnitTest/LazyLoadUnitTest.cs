using System;
using TechAndSolve.LazyLoad.Domain.Services.Bag;
using TechAndSolve.LazyLoad.Domain.Services.DataFile;
using Xunit;

namespace TechAndSolve.LazyLoad.UnitTest
{
    public class LazyLoadUnitTest
    {
        [Fact]
        public void LazyLoad()
        {
            DataFile iCal = new DataFile(@"D:\Pruebas tecnicas\TechAndSolve\TechAndSolve\TechAndSolve.LazyLoad\Recursos\lazy_loading_example_input.txt");
            var result = iCal.GetResult();
            Bag oBag = new Bag(result);
            var liBag = oBag.BagTravels();
        }
    }
}
