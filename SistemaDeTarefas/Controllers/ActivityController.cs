using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repositorios;
using SistemaDeTarefas.Repositorios.Interfaces;

namespace SistemaDeTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private readonly ActivityRepository _activityRepository;
        public ActivityController(ActivityRepository activityRepository)
        {
            _activityRepository = activityRepository;
        }

        [HttpGet]
        public async  Task<ActionResult<List<ActivityModel>>> SearchAll()
        {
          List<ActivityModel> activity = await _activityRepository.SearchAllActivity();

            return Ok(activity);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<List<ActivityModel>>> SearchAForId(int id)
        {
            ActivityModel activityModel = await _activityRepository.SearchAForId(id);

            return Ok(activityModel);
        }

        [HttpPost]
        public async Task<ActionResult<ActivityModel>> ToAdd([FromBody] ActivityModel activityModel)
            {
            ActivityModel tarefa = await _activityRepository.ToAdd(activityModel);

             return Ok(activityModel);

            }

        [HttpPut("{id}")]
        public async Task<ActionResult<ActivityModel>> Update([FromBody] ActivityModel activityModel, int id)
        {

            activityModel.Id = id;
            ActivityModel activity = await _activityRepository.Update(activityModel, id);

            return Ok(activity);

        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<ActivityModel>> Delete(int id)
        {

           
           bool delete = await _activityRepository.Delete(id);

            return Ok(delete);

        }

        [HttpDelete("Delete all")]
        public async Task<ActionResult<ActivityModel>> DeleteAllList(ActivityModel activityModel)
        {


            ActivityModel delete = await _activityRepository.DeleteAllList(activityModel);

            return Ok(delete);

        }

    }
}
