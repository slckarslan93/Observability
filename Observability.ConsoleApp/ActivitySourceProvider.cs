﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observability.ConsoleApp
{
    public static class ActivitySourceProvider
    {
        public static ActivitySource Source = new ActivitySource(OpenTelemetryConstants.ActivitySourceName);
    }
}
