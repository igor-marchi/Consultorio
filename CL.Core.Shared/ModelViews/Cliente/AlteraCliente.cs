namespace CL.Core.Shared.ModelViews.Cliente
{
    /// <summary>
    /// Objeto utilizado para alteração de um cliente
    /// </summary>
    public class AlteraCliente : NovoCliente
    {
        /// <summary>
        /// Id cliente na base de dados
        /// </summary>
        /// <example>1</example>
        public long Id { get; set; }
    }
}