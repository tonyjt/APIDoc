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
    public class DALDomain:IDALDomain
    {
        /// <summary>
        /// 获取Domain
        /// </summary>
        /// <param name="domainId"></param>
        /// <returns></returns>
        public Domain GetDomain(Id domainId)
        {
            APIDoc_WebDBContext context = new APIDoc_WebDBContext();

            var domain = (from q in context.Domains
                        where q.DomainId == domainId.Value
                        select q).FirstOrDefault();

            return ConvertModelHelper.ToDomainModel(domain);
        }

        /// <summary>
        /// 创建Domain
        /// </summary>
        /// <param name="domain"></param>
        public bool Insert(Domain domain)
        {
            DBDomain dbModel = ConvertModelHelper.ToDBDomainModel(domain);

            APIDoc_WebDBContext context = new APIDoc_WebDBContext();
            var dbDomain = (from q in context.Domains
                            where q.DomainId == domain.Id.Value
                          select q).FirstOrDefault();

            if (dbDomain == null)
            {
                context.Domains.Add(dbModel);
                context.SaveChanges();
                return true;
            }
            else 
                return false;
        }

        /// <summary>
        /// 更新Domain
        /// </summary>
        /// <param name="domain"></param>
        public bool Update(Domain domain)
        {
            DBDomain dbModel = ConvertModelHelper.ToDBDomainModel(domain);
            if (dbModel == null) return false;
            APIDoc_WebDBContext context = new APIDoc_WebDBContext();
            var dbDomain = (from q in context.Domains
                            where q.DomainId == domain.Id.Value
                            select q).FirstOrDefault();

            if (dbDomain == null)
            {
                context.Domains.Add(dbModel);


            }
            else
            {
                dbDomain.Title = dbModel.Title;
                dbDomain.Description = dbModel.Description;
                dbDomain.RootUrl = dbModel.RootUrl;
            }
            context.SaveChanges();
            return true;
        }
    }
}
