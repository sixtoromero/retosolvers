using System;
using TechAndSolve.LazyLoad.Domain.Services.Bag;
using TechAndSolve.LazyLoad.Domain.Services.DataFile;
using TechAndSolve.LazyLoad.Domain.Services.Process;
using Xunit;

namespace TechAndSolve.LazyLoad.UnitTest
{
    public class LazyLoadUnitTest
    {
        [Fact]
        public void LazyLoad()
        {
            DataFile iCal = new DataFile(@"D:\techandsolve\TechAndSolve.LazyLoad\Recursos\lazy_loading_example_input.txt");
            var result = iCal.GetResult();
            Bag oBag = new Bag(result);
            var liBag = oBag.BagTravels();

            ProcessLazy pro = new ProcessLazy(liBag);
            var sbResult = pro.GetResult();
        }
    }
}
