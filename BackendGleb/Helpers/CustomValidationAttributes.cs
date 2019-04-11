﻿using BackendGleb.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackendGleb.Helpers
{
    public class CustomEmailAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value,
            ValidationContext validationContext)
        {
            var service = (UserManager<DbUser>)validationContext
                       .GetService(typeof(UserManager<DbUser>));

            var user = service.FindByEmailAsync(value.ToString())
                .Result;

            // var context = (EFDbContext)validationContext
            //        .GetService(typeof(EFDbContext));

            if (user != null)
            {
                return new ValidationResult(null);
            }
            return ValidationResult.Success;
        }
    }
}
