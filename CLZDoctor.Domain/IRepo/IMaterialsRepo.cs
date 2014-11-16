using System.Collections.Generic;
using CLZDoctor.Entities;

// ReSharper disable once CheckNamespace
namespace CLZDoctor.Domain
{
    internal interface IMaterialsRepo
    {
        int Insert(Materials materials);
        IEnumerable<Materials> SelectMaterialses(string name);
        Materials SelectMaterials(string name);
    }
}
