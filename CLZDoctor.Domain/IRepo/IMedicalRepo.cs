

using System.Collections.Generic;
using CLZDoctor.Entities;

namespace CLZDoctor.Domain
{
    internal interface IMedicalRepo
    {
        int Insert(Medical medical);
        IEnumerable<Medical> SelectMedicals();
        IEnumerable<Medical> SelectMedicals(int take, int skip);
        int Size();
        bool Update(int id,int isVisit);
        bool Update(Medical medical);
        bool Delete(int id);
        Medical SelectMedical(int id);
    }
}
