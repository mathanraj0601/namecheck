using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CLI.Engine
{
    public class SnakeCaseEngine
    {
        const string PATTERN = @"^[a-z](?:_[a-z0-9]*)$";
        public static bool Check(string identifierName)
        {
            return Regex.IsMatch(identifierName, PATTERN);
        }
    }
}
