﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp
{
    public class VersionResolver : MarshalByRefObject
    {
        public string GetLibVersion() => VersionSelect.GetVersion();
    }
}
