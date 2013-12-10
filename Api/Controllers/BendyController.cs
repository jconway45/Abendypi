using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Mvc;
using Core.Data;
using Core.Domain;

namespace Api.Controllers
{
    public class BendyController : ApiController
    {
        private readonly IDocumentRepository _documentRepository;

        public BendyController(IDocumentRepository documentRepository)
        {
            _documentRepository = documentRepository;
        }

        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public HttpResponseMessage Get(string path)
        {
            string yourJson = _documentRepository.LoadDocument(path).body;
            var response = this.Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(yourJson, Encoding.UTF8, "application/json");

            return response;
        }

        // POST api/values
        public void Post(string path, HttpRequestMessage req)
        {
            var data2 = req.Content.ReadAsStringAsync().Result;
            _documentRepository.SaveDocument(new Document { body = data2, path = path });
        }

        // PUT api/values/5
        public void Put(string path, FormCollection collection)
        {
        }

        // DELETE api/values/5
        public void Delete(string path)
        {
        }
    }
}