using MapperBenchmark;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        [TestMethod]
  
        public void ValidateGetXmlToObjectWithParam_CurrencyRangeMax_Test()
        {

            BenchmarkMapper mapper = new BenchmarkMapper();

            mapper.CreateFakeData();

            mapper.Mapster();
            mapper.AutoMapperBenchmark();
            mapper.HandMadeMap();
            mapper.TinyMapperBenchmark();



        }
    }
}
