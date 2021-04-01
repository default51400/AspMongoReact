using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspMongoReact.Models.Entities;
using MongoDB.Driver;

namespace AspMongoReact.Repositories.Interfaces
{
    public interface IUsersRepository
    {
        Task<IEnumerable<User>> GetAll();
        Task<User> GetById(string id);
        Task Add(User user);
        Task<DeleteResult> Remove(string id);
        // обновление содержания (body) записи
        Task<UpdateResult> Update(string id, string body);
    }
}
