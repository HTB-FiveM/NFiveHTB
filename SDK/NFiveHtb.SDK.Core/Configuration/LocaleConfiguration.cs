﻿namespace NFiveHtb.SDK.Core.Configuration
{
    using JetBrains.Annotations;
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    [PublicAPI]
    public class LocaleConfiguration
	{
		public List<CultureInfo> Culture { get; set; }

		public TimeZoneInfo TimeZone { get; set; }
	}
}