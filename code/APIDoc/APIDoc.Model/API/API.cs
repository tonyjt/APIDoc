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
namespace APIDoc.Model
{
    public class API : BaseTitle
    {
        public Id Id { get; set; }

        public Id CategoryId { get; set; }

        public Request Request
        {
            get;
            set;
        }

        public Response Response
        {
            get;
            set;
        }

        public string Description { get; set; }

        public API()
        {
        }

    }

}