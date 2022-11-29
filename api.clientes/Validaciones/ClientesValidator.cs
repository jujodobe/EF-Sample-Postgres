using api.clientes.Models;
using FluentValidation;

namespace api.clientes.Validaciones
{
    public class ClientesValidator : AbstractValidator<Clientes>
    {
        public ClientesValidator()
        {
            RuleFor(x => x.Nombre).NotNull().NotEmpty().Length(2, 10);
            RuleFor(x => x.NroDocumeno).NotNull().NotEmpty().Length(3, 10);
        }
    }
}
