using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SieuNhanGaoBlog.Areas.Admin.Models
{
    public class ReflectionControler
    {
        //lấy danh sách các controller thông qua các namespace mà chúng ta truyền vào
        public static List<Type> GetControllers(string namespaces)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            IEnumerable<Type> types =
            assembly.GetTypes()
            .Where(type => typeof(Controller).IsAssignableFrom(type) && type.Namespace.Contains(namespaces))
            .OrderBy(x => x.Name);
            return types.ToList();
        }

        //lấy danh sách các action theo controller truyền vào
        public static List<string> GetActions(Type controller)
        {
            List<string> listAction = new List<string>();
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