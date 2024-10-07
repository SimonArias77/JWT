using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RepasoJWT.Repositories;

namespace RepasoJWT.Controllers.v1.Pets
{
    [ApiController]
    [Route("api/v1/pets")]
    [Tags("pets")]
    public class PetsDeleteController : PetsController
    {
        public PetsDeleteController(IPetRepository petRepository) : base(petRepository)
        {
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeletePet(int id)
        {
            await servicios.Delete(id);
            return NoContent();
        }
    }
}