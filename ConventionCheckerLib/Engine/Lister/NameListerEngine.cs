using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI.Engine.Lister
{
    public class NameListerEngine
    {
        public static void Get(List<string> FollowingNames,
                                          List<string> ViolatingNames,
                                          NamingConventionEngine namingConventionEngine,
                                          string convention,
                                          string name)
        {

            if (namingConventionEngine.Check(convention, name))
            {
                FollowingNames.Add(name);
            }
            else
            {
                ViolatingNames.Add(name);
            }
        }
    }
}
