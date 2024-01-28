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
using Pillsy.DataTransferObjects.Account.UpdatePasswordDto;

namespace Pillsy.Controllers.Accounts
{

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

        [Authorize(Roles = "Admin")]
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
                try
                {
                    var data = await _accountService.GetAccountByEmailAndPassword(accountLoginDTO.Email, accountLoginDTO.Password);
                    if (data != null)
                    {
                        var account = _mapper.Map<AccountDTO>(data);
                        var patient = await _patientService.GetPatientByAccountIdAsync(data.AccountId);
                        Claim[] claims = null;
                        if (patient != null)
                        {
                            claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim(ClaimTypes.Role, account.Role.ToString()),
                        new Claim("AccountId", data.AccountId.ToString()),
                        new Claim("PatientId", patient.PatientID.ToString()),
                        new Claim("Email", account.Email),
                        new Claim("Role", account.Role.ToString()),
                        new Claim("Username", patient.FirstName + " " + patient.LastName)
                            };
                        }
                        else
                        {
                            claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim(ClaimTypes.Role, account.Role.ToString()),
                        new Claim("AccountId", data.AccountId.ToString()),
                        new Claim("Email", account.Email),
                        new Claim("Role", account.Role.ToString()),
                        };
                        }

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
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
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


        [Authorize(Roles = "Patient")]
        [HttpPut]
        [Route("private/manage-password")]
        public async Task<IActionResult> ChangePasswordPatient(UpdatePasswordDto account)
        {
            try
            {
                var accountExist = await _accountService.GetAccountByAccountIdAndPassword(account.AccountId, account.OldPassword.Trim());
                if (accountExist == null)
                {
                    return NotFound("Account " + account.AccountId + " does not exist!");
                }

                if (accountExist.Password != null)
                {
                    accountExist.Password = account.NewPassword;
                }
                //var accountExist = await _accountService.GetAccountById();
                //if (!String.IsNullOrEmpty(patient.FirstName?.Trim()))
                //{
                //    patientExist.FirstName = patient.FirstName.Trim();
                //}

                //if (!String.IsNullOrEmpty(patient.LastName?.Trim()))
                //{
                //    patientExist.LastName = patient.LastName.Trim();
                //}

                //if (patient.DateOfBirth != null)
                //{
                //    patientExist.DateOfBirth = patient.DateOfBirth;
                //}
                //if (patient.Gender != null)
                //{
                //    patientExist.Gender = patient.Gender;
                //}
                //if (!String.IsNullOrEmpty(patient.PhoneNumber?.Trim()))
                //{
                //    patientExist.PhoneNumber = patient.PhoneNumber;
                //}
                //if (!String.IsNullOrEmpty(patient.Address?.Trim()))
                //{
                //    patientExist.Address = patient.Address;
                //}

                var result = await _accountService.UpdateAccount(accountExist);
                if (result)
                    return Ok("Password updated!");
                return BadRequest("Password update failed!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
