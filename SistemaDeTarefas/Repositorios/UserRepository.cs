
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas.Data;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repositorios.Interfaces;
using System.Xml.Linq;

namespace SistemaDeTarefas.Repositorios
{
    public class UserRepository : IUserRepository

    {
      
        private readonly SystemActivityDBContext _dbContext;
        public UserRepository(SystemActivityDBContext systemActivityDBContext)
    {
            _dbContext = systemActivityDBContext;

        }

        public async Task<List<UserModel>> SearchAllUser()
        {
            return await _dbContext.Users.ToListAsync();
        }


        public  async Task<UserModel> SearchForId(int id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }


        public async Task<UserModel> ToAdd(UserModel user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<UserModel> Update(UserModel user, int id)
        {
            UserModel userforid = await SearchForId(id);

            if(userforid == null)
            {
                throw new Exception($"Usuario para o ID {id} não foi encontrado.");
            }

            userforid.Nome = user.Nome;
            userforid.Email = user.Email;

            _dbContext.Users.Update(userforid);
          await _dbContext.SaveChangesAsync();

            return userforid;
        }


        public async Task<bool> Delete(int id)
        {
            UserModel userforid = await SearchForId(id);

            if (userforid == null)
            {
                throw new Exception($"Usuario para o ID {id} não foi encontrado.");
            } 

            _dbContext.Users.Remove(userforid);
           await  _dbContext.SaveChangesAsync();
            return true;


        }


        public async Task<bool> DeleteAllList(UserModel userModel)
        {


            var deleteAllList = await _dbContext.Users.ToListAsync();

            if (_dbContext.Users.ToListAsync() == null)
            {
               throw new Exception($"UsuarioS não foram encontrado.");
            }

             

            _dbContext.Users.RemoveRange(deleteAllList);
            await _dbContext.SaveChangesAsync();

            

            return true;
        }

        
    }
}
