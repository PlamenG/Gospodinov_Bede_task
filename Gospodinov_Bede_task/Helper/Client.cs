using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Gospodinov_Bede_task.Objects;
using System.Collections.Generic;

namespace Gospodinov_Bede_task.Helper
{
    public static class Client
    {
        public static readonly HttpClient client = new HttpClient();
    }
}
