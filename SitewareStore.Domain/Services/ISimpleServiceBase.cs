using SitewareStore.Infra.CrossCutting.Responses;

namespace SitewareStore.Domain.Services
{
    /// <summary>
    /// Interface de serviço base para execuções simples
    /// </summary>
    /// <typeparam name="Response">Tipo da classe de retorno</typeparam>
    public interface ISimpleServiceBase<Response> where Response : class
    {
        /// <summary>
        /// Método para executar o serviço
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <returns>Container-resposta</returns>
        Task<InternalResponse<Response>> Execute(Guid id);
    }
}
