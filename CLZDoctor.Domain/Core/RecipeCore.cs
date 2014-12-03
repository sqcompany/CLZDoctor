using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject;
namespace CLZDoctor.Domain
{
    public class RecipeCore : IRecipeCore
    {
        private readonly static IKernel Kernel = new StandardKernel(new DomainModule());
        public IEnumerable<Entities.Recipe> SelectList(int take, int skip,out int count)
        {
            count = Kernel.Get<IRecipeRepo>().Size();
            return Kernel.Get<IRecipeRepo>().SelectList(take, skip);
        }

        public bool DeleteById(int Id)
        {
            return Kernel.Get<IRecipeRepo>().DeleteById(Id);
        }

    }
}
