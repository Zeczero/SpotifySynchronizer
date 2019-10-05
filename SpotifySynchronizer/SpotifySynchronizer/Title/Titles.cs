using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifySynchronizer.Title
{
    class Titles
    {
        public void GetTitle (string name)
        {
            Console.Write("\t" + name);
        }
        public void GetCredits(string credit = "by Zeczero")
        {
            Console.WriteLine(credit);
        }
    }
}
