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
        List<Prescription> SelectPrescriptionsByMakeUp(List<string> names, int take, int skip, out int count);
        Prescription SelectPrescription(int id);
        bool Delete(int id);
    }
}
