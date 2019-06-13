namespace DiplomApi.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Cors;
    using Microsoft.AspNetCore.Mvc;
    using DiplomApi.Classes;
    using DiplomApi.Repositories.AuthorizInfo;
    using DiplomApi.Models;
    using DiplomApi.Repositories.SendDocumentForApproval;

    [Route("api/[controller]")]
    [ApiController]
    public class SendDocumentForApprovalController : ControllerBase
    {
        private readonly ISendDocumentForApprovalRepository _sendDocumentForApprovalRepo;

        public SendDocumentForApprovalController(ISendDocumentForApprovalRepository sendDocumentForApprovalRepo)
        {
            _sendDocumentForApprovalRepo = sendDocumentForApprovalRepo;
        }

        [HttpPost]
        [EnableCors("MyPolicy")]
        public async Task Post(ActionHistory actionHistory)
        {
            await _sendDocumentForApprovalRepo.AddDocumentHistory(actionHistory);
        }
    }
}
