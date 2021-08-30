namespace CL.Core.Shared.ModelViews
{
    public class NovoEndereco
    {
        /// <summary>
        /// Código postal da sua cidade
        /// </summary>
        /// <example>99370000</example>
        public int CEP { get; set; }

        /// <summary>
        /// Estado de origem
        /// </summary>
        /// <example>SantaCatarina</example>
        public string Estado { get; set; }

        /// <summary>
        /// Cidade de origem
        /// </summary>
        /// <example>Brusque</example>
        public string Cidade { get; set; }

        /// <summary>
        /// Logradouro
        /// </summary>
        /// <example>Rua Aurea</example>
        public string Logradouro { get; set; }

        /// <summary>
        /// Número da residência
        /// </summary>
        /// <example>1055</example>
        public string Numero { get; set; }

        /// <summary>
        /// Complemento do endereço
        /// </summary>
        /// <example>Próximo ao poste do Caju</example>
        public string Complemento { get; set; }
    }
}