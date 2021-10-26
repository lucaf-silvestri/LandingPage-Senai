using Microsoft.EntityFrameworkCore;
using senai.wishlist.WebAPI.Contexts;
using senai.wishlist.WebAPI.Domains;
using senai.wishlist.WebAPI.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace senai.wishlist.WebAPI.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        WishlistContext ctx = new WishlistContext();
        public void Atualizar(int idUsuario, Usuario UsuarioAtualizado)
        {
            Usuario UsuarioBuscado = ListarId(idUsuario);

            if (UsuarioBuscado != null)
            {
                UsuarioBuscado.IdUsuario = UsuarioAtualizado.IdUsuario;
                UsuarioBuscado.Username = UsuarioAtualizado.Username;
                UsuarioBuscado.Email = UsuarioAtualizado.Email;
                UsuarioBuscado.Senha = UsuarioAtualizado.Senha;
            }

            ctx.Usuarios.Update(UsuarioBuscado);
            ctx.SaveChanges();
        }

        public void Cadastrar(Usuario novoUsuario)
        {
            ctx.Usuarios.Add(novoUsuario);
            ctx.SaveChanges();
        }

        public void Deletar(int idUsuario)
        {
            Usuario UsuarioBuscado = ListarId(idUsuario);
            ctx.Usuarios.Remove(UsuarioBuscado);
            ctx.SaveChanges();
        }

        public List<Usuario> Listar()
        {
            return ctx.Usuarios.ToList();
        }

        public Usuario ListarId(int id)
        {
            return ctx.Usuarios.FirstOrDefault(c => c.IdUsuario == id);
        }

        public Usuario Login(string email, string senha)
        {
            return ctx.Usuarios.FirstOrDefault(x => x.Email == email && x.Senha == senha);
        }

        public List<Usuario> ListarComDesejos()
        {
            return ctx.Usuarios.Include(x => x.Desejos).ToList();
        }
    }
}
