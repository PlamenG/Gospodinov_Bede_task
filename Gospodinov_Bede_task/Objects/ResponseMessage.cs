using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gospodinov_Bede_task.Objects
{
    public class ResponseMessageContent
    {
        [JsonProperty("Message")]
        public string Message { get; private set; }

        public ResponseMessageContent(string message)
        {
            Message = message;
        }
    }
}
