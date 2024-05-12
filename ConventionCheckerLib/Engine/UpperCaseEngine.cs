using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CLI.Engine
{
    public class UpperCaseEngine
    {
        const string PATTERN = @"^[A-Z][A-Z0-9]*$";
        public static bool Check(string identifierName)
        {
            return Regex.IsMatch(identifierName, PATTERN);
        }
    }
}
