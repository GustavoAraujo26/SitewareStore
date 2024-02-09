using SitewareStore.Infra.CrossCutting.Attributes;
using System;

namespace SitewareStore.Domain.Enums
{
    /// <summary>
    /// Tipo de promoção
    /// </summary>
    public enum PromotionType
    {
        /// <summary>
        /// Valor cheio por quantidade
        /// </summary>
        /// /// <remarks>
        /// Ex.: 3 produtos por R$10,00
        /// </remarks>
        [Description("Valor cheio por quantidade. Ex.: 3 por R$10,00")]
        FullPriceByQuantity = 1,
        /// <summary>
        /// Leve mais pague menos (sempre a quantidade total menos 1)
        /// </summary>
        /// /// <remarks>
        /// Ex.: Leve 3 pague 2
        /// </remarks>
        [Description("Leve mais pague menos (sempre a quantidade total menos 1). Ex.: Leve 3 pague 2")]
        PayQuantityMinusOne = 2,
        /// <summary>
        /// Desconto de porcentagem
        /// </summary>
        /// /// <remarks>
        /// Ex.: 10% de desconto
        /// </remarks>
        [Description("Desconto de porcentagem. Ex.: 10% de desconto")]
        PercentageDiscount = 3
    }

    /// <summary>
    /// Extensões para o enumerador de tipo de promoção
    /// </summary>
    public static class PromotionTypeExtensions
    {
        /// <summary>
        /// Retorna a descrição do valor selecionado no enumerador
        /// </summary>
        /// <param name="promotionType">Tipo de promoção</param>
        /// <returns>Texto com a descrição</returns>
        public static string GetDescription(this PromotionType promotionType)
        {
            var enumType = typeof(PromotionType);
            var memberInfo = enumType.GetMember(promotionType.ToString());
            var enumValueMemberInfo = memberInfo.FirstOrDefault(x => x.DeclaringType == enumType);
            var valueAttributes = enumValueMemberInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return ((DescriptionAttribute)valueAttributes[0]).Value;
        }

        /// <summary>
        /// Lista todas as opções do enumerador
        /// </summary>
        /// <param name="promotionType">Tipo da promoção</param>
        /// <returns></returns>
        public static List<KeyValuePair<int, string>> ListOptions(this PromotionType promotionType)
        {
            var result = new List<KeyValuePair<int, string>>();

            var enumOptionList = Enum.GetValues(typeof(PromotionType)).Cast<PromotionType>().ToList();

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
