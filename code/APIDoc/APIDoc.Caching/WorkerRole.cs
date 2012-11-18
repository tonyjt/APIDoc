using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Diagnostics;
using Microsoft.WindowsAzure.ServiceRuntime;
using Microsoft.WindowsAzure.StorageClient;

namespace APIDoc.Caching
{
    public class WorkerRole : RoleEntryPoint
    {
        // 无需更多实现即可支持缓存辅助角色。 
        // 其他功能可能会影响缓存服务的性能。 
        // 有关专用缓存辅助角色和缓存服务的信息， 
        // 请参阅 MSDN 文档，网址为 http://go.microsoft.com/fwlink/?LinkID=247285
    }
}
