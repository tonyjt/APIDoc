using APIDoc.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIDoc.IDAL
{
    public interface IDALCategory
    {
        /// <summary>
        /// 获取Category
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        Category GetAPI(Id categoryId);

        /// <summary>
        /// 获取目录下的Category
        /// </summary>
        /// <param name="domainId"></param>
        /// <returns></returns>
        IList<Category> GetAllCategoryInDomain(Id domainId);

        /// <summary>
        /// 创建Category
        /// </summary>
        /// <param name="category"></param>
        bool Insert(Category category);

        /// <summary>
        /// 更新Category
        /// </summary>
        /// <param name="category"></param>
        bool Update(Category category);


    }
}
