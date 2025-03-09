using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using System.Collections.Generic; // Required for IEnumerable

namespace WebApi.Controllers
{
    // Use a clearer route template
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("Custom Cash4ERP Controller")]

    public class Cash4ERP : ControllerBase
    {
        // GET: api/cash4erp
        [HttpGet("GetPlanningValues")]
        //[HttpPost("GetPlanningValues")]
        //[SwaggerOperation(Summary = "Get Cash4ERP Data", Description = "This is a custom description for the API")]

        public IEnumerable<string> GetPlanningValues()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/cash4erp/5
        [HttpGet("{id}")]
        [ApiExplorerSettings(IgnoreApi = true)]  // Hide only this action
        public string Getrrr(int id)
        {
            return id.ToString();
        }

        // POST api/cash4erp
        [HttpPost]
        [ApiExplorerSettings(IgnoreApi = true)]  // Hide only this action
        public void Post([FromBody] string value)
        {
        }

        // PUT api/cash4erp/5
        [HttpPut("{id}")]
        [ApiExplorerSettings(IgnoreApi = true)]  // Hide only this action
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/cash4erp/5
        [HttpDelete("{id}")]
        [ApiExplorerSettings(IgnoreApi = true)]  // Hide only this action
        public void Delete(int id)
        {
        }
        [HttpGet("GetBankPages")]
        //[HttpPost("GetBankPages")]
        public IActionResult GetBankPages([FromBody] BankPageHeader model)
        {
            return Ok(model);
        }

        [HttpPost("GetBankPagesDetails")]
        [ApiExplorerSettings(IgnoreApi = true)]  // Hide only this action
        public IActionResult GetBankPages([FromBody] BankPageDetails model)
        {
            return Ok(model);
        }

        [HttpPost("WriteDifferenceMovements")]
        public IActionResult WriteDifferenceMovements([FromBody] BankPageHeader model)
        {
            return Ok(model);
        }

        [HttpPost("WriteInitialMovements")]
        public IActionResult WriteInitialMovements([FromBody] BankPageHeader model)
        {
            return Ok(model);
        }
        [HttpGet("GetSafeValues")]

        //[HttpPost("GetSafeValues")]
        public string GetSafeValues()
        {
            return "bank details";
        }
    }

    // Example model class (Optional, if you're posting complex data)
    public class BankPageHeader
    {
        public string? Statement { get; set; }
        public int Amount { get; set; }
        public DateTime ValueDate { get; set; }
    }



    public class BankPageDetails
    {
        public string? Statement { get; set; }
        public int Amount { get; set; }
        public int SourceAmount { get; set; }

        public DateTime ValueDate { get; set; }

    }
}
