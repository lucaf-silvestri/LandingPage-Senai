using senai.wishlist.WebAPI.Domains;
using System.Collections.Generic;

namespace senai.wishlist.WebAPI.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório DesejoRepository
    /// </summary>
    interface IDesejoRepository
    {
        /// <summary>
        /// Lista todos os Desejos
        /// </summary>
        /// <returns>Lista de Desejos</returns>
        List<Desejo> Listar();

        /// <summary>
        /// Busca um Desejo através de seu ID
        /// </summary>
        /// <param name="id">ID do Desejo buscado</param>
        /// <returns>O Desejo buscado</returns>
        Desejo ListarId(int id);

        /// <summary>
        /// Cadastra um novo Desejo
        /// </summary>
        /// <param name="novoDesejo">Objeto novoDesejo com os novos dados</param>
        void Cadastrar(Desejo novoDesejo);

        /// <summary>
        /// Atualiza um Desejo existente passando o id pela URL da requisição
        /// </summary>
        /// <param name="idDesejo">id do Desejo que será atualizado</param>
        /// <param name="DesejoAtualizado">Objeto DesejoAtualizado com os novos dados</param>
        void Atualizar(int idDesejo, Desejo DesejoAtualizado);

        /// <summary>
        /// Deleta um Desejo existente
        /// </summary>
        /// <param name="idDesejo">ID do Desejo deletado</param>
        void Deletar(int idDesejo);

        /// <summary>
        /// Lista todos os Desejos que um determinado Usuario possui
        /// </summary>
        /// <param name="idUsuario">ID do usuário que possui os Desejos listados</param>
        /// <returns>Uma lista de Desejos</returns>
        List<Desejo> MeusDesejos(int idUsuario);
    }
}