using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CLZDoctor.Entities;

namespace CLZDoctor.Domain
{
    public class FavoriteCore:IFavoriteCore
    {
        private readonly static IKernel Kernel = new StandardKernel(new DomainModule());
        public int CreateFavorite(Favorite favorite)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Favorite> GetFavorites(FavoriteQuery query, int take, int skip, out int count)
        {
            return Kernel.Get<IFavoriteRepo>().SelectFavorites(query, take, skip, out count);
        }

        public bool DeleteFavorites(int id)
        {
            throw new NotImplementedException();
        }
    }
}
