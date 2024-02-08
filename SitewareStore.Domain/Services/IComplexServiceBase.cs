using SitewareStore.Infra.CrossCutting.Responses;

namespace SitewareStore.Domain.Services
{
    /// <summary>
    /// Interface de serviço base para execuções complexas
    /// </summary>
    /// <typeparam name="Request">Tipo da classe de requisição</typeparam>
    /// <typeparam name="Response">Tipo da classe de resposta</typeparam>
    public interface IComplexServiceBase<Request, Response>
        where Request : class
        where Response : class
    {
        /// <summary>
        /// Método para executar o serviço
        /// </summary>
        /// <param name="request">Conjunto de informações para serem tratadas no serviço</param>
        /// <returns>Container-resposta</returns>
        Task<InternalResponse<Response>> Execute(Request request);
    }
}
