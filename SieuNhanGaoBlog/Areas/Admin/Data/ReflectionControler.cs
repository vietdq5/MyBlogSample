using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SieuNhanGaoBlog.Areas.Admin.Data
{
    public class ReflectionControler
    {
        //
        // Summary: Get controler of namespace
        //
        // Parameters: Type controller
        //
        // Returns: IList action of namespace
        //
        public static IList<Type> GetControllers(string namespaces)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            IEnumerable<Type> types = assembly.GetTypes()
            .Where(type => typeof(Controller).IsAssignableFrom(type) && type.Namespace.Contains(namespaces))
            .OrderBy(x => x.Name);

            return types.ToList();
        }

        //
        // Summary: Get action of controler
        //
        // Parameters: Type controller
        //
        // Returns: IList action of Controller
        //
        public static IList<string> GetActions(Type controller)
        {
            IList<string> listAction = new List<string>();
            IEnumerable<MemberInfo> memberInfos =
                controller.GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public)
                    .Where(
                        m =>
                            !m.GetCustomAttributes(typeof(System.Runtime.CompilerServices.CompilerGeneratedAttribute),
                                true).Any()).OrderBy(x => x.Name);
            foreach (MemberInfo method in memberInfos)
            {
                if (method.ReflectedType.IsPublic && !method.IsDefined(typeof(NonActionAttribute)))
                {
                    listAction.Add(method.Name.ToString());
                }
            }
            return listAction;
        }
    }
}