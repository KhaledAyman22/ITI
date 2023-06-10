using AOPAPI.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Web;
using Unity.Interception.InterceptionBehaviors;
using Unity.Interception.PolicyInjection.Pipeline;

namespace AOPAPI.Aspects.Logging.Interceptor
{
    public class LoggingInterceptor : IInterceptionBehavior
    {
        private readonly ILogger _logger;

        public LoggingInterceptor(ILogger logger)
        {
            _logger = logger;
        }

        public bool WillExecute => true;

        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            _logger.LogDebug($"{nameof(Invoke)} params {input.Arguments[0]}");

            Stopwatch sw = new Stopwatch();
            sw.Start();
            var result = getNext()(input, getNext);
            sw.Stop();
            _logger.LogDebug($"{nameof(Invoke)} took {sw.ElapsedMilliseconds}ms");
            
            // after invocation
            if (result.Exception != null)
            {
                _logger.LogError(result.Exception);
                var defaultValue = GetDefaultValue(input.MethodBase);
                return input.CreateMethodReturn(defaultValue);
            }

            _logger.LogDebug($"{nameof(Invoke)} returned {result.ReturnValue}");
            _logger.LogDebug($"---------------------------------------------------");
            return result;
        }

        private object GetDefaultValue(MethodBase methodBase)
        {
            var info = methodBase as MethodInfo;
            var returnType = info.ReturnType;
            if (!returnType.IsValueType)
                return null;
            if (returnType == typeof(int))
                return default(int);
            return default;
        }
    }
}