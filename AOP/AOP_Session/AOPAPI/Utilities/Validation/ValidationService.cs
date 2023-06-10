using AOPAPI.Utilities.Validation.ValidatorContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Unity;

namespace AOPAPI.Utilities.Validation
{
    public class ValidationService : IValidationService
    {
        private readonly IUnityContainer _unityContainer;

        public ValidationService(IUnityContainer unityContainer)
        {
            _unityContainer = unityContainer;
        }

        public bool IsValid<TInput>(TInput input)
            where TInput : class
        {
            var validator = _unityContainer.Resolve<IInputValidator<TInput>>();
            return validator.IsValid(input);
        }
    }
}