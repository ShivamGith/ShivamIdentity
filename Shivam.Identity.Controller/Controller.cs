using Microsoft.AspNetCore.Mvc;
using Shivam.Identity.Abstractions;
using System;

namespace Shivam.Identity.Controller
{
    /// <summary>
    /// Controller for managing user-related operations.
    /// </summary>
    [ApiController]
    [Route("")]
    public class UserController : ControllerBase
    {
        private readonly IService _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        /// <param name="service">The service to handle user operations.</param>
        public UserController(IService service)
        {
            _service = service;
        }

        /// <summary>
        /// Creates a new user.
        /// </summary>
        /// <param name="request">The request containing user details.</param>
        /// <returns>An <see cref="IActionResult"/> representing the result of the operation.</returns>
        [HttpPost("create-user")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request)
        {
            try
            {
                var response = await _service.CreateUserAsync(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Log the exception (ex) here if needed
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Gets a user by ID.
        /// </summary>
        /// <param name="id">The ID of the user to retrieve.</param>
        /// <returns>An <see cref="IActionResult"/> representing the result of the operation.</returns>
        [HttpGet]
        public async Task<IActionResult> GetUser([FromQuery] string id)
        {
            try
            {
                var user = await _service.GetUserAsync(id);
                return Ok(user);
            }
            catch (Exception ex)
            {
                // Log the exception (ex) here if needed
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}