﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinervaPlugin.Logger
{
    internal interface ILogger
    {
        public void Debug(string message);
        public void Error(string message);
        public void Info(string message);
    }
}
