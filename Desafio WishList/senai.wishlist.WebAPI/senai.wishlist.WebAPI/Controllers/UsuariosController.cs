using Microsoft.AspNetCore.Mvc;
using senai.wishlist.WebAPI.Domains;
using senai.wishlist.WebAPI.Interfaces;
using senai.wishlist.WebAPI.Repositories;
using System;
using System.Collections.Generic;

namespace senai.wishlist.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepository _UsuarioRepository { get; set; }

        public UsuariosController()
        {
            _UsuarioRepository = new UsuarioRepository();
        }
        [HttpGet]
        public IActionResult Get()
        {
            List<Usuario> listaUsuarios = _UsuarioRepository.Listar();
            return Ok(listaUsuarios);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Usuario UsuarioBuscado = _UsuarioRepository.ListarId(id);

            if (UsuarioBuscado == null)
            {
                return NotFound("Nenhum Usuário encontrado.");
            }

            return Ok(UsuarioBuscado);
        }

        [HttpPost]
        public IActionResult Post(Usuario novoUsuario)
        {
            _UsuarioRepository.Cadastrar(novoUsuario);

            return StatusCode(201);
        }

        [HttpDelete("excluir/{id}")]
        public IActionResult Delete(int id)
        {
            _UsuarioRepository.Deletar(id);
            return StatusCode(204);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Usuario UsuarioAtualizado)
        {
            Usuario UsuarioBuscado = _UsuarioRepository.ListarId(id);

            if (UsuarioBuscado == null)
            {
                return NotFound
                    (new
                    {
                        mensagem = "Usuário não encontrado.",
                        erro = true
                    });
            }

            try
            {
                _UsuarioRepository.Atualizar(id, UsuarioAtualizado);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpGet("desejos")]
        public IActionResult ListarComDesejos()
        {
            try
            {
                return Ok(_UsuarioRepository.ListarComDesejos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
