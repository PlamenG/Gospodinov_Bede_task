using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gospodinov_Bede_task.Objects
{
    public class ResponseCodeAndPayload<T>
    {
        public string ResponseCode { get; private set; }
        public T PayLoadObject { get; private set; }

        public ResponseCodeAndPayload(string responseCode, T payLoadObject)
        {
            this.ResponseCode = responseCode;
            this.PayLoadObject = payLoadObject;
        }
    }
}

