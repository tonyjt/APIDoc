using APIDoc.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIDoc.IDAL
{
    public interface IDALDomain
    {
        /// <summary>
        /// 获取Domain
        /// </summary>
        /// <param name="domainId"></param>
        /// <returns></returns>
        Domain GetDomain(Id domainId);

        /// <summary>
        /// 创建Domain
        /// </summary>
        /// <param name="domain"></param>
        bool Insert(Domain domain);

        /// <summary>
        /// 更新Domain
        /// </summary>
        /// <param name="domain"></param>
        void Update(Domain domain);
    }
}
