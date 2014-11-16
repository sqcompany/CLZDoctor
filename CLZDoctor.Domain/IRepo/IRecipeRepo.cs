using System.Collections.Generic;
using CLZDoctor.Entities;

// ReSharper disable once CheckNamespace
namespace CLZDoctor.Domain
{
    internal interface IRecipeRepo
    {
        int Insert(Recipe recipe);
        IEnumerable<Recipe> SelectList(int prescripId);
        List<int> SelectList(List<string> recipes);
        bool Delete(int prescriptId);
    }
}
