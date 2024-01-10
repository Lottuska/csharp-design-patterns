using System;

namespace Coding.Exercise
{
    public class SingletonTester
    {
        private static int instanceId = 0;

        public static bool IsSingleton(Func<object> func)
        {
            var response = false;
            if (instanceId != func.GetHashCode())
            {
                response = true;
                instanceId = func.GetHashCode();
            }

            return response;
        }
    }
}
