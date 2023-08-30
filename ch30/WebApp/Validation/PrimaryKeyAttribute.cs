﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Validation
{
    public class PrimaryKeyAttribute : ValidationAttribute
    {
        public Type? ContextTypes { get; set; }
        public Type? DataType { get; set; }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (ContextTypes != null && DataType != null )
            {
                DbContext? context = validationContext.GetRequiredService(ContextTypes) as DbContext;
                if ( context != null && context.Find(DataType, value) == null)
                {
                    return new ValidationResult(ErrorMessage ?? "Enter an existing key value");
                }
            }

            return ValidationResult.Success;
        }
    }
}
