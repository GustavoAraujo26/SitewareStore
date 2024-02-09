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
        /// <param name="statusType">Tipo de status</param>
        /// <returns>Texto com a descrição</returns>
        public static string GetDescription(this ShoppingCartStatus statusType)
        {
            var enumType = typeof(ShoppingCartStatus);
            var memberInfo = enumType.GetMember(statusType.ToString());
            var enumValueMemberInfo = memberInfo.FirstOrDefault(x => x.DeclaringType == enumType);
            var valueAttributes = enumValueMemberInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return ((DescriptionAttribute)valueAttributes[0]).Value;
        }

        /// <summary>
        /// Lista todas as opções do enumerador
        /// </summary>
        /// <param name="statusType">Tipo de status</param>
        /// <returns></returns>
        public static List<KeyValuePair<int, string>> ListOptions(this ShoppingCartStatus statusType)
        {
            var result = new List<KeyValuePair<int, string>>();

            var enumOptionList = Enum.GetValues(typeof(ShoppingCartStatus)).Cast<ShoppingCartStatus>().ToList();

            foreach (var enumOption in enumOptionList)
            {
                int optionValue = (int)enumOption;
                string description = enumOption.GetDescription();

                result.Add(new KeyValuePair<int, string>(optionValue, description));
            }

            return result;
        }
    }
}
