
using System.Collections.Generic;
using CLZDoctor.Entities;

namespace CLZDoctor.Domain
{
    public interface IMedicalCore
    {
        int Insert(Medical medical);
        IEnumerable<Medical> SelectMedicals();
        IEnumerable<Medical> SelectMedicals(int take, int skip,out int count);
        bool Update(int id, int isVisit);
    }
}
