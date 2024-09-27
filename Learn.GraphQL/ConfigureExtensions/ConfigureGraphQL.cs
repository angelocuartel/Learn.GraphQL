using HotChocolate.Execution.Configuration;
using Learn.GraphQL.ObjectTypes;
using System.Reflection;

namespace Learn.GraphQL.ConfigureExtensions
{
    public static partial class ConfigureExtensions 
    {
        public static void AddAllObjectTypes(this IRequestExecutorBuilder requestExecutorBuilder)
        {
            var currentAssembly = Assembly.GetExecutingAssembly();
            var objectTypeClassList = currentAssembly.GetTypes()
                                    .Where(i => i.IsSubclassOf(typeof(ObjectType)) && i.IsClass)
                                    .ToList();

            foreach (var objectType in objectTypeClassList)
            {
                requestExecutorBuilder.AddType(objectType);
            }
            
        }
    }
}
