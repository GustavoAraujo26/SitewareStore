using SitewareStore.Infra.CrossCutting.Attributes;

namespace SitewareStore.Domain.Enums
{
    /// <summary>
    /// Tipo de status
    /// </summary>
    public enum StatusType
    {
        /// <summary>
        /// Ativo
        /// </summary>
        [Description("Ativo")]
        Active = 1,
        /// <summary>
        /// Cancelado
        /// </summary>
        [Description("Cancelado")]
        Cancelled = 2
    }

    /// <summary>
    /// Extensões para o enumerador de tipo de status
    /// </summary>
    public static class StatusTypeExtensions
    {
        /// <summary>
        /// Retorna a descrição do valor selecionado no enumerador
        /// </summary>
        /// <param name="promotionType">Tipo de status</param>
        /// <returns>Texto com a descrição</returns>
        public static string GetDescription(this StatusType promotionType)
        {
            var enumType = typeof(StatusType);
            var memberInfo = enumType.GetMember(StatusType.Active.ToString());
            var enumValueMemberInfo = memberInfo.FirstOrDefault(x => x.DeclaringType == enumType);
            var valueAttributes = enumValueMemberInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return ((DescriptionAttribute)valueAttributes[0]).Value;
        }
    }
}
