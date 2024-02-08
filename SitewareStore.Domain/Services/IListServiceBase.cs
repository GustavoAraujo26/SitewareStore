using SitewareStore.Infra.CrossCutting.Responses;

namespace SitewareStore.Domain.Services
{
    /// <summary>
    /// Interface de serviço base para listagens
    /// </summary>
    /// <typeparam name="Response">Tipo da classe de retorno</typeparam>
    public interface IListServiceBase<Response> where Response : class
    {
        /// <summary>
        /// Método para executar o serviço
        /// </summary>
        /// <returns>Container-resposta</returns>
        Task<InternalResponse<Response>> Execute();
    }
}
