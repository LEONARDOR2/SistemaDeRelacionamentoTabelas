using SistemaDeTarefas.Models;

namespace SistemaDeTarefas.Repositorios.Interfaces
{
    public interface IActivityRepository
    {
        Task<List<ActivityModel>> SearchAllActivity();

        Task<ActivityModel> SearchAForId(int id);

        Task<ActivityModel> ToAdd(ActivityModel activity);

        Task<ActivityModel> Update(ActivityModel activity, int id);

        Task<bool> Delete(int id);

        Task<ActivityModel> DeleteAllList(ActivityModel activityModel);
    }
}
