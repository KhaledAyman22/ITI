using AOPAPI.Utilities;
using PostSharp.Aspects;
using PostSharp.Aspects.Advices;
using PostSharp.Extensibility;
using PostSharp.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Unity;

namespace AOPAPI.Aspects.Logging.ILWeaving
{
    [PSerializable]
    [MulticastAttributeUsage(MulticastTargets.Method, TargetMemberAttributes = MulticastAttributes.Public)]
    public class LoggingAspect : OnMethodBoundaryAspect, IInstanceScopedAspect
    {
        [IntroduceMember(Visibility = PostSharp.Reflection.Visibility.Private, OverrideAction = MemberOverrideAction.Ignore)]
        [CopyCustomAttributes(typeof(DependencyAttribute))]
        [Dependency]
        public ILogger Logger { get; set; }

        [ImportMember("Logger", IsRequired = true)]
        public Property<ILogger> LoggerProperty;

        public override void OnException(MethodExecutionArgs args)
        {
            LoggerProperty.Get().LogError(args.Exception);
            args.FlowBehavior = FlowBehavior.Return;
            args.ReturnValue = null;
        }

        public override void OnEntry(MethodExecutionArgs args)
        {
            LoggerProperty.Get().LogDebug("Entry");
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