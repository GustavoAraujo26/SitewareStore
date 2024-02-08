using FluentValidation.Results;
using SitewareStore.Infra.CrossCutting.Responses;
using System.Net;

namespace SitewareStore.Infra.CrossCutting.Extensions
{
    /// <summary>
    /// Extensões para validações
    /// </summary>
    public static class ValidationExtensions
    {
        /// <summary>
        /// Formata resposta no padrão do sistema para validações realizadas através do FluentValidation
        /// </summary>
        /// <typeparam name="T">Classe a ser validada</typeparam>
        /// <param name="validationResult">Resultado da validação</param>
        /// <returns>Container-resposta</returns>
        public static InternalResponse<T> FormatResponse<T>(this ValidationResult? validationResult) where T : class
        {
            if (validationResult is null || validationResult.IsValid)
                return InternalResponse<T>.Custom(HttpStatusCode.OK, "Validated!");

            var errorList = validationResult.Errors.Select(x => $"[{x.PropertyName}: {x.ErrorMessage}]").ToList();
            string errorMessage = string.Join(", ", errorList);

            return InternalResponse<T>.Custom(HttpStatusCode.UnprocessableEntity, errorMessage);
        }
    }
}
