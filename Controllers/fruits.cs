using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace learningAPI.Controllers
{
    [Route("api/fruits")]
    [ApiController]
    public class Fruits : ControllerBase
    {
         private static List<String> fruits = new List<String> {"Apple", "Banana", "Orange", "Mango"};

        [HttpGet]
        public IActionResult GetAllFruits(){
            return Ok(fruits.ToArray());
        }

        [HttpPost]
        public IActionResult AddFruits([FromBody] string fruit) {

            fruits.Add(fruit);
            return CreatedAtAction(nameof(GetAllFruits), new {name = fruit}, fruit);
            

        }

        [HttpPut("{index}")]
        public IActionResult UpdateFruit(int index, [FromBody] string fruit){
            if (index < 0 || index >=fruit.Length)
            {
                return BadRequest("Invalid Fruit index: " + index);
            }

            fruits[index] = fruit;
            return Ok(fruit);
        } 
        
    }
}
