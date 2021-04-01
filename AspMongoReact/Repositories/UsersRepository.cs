using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspMongoReact.Contexts;
using AspMongoReact.Models;
using AspMongoReact.Models.Entities;
using AspMongoReact.Repositories.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace AspMongoReact.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly UsersContext _context = null;

        public UsersRepository(IOptions<Settings> settings)
        {
            _context = new UsersContext(settings);
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context.Users.Find(_ => true).ToListAsync();
        }

        public async Task<User> GetById(string id)
        {
            var filter = Builders<User>.Filter.Eq("Id", id);
            return await _context.Users
                            .Find(filter)
                            .FirstOrDefaultAsync();
        }

        public async Task Add(User item)
        {
            await _context.Users.InsertOneAsync(item);
        }

        public async Task<DeleteResult> Remove(string id)
        {
            return await _context.Users.DeleteOneAsync(
                 Builders<User>.Filter.Eq("Id", id));
        }

        public async Task<UpdateResult> Update(string id, string body)
        {
            var filter = Builders<User>.Filter.Eq(s => s.Id, id);
            var update = Builders<User>.Update
                            .Set(s => s.Body, body)
                            .CurrentDate(s => s.Updated);

            return await _context.Users.UpdateOneAsync(filter, update);
        }
    }
}
