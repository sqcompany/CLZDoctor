using System.Collections.Generic;
using CLZDoctor.Entities;

// ReSharper disable once CheckNamespace
namespace CLZDoctor.Domain
{
    public interface IPrescriptTypeCore
    {
        List<PrescripType> Insert(List<PrescripType> list);
        int Insert(PrescripType prescrip);
        List<PrescripType> SelectPrescripTypes();
        PrescripType SelectPrescripType(int id);
        bool Update(PrescripType prescrip);
    }
}
