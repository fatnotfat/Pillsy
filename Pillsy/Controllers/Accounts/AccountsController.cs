using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BusinessObject;
using Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Pillsy.DataTransferObjects.Account.AccountDTO;
using Pillsy.DataTransferObjects.Account.AccountLoginDTO;
using Pillsy.Mappers;
using Pillsy.DataTransferObjects.Account.AccountCreateDTO;

namespace Pillsy.Controllers.Accounts
{
    [Authorize(Roles = "Admin")]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IPatientService _patientService;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public AccountsController(IAccountService accountService, IConfiguration configuration, IMapper mapper, IPatientService patientService)
        {
            _accountService = accountService;
            _configuration = configuration;
            _mapper = mapper;
            _patientService = patientService;
        }

        // GET: api/Accounts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Account>>> GetAccounts()
        {
            //create map
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AccountFrofile());
            });
            var mapper = config.CreateMapper();
            //End create map

            //transfer from account to account dto

            var data = await _accountService.GetAllAccounts();
            var accounts = data.Select(
                             acc => mapper.Map<Account, AccountDTO>(acc)
                           );
            if (await _accountService.GetAllAccounts() == null)
            {
                return NotFound();
            }
            return Ok(accounts);
        }

        [HttpPost]
        [Route("/api/v1/auth/login")]
        [AllowAnonymous]
        public async Task<IActionResult> CheckLogin(AccountLoginDTO accountLoginDTO)
        {
            if (!String.IsNullOrEmpty(accountLoginDTO.Email) && !String.IsNullOrEmpty(accountLoginDTO.Password))
            {
                var data = await _accountService.GetAccountByEmailAndPassword(accountLoginDTO.Email, accountLoginDTO.Password);
                if (data != null)
                {
                    var account = _mapper.Map<AccountDTO>(data);
                    var patient = await _patientService.GetPatientByAccountIdAsync(data.AccountId);
                    var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim(ClaimTypes.Role, account.Role.ToString()),
                        new Claim("AccountId", data.AccountId.ToString()),
                        new Claim("Email", account.Email),
                        new Claim("Role", account.Role.ToString()),
                        new Claim("Username", patient.FirstName + " " + patient.LastName)
                    };
                    //create claims details based on the user information

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(60),
                        signingCredentials: signIn);

                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                return BadRequest("Invalid credentials");
            }
            return BadRequest("The value input should not be empty!");
        }



        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<Account>> PostAccount(AccountCreateDTO accountDTO)
        {
            var data = _mapper.Map<Account>(accountDTO);
            if (await _accountService.GetAllAccounts() == null)
            {
                return Problem("Entity set 'PillsyDBContext.Accounts'  is null.");
            }
            var account = await _accountService.AddNewAccount(data);

            return Ok("user " + account.AccountId + " was created");
        }

    }
}
