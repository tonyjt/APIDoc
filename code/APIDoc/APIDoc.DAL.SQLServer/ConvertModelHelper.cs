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
        #region To Model
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

        public static Domain ToDomainModel(DBDomain dbModel)
        {
            if (dbModel == null) return null;

            return new Domain
            {
                Id = new Id(dbModel.DomainId),
                Title =dbModel.Title,
                Description = dbModel.Description,
                RootUrl = dbModel.RootUrl
            };
        }
        #endregion

        #region  To DB Model
        public static DBAPIDoc ToDBAPIModel(API api)
        {
            if (api == null) return null;

            IList<DBParameter> dbParameters = new List<DBParameter>();

            foreach (Parameter pa in api.Request.ParameterSet)
            {
                dbParameters.Add(ToDBParameterModel(api.Id.Value, pa, ParameterType.Request));
            }

            foreach (Parameter pa in api.Response.ParameterSet)
            {
                dbParameters.Add(ToDBParameterModel(api.Id.Value, pa, ParameterType.Response));
            }


            IList<DBResponseDemo> responseDemos = new List<DBResponseDemo>();
            foreach (ResponseDemo demo in api.Response.DemoSet)
            {
                responseDemos.Add(ToDBResponseDemoModel(api.Id.Value, demo));
            }

            IList<DBError> errors = new List<DBError>();
            foreach (ErrorCode code in api.Response.ErrorCodeSet)
            {
                errors.Add(ToDBErrorModel(api.Id.Value,code));
            }

            return new DBAPIDoc
            {
                Parameters = dbParameters,
                APIDocId = api.Id.Value,
                Title = api.Title,
                Description = api.Description,
                CategoryId = api.CategoryId.Value,
                RequestUrl = api.Request.Url,
                RequestType = (byte)api.Request.RequestType,
                NeedAuth = api.Request.NeedAuth,
                ActionTypes = api.Request.ActionType,
                ResponseDemoes = responseDemos,
                Errors = errors
            };
        }

        public static DBParameter ToDBParameterModel(Guid apiDocId,Parameter parameter,ParameterType type)
        {
            if (parameter == null) return null;

            return new DBParameter
            {
                APIDocId = apiDocId,
                Key = parameter.Key,
                Type = (byte)type,
                Description = parameter.Description,
                Indispensable = parameter.Indispensable,
                ParameterType = parameter.Type

            };
        }

        public static DBResponseDemo ToDBResponseDemoModel(Guid apiDocId, ResponseDemo demo)
        {
            if (demo == null) return null;

            return new DBResponseDemo
            {
                APIDocId = apiDocId,
                Demo = demo.Demo,
                ResponseType = (byte)demo.ResponseType
            };
        }

        public static DBError ToDBErrorModel(Guid apiDocid, ErrorCode errorCode)
        {
            if (errorCode == null) return null;

            return new DBError
            {
                Description = errorCode.Description,
                DomainId = errorCode.DomainId.Value,
                ErrorCode = errorCode.Code,
                Message = errorCode.Message,
                APIDocs = new List<DBAPIDoc>()
                {
                    new DBAPIDoc(){
                        APIDocId = apiDocid
                    }
                }
            };
        }

        public static DBDomain ToDBDomainModel(Domain model)
        {
            if (model == null) return null;

            return new DBDomain
            {
                DomainId= model.Id.Value,
                Title = model.Title,
                Description = model.Description,
                RootUrl = model.RootUrl
            };
        }
        #endregion
    }
}

