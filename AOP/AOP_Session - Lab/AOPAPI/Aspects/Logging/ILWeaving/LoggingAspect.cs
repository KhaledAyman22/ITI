using AOPAPI.Utilities;
using PostSharp.Aspects;
using PostSharp.Aspects.Advices;
using PostSharp.Extensibility;
using PostSharp.Serialization;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Http.Results;
using Unity;

namespace AOPAPI.Aspects.Logging.ILWeaving
{
    [PSerializable]
    [MulticastAttributeUsage(MulticastTargets.Method, TargetMemberAttributes = MulticastAttributes.Public)]
    public class LoggingAspect : OnMethodBoundaryAspect, IInstanceScopedAspect
    {
        [IntroduceMember(Visibility = PostSharp.Reflection.Visibility.Public, OverrideAction = MemberOverrideAction.Ignore)]
        [CopyCustomAttributes(typeof(DependencyAttribute))]
        [Dependency]
        public ILogger Logger { get; set; }

        [ImportMember("Logger", IsRequired = true)]
        public Property<ILogger> LoggerProperty;

        //[IntroduceMember(Visibility = PostSharp.Reflection.Visibility.Public, OverrideAction = MemberOverrideAction.Ignore)]
        public DateTime Sw;


        //[ImportMember("Sw", IsRequired = true)]
        //public Property<Stopwatch> SwProperty;

        public override void OnException(MethodExecutionArgs args)
        {
            LoggerProperty.Get().LogError(args.Exception);
            args.FlowBehavior = FlowBehavior.Return;
            args.ReturnValue = Activator.CreateInstance(args.ReturnValue.GetType());
        }

        public override void OnExit(MethodExecutionArgs args)
        {
            LoggerProperty.Get().LogDebug($"{nameof(Invoke)} took {DateTime.Now - Sw}ms");
            LoggerProperty.Get().LogDebug($"{nameof(Invoke)} returned {args.ReturnValue}");
            LoggerProperty.Get().LogDebug($"---------------------------------------------------");
        }

        public override void OnEntry(MethodExecutionArgs args)
        {
            Sw = DateTime.Now;

            //LoggerProperty.Get().LogDebug("Entry");
            LoggerProperty.Get().LogDebug($"{nameof(Invoke)} params {args.Arguments[0]}");
            base.OnEntry(args);
        }

        public object CreateInstance(AdviceArgs adviceArgs)
        {
            return this.MemberwiseClone();
        }

        public void RuntimeInitializeInstance()
        {
        }
    }
}