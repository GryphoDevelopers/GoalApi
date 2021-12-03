using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoalWebApi.Models.Validations
{
    public class MainValidation
    {
        public List<string> Errors { get; private set; }
        public MainValidation(List<string> errors)
        {
            Errors = errors;
        }

        public MainValidation()
        {
            Errors = new List<string>();
        }

        public void AddError(string error)
        {
            Errors.Add(error);
        }

        public void AddErrors(List<string> errors)
        {
            Errors.AddRange(errors);
        }

        public bool isValid()
        {
            return !Errors.Any();
        }
    }
}
