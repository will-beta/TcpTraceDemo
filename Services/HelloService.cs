using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contracts;

namespace Services
{
    public class HelloService : IHelloService
    {
        public string Greeting(string name)
        {
            return string.Format("Hello,{0}!", name);
        }
    }

}
