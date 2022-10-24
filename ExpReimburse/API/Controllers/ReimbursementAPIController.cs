using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Service;
using Model;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReimbursementAPIController : ControllerBase
    {

       private readonly ILogger<ReimbursementAPIController> _logger;
       private readonly ServiceClass _service;

       public ReimbursementAPIController(ILogger<ReimbursementAPIController> logger, ServiceClass service){

            _logger = logger;
            _service = service;
       }

       [HttpPost("register")]
       public async Task<ActionResult<User>> RegisterUser(User user)
       {

        if(!ModelState.IsValid){

            UnprocessableEntity(user);
        }
        else{

            User returnUser = await  _service.register(user);
            if(returnUser == null){
                
                return BadRequest(user);
            }else{
                
                return Created("register/user", returnUser);
            }
            
        }

        return null;
       }


       [HttpPost("login")]
       public async Task<ActionResult<User>> LoginUser(User user)
       {
            if(!ModelState.IsValid){
                UnprocessableEntity(user);
            }
            else{

                User returnUser = await _service.login(user);
                if(returnUser == null){
                    
                    return BadRequest(user);
                }
                else{
                    
                    return Created("login/user", returnUser);
                }
            }

            return null;
       }


       [HttpPost("submit")]
        public async Task<ActionResult<Ticket>> SumbitTicket(Ticket ticket)
        {
            if(!ModelState.IsValid){
                UnprocessableEntity(ticket);
            }
            else{

                Ticket returnticket = await _service.sumbitTicket(ticket);
                if(returnticket == null){
                    return BadRequest(ticket);
                }
                else{
                    return Created("submit/ticket", returnticket);
                }
            }
            
            return null;        
        
        }
    }

    
}