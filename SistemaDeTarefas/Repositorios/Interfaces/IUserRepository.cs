using SistemaDeTarefas.Models;

namespace SistemaDeTarefas.Repositorios.Interfaces
{
    public interface IUserRepository
    {
        Task<List<UserModel>> SearchAllUser();

        Task<UserModel> SearchForId(int id);

        Task<UserModel> ToAdd(UserModel user);

        Task<UserModel> Update(UserModel user, int id);

        Task<bool> Delete(int id);

        Task<bool> DeleteAllList(UserModel userModel);
    }
}
