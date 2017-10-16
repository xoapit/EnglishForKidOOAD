using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;

namespace EnglishForKidAPI.Models
{
    public class ReflectionController
    {
        // Get List APIControllers
        public List<Type> GetControllers(string namespaces = "EnglishForKidAPI.Controller")
        {
            List<Type> listController = new List<Type>();
            Assembly assembly = Assembly.GetExecutingAssembly();
            //Get depend on base class type name into typeof(method)
            IEnumerable<Type> types = assembly.GetTypes().Where(type => typeof(System.Web.Http.ApiController).IsAssignableFrom(type) && type.Namespace.Contains(namespaces) && !(type.Name.Contains("Base"))).OrderBy(x => x.Name);
            return types.ToList();
        }

        // Get Actions belong to this APIController
        public List<string> GetActions(Type controller)
        {
            List<string> listAction = new List<string>();
            IEnumerable<MemberInfo> memberInfo = controller.GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public).Where(m => !m.GetCustomAttributes(typeof(System.Runtime.CompilerServices.CompilerGeneratedAttribute), true).Any()).OrderBy(x => x.Name);
            foreach (MemberInfo method in memberInfo)
            {
                if (method.ReflectedType.IsPublic && !method.IsDefined(typeof(NonActionAttribute)))
                {
                    listAction.Add(method.Name.ToString());
                }
            }
            return listAction;
        }

        public string GetActionsForUser(string userID = "431b7969-6ab1-461f-ab96-233d00dbe5c3")
        {
            // RequestContext.Priciple.Identity.Name();

            ApplicationDbContext context = new ApplicationDbContext();
            var user = context.Users.FirstOrDefault(u => u.Id == userID);

            string result = user.UserName + user.Roles;

            return result;
        }
    }
}