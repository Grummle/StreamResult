using System.IO;
using System.Web;
using System.Web.Mvc;

namespace StreamResult
{
    public class StreamResult : FileStreamResult
    {
        private string _filename { get; }
        public long? _contentLength { get; set; }

        public StreamResult(Stream fileStream, string contentType, string filename = null, long? contentLength = null)
            : base(fileStream, contentType)
        {
            _filename = filename;
            _contentLength = contentLength;
        }

        protected override void WriteFile(HttpResponseBase response)
        {
            response.BufferOutput = false;

            if (!string.IsNullOrEmpty(_filename))
                response.Headers.Add("Content-Disposition", $"attachment; filename=\"{_filename}\"");

            if (_contentLength.HasValue)
                response.Headers.Add("Content-Length", _contentLength.ToString());

            base.WriteFile(response);
        }
    }
}