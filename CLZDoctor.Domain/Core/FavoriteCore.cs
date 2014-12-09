using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CLZDoctor.Domain
{
    public class FavoriteCore:IFavoriteCore
    {
        public int CreateFavorite(Entities.Favorite favorite)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Entities.Favorite> GetFavorites(Entities.FavoriteQuery query, int take, int skip, out int count)
        {
            throw new NotImplementedException();
        }

        public bool DeleteFavorites(int id)
        {
            throw new NotImplementedException();
        }
    }
}
