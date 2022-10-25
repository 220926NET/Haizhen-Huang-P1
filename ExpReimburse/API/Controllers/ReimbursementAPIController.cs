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
                
                return BadRequest("Invalid Input: Username is already taken");
            }else{
                
                return Created("", "Register successfully");
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
                    
                    return BadRequest("Invalid Credential");
                }
                else{
                    
                    Response.Headers.Add("current-User",user.userName);
                    return Created("", returnUser);
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
                    return BadRequest("Submission failed: Missing neccessary information");
                }
                else{
                    return Created("", returnticket);
                }
            }
            
            return null;        
        
        }

        [HttpPost("view/ticket/history")]
        public async Task<ActionResult<Ticket>> viewTicketHistory(User user){

            if(!ModelState.IsValid){
                UnprocessableEntity(user);
            }
            else{

                List<Ticket> returnTicket = await _service.viewTicket(user);
                if(returnTicket == null){

                    return NoContent();
                }
                else{
                    Response.Headers.Add("current-User", user.userName);
                    return Created("view/ticketHistory", returnTicket);
                }
                
            }
            return null;

        }


        [HttpGet("view/ticket/pending")]
        public async Task<ActionResult<Ticket>> ViewTicketPending(){

            if(!ModelState.IsValid){

                UnprocessableEntity();
            }
            else{

                List<Ticket> returnTicket = await _service.viewTicket();
                if(returnTicket == null){

                    return NotFound();
                }
                else{

                    return Ok(returnTicket);
                }
            }
            return null;
        }
        

        [HttpPut("process/ticket")]
        public async Task<ActionResult<Ticket>> ProcessTicketPending(User user,int ticketID, bool action){

            if(!ModelState.IsValid){

                UnprocessableEntity();
            }
            else{

                Ticket returnTicket =  await _service.ProcessTicket(user, ticketID, action);
                if(returnTicket != null){


                    Response.Headers.Add("current-User", user.userName);
                    return Accepted("",returnTicket);
                }
                else{

                    return NotFound("Employee cannot process request");
                }

            }
            
            return NotFound();
            
        }

        
    }

    
}