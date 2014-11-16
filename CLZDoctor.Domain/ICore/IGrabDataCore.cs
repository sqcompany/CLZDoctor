using System.Collections.Generic;
using CLZDoctor.Entities;

namespace CLZDoctor.Domain
{
    public interface IGrabDataCore
    {
        int Add(GrabData grabData);
        IEnumerable<GrabData> Select();
    }
}
