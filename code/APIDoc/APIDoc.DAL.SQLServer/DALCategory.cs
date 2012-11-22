using APIDoc.DAL.SQLServer.Models;
using APIDoc.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIDoc.DAL.SQLServer
{
    public class DALCategory
    {
        /// <summary>
        /// 获取Category
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public Category GetAPI(Id categoryId)
        {
            APIDoc_WebDBContext context = new APIDoc_WebDBContext();

            var category = (from q in context.Categories
                          where q.CategoryId == categoryId.Value
                          select q).FirstOrDefault();

            if (category != null)
            {
                var childCategories = from q in context.Categories
                                      where q.ParentId == category.CategoryId
                                      select q;

                return ConvertModelHelper.ToCategoryModel(category, childCategories.ToList());
            }

            else
                return null;
        }

        /// <summary>
        /// 获取目录下的Category
        /// </summary>
        /// <param name="domainId"></param>
        /// <returns></returns>
        public IList<Category> GetAllCategoryInDomain(Id domainId)
        {
            APIDoc_WebDBContext context = new APIDoc_WebDBContext();

            //IList<Category> categoryList;

            var dbCategoryList = from q in context.Categories
                               where q.DomainId == domainId.Value
                               select q;

            if (dbCategoryList != null)
            {
                IList<Category> categories = new List<Category>();
                foreach (DBCategory dbCategory in dbCategoryList)
                {
                    categories.Add(ConvertModelHelper.ToCategoryModel(dbCategory));
                }

                return categories;
            }

            else
                return null;

        }

        /// <summary>
        /// 创建Category
        /// </summary>
        /// <param name="category"></param>
        public bool Insert(Category category)
        {
            APIDoc_WebDBContext context = new APIDoc_WebDBContext();

            DBCategory dbModel = ConvertModelHelper.ToDBCategoryModel(category);

            if (dbModel == null) return false;
            
            var dbCategory = (from q in context.Categories
                            where q.CategoryId == category.Id.Value
                            select q).FirstOrDefault();

            if (dbCategory == null)
            {
                context.Categories.Add(dbCategory);

                context.SaveChanges();

                return true;
            }
            else
                return false;
            
        }

        /// <summary>
        /// 更新Category
        /// </summary>
        /// <param name="category"></param>
        public bool Update(Category category)
        {
            APIDoc_WebDBContext context = new APIDoc_WebDBContext();

            DBCategory dbModel = ConvertModelHelper.ToDBCategoryModel(category);

            if (dbModel == null) return false;

            var dbCategory = (from q in context.Categories
                              where q.CategoryId == category.Id.Value
                              select q).FirstOrDefault();

            if (dbCategory == null)
            {
                context.Categories.Add(dbModel);
            }
            else
            {
                dbCategory.DomainId = dbModel.DomainId;
                dbCategory.Title = dbModel.Title;
                dbCategory.ParentId = dbModel.ParentId;
            }
            context.SaveChanges();
            return true;
        }
    }
}
