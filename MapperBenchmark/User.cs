using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.Configuration.Conventions;

namespace MapperBenchmark
{
    public class User
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Web { get; set; }

        public UserDetail UserDetail { get; set; }
    }


    public class GetUserNameResponseDTO
    {
        public GetUserNameResponseDTO()
        {

            this.UserDetailDTO = new UserDetailDTO();
        
        }
        public long Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public UserDetailDTO UserDetailDTO { get; set; } 
    }

    public  class UserDetailDTO
    {
        [MapTo(nameof(UserDetail.MomName))]
        public string MatherName { get; set; }
        public int MatherAge { get; set; }
    }

    public class UserDetail
    {
        public string MomName { get; set; }
 
    }
}


