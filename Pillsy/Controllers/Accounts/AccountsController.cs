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
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Pillsy.DataTransferObjects.ForgotPasswordDTO;
using System.Data;
using Pillsy.DataTransferObjects.Account.AccountByMonthDTO;
using Pillsy.DataTransferObjects.Account.UpdateAccountDto;
using System.Transactions;

namespace Pillsy.Controllers.Accounts
{

    [Route("api/v1/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IPatientService _patientService;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IEmailService _emailService;
        private readonly ICustomerPackageService _customerPackageService;

        public AccountsController(IAccountService accountService, IConfiguration configuration, IMapper mapper, IPatientService patientService, IEmailService emailService, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, ICustomerPackageService customerPackageService)
        {
            _accountService = accountService;
            _configuration = configuration;
            _mapper = mapper;
            _patientService = patientService;
            _emailService = emailService;
            _userManager = userManager;
            _roleManager = roleManager;
            _customerPackageService = customerPackageService;
        }

        [Authorize(Roles = "Admin")]
        // GET: api/Accounts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountDTO>>> GetAccounts()
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

        [Authorize(Roles = "Admin")]
        // GET: api/Accounts
        [HttpGet]
        [Route("totals")]
        public async Task<ActionResult<IEnumerable<Account>>> GetAccountsTotals()
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
            return Ok(accounts.Count());
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
                            var customerPackage = await _customerPackageService.GetCustomerPackageByPatientId(patient.PatientID);

                            claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim(ClaimTypes.Role, account.Role.ToString()),
                        new Claim("AccountId", data.AccountId.ToString()),
                        new Claim("PatientId", patient.PatientID.ToString()),
                        new Claim("CustomerPackageId", customerPackage.CustomerPackageId.ToString()),
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
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    var data = _mapper.Map<Account>(accountDTO);
                    if (await _accountService.GetAllAccounts() == null)
                    {
                        return Problem("Entity set 'PillsyDBContext.Accounts'  is null.");
                    }
                    var account = await _accountService.AddNewAccount(data);
                    Random random = new Random();
                    var number = random.Next(1,1000000000);
                    IdentityUser user = new()
                    {
                        Email = account.Email,
                        SecurityStamp = Guid.NewGuid().ToString(),
                        UserName = $"User{number}",
                        TwoFactorEnabled = false
                    };

                    var result = await _userManager.CreateAsync(user, account.Password);
                    if (!result.Succeeded)
                    {
                        return StatusCode(StatusCodes.Status500InternalServerError,
                            new Response { Status = "Error", Message = "User Failed to Create" });
                    }

                    //Add Token to Verify the email....
                    var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

                    
                    scope.Complete();
                    return Ok("user " + account.AccountId + " was created");
                }
                catch (Exception ex)
                {
                    scope.Dispose();
                    return BadRequest($"{ex.Message}");
                }

            }
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



        [HttpPost]
        [AllowAnonymous]
        [Route("forgot-password")]

        public async Task<IActionResult> ForgotPassword([Required] string email)
        {
            var account = await _userManager.FindByEmailAsync(email);
            if (account != null)
            {
                var token = await _userManager.GenerateTwoFactorTokenAsync(account, "Email");
                var formData = Request.Scheme;
                var forgotPasswordLink = Url.Action(nameof(ResetPassword), "Accounts", new { token, email = account.Email }, formData);
                var message = new Message(new string[] { account.Email! }, "OTP to forgot password", token);
                _emailService.SendEmail(message);
                return StatusCode(StatusCodes.Status200OK,
                    new Response { Status = "Success", Message = $"Password changed request is sent on Email {account.Email}. Please open your email & click the link!", Body = token });
            }
            return StatusCode(StatusCodes.Status400BadRequest,
                    new Response { Status = "Error", Message = $"Could not send link to email. Please try again!" });
        }

