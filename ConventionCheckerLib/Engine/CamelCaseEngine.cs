using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CLI.Engine
{
    public class CamelCaseEngine
    {
        const string PATTERN = "^[a-z]+(?:[A-Z][a-z]+)*$";
        public static bool Check(string identifierName)
        {
            return Regex.IsMatch(identifierName, PATTERN);
        }
    }
}
