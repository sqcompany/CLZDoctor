using CLZDoctor.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CLZDoctor.Domain
{
    public interface IRecipeCore
    {
        IEnumerable<Recipe> SelectList(int take, int skip, out int count);

        bool DeleteById(int Id);
    }
}
