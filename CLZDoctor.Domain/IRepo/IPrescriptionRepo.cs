using System.Collections.Generic;
using CLZDoctor.Entities;

// ReSharper disable once CheckNamespace
namespace CLZDoctor.Domain
{
    internal interface IPrescriptionRepo
    {
        int Insert(Prescription prescription);
        bool Update(Prescription prescription);
        int Size(int type, string value);
        IEnumerable<Prescription> SelectList();
        IEnumerable<Prescription> SelectList(string name);
        IEnumerable<Prescription> SelectList(int type, string value, int take, int skip);
        IEnumerable<Prescription> SelectList(List<int> ids);
        Prescription SelectPrescription(int id);
        bool Delete(int id);
    }
}