        [HttpGet("reset-password")]
        public async Task<IActionResult> ResetPassword(string token, string email)
        {
            var model = new ResetPassword { Token = token, Email = email };
            return Ok(new
            {
                model
            });
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("reset-password")]
        public async Task<IActionResult> ResetPassword(ResetPassword resetPassword)
        {
            var account = await _userManager.FindByEmailAsync(resetPassword.Email);
            var accountExisted = await _accountService.GetAccountByEmail(resetPassword.Email);
            if (account != null)
            {

                var resetPassResult = await _userManager.ChangePasswordAsync(account, accountExisted.Password, resetPassword.Password);
                if (!resetPassResult.Succeeded)
                {
                    foreach (var error in resetPassResult.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }
                    return Ok(ModelState);
                }

                //change password in table account
                var accountExist = await _accountService.GetAccountByEmail(resetPassword.Email);
                if (accountExist != null)
                {
                    UpdatePasswordDto updatePasswordDto = new UpdatePasswordDto()
                    {
                        AccountId = accountExist.AccountId,
                        OldPassword = accountExist.Password,
                        NewPassword = resetPassword.Password
                    };

                    var result = await ChangePasswordPatient(updatePasswordDto);
                    return StatusCode(StatusCodes.Status200OK,
                        new Response { Status = "Success", Message = $"Password has been changed!" });
                }
            }
            return StatusCode(StatusCodes.Status400BadRequest,
                    new Response { Status = "Error", Message = $"Could not change the password. Please try again!" });
        }

        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Audience"],
                expires: DateTime.Now.AddDays(2),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }

        [Authorize(Roles = "Admin")]
        // GET: api/Accounts
        [HttpGet]
        [Route("user/month")]
        public async Task<ActionResult<IEnumerable<Account>>> GetAccountsByMonth()
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


            List<AccountByMonthDTO> accountByMonths = new List<AccountByMonthDTO>();

            for (int i = 1; i <= 12; i++)
            {
                var jan = data.Where(d => d.CreatedDate!.Value.Month.Equals(i));
                var count = jan.Count();
                DateTime dateTime = new DateTime(DateTime.Now.Year, i, 1);
                accountByMonths.Add(new AccountByMonthDTO
                {
                    X = dateTime,
                    Y = count
                });
            }

            var accounts = data.Select(
                             acc => mapper.Map<Account, AccountDTO>(acc)
                           );
            if (await _accountService.GetAllAccounts() == null)
            {
                return NotFound();
            }

            return Ok(accountByMonths);
        }

        [Authorize(Roles = "Admin")]
        // GET: api/Accounts
        [HttpGet]
        [Route("user/month/totals")]
        public async Task<ActionResult<IEnumerable<Account>>> GetAccountsByMonthTotals()
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


            List<AccountByMonthDTO> accountByMonths = new List<AccountByMonthDTO>();

            for (int i = 1; i <= 12; i++)
            {
                var jan = data.Where(d => d.CreatedDate!.Value.Month.Equals(i));
                var count = jan.Count();
                DateTime dateTime = new DateTime(DateTime.Now.Year, i, 1);
                accountByMonths.Add(new AccountByMonthDTO
                {
                    X = dateTime,
                    Y = count
                });
            }

            var accounts = data.Select(
                             acc => mapper.Map<Account, AccountDTO>(acc)
                           );
            if (await _accountService.GetAllAccounts() == null)
            {
                return NotFound();
            }
            double accountByMonthsTotals = accountByMonths.Sum(acc => acc.Y);

            return Ok(accountByMonthsTotals);
        }



        [Authorize(Roles = "Admin")]
        [HttpPut]
        [Route("update-account")]
        public async Task<IActionResult> UpdateAccount(UpdateAccountDto updateAccountDto)
        {
            try
            {
                var accountExist = await _accountService.GetAccountById(updateAccountDto.AccountId);
                if (accountExist == null)
                {
                    return NotFound("Account " + updateAccountDto.AccountId + " does not exist!");
                }

                if (updateAccountDto.Role != null)
                {
                    accountExist.Role = (int)updateAccountDto.Role;
                }
                if (updateAccountDto.Status != null)
                {
                    accountExist.Status = (int)updateAccountDto.Status;
                }

                var result = await _accountService.UpdateAccount(accountExist);
                if (result)
                    return Ok("Account updated!");
                return BadRequest("Account update failed!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
