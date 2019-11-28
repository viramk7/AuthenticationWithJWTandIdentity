using System;
using System.Collections.Generic;

namespace AuthenticationDemo.Models
{
    public class RegisterOutputDto : BaseGatewayResponse
    {
        public RegisterOutputDto(string userId, string email, 
                                 bool success = false, IEnumerable<Error> errors = null) : base(success, errors)
        {
            UserId = userId;
            Email = email;
        }

        public string UserId { get; set; }
        public string Email { get; set; }
    }
}
