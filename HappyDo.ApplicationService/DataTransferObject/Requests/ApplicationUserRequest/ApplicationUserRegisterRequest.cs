using HappyDo.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDo.ApplicationService.DataTransferObject.Requests.ApplicationUserRequest
{
    public sealed record ApplicationUserRegisterRequest
    {
        public required string UserLogin { get; set; }
        public required string Name { get; set; }
        public required DateTime DateOfBirth { get; set; }  
        public required string CPF { get; set; }
        public required string PhoneNumber { get; set; }
        public required string Street { get; set; }
        public required string City { get; set; }
        public required string State { get; set; }
        public required string PostalCode { get; set; }
        public required string Country { get; set; }
        public EUserStatus UserStatus { get; set; }
        public string Password { get; set; }
        public Guid RoleId { get; set; }
    }

}
