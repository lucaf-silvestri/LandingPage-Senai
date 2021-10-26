using Microsoft.EntityFrameworkCore;
using senai.wishlist.WebAPI.Contexts;
using senai.wishlist.WebAPI.Domains;
using senai.wishlist.WebAPI.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace senai.wishlist.WebAPI.Repositories
{
    public class DesejoRepository : IDesejoRepository
    {
        WishlistContext ctx = new WishlistContext();
        public void Atualizar(int idDesejo, Desejo DesejoAtualizado)
        {
            Desejo DesejoBuscado = ListarId(idDesejo);

            if (DesejoBuscado != null)
            {
                DesejoBuscado.IdDesejo = DesejoAtualizado.IdDesejo;
                DesejoBuscado.IdUsuario = DesejoAtualizado.IdUsuario;
                DesejoBuscado.Descricao = DesejoAtualizado.Descricao;
                DesejoBuscado.DataCadastro = DesejoAtualizado.DataCadastro;
            }

            ctx.Desejos.Update(DesejoBuscado);
            ctx.SaveChanges();
        }

        public void Cadastrar(Desejo novoDesejo)
        {
            ctx.Desejos.Add(novoDesejo);
            ctx.SaveChanges();
        }

        public void Deletar(int idDesejo)
        {
            Desejo DesejoBuscado = ListarId(idDesejo);
            ctx.Desejos.Remove(DesejoBuscado);
            ctx.SaveChanges();
        }

        public List<Desejo> Listar()
        {
            return ctx.Desejos.ToList();
        }

        public Desejo ListarId(int id)
        {
            return ctx.Desejos.FirstOrDefault(c => c.IdDesejo == id);
        }

        public List<Desejo> MeusDesejos(int idUsuario)
        {
            return ctx.Desejos
                .Include(p => p.IdUsuarioNavigation)
                .Where(p => p.IdUsuario == idUsuario)
                .ToList();
        }
    }
}