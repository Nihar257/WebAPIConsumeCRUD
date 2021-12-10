using DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        AppDbContext _db;

        public ProductController(AppDbContext db)

        {

            _db = db;

        }
        [HttpGet]

        public IEnumerable<Product> GetAll()
        {
            return _db.Products;

        }
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return _db.Products.Find(id);

        }
       
        [ProducesResponseType(StatusCodes.Status201Created,Type =typeof(Product))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError,Type=typeof(string))]
        [SwaggerOperation(summary:"Add new Product based upon {id}",OperationId ="AddProduct")]

        [HttpPost]
        public IActionResult Add(Product model)
        {
            try
            {
                _db.Products.Add(model);
                _db.SaveChanges();

                // return Created("/product", model);

                return StatusCode(StatusCodes.Status201Created,model);

            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }


        }

        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        [SwaggerOperation(summary: "Update Product based upon {id}", OperationId = "UpdateProduct")]

        [HttpPut("{id}")]
        public IActionResult update(int id, Product model)
        {
            try
            {
                if (id != model.ProductId)
                    return BadRequest();
                _db.Products.Update(model);
                _db.SaveChanges();

                // return Created("/product", model);

                return StatusCode(StatusCodes.Status200OK);

            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }


        }

        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            try
            {
                Product model = _db.Products.Find(id);
                if (model != null)
                {
                    _db.Products.Remove(model);
                    _db.SaveChanges();
                    return Ok();
                }
                return BadRequest();

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }




        }
    }
}