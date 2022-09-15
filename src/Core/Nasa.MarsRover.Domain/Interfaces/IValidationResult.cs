using System.Collections.Generic;

namespace Nasa.MarsRover.Domain.Interfaces
{
    public interface IValidationResult
    {
        bool IsValid { get; }
        dynamic Data { get; set; }
        List<string> Errors { get; }
        void AddError(string error);
    }
}