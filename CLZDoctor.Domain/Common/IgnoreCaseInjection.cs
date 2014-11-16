﻿using System;
using Omu.ValueInjecter;

namespace CLZDoctor.Domain.Common
{
    public class IgnoreCaseInjection : ConventionInjection
    {
        protected override bool Match(ConventionInfo c)
        {
            return String.Compare(c.SourceProp.Name, c.TargetProp.Name,
                StringComparison.OrdinalIgnoreCase) == 0;
        }
    }
}