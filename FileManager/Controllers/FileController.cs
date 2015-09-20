using FileManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BL = FileManager.Helpers;

namespace FileManager.Controllers
{
    [RoutePrefix("api/file")]
    public class FileController : ApiController
    {
        private static BL.FileManager fm = BL.FileManager.Instance;

        [Route("getbasedirectoryfiles")]
        public HttpResponseMessage GetBaseDirectoryFiles()
        {
            try
            {
                var files = fm.GetBaseDirectoryFiles();
                return Request.CreateResponse(HttpStatusCode.OK, files);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }





        [Route("getfiles")]
        public HttpResponseMessage GetFiles([FromUri]string path)
        {
            try
            {
                var files = fm.GetFiles(path);

                return Request.CreateResponse(HttpStatusCode.OK, files);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message);

            }
        }
    }
}
