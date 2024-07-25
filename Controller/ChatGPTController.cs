
using Microsoft.AspNetCore.Mvc;
using Microsoft.SemanticKernel;
namespace chatgpt_dotnet.Controller
{
    public class ChatGPTController : ControllerBase
    {
        private readonly Kernel _kernel;
        public ChatGPTController(Kernel kernel){
                _kernel = kernel;
        }
        
    
        [HttpPost]
        [Route("api/chatgpt")]
        public async Task<IActionResult> GetResponse([FromQuery] string prompt)
        {
           var res = await  _kernel.InvokePromptAsync<string>(prompt);
            if(res == null)
                {
                    NotFound("something went wrong");
                }
                return Ok(res);
        }
        
    }
}