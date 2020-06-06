
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace TSAnalyzer.Controllers
{
    [Route("api/[controller]")]
    public abstract class RestfulControllerBase<T> : ControllerBase where T : class ,IEntity
    {
        protected IRepository<T> Repository { get; private set; }

        public RestfulControllerBase(IRepository<T> repository)
        {
            Repository = repository;
        }

        // GET api/{controller}
        [HttpGet]
        public virtual ActionResult<IEnumerable<T>> Get() => ResponseOrLogError(() => Ok(Repository.GetAll()));


        // GET api/{controller}/5
        [HttpGet("{id}")]
        public virtual ActionResult<T> Get(int id) => ResponseOrLogError(() => Ok(Repository.Get(id)));


        // POST api/{controller}
        [HttpPost]
        public virtual ActionResult Post([FromBody] T viewObject) => ResponseOrLogError(() => Ok(Repository.Add(viewObject)));


        // PUT api/{controller}/5
        [HttpPut("{id}")]
        public virtual ActionResult Put(int id, [FromBody] T viewObject) => ResponseOrLogError(() => Ok(Repository.Update(viewObject)));

        // DELETE api/{controller}/5
        [HttpDelete("{id}")]
        public virtual ActionResult Delete(int id) => ResponseOrLogError(() => Ok(Repository.Remove(id)));

        protected ActionResult ResponseOrLogError(Func<ActionResult> executeResponse)
        {
            try
            {
                return executeResponse();
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }
    }
}