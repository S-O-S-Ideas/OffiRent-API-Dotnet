using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OffiRent.API.Domain.Models;
using OffiRent.API.Domain.Services;
using OffiRent.API.Extensions;
using OffiRent.API.Resources.Account;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OffiRent.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;

        public AccountController(IAccountService accountService, IMapper mapper)
        {
            _accountService = accountService;
            _mapper = mapper;
        }

        [SwaggerOperation(
           Summary = "Update Premium Status of Account",
           Tags = new[] { "Accounts" }


        )]
        [SwaggerResponse(200, "Change type of OffiProvider account to Premium", typeof(AccountResource))]
        [HttpPatch("id")]
        public async Task<IActionResult> UpdateAsync(int id)
        {
            var result = await _accountService.UpdateSync(id);

            if (!result.Success)
                return BadRequest(result.Message);
            var accountResource = _mapper.Map<Account, AccountResource>(result.Resource);
            return Ok(accountResource);
        }

        [SwaggerOperation(
            Summary = "List all accounts",
            Description = "Retrieve all the accounts registered.",
            OperationId = "ListAllAccounnts",
            Tags = new[] { "Accounts" }
            )]
        [SwaggerResponse(200, "List of registered accounts", typeof(IEnumerable<AccountResource>))]
        [ProducesResponseType(typeof(IEnumerable<AccountResource>), 200)]
        [HttpGet]
        public async Task<IEnumerable<AccountResource>> GetAllAsync()
        {
            var categories = await _accountService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Account>,
                IEnumerable<AccountResource>>(categories);
            return resources;
        }


        [SwaggerOperation(
            Summary = "Register Account",
            Description = "Register a new account.",
            OperationId = "RegisterNewAccount",
            Tags = new[] { "Accounts" }
            )]
        [SwaggerResponse(200, "New account registered", typeof(IEnumerable<AccountResource>))]
        [ProducesResponseType(typeof(IEnumerable<AccountResource>), 200)]
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveAccountResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var account = _mapper.Map<SaveAccountResource, Account>(resource);
            var result = await _accountService.SaveAsync(account);

            if (!result.Success)
                return BadRequest(result.Message);

            var accountResource = _mapper.Map<Account, AccountResource>(result.Resource);

            return Ok(accountResource);

        }

        [SwaggerOperation(
            Summary = "Edit account data",
            Description = "Edit a property from a account. Can handle: [FirstName, LastName, Identification, " +
            "Email, Password or PhoneNumber",
            OperationId = "ListAllCategories",
            Tags = new[] { "Accounts" }
            )]
        [SwaggerResponse(200, "List of Categories", typeof(IEnumerable<AccountResource>))]
        [ProducesResponseType(typeof(IEnumerable<AccountResource>), 200)]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveAccountResource resource)
        {

            var account = _mapper.Map<SaveAccountResource, Account>(resource);
            var result = await _accountService.UpdateAsync(id, account);

            if (!result.Success)
                return BadRequest(result.Message);

            var accountResource = _mapper.Map<Account, AccountResource>(result.Resource);
            return Ok(accountResource);
        }

        [SwaggerOperation(
           Summary = "Delete a Account",
           Tags = new[] { "Accounts" })
        ]

        [SwaggerResponse(200, "Delete an account given it's id", typeof(AccountResource))]
        [HttpDelete("id")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _accountService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);
            var accountResource = _mapper.Map<Account, AccountResource>(result.Resource);
            return Ok(accountResource);
        }
    }
}
