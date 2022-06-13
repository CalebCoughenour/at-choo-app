// using Microsoft.AspNetCore.Mvc;
// using Microsoft.AspNetCore.Identity;
// using AllergyMatchMaker.Models;
// using AllergyMatchMaker.DTO;
// using System.Threading.Tasks;
// using System.Net;
// using System;
// using System.Linq;

// namespace AllergyMatchMaker.Controllers
// {
//   [Route("api/[controller]")]
//   [ApiController]
//   public class AccountsController : ControllerBase
//   {
//     private readonly UserManager<ApplicationUser> _userManager;
//     private readonly SignInManager<ApplicationUser> _signInManager;

//     public AccountsController (UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
//     {
//       _userManager = userManager;
//       _signInManager = signInManager;
//     }

//     [HttpPost("register")]
//     public async Task<ActionResult<RegisterUserDTO>> Register (RegisterUserDTO model)
//     {
//       Console.WriteLine("HIT");
//       var user = new ApplicationUser { UserName = model.Email };
//       IdentityResult result = await _userManager.CreateAsync(user, model.Password);
//       if (result.Succeeded)
//       {
//         return Ok(user.Id);
//       }
//       else
//       {
//         return BadRequest(result.Errors);
//       }
//     }
//     [HttpGet]
//     public string GetString ()
//     {
//       return "works";
//     }

//     [HttpPost("Login")]
//     public async Task<ActionResult> Login(LoginUserDTO model)
//     {
//       Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: true, lockoutOnFailure: false);
      
//       if (result.Succeeded)
//       {
//         var user = await _userManager.FindByNameAsync(model.Email);
//           return Ok(user.Id);
//       }
//       else
//       {
//           return BadRequest();
//       }
//     }
//   }
// }