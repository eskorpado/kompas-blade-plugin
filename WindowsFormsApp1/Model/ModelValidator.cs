using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace WindowsFormsApp1.Model
{
    internal static class ModelValidator
    {
        public static void Validate(Blade blade)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(blade);
            if (Validator.TryValidateObject(blade, context, results, true)) return;
            throw new ValidationException(results);
        }
    }

    class ValidationException : Exception
    {
        public ValidationException(IEnumerable<ValidationResult> results) : base(String.Join("\n", results.Select(result => result.ErrorMessage)))
        {
            var list = new List<string>();
        }
    }

}
