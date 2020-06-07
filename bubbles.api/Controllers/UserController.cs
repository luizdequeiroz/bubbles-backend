using System;
using System.Linq;
using bubbles.api.Models;
using bubbles.api.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace bubbles.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly BubblesContext dbContext;

        public UserController(BubblesContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPost]
        public IActionResult CreateUser(User user)
        {
            try
            {
                dbContext.Users.Add(user);
                dbContext.SaveChanges();

                if (user.Id == 0)
                    return BadRequest(new
                    {
                        result = false,
                        message = "Usuário não foi cadastrado!"
                    });

                return Ok(new
                {
                    result = true,
                    content = user,
                    message = "Usuário cadastrado com sucesso!"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    result = false,
                    message = ex.Message,
                    exception = ex
                });
            }
        }

        [HttpGet("{id}")]
        public IActionResult ReadUserById(int id)
        {
            try
            {
                var user = dbContext.Users.Find(id);

                if (user == null)
                    return NotFound("Nenhum usuário encontrado!");

                return Ok(new
                {
                    result = true,
                    content = user,
                    message = "Usuários encontrados!"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {        
                    result = false,
                    message = ex.Message,
                    exception = ex
                });
            }
        }

        [HttpGet]
        public IActionResult ReadAllUsers()
        {
            try
            {
                var users = dbContext.Users.ToList();

                if (users.Count == 0)
                    return NotFound(new
                    {
                        result = false,
                        message = "Nenhum usuário encontrado!"
                    });

                return Ok(new
                {
                    result = true,
                    content = users,
                    message = "Usuários encontrados!"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    result = false,
                    message = ex.Message,
                    exception = ex
                });
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, User user)
        {
            try
            {
                var userById = dbContext.Users.Find(id);

                if (userById == null)
                    return NotFound("Nenhum usuário encontrado!");

                userById.Username = user.Username;            
                userById.UpdateDate = DateTime.Now;
                dbContext.SaveChanges();

                return Ok(new
                {
                    result = true,
                    content = user,
                    message = "Usuário atualizado com sucesso!"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    result = false,
                    message = ex.Message,
                    exception = ex
                });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                var userById = dbContext.Users.Find(id);

                if (userById == null)
                    return NotFound("Nenhum usuário encontrado!");

                dbContext.Users.Remove(userById);
                dbContext.SaveChanges();

                return Ok(new
                {
                    result = true,
                    content = userById,
                    message = "Usuário deletado com sucesso!"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    result = false,
                    message = ex.Message,
                    exception = ex
                });
            }
        }
    }
}
