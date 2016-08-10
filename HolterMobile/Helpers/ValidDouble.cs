using HolterMobile.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HolterMobile.Helpers
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Method | AttributeTargets.Parameter | AttributeTargets.Property, AllowMultiple = false)]

    public class ValidDouble : ValidationAttribute

    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            
            if (value == null || value.ToString().Length == 0)
            {
                
                return ValidationResult.Success;
                
            }
            
            double d;

            return !double.TryParse(value.ToString(), out d) ? new ValidationResult(ErrorMessage) : ValidationResult.Success;
            
        }

    }

}

 

public class ValidDoubleValidator : DataAnnotationsModelValidator<ValidDouble>

{

    public ValidDoubleValidator(ModelMetadata metadata, ControllerContext context, ValidDouble attribute)

        : base(metadata, context, attribute) {

        if (!attribute.IsValid(context.HttpContext.Request.Form[metadata.PropertyName])) {

            var propertyName = metadata.PropertyName;

            context.Controller.ViewData.ModelState[propertyName].Errors.Clear();

            context.Controller.ViewData.ModelState[propertyName].Errors.Add(attribute.ErrorMessage);

        }

    }

}