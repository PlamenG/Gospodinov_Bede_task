using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Gospodinov_Bede_task.Helper
{
    public static class ExceptionHandler
    {
        public static void ThrowIfStatusCodeNotOk(string response)
        {
            if (response != HttpStatusCode.OK.ToString())
            {
                throw new Exception("New book was NOT seeded! HttpStatusCode code is " + response);
            }
        }

        public static void ThrowIfStatusCodeNotNoContent(string response)
        {
            if (response != HttpStatusCode.NoContent.ToString())
            {
                throw new Exception("New book was NOT deleted! HttpStatusCode code is " + response);
            }
        }
    }
}
