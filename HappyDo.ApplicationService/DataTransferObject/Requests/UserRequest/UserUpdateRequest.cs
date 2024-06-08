using HappyDo.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDo.ApplicationService.DataTransferObject.Requests.UserRequest
{
    public sealed record UserUpdateRequest
    {
        public int UserId { get; set; }
        public required string Name { get; set; }
        public EUserStatus UserStatus { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }

}
