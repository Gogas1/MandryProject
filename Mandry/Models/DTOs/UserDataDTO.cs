﻿using Mandry.Models.DTOs.ApiDTOs;

namespace Mandry.Models.DTOs
{
    public class UserDataDTO
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public ImageDTO Avatar { get; set; }
    }
}
