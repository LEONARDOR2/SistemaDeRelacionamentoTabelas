using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repositorios.Interfaces;

namespace SistemaDeTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async  Task<ActionResult<List<UserModel>>> SearchAllUser()
        {
          List<UserModel> user =  await _userRepository.SearchAllUser();

            return Ok(user);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<List<UserModel>>> SearchForId(int id)
        {
            UserModel usuario = await _userRepository.SearchForId(id);

            return Ok(usuario);
        }

        [HttpPost]
        public async Task<ActionResult<UserModel>> ToAdd([FromBody] UserModel user)
            {
            UserModel User =  await _userRepository.ToAdd(user);

             return Ok(User);

            }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserModel>> Update([FromBody] UserModel userModel, int id)
        {

            userModel.Id = id;
            UserModel usuario = await _userRepository.Update(userModel, id);

            return Ok(userModel);

        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<UserModel>> Delete(int id)
        {

           
           bool delete = await _userRepository.Delete(id);

            return Ok(delete);

        }

        [HttpDelete("Delete all")]
        public async Task<ActionResult<UserModel>> DeleteList(UserModel userModel)
        {


          bool   delete = await _userRepository.DeleteAllList(userModel);

            return Ok(delete);

        }

    }
}
