namespace DiplomApi.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Cors;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using DiplomApi.Repositories.Employee;
    using DiplomApi.Repositories.ActionHistory;

    [Route("api/[controller]")]
    [ApiController]
    public class ActionHistoryController : ControllerBase
    {
        private readonly IActionHistoryRepository _employeeRepo;

        public ActionHistoryController(IActionHistoryRepository employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }

        [HttpGet]
        [EnableCors("MyPolicy")]
        public async Task<IEnumerable<ActionHistory>> GetAll(int id)
        {
            return await _employeeRepo.GetAll();
        }
    }
}