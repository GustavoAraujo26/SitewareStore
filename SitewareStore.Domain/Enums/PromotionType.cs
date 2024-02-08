using SitewareStore.Infra.CrossCutting.Attributes;

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
            var memberInfo = enumType.GetMember(PromotionType.FullPriceByQuantity.ToString());
            var enumValueMemberInfo = memberInfo.FirstOrDefault(x => x.DeclaringType == enumType);
            var valueAttributes = enumValueMemberInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return ((DescriptionAttribute)valueAttributes[0]).Value;
        }
    }
}
