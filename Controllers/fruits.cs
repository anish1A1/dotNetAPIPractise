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
            // gets the fruits index and change its value to the new fruit name 
            fruits[index] = fruit;
            return Ok($"Updated fruit {fruit}");
        } 
        

        [HttpDelete("{index}")]
        public IActionResult DeleteFruit(int index){
            if (index <= 0 || index >= fruits.Count)
            {
                return BadRequest("Invalid Fruit index: " + index);
            }
            string deletedFruit = fruits[index];
            fruits.RemoveAt(index);
            return Ok($"Deleted fruit {deletedFruit}");
        }
    }
}
