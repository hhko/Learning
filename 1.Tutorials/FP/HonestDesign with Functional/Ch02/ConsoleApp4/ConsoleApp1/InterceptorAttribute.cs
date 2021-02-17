using MethodDecorator.Fody.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    // Any attribute which provides OnEntry/OnExit/OnException with proper args
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Constructor | AttributeTargets.Assembly | AttributeTargets.Module)]
    public class InterceptorAttribute : Attribute, IMethodDecorator
    {
        // instance, method and args can be captured here and stored in attribute instance fields
        // for future usage in OnEntry/OnExit/OnException
        public void Init(object instance, MethodBase method, object[] args)
        {
            //TestMessages.Record(string.Format("Init: {0} [{1}]", method.DeclaringType.FullName + "." + method.Name, args.Length));
        }

        public void OnEntry()
        {
            //TestMessages.Record("OnEntry");
        }

        public void OnExit()
        {
            //TestMessages.Record("OnExit");
        }

        public void OnException(Exception exception)
        {
            //TestMessages.Record(string.Format("OnException: {0}: {1}", exception.GetType(), exception.Message));
        }
    }

    //public class Sample
    //{
    //    [Interceptor]
    //    public void Method()
    //    {
    //       // Debug.WriteLine("Your Code");
    //    }
    //}
}
