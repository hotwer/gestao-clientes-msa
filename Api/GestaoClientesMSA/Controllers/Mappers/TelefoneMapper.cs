using GestaoClientesMSA.Controllers.Dtos;
using GestaoClientesMSA.Models;

namespace GestaoClientesMSA.Controllers.Mappers
{
    public class TelefoneMapper : IMapper<Telefone, TelefoneDto>
    {
        public void Map(TelefoneDto dto, Telefone model)
        {
            if (dto == null)
            {
                return;
            }

            model.Numero = dto.Numero;
            model.Tipo = (TelefoneTipo)dto.Tipo;
        }

        public void Map(Telefone model, TelefoneDto dto)
        {
            if (model == null)
            {
                return;
            }

            dto.Id = model.Id;
            dto.Numero = model.Numero;
            dto.Tipo = (int)model.Tipo;
        }
    }


}
