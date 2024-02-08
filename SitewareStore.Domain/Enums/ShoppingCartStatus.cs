using SitewareStore.Infra.CrossCutting.Attributes;

namespace SitewareStore.Domain.Enums
{
    /// <summary>
    /// Status do carrinho de compras
    /// </summary>
    public enum ShoppingCartStatus
    {
        /// <summary>
        /// Pendente
        /// </summary>
        [Description("Pendente - Em aberto")]
        Pending = 1,
        /// <summary>
        /// Finalizado
        /// </summary>
        [Description("Finalizado")]
        Finished = 2,
        /// <summary>
        /// Cancelado
        /// </summary>
        [Description("Cancelado")]
        Canceled = 3
    }

    /// <summary>
    /// Extensões para o enumerador de tipo de status
    /// </summary>
    public static class ShoppingCartStatusExtensions
    {
        /// <summary>
        /// Retorna a descrição do valor selecionado no enumerador
        /// </summary>
        /// <param name="promotionType">Tipo de status</param>
        /// <returns>Texto com a descrição</returns>
        public static string GetDescription(this ShoppingCartStatus promotionType)
        {
            var enumType = typeof(ShoppingCartStatus);
            var memberInfo = enumType.GetMember(ShoppingCartStatus.Pending.ToString());
            var enumValueMemberInfo = memberInfo.FirstOrDefault(x => x.DeclaringType == enumType);
            var valueAttributes = enumValueMemberInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return ((DescriptionAttribute)valueAttributes[0]).Value;
        }
    }
}
