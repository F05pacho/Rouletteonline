using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Rouletteonline.Services;
using Rouletteonline.Models;


namespace Rouletteonline.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RouletteonlineController : ControllerBase
    {
        private IRouletteonlineService rouletteService;
        
        public RouletteonlineController(IRouletteonlineService rouletteonlineService)
        {
            this.rouletteService = rouletteService;
        }

        /// <summary>
        /// Create a new roulette
        /// </summary>
        /// <returns roulette></returns>
       [HttpPost]
       public IActionResult NewRulette()
        {
            Models.Rouletteonline rouletteonline = rouletteService.create();
            return Ok(rouletteonline);
        }
        
        /// <summary>
        /// Get All result
        /// </summary>
        /// <returns rouletteService></returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(rouletteService.GetAll());
        }

        /// <summary>
        /// Open the rulette id
        /// </summary>
        /// <returns ></returns>
        [HttpPut("{id}/open")]
        public IActionResult Open([FromRoute(Name = "id")] string id)
        {
            try
            {
                rouletteService.Open(id);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(405);
            }
        }

        /// <summary>
        /// Close bets on a roulette
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("{id}/close")]
        public IActionResult Close([FromRoute(Name = "id")] string id)
        {
            try
            {
                Models.Rouletteonline roulette = rouletteService.Close(id);
                return Ok(roulette);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(405);
            }
        }

        /// <summary>
        /// It lets make a bet between 0.5 and 10000
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="id"></param>
        /// <param name="request">range 0-36</param>
        /// <returns></returns>
        [HttpPost("{id}/bet")]
        public IActionResult Bet([FromHeader(Name = "user-id")] string UserId, [FromRoute(Name = "id")] string id,
            [FromBody] Bets request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    error = true,
                    msg = "Bad Request"
                });
            }

            try
            {
                Models.Rouletteonline roulette = rouletteService.Bet(id, UserId, request.position, request.money);
                return Ok(roulette);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(405);
            }
            
        }


    }
}
