using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E = Elmah;

namespace OpenServices.Elmah.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");
            new System.Web.
            var a = E.ErrorSignal.FromContext(new System.Web.HttpContext());
            E.ErrorSignal.FromCurrentContext().Raise(new Exception());
        }
    }
}
