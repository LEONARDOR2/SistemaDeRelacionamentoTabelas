
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas.Data;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repositorios.Interfaces;

namespace SistemaDeTarefas.Repositorios
{
    public class ActivityRepository : IActivityRepository

    {
           private readonly SystemActivityDBContext _dbContext;
        public ActivityRepository(SystemActivityDBContext sistemaTarefasDBContext)
    {
            _dbContext = sistemaTarefasDBContext;

        }


        public async Task<List<ActivityModel>> SearchAllActivity()
        {
            return await _dbContext.Activity
                .Include(x => x.Usuario)
                .ToListAsync();
        }

        public  async Task<ActivityModel> SearchAForId(int id)
        {
            return await _dbContext.Activity
                .Include(x=> x.Usuario)
                .FirstOrDefaultAsync(x => x.Id == id);
        }


        public async Task<ActivityModel> ToAdd(ActivityModel activity)
        {
            await _dbContext.Activity.AddAsync(activity);
           await _dbContext.SaveChangesAsync();

            return activity;
        }

        public async Task<ActivityModel> Update(ActivityModel activity, int id)
        {
            ActivityModel activityforid = await SearchAForId(id);

            if(activityforid == null)
            {
                throw new Exception($"Tarefa para o ID {id} não foi encontrado.");
            }
            activityforid.Nome = activity.Nome;
            activityforid.Descricao = activity.Descricao;
            activityforid.Status = activity.Status;
            activityforid.UsuarioId = activity.UsuarioId;

            _dbContext.Activity.Update(activityforid);
          await _dbContext.SaveChangesAsync();

            return activityforid;
        }


        public async Task<bool> Delete(int id)
        {
            ActivityModel activityforid = await SearchAForId(id);

            if (activityforid == null)
            {
                throw new Exception($"Tarefa para o ID {id} não foi encontrado.");
            } 

            _dbContext.Activity.Remove(activityforid);
           await  _dbContext.SaveChangesAsync();
            return true;


        }


        public async Task<ActivityModel> DeleteAllList(ActivityModel activityModel)
        {

            var activityModels = await _dbContext.Activity.ToListAsync();

            if (_dbContext.Activity.ToListAsync() == null)
            {
                throw new Exception($"Tarefas não foram encontrado.");
            }



            _dbContext.Activity.RemoveRange(activityModels);
            await _dbContext.SaveChangesAsync();

            return activityModel;
        }


    }
}
