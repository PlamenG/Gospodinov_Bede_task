using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gospodinov_Bede_task.Objects
{
    public class ResponseCodeAndPayload
    {
        private string responsCode;
        private Object payLoadObject;

        public ResponseCodeAndPayload(string responsCode, object payLoadObject)
        {
            this.responsCode = responsCode;
            this.payLoadObject = payLoadObject;
        }
    }
}

