﻿using System.ComponentModel.DataAnnotations;

namespace TTcms.Services.Identity.API.Models.ManageViewModels
{
    public record AddPhoneNumberViewModel
    {
        [Required]
        [Phone]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; init; }
    }
}
