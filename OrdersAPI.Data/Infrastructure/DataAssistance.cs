using Dapper;
using System.Linq;

namespace OrdersAPI.Data.Infrastructure
{
    public class DataAssistance
    {
        public static string SQLView<T>(T objProperties, string view)
        {
            var properties = GenerericProperties(objProperties);
            return string.Concat($"SELECT {properties} FROM {view}");
        }

        public static string SQLView<T>(T objProperties, string view, string conditions)
        {
            var properties = GenerericProperties(objProperties);
            return string.Concat($"SELECT {properties} FROM {view} WHERE {conditions}");
        }

        public static DynamicParameters AddParameters<T>(T objProperties)
        {
            var parameters = new DynamicParameters();

            foreach (var prop in objProperties.GetType().GetProperties())
            {
                parameters.Add($"@{prop.Name}", prop.GetValue(objProperties, null));
            }

            return parameters;
        }

        private static string GenerericProperties<T>(T objProperties)
        {
            var properties = "";

            foreach (var proper in objProperties.GetType().GetProperties())
            {
                if (proper != null)
                    properties += (proper == objProperties.GetType().GetProperties().LastOrDefault())
                        ? string.Concat($"[{proper.Name}]")
                        : string.Concat($"[{proper.Name}] ,");
            }

            return properties;
        }
    }
}
