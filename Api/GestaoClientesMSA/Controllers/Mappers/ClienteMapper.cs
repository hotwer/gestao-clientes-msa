using GestaoClientesMSA.Controllers.Dtos;
using GestaoClientesMSA.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GestaoClientesMSA.Controllers.Mappers
{
    public class ClienteMapper : IMapper<Cliente, ClienteDto>
    {
        private readonly IMapper<Telefone, TelefoneDto> _telefoneMapper;

        public ClienteMapper(IMapper<Telefone, TelefoneDto> telefoneMapper)
        {
            _telefoneMapper = telefoneMapper;
        }

        public void Map(ClienteDto dto, Cliente model)
        {
            if (dto == null)
            {
                return;
            }

            model.Nome = dto.Nome;
            model.Email = dto.Email;
            model.DataNascimento = dto.DataNascimento;

            var keepIds = new List<int>();

            // casting para acessar métodos de lista
            //var modelTelefones = model.Telefones.ToList();

            //if (modelTelefones == null)
            //{
            //    modelTelefones = new List<Telefone>();
            //}

            foreach (var telefoneDto in dto.Telefones)
            {
                var telefoneModel = model.Telefones.Where(telefone => 
                    telefone.Id != 0 
                    && telefone.Id == telefoneDto.Id
                ).FirstOrDefault();

                if (telefoneModel == null)
                {
                    telefoneModel = new Telefone();
                    model.AddTelefone(telefoneModel);
                }
                else
                {
                    keepIds.Add(telefoneDto.Id);
                }

                _telefoneMapper.Map(telefoneDto, telefoneModel);
            }

            // remove todos os telefones excluidos
            var l = model.Telefones.Where(telefone => !keepIds.Contains(telefone.Id) && telefone.Id != 0).ToList();

            foreach (var removeTelefone in l)
            {
                model.RemoveTelefone(removeTelefone);
            }
            
        }

        public void Map(Cliente model, ClienteDto dto)
        {
            if (model == null)
            {
                return;
            }

            dto.Id = model.Id;
            dto.Nome = model.Nome;
            dto.Email = model.Email;
            dto.DataNascimento = model.DataNascimento;
            dto.Telefones = new List<TelefoneDto>();

            // sempre remove todos os registros e adiciona denovo
            foreach (var telefoneModel in model.Telefones)
            {
                var telefoneDto = new TelefoneDto();

                dto.Telefones.Add(telefoneDto);

                _telefoneMapper.Map(telefoneModel, telefoneDto);
            }
        }
    }


}
