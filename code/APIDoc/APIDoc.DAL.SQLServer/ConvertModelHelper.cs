using APIDoc.DAL.SQLServer.Models;
using APIDoc.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIDoc.DAL.SQLServer
{
    public static class ConvertModelHelper
    {
        public static API ToAPIModel(DBAPIDoc apiDoc)
        {
            if (apiDoc == null) return null;

            #region request
            var ps = from p in apiDoc.Parameters
                               where (ParameterType)p.Type == ParameterType.Request
                               select p;

            IList<Parameter> parameters = new List<Parameter>();

            foreach(DBParameter dbPara in ps)
            {
                parameters.Add(ToParameterModel(dbPara));
            }

         
            Request request = new Request
            {
                Url = apiDoc.RequestUrl,
                RequestType = (RequestType)apiDoc.RequestType,
                ParameterSet = parameters,
                NeedAuth = apiDoc.NeedAuth,
                ActionType = apiDoc.ActionTypes
            };

            #endregion 

            #region Response
            
            var resPs = from p in apiDoc.Parameters
                        where (ParameterType)p.Type == ParameterType.Response
                        select p;

            IList<Parameter> resParameters = new List<Parameter>();

            foreach (DBParameter dbPara in resPs)
            {
                resParameters.Add(ToParameterModel(dbPara));
            }

            IList<ResponseDemo> demos = new List<ResponseDemo>();
            foreach (DBResponseDemo dbres in apiDoc.ResponseDemoes)
            {
                demos.Add(ToResponseDemoModel(dbres));
            }

            IList<ErrorCode> errorCodes = new List<ErrorCode>();
            foreach (DBError dbError in apiDoc.Errors)
            {
                errorCodes.Add(ToErrorCodeModel(dbError));
            }

            Response response = new Response
            {
                ParameterSet = resParameters,
                DemoSet = demos,
                ErrorCodeSet = errorCodes
            };

            #endregion

            return new API
            {
                Id = new Id(apiDoc.APIDocId),
                CategoryId = new Id(apiDoc.CategoryId),
                Title = apiDoc.Title,
                Description = apiDoc.Description,
                Request = request,
                Response = response
            };
        }

        public static Parameter ToParameterModel(DBParameter dbPara)
        {
            if (dbPara == null) return null;

            return new Parameter
            {
                Key = dbPara.Key,
                Type = dbPara.ParameterType,
                Description =dbPara.Description,
                Indispensable = dbPara.Indispensable
            };
        }

        public static ResponseDemo ToResponseDemoModel(DBResponseDemo dbres)
        {
            if (dbres == null) return null;

            return new ResponseDemo
            {
                ResponseType = (ResponseType)dbres.ResponseType,
                Demo = dbres.Demo
            };
        }

        public static ErrorCode ToErrorCodeModel(DBError dbError)
        {
            if (dbError == null) return null;

            return new ErrorCode
            {
                DomainId = new Id(dbError.DomainId),
                Code = dbError.ErrorCode,
                Description = dbError.Description,
                Message = dbError.Message
            };
        }
    }
}
