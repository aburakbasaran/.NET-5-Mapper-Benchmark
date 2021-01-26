using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using Mapster;
using Nelibur.ObjectMapper;

namespace MapperBenchmark
{
    [ShortRunJob]
    [MemoryDiagnoser]
    [KeepBenchmarkFiles(true)]
    [Orderer(SummaryOrderPolicy.FastestToSlowest, MethodOrderPolicy.Declared)]
    [MarkdownExporter, AsciiDocExporter, HtmlExporter, CsvExporter, RPlotExporter]
    public class BenchmarkMapper
    {
        [Params(1,10,100,1000)]
        public int loops ;

        private List<User> _userrList;
        private readonly MapperConfiguration _config;

        public BenchmarkMapper()
        {
            #region Config
            _config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<User, GetUserNameResponseDTO>().ForMember(x => x.UserDetailDTO, opt => opt.MapFrom(src => src.UserDetail));
                    cfg.CreateMap<UserDetail, UserDetailDTO>().ForMember(x => x.MatherName, opt => opt.MapFrom(src => src.MomName));

                });


            TypeAdapterConfig<User, GetUserNameResponseDTO>.NewConfig()
                            .Map(dest => dest.UserDetailDTO, src => src.UserDetail);

            TypeAdapterConfig<UserDetail, UserDetailDTO>.NewConfig()
                       .Map(dest => dest.MatherName, src => src.MomName);



            //TinyMapper.Bind<List<User>, List<GetUserNameResponseDTO>>();


            TinyMapper.Bind<User, GetUserNameResponseDTO>(config =>
            {
                config.Bind(source => source.UserDetail, target => target.UserDetailDTO);      
            });


            TinyMapper.Bind<UserDetail, UserDetailDTO > (config =>
            {
                config.Bind(source => source.MomName, target => target.MatherName);
            });



            #endregion
        }
        [GlobalSetup]
        public void CreateFakeData()
        {
            _userrList = new List<User>();

            for (int i = 0; i < loops; i++)
            {

                var _userDetail = new UserDetail();
                _userDetail.MomName = Faker.Name.Middle();

                _userrList.Add(new User
                {
                    Address = Faker.Address.SecondaryAddress(),
                    City = Faker.Address.City(),
                    Age = Faker.RandomNumber.Next(10, 100),
                    Name = Faker.Name.First(),
                    Surname = Faker.Name.Last(),
                    Phone = Faker.Phone.Number(),
                    Web = Faker.Internet.DomainName(),
                    Email = Faker.Internet.Email(),
                    Country = Faker.Address.Country(),
                    UserDetail = _userDetail
                });
            }
        }

        [Benchmark]
        public void AutoMapperBenchmark()
        {
            var config = _config.CreateMapper();
            var dto = config.Map<List<GetUserNameResponseDTO>>(_userrList);
        }

        [Benchmark]
        public void TinyMapperBenchmark()
        {
            var customerDtoList = new List<GetUserNameResponseDTO>();
            for (int i = 0; i < _userrList.Count; i++)
            {
                customerDtoList.Add(TinyMapper.Map<GetUserNameResponseDTO>(_userrList[i]));
            }

        }

        [Benchmark]
        public void Mapster()
        {
            var customerDtoList = new List<GetUserNameResponseDTO>();
            var dto = _userrList.Adapt(customerDtoList);
        }

        [Benchmark]
        public void HandMadeMap()
        {
            var dt0 = _userrList.Select(l => new GetUserNameResponseDTO
            {
                Id = l.Id,
                Name = l.Name,
                Surname = l.Surname,
                UserDetailDTO =  { MatherName = l.UserDetail.MomName }
            }).ToList();
        }





    }
}
