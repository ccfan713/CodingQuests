using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTests.DP
{
    public class NoPublicCtor
    {
        private NoPublicCtor()
        {

        }

        public static NoPublicCtor Creator()
        {
            return new NoPublicCtor();
        }
    }
}
