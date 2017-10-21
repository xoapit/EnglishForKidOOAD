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

        protected ApplicationDbContext db = ApplicationDbContext.Create();

        public List<string> GetActionsForUser(string username = "admin")
        {
            List<string> result = new List<string>();
            var user = db.Users.FirstOrDefault(u => u.UserName == username);
            var roles = db.UserRoles.Where(ur => ur.UserId == user.Id);

            foreach (var role in roles)
            {
                var functions = db.Functions.Where(f => f.IdentityRoleID == role.RoleId);
                foreach (var function in functions)
                {
                    result.Add(function.Name);
                }
            }

            return result;
        }
    }
}