using Microsoft.AspNetCore.Mvc;
using senai.wishlist.WebAPI.Domains;
using senai.wishlist.WebAPI.Interfaces;
using senai.wishlist.WebAPI.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace senai.wishlist.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class DesejosController : ControllerBase
    {
        private IDesejoRepository _DesejoRepository { get; set; }

        public DesejosController()
        {
            _DesejoRepository = new DesejoRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<Desejo> listaDesejos = _DesejoRepository.Listar();
            return Ok(listaDesejos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Desejo DesejoBuscado = _DesejoRepository.ListarId(id);

            if (DesejoBuscado == null)
            {
                return NotFound("Nenhum Desejo encontrado.");
            }

            return Ok(DesejoBuscado);
        }

        [HttpPost]
        public IActionResult Post(Desejo novoDesejo)
        {
            _DesejoRepository.Cadastrar(novoDesejo);

            return StatusCode(201);
        }

        [HttpDelete("excluir/{id}")]
        public IActionResult Delete(int id)
        {
            _DesejoRepository.Deletar(id);
            return StatusCode(204);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Desejo DesejoAtualizado)
        {
            Desejo DesejoBuscado = _DesejoRepository.ListarId(id);

            if (DesejoBuscado == null)
            {
                return NotFound
                    (new
                    {
                        mensagem = "Desejo não encontrado.",
                        erro = true
                    });
            }

            try
            {
                _DesejoRepository.Atualizar(id, DesejoAtualizado);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpGet("meus")]
        public IActionResult MeusDesejos()
        {
            try
            {
                int idUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                return Ok(_DesejoRepository.MeusDesejos(idUsuario));
            }
            catch (Exception error)
            {
                return BadRequest(new
                {
                    mensagem = "Não é possível listar os desejos sem um usuário logado.",
                    error
                });
            }
        }
    }
}