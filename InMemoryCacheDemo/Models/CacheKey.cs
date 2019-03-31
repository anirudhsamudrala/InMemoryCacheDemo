using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InMemoryCacheDemo.Models
{
    public static class CacheKey
    {
        public static string FirstName { get { return "_FirstName"; } }
        public static string LastName { get { return "_LastName"; } }
        public static string Email { get { return "_Email"; } }
        public static string EmployeeID { get { return "_EmployeeID"; } }
    }
}
