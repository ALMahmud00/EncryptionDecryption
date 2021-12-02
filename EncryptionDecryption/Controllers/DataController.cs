using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EncryptionDecryption.Controllers
{
    [Route("protection/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly IDataProtector _dataProtector;
        public DataController(IDataProtectionProvider _dataProtector)
        {
            this._dataProtector = _dataProtector.CreateProtector("@aV#2g7$fwaaciabidsssqp!jkad5");
        }
        [HttpGet]
        public IActionResult Index(string plainText)
        {
            var encryptedText = _dataProtector.Protect(plainText);
            var decryptedText = _dataProtector.Unprotect(encryptedText);

            return Ok(new { plainText, encryptedText, decryptedText });
        }
    }
}
