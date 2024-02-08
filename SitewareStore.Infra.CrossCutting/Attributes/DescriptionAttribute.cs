namespace SitewareStore.Infra.CrossCutting.Attributes
{
    /// <summary>
    /// Atributo para exibição de descrição
    /// </summary>
    public class DescriptionAttribute : Attribute
    {
        /// <summary>
        /// Construtor para inicializar o atributo
        /// </summary>
        /// <param name="value">Descrição a ser exibida</param>
        public DescriptionAttribute(string value)
        {
            Value = value;
        }

        /// <summary>
        /// Valor da descrição a ser exibida
        /// </summary>
        public string Value { get; set; }
    }
}
