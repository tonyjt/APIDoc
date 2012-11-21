using APIDoc.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIDoc.IDAL
{
    public interface IDALAPIDoc
    {
        /// <summary>
        /// 获取API
        /// </summary>
        /// <param name="apiDocId"></param>
        /// <returns></returns>
        API GetAPI(Id apiDocId);

        /// <summary>
        /// 获取目录下的API
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        IList<API> GetAllAPIInCategory(Id categoryId);

        /// <summary>
        /// 创建API
        /// </summary>
        /// <param name="api"></param>
        bool Insert(API api);

        /// <summary>
        /// 更新API
        /// </summary>
        /// <param name="api"></param>
        void Update(API api);



    }
}
