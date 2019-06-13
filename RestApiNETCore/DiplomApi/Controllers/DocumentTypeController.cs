namespace DiplomApi.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Cors;
    using Microsoft.AspNetCore.Mvc;
    using DiplomApi.Repositories.DocumentType;
    using DiplomApi.Models;
    using System.Collections.Generic;

    [Route("api/[controller]")]
    [ApiController]
    public class DocumentTypeController : ControllerBase
    {
        private readonly IDocumentTypeRepository _documentTypeRepository;

        public DocumentTypeController(IDocumentTypeRepository documentTypeRepository)
        {
            _documentTypeRepository = documentTypeRepository;
        }

        [HttpGet]
        [Route("{id}")]
        [EnableCors("MyPolicy")]
        public async Task<DocumentType> GetByID(int id)
        {
            return await _documentTypeRepository.GetByID(id);
        }

        [HttpGet]
        [EnableCors("MyPolicy")]
        public async Task<IEnumerable<DocumentType>> GetAll(int id)
        {
            return await _documentTypeRepository.GetAll();
        }
    }
}
