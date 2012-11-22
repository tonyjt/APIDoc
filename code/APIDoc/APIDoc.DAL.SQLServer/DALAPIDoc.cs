using APIDoc.DAL.SQLServer.Models;
using APIDoc.IDAL;
using APIDoc.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIDoc.DAL.SQLServer
{
    public class DALAPIDoc:IDALAPIDoc
    {
        /// <summary>
        /// 获取API
        /// </summary>
        /// <param name="apiDocId"></param>
        /// <returns></returns>
        public API GetAPI(Id apiDocId)
        {
             APIDoc_WebDBContext context = new APIDoc_WebDBContext();
             var dbAPIDoc = from q in context.APIDocs
                      where q.APIDocId == apiDocId.Value
                      select q;

             return ConvertModelHelper.ToAPIModel(dbAPIDoc.First());
        }

        /// <summary>
        /// 获取目录下的API
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public IList<API> GetAllAPIInCategory(Id categoryId)
        {
            APIDoc_WebDBContext context = new APIDoc_WebDBContext();
            var dbAPIDoc = from q in context.APIDocs
                           where q.CategoryId == categoryId.Value
                           select q;

            IList<API> apiList = new List<API>();

            foreach (DBAPIDoc dbApi in dbAPIDoc)
            {
                apiList.Add(ConvertModelHelper.ToAPIModel(dbApi));
            }
            return apiList;
        }

        /// <summary>
        /// 创建API
        /// </summary>
        /// <param name="api"></param>
        public bool Insert(API api)
        {
            APIDoc_WebDBContext context = new APIDoc_WebDBContext();

            DBAPIDoc dbApiDoc = ConvertModelHelper.ToDBAPIModel(api);

            if(dbApiDoc ==null) return false;

            var apid = (from q in context.APIDocs
                           where q.APIDocId == api.Id.Value
                           select q).FirstOrDefault();

            if (apid == null)
            {
                context.APIDocs.Add(dbApiDoc);

                context.SaveChanges();

                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// 更新API
        /// </summary>
        /// <param name="api"></param>
        public bool Update(API api)
        {
            APIDoc_WebDBContext context = new APIDoc_WebDBContext();

            DBAPIDoc dbApiDoc = ConvertModelHelper.ToDBAPIModel(api);

            if (dbApiDoc == null) return false;

            var apid = (from q in context.APIDocs
                           where q.APIDocId == api.Id.Value
                           select q).FirstOrDefault();

            if(apid == null)
            {
                context.APIDocs.Add(dbApiDoc);
            }
            else
            {
                apid.Parameters = dbApiDoc.Parameters;
                apid.Title = dbApiDoc.Title;
                apid.Description = dbApiDoc.Description;
                apid.CategoryId = dbApiDoc.CategoryId;
                apid.RequestUrl = dbApiDoc.RequestUrl;
                apid.RequestType = dbApiDoc.RequestType;
                apid.NeedAuth = dbApiDoc.NeedAuth;
                apid.ActionTypes = dbApiDoc.ActionTypes;
                apid.ResponseDemoes = dbApiDoc.ResponseDemoes;
                apid.Errors = dbApiDoc.Errors;
            }
            context.SaveChanges();

            return true;
        }

    }
}
