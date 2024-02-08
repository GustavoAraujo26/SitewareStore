using System.Net;

namespace SitewareStore.Domain.Responses
{
    /// <summary>
    /// Resposta interna do sistema
    /// </summary>
    /// <typeparam name="T">Tipo de objeto a ser retornado</typeparam>
    public class InternalResponse<T> where T : class
    {
        /// <summary>
        /// Construtor para inicializar as propriedades
        /// </summary>
        /// <param name="status">Status da resposta</param>
        /// <param name="message">Mensagem retornada</param>
        /// <param name="stackTrace">Caminho percorrido</param>
        /// <param name="single">Objeto único a ser retornado</param>
        /// <param name="list">Lista de objetos</param>
        public InternalResponse(HttpStatusCode status, string? message, 
            string? stackTrace, T? single, List<T>? list)
        {
            Status = status;
            Message = message;
            StackTrace = stackTrace;
            Single = single;
            List = list;
        }

        /// <summary>
        /// Status da resposta
        /// </summary>
        public HttpStatusCode Status { get; private set; }

        /// <summary>
        /// Mensagem retornada
        /// </summary>
        public string? Message { get; private set; }

        /// <summary>
        /// Caminho percorrido
        /// </summary>
        public string? StackTrace { get; private set; }

        /// <summary>
        /// Objeto único a ser retornado
        /// </summary>
        public T? Single { get; private set; }

        /// <summary>
        /// Lista de objetos
        /// </summary>
        public List<T>? List { get; private set; }

        /// <summary>
        /// Verifica se a resposta é de sucesso
        /// </summary>
        /// <returns>Boleano indicando status da chamada</returns>
        public bool IsSuccess() =>
            (int)Status >= 200 && (int)Status <= 299;

        /// <summary>
        /// Cria resposta de sucesso com retorno de item
        /// </summary>
        /// <param name="single">Item a ser retornado</param>
        /// <returns>Container-resposta</returns>
        public static InternalResponse<T> Success(T single) =>
            new InternalResponse<T>(HttpStatusCode.OK, "Success", null, single, null);

        /// <summary>
        /// Cria resposta de sucesso com retorno de lista de itens
        /// </summary>
        /// <param name="list">Lista de itens</param>
        /// <returns>Container-resposta</returns>
        public static InternalResponse<T> Success(List<T> list) =>
            new InternalResponse<T>(HttpStatusCode.OK, "Success", null, null, list);

        /// <summary>
        /// Cria resposta customizada
        /// </summary>
        /// <param name="status">Status HTTP</param>
        /// <param name="message">Mensagem a ser retornada</param>
        /// <param name="stackTrace">Caminho percorrido</param>
        /// <returns>Container-resposta</returns>
        public static InternalResponse<T> Custom(HttpStatusCode status, string? message, string? stackTrace = null) =>
            new InternalResponse<T>(status, message, stackTrace, null, null);

        /// <summary>
        /// Cria resposta de falha com base em exceções
        /// </summary>
        /// <param name="ex">Exceção</param>
        /// <returns>Container-resposta</returns>
        public static InternalResponse<T> Error(Exception ex) =>
            new InternalResponse<T>(HttpStatusCode.InternalServerError, ex.Message, ex.StackTrace, null, null);
    }
}
