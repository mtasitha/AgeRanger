using AgeRanger.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AgeRanger.Web.Controllers.API
{
    public class AgeGroupController : ApiController
    {
        AgeRangerRepository _repository;
        public AgeGroupController()
        {
            _repository = new AgeRangerRepository();
        }

        public HttpResponseMessage Get()
        {
            try
            {
                var agegroups = _repository.GetAgeGroups();
                return Request.CreateResponse(HttpStatusCode.OK, agegroups);
            }
            catch (Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Something went wrong");
            }
        } 

        public HttpResponseMessage Get(int id)
        {
            try
            {
                var agegroup = _repository.GetAgeGroup(id);
                return Request.CreateResponse(HttpStatusCode.OK, agegroup);
            }
            catch (Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Something went wrong");
            }
        }
    }
}
