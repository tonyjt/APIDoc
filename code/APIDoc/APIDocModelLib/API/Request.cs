﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成
//     如果重新生成代码，将丢失对此文件所做的更改。
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace APIDocModel
{
    public class Request
    {
        public string Url
        {
            get;
            set;
        }

        public RequestType RequestType
        {
            get;
            set;
        }

        public Set<ActionType> ActionType
        {
            get;
            set;
        }

        public bool NeedAuth
        {
            get;
            set;
        }

        public Set<Parameter> ParameterSet
        {
            get;
            set;
        }

        public Request()
        {
        }

    }

}