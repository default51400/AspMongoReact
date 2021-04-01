using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspMongoReact.Models.Entities;
using AspMongoReact.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AspMongoReact.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IUsersRepository _usersRepository;

        public UsersController(IUsersRepository noteRepository)
        {
            _usersRepository = noteRepository;
        }

        [HttpGet]
        public Task<IEnumerable<User>> Get()
        {
            try
            {
                return GetUserInternal();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async Task<IEnumerable<User>> GetUserInternal()
        {
            try
            {
                return await _usersRepository.GetAll();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("{id}")]
        public Task<User> Get(string id)
        {
            try
            {
                return GetUserByIdInternal(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private async Task<User> GetUserByIdInternal(string id)
        {
            try
            {
                return await _usersRepository.GetById(id) ?? new User();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
            try
            {
                _usersRepository.Add(new User() { Body = value, Created = DateTime.Now });
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut("{id}")]
        public void Put(string id, [FromBody] string value)
        {
            try
            {
                _usersRepository.Update(id, value);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            try
            {
                _usersRepository.Remove(id);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
