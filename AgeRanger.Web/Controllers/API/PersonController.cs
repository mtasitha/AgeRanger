using AgeRanger.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AgeRanger.Web.Controllers.API
{
    public class PersonController : ApiController
    {
        AgeRangerRepository _repository;
        public PersonController()
        {
            _repository = new AgeRangerRepository();
        }

        [HttpGet]
        [Route("api/person/{search_text?}")]
        public HttpResponseMessage Get(string search_text)
        {
            try
            {
                var agegroups = _repository.GetAgeGroups().ToList();
                var persons = _repository.GetPersons(search_text).ToList();

                var personvm = persons.Select(x => new
                {
                    id = x.Id,
                    firstname = x.FirstName,
                    lastname = x.LastName,
                    age = x.Age,
                    agegroup = agegroups.Where(ag => (ag.MinAge <= x.Age || ag.MinAge == null) && (ag.MaxAge > x.Age || ag.MaxAge == null)).Select(ag => ag.Description).FirstOrDefault() ?? string.Empty
                });

                return Request.CreateResponse(HttpStatusCode.OK, personvm);
            }
            catch (Exception ex)
            {
                string exmsg = ex.Message;
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Something went wrong");
            }
        }

        [HttpGet]
        [Route("api/person/getbyid/{id?}")]
        public HttpResponseMessage Get(int? id)
        {
            try
            {
                int pid = 0;
                int.TryParse(id.ToString(), out pid);
                var person = _repository.GetPerson(pid);

                return Request.CreateResponse(HttpStatusCode.OK, person);
            }
            catch (Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Something went wrong");
            }
        }

        [HttpPost]
        [Route("api/person/add")]
        public HttpResponseMessage Post([FromBody]Person person)
        {
            try
            {
                bool isOk = _repository.AddPerson(person);

                if(_repository.SaveAll())
                    return Request.CreateResponse(HttpStatusCode.OK, isOk);
                else
                    return Request.CreateErrorResponse(HttpStatusCode.NotModified, "Saving to DB unsuccess");
            }
            catch (Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Something went wrong");
            }
        }
    }
}
