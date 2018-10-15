using NUnit.Framework;
using System.Reflection;

namespace Gospodinov_Bede_task.Helper
{
    public static class AssertHelper
    {
        public static void PropertyValuesAreEquals(object expected, object actual)
        {
            PropertyInfo[] properties = expected.GetType().GetProperties();
            foreach (PropertyInfo property in properties)
            {
                object expectedValue = property.GetValue(expected, null);
                object actualValue = property.GetValue(actual, null);

                if (!Equals(expectedValue, actualValue))
                    Assert.Fail("Property {0}.{1} does not match. Expected: {2} but was: {3}"
                                , property.DeclaringType.Name
                                , property.Name
                                , expectedValue
                                , actualValue);
            }
        }
    }
}
