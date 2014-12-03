
namespace CLZDoctor.Entities
{
    public class Prescription : BaseEntity
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 别名
        /// </summary>
        public string Alias { get; set; }
        /// <summary>
        /// 分类
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 组成
        /// </summary>
        public string MakeUp { get; set; }
        /// <summary>
        /// 用法
        /// </summary>
        public string Usage { get; set; }
        /// <summary>
        /// 功效
        /// </summary>
        public string Effect { get; set; }
        /// <summary>
        /// 方解
        /// </summary>
        public string Explain { get; set; }
        /// <summary>
        /// 方歌
        /// </summary>
        public string FangGe { get; set; }
        /// <summary>
        /// 注意事项
        /// </summary>
        public string Notes { get; set; }
        /// <summary>
        /// 相关症状
        /// </summary>
        public string Related { get; set; }
        /// <summary>
        /// 同类方剂
        /// </summary>
        public string Similar { get; set; }
        /// <summary>
        /// 来源
        /// </summary>
        public string Source { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

    }
}
