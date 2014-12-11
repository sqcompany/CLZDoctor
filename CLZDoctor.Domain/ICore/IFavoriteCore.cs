using System.Collections.Generic;
using CLZDoctor.Entities;

namespace CLZDoctor.Domain
{
    public interface IFavoriteCore
    {
        /// <summary>
        /// 添加收藏
        /// </summary>
        /// <param name="favorite">收藏实例</param>
        /// <returns>实例ID</returns>
        int CreateFavorite(Favorite favorite);
        /// <summary>
        /// 根据查询条件分页获取收藏列表
        /// </summary>
        /// <param name="query">查询条件</param>
        /// <param name="take">分页大小</param>
        /// <param name="skip">当前索引</param>
        /// <param name="count">总数</param>
        /// <returns>收藏列表</returns>
        IEnumerable<Favorite> GetFavorites(FavoriteQuery query,int take, int skip, out int count);
        /// <summary>
        /// 删除收藏
        /// </summary>
        /// <param name="id">收藏ID</param>
        /// <returns>true/false</returns>
        bool DeleteFavorites(int id);
    }
}
