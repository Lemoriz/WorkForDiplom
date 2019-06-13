namespace DiplomApi.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Cors;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using DiplomApi.Repositories.Employee;
    using DiplomApi.Repositories.ActionHistory;
    using DiplomApi.Repositories.ActionStatus;

    [Route("api/[controller]")]
    [ApiController]
    public class ActionStatusController : ControllerBase
    {
        private readonly IActionStatusRepository _employeeRepo;

        public ActionStatusController(IActionStatusRepository employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }

        [HttpGet]
        [EnableCors("MyPolicy")]
        public async Task<IEnumerable<ActionStatus>> GetAll(int id)
        {
            return await _employeeRepo.GetAll();
        }
    }
}