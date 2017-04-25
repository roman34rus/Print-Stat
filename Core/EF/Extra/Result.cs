using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;

namespace Core.EF
{
    public class Result
    {
        public bool Success { get; private set; } = true;

        public List<Error> Errors { get; private set; } = new List<Error>();

        public void AddDBValidationErrors(IEnumerable<DbValidationError> errors)
        {
            if (errors != null && errors.Count() > 0)
            {
                Success = false;

                foreach (var error in errors)
                    Errors.Add(new Error(error.PropertyName, error.ErrorMessage));
            }
        }

        public void AddCustomError(string propertyName, string errorMessage)
        {
            Success = false;

            Errors.Add(new Error(propertyName, errorMessage));
        }

        public void AddResult(Result result)
        {
            if (!result.Success)
            {
                Success = false;

                Errors.AddRange(result.Errors);
            }
        }

        public Result()
        { }

        public Result(string propertyName, string errorMessage)
        {
            AddCustomError(propertyName, errorMessage);
        }

        public class Error
        {
            public string PropertyName { get; private set; }

            public string ErrorMessage { get; private set; }

            public Error(string propertyName, string errorMessage)
            {
                PropertyName = propertyName;
                ErrorMessage = errorMessage;
            }
        }
    }
}
