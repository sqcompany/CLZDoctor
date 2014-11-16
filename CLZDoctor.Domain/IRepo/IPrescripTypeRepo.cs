using System.Collections.Generic;
using CLZDoctor.Entities;

// ReSharper disable once CheckNamespace
namespace CLZDoctor.Domain
{
    public interface IPrescripTypeRepo
    {
        IEnumerable<PrescripType> SelectPrescripTypes();
        PrescripType SelectPrescripType(int id);
        int Insert(PrescripType prescripType);
        bool Update(PrescripType prescripType);
        bool Delete(int id);
    }
}
