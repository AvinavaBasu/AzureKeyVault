using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.KeyVault;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace KeyVaults.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }


        [HttpGet("{Contact}")]

        public async Task<IActionResult> Contact()
        {
            var keyVaultClient = new KeyVaultClient(AuthencticaVault);
            var result = await keyVaultClient.GetSecretAsync(
                "https://demokeyvaultazure.vault.azure.net/secrets/DefaultConnection/f4965b55574341f581fb3905fb3cc817");
            var con = result.Value;
            return View();
        }

        private IActionResult View()
        {
            throw new NotImplementedException();
        }

        private async Task<string> AuthencticaVault(string authority, string resource, string scope)
        {
            var clientCredential = new ClientCredential("65108ee3-71b8-487b-af4a-45aeab479821",
                "?p:@5*dX164]cpQwvh=z[c-R*GKq19l_");
            var authenticationContext= new AuthenticationContext(authority);
            var result=await authenticationContext.AcquireTokenAsync(resource, clientCredential);
            return result.AccessToken;
        }
    }
}
