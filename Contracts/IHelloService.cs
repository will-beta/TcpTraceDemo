﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace Contracts
{
    [ServiceContract]
    public interface IHelloService
    {
        [OperationContract]
        string Greeting(string name);

    }

}
