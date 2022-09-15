using Nasa.MarsRover.Domain.Interfaces;
using System.Collections.Generic;

namespace Nasa.MarsRover.Domain.Validations
{
    public class ValidationResult : IValidationResult
    { 
        public bool IsValid { get; set; } = true;
        public List<string> Errors { get; set; } = new List<string>();
        public dynamic Data { get; set; }

        public void AddError(string error) 
        {
            Errors.Add(error);
            IsValid = false;
        }
    }
}
