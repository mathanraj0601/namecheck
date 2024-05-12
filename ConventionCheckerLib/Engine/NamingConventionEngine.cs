using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI.Engine
{
    public  class NamingConventionEngine
    {
        public NamingConventionEngine() 
        { 
        
        }

        public bool Check(string convention,string name)
        {
            switch (convention)
            {
                case "PASCALCASE":
                    return PascalCaseEngine.Check(name);
                case "camelCase":
                    return CamelCaseEngine.Check(name);
                case "snake_case":
                    return SnakeCaseEngine.Check(name);
                case "kebab-case":
                    return KebabCaseEngine.Check(name);
                case "UPPERCASE":
                    return UpperCaseEngine.Check(name);
                default:
                    return false;
            }
        }

    }
}
