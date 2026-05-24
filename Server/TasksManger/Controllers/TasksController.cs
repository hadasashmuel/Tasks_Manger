using BLL;
using DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace TasksManger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {

        private readonly ITasksRepository _tasksRepositroy;
        public TasksController(ITasksRepository _tasksRepositroy)
        {
            this._tasksRepositroy = _tasksRepositroy;
        }

        [HttpGet("get")]
        public List<Tasks> GetTasks()
        {
            //    //try
            //    //{
            return _tasksRepositroy.GetAll();
            //    //}
            //    //catch (Exception ex)
            //    //{
            //    //    return 0;
            //    //    Console.WriteLine(ex.Message);
        }
        //}

        [HttpGet("getById/{id}")]
        public ActionResult<Tasks> GetTasksById(int id)
        {
            Tasks tasks = _tasksRepositroy.GetById(id);
            if (tasks == null)
                return NotFound();
            return Ok(tasks);
        }

        [HttpGet("getByName/{name}")]
        public ActionResult<List<Tasks>> GetUsersByName(string name)
        {
            return _tasksRepositroy.GetTasksByName(name);
        }

        [HttpPost("addTasks")]
        public ActionResult<Tasks> AddTasks(Tasks newtasks)
        {
            if (newtasks == null || ModelState.IsValid)
                return BadRequest();

            Tasks existingTasks = _tasksRepositroy.GetById(newtasks.TasksId);

            if (existingTasks != null)
                return Conflict("Tasks already exists.");
            _tasksRepositroy.Add(newtasks);
            _tasksRepositroy.SaveChanges();

            return CreatedAtAction(nameof(AddTasks), new { id = newtasks.TasksId }, newtasks);
        }

        [HttpPut("update/{id}")]
        public ActionResult<Tasks> UpdateTasks(int id, Tasks tasks)
        {
            if (tasks == null || !ModelState.IsValid)
                return BadRequest();
            if (id != tasks.TasksId)
                return Conflict();
            _tasksRepositroy.Update(tasks);
            _tasksRepositroy.SaveChanges();
            return Ok(tasks);
        }
        [HttpDelete("delete/{id}")]
        public ActionResult DeleteTasks(int id)
        {
            Tasks tasks = _tasksRepositroy.GetById(id);
            if (tasks == null)
                return NotFound();//404
            _tasksRepositroy.DeleteById(id);
            _tasksRepositroy.SaveChanges();
                
            return NoContent();
        }
    }
}
