﻿using System.ComponentModel.DataAnnotations;

namespace GST_API.APIModels
{
    public class AuthenticateModel
    {
        public string username { get; set; }
        public string password { get; set; }

        public bool isASPUser { get; set; } = false;
    }

    public class PublicAuthenticateModel : AuthenticateModel
    {
        public string gstnUsername { get; set; }
        public string gstnPassword { get; set; }
    }
}
