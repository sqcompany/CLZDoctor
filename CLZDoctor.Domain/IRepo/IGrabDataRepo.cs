using System.Collections.Generic;
using CLZDoctor.Entities;

namespace CLZDoctor.Domain
{
    public interface IGrabDataRepo
    {
        int Add(GrabData grabData);
        IEnumerable<GrabData> Select();
        IEnumerable<GrabData> Select(int count);
        void UpdateState(int id, int state);
    }
}
