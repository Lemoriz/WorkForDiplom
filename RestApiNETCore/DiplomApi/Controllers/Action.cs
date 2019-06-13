namespace DiplomApi.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Cors;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using DiplomApi.Repositories.Employee;
    using DiplomApi.Repositories.ActionHistory;
    using DiplomApi.Repositories.Action;

    [Route("api/[controller]")]
    [ApiController]
    public class Action : ControllerBase
    {
        private readonly IActionRepository _employeeRepo;

        public Action(IActionRepository employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }

        [HttpGet]
        [EnableCors("MyPolicy")]
        public async Task<IEnumerable<Models.Action>> GetAll(int id)
        {
            return await _employeeRepo.GetAll();
        }
    }
}