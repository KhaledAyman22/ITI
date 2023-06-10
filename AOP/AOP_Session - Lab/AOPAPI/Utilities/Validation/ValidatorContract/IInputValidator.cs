using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOPAPI.Utilities.Validation.ValidatorContract
{
    public interface IInputValidator<TInput> where TInput : class
    {
        bool IsValid(TInput input);
    }
}
