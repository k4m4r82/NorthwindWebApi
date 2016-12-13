using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Northwind.Model;
using Northwind.Repository.Api;
using Northwind.Repository.Service;

namespace Northwind.WebAPI.Controllers
{
    public class CategoryController : ApiController
    {
        private ICategoryRepository _repo;

        public CategoryController()
        {
            _repo = new CategoryRepositoryDapper();
        }

        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            HttpResponseMessage response = null;

            var listOfCategory = _repo.GetAll();

            if (listOfCategory.Count == 0)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.NotFound, "Response does not contain any data.");
            }
            else
            {
                response = Request.CreateResponse<IList<Category>>(HttpStatusCode.OK, listOfCategory);
            }

            return response;
        }
    }
}
