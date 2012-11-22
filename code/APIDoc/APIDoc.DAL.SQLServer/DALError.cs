using APIDoc.DAL.SQLServer.Models;
using APIDoc.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIDoc.DAL.SQLServer
{
    public class DALError
    {
        /// <summary>
        /// 获取ErrorCode
        /// </summary>
        /// <param name="Code"></param>
        /// <returns></returns>
        public ErrorCode GetErrorCode(Id domainId, int Code)
        {
            APIDoc_WebDBContext context = new APIDoc_WebDBContext();

            var dbmodel = (from q in context.Errors
                           where q.DomainId == domainId.Value && q.ErrorCode == Code
                           select q).FirstOrDefault();

            return ConvertModelHelper.ToErrorCodeModel(dbmodel);
        }

        /// <summary>
        /// 获取某API的ErrorCode
        /// </summary>
        /// <param name="apiDocId"></param>
        /// <returns></returns>
        public IList<ErrorCode> GetAPIErrorCodes(Id apiDocId)
        {
            APIDoc_WebDBContext context = new APIDoc_WebDBContext();

            var dbErrors = (from q in context.APIDocs
                           where q.APIDocId == apiDocId.Value
                           select q.Errors).FirstOrDefault();

            return GetErrorCodeListFromDBErrorList(dbErrors.ToList());
        }

        /// <summary>
        /// 获取某Domain下的所有ErrorCode
        /// </summary>
        /// <param name="domainId"></param>
        /// <returns></returns>
        public IList<ErrorCode> GetErrorCodesInDomain(Id domainId)
        {
            APIDoc_WebDBContext context = new APIDoc_WebDBContext();

            var dbErrors = from q in context.Errors
                           where q.DomainId == domainId.Value
                           select q;

            return GetErrorCodeListFromDBErrorList(dbErrors.ToList());
        }

        /// <summary>
        /// 创建ErrorCode
        /// </summary>
        /// <param name="domain"></param>
        public bool Insert(ErrorCode errorCode, Id apiDocId = null)
        {
            return false;
        }

        /// <summary>
        /// 更新ErrorCode
        /// </summary>
        /// <param name="domain"></param>
        public bool Update(ErrorCode errorCode)
        {
            return false;
        }

        /// <summary>
        /// 设置API的ErrorCode
        /// </summary>
        /// <param name="apiDocId"></param>
        /// <param name="errorCodeId"></param>
        public bool SetAPIErrorCodes(Id apiDocId, List<int> errorCodeId)
        {
            return false;
        }

        private IList<ErrorCode> GetErrorCodeListFromDBErrorList(IList<DBError> dbErrors)
        {
            if (dbErrors != null)
            {
                IList<ErrorCode> errorCodes = new List<ErrorCode>();
                foreach (DBError dbErr in dbErrors)
                {
                    errorCodes.Add(ConvertModelHelper.ToErrorCodeModel(dbErr));
                }
                return errorCodes;
            }
            else
                return null;
        }
    }
}
