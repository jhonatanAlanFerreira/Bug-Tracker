using System.Collections.Generic;
using System.Reflection;

namespace bug_tracker.Utils
{
    public static class ClassToDictionary
    {
        public static Dictionary<string, object> ToDictionary<T>(T data, bool SkipNull = true)
        {
            Dictionary<string, object> ret = new Dictionary<string, object>();

            foreach (PropertyInfo prop in data.GetType().GetProperties())
            {
                string propName = prop.Name;
                var val = data.GetType().GetProperty(propName).GetValue(data, null);
                if (val != null)
                {
                    ret.Add(propName, val);
                }
                else if (!SkipNull)
                {
                    ret.Add(propName, null);
                }
            }

            return ret;
        }
    }
}