using System.Collections.Generic;
using CLZDoctor.Entities;

namespace CLZDoctor.Domain
{
    internal interface IFavoriteRepo
    {
        IEnumerable<Favorite> SelectFavorites(FavoriteQuery query,int take,int skip,out int count); 
    }
}
