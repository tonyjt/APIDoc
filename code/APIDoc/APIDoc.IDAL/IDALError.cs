using APIDoc.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIDoc.IDAL
{
    public interface IDALError
    {
        /// <summary>
        /// 获取ErrorCode
        /// </summary>
        /// <param name="Code"></param>
        /// <returns></returns>
        ErrorCode GetErrorCode(Id domainId,int Code);

        /// <summary>
        /// 获取某API的ErrorCode
        /// </summary>
        /// <param name="apiDocId"></param>
        /// <returns></returns>
        IList<ErrorCode> GetAPIErrorCodes(Id apiDocId);

        /// <summary>
        /// 获取某Domain下的所有ErrorCode
        /// </summary>
        /// <param name="domainId"></param>
        /// <returns></returns>
        IList<ErrorCode> GetErrorCodesInDomain(Id domainId);

        /// <summary>
        /// 创建ErrorCode
        /// </summary>
        /// <param name="domain"></param>
        void Insert(ErrorCode errorCode,Id apiDocId = null);

        /// <summary>
        /// 更新ErrorCode
        /// </summary>
        /// <param name="domain"></param>
        void Update(ErrorCode errorCode);

        /// <summary>
        /// 设置API的ErrorCode
        /// </summary>
        /// <param name="apiDocId"></param>
        /// <param name="errorCodeId"></param>
        void SetAPIErrorCodes(Id apiDocId, List<int> errorCodeId);
    }
}
