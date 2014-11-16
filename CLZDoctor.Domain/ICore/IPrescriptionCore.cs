using System.Collections.Generic;
using CLZDoctor.Entities;

// ReSharper disable once CheckNamespace
namespace CLZDoctor.Domain
{
    public interface IPrescriptionCore
    {
        int Insert(Prescription prescription);
        void SplitRecipe();
        bool Update(Prescription prescription);
        List<Prescription> SelectPrescriptions(int type, string value, int take, int skip, out int count);
        List<Prescription> SelectPrescriptions(List<string> names);
        Prescription SelectPrescription(int id);
        bool Delete(int id);
    }
}
