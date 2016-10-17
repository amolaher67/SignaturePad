
using API.Models;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace API.Controllers
{
    [RoutePrefix("api/UploadFile")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [Route("Upload")]
        public async Task<IHttpActionResult> Post()
        {
            try
            {
                if (Request.Content.IsMimeMultipartContent())
                {

                    //For larger files, this might need to be added:
                    Request.Content.LoadIntoBufferAsync().Wait();

                    var data = await Request.Content.ReadAsMultipartAsync();
                    var a = data;
                    if (a != null)
                    {
                        var c = a;
                    }


                }

                return Ok("File Uploaded");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [Route("AddNewSignature")]
        [HttpPost]
        public async Task<IHttpActionResult> AddNewSignature(SaveCanvasModel model)
        {
            try
            {
                 #if DEBUUG
                   string fileNameWitPath = HttpContext.Current.Server.MapPath("/Signatures/"+DateTime.Now.ToString().Replace("/", "-").Replace(" ", "- ").Replace(":", "") + ".png");
                #else
                  string fileNameWitPath = @"E:/AngularBasicAuth/API/Signatures/" + DateTime.Now.ToString().Replace(" / ", " - ").Replace(" ", " - ").Replace(":", "") + ".png";
                #endif

                using (FileStream fs = new FileStream(fileNameWitPath, FileMode.Create))
                {
                    using (BinaryWriter bw = new BinaryWriter(fs))
                    {
                        byte[] data = Convert.FromBase64String(model.imageData);
                        bw.Write(data);
                        bw.Close();
                    }
                }
                return Ok();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
