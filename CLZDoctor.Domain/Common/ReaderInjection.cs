﻿using System;
using System.Data;
using Omu.ValueInjecter;

namespace CLZDoctor.Domain.Common
{
    public class ReaderInjection : KnownSourceValueInjection<IDataReader>
    {
        protected override void Inject(IDataReader source, object target)
        {
            for (var i = 0; i < source.FieldCount; i++)
            {
                var activeTarget = target.GetProps().GetByName(source.GetName(i), true);
                if (activeTarget == null) continue;

                var value = source.GetValue(i);
                if (value == DBNull.Value) continue;

                activeTarget.SetValue(target, value);
            }
        }
    }
}