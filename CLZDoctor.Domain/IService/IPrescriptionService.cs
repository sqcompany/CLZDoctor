using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CLZDoctor.Domain.Common;
using CLZDoctor.Entities;

// ReSharper disable once CheckNamespace
namespace CLZDoctor.Domain
{
    public interface IPrescriptionService
    {
        OperationResult Insert(Prescription prescription);
    }
}
