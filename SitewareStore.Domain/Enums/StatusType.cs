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
        /// <param name="statusType">Tipo de status</param>
        /// <returns>Texto com a descrição</returns>
        public static string GetDescription(this StatusType statusType)
        {
            var enumType = typeof(StatusType);
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
        public static List<KeyValuePair<int, string>> ListOptions(this StatusType statusType)
        {
            var result = new List<KeyValuePair<int, string>>();

            var enumOptionList = Enum.GetValues(typeof(StatusType)).Cast<StatusType>().ToList();

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
