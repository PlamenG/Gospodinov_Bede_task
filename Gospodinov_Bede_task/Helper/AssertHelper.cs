using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
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
                PropertyEvaluationEqual(expected, actual, property);
            }
        }

        public static void AssertListsAreEquals<T>(List<T> expectedList, List<T> actualList)
        {
            if (actualList.Count != expectedList.Count)
                Assert.Fail("Expected IList containing {0} elements but was IList containing {1} elements", expectedList.Count, actualList.Count);

            for (int i = 0; i < actualList.Count; i++)
            {
                PropertyInfo[] properties = expectedList[i].GetType().GetProperties();
                foreach (PropertyInfo property in properties)
                {
                    PropertyEvaluationEqual(expectedList[i], actualList[i], property);
                }
            }
        }

        private static void PropertyEvaluationEqual(object expected, object actual, PropertyInfo property)
        {
            object actualValue = property.GetValue(actual, null);
            object expectedValue = property.GetValue(expected, null);

            var type = actual.ToString();

            if (!Equals(expectedValue, actualValue))
                Assert.Fail("Property {0}.{1} does not match. Expected: {2} but was: {3}"
                            , property.DeclaringType.Name
                            , property.Name
                            , expectedValue
                            , actualValue);
        }
    }
}
