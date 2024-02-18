using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.ContactRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;

        public ContactsController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }
        [HttpGet("Last4Contact")]
        public async Task<IActionResult> Last4Contact()
        {
            var values = await _contactRepository.GetLast4Contact();
            return Ok(values);
        }
    }
}
