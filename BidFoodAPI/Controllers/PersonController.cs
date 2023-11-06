using Microsoft.AspNetCore.Mvc;
using BidFoodAPI.Models;
using Newtonsoft.Json;

namespace BidFoodAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        [HttpPost]
        public IActionResult SubmitForm([FromBody] Person personData)
        {
            try
            {
                // Serialize the submitted data to JSON
                var jsonData = JsonConvert.SerializeObject(personData);

                // Save JSON data to a flat file
                string fileName = "personData.json";
                System.IO.File.AppendAllText(fileName, jsonData);

                return Ok("Form data saved successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest("Error saving data: " + ex.Message);
            }
        }
    }
}
