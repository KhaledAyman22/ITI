using AOPAPI.Utilities;
using AOPAPI.Utilities.Validation.ValidatorContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Services.Description;
using Unity;
using Unity.Interception.InterceptionBehaviors;
using Unity.Interception.PolicyInjection.Pipeline;

namespace AOPAPI.Aspects.Validation.Interceptor
{
    public class ValidationInterceptor : IInterceptionBehavior
    {
        private readonly IUnityContainer _unityContainer;

        public ValidationInterceptor(IUnityContainer unityContainer)
        {
            _unityContainer = unityContainer;
        }
        public bool WillExecute => true;

        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            try
            {
                if (input.Arguments.Count == 0)
                    return getNext()(input, getNext);

                var arg = input.Arguments[0];
                var argType = arg.GetType();
                if (!argType.IsClass)
                    return getNext()(input, getNext);

                var validatorType = typeof(IInputValidator<>).MakeGenericType(argType);
                var validator = _unityContainer.Resolve(validatorType);
                var isValid =  (bool)validator.GetType().GetMethod("IsValid").Invoke(validator, new object[] { arg });
                if (!isValid)
                {
                    var defaultValue = GetDefaultValue(input.MethodBase);
                    return input.CreateMethodReturn(defaultValue);
                }
                var result  = getNext()(input, getNext); 
                return result;
            }
            catch (ResolutionFailedException)
            {
                return getNext()(input, getNext);
            }
        }


            private object GetDefaultValue(MethodBase methodBase)
            {
                var info = methodBase as MethodInfo;
                var returnType = info.ReturnType;
                if (!returnType.IsValueType)
                    return null;
                else
                    return Activator.CreateInstance(returnType);
            }
        }
}