using System.IO;
using System.Web;
using System.Web.Mvc;

namespace StreamResult
{
    public class StreamResult : FileStreamResult
    {
        public StreamResult(Stream fileStream, string contentType)
            : base(fileStream, contentType)
        {
        }

        protected override void WriteFile(HttpResponseBase response)
        {
            response.BufferOutput = false;

            base.WriteFile(response);
        }
    }
}