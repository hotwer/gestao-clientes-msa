using GestaoClientesMSA.Controllers.Dtos;
using GestaoClientesMSA.Controllers.Mappers;
using GestaoClientesMSA.Database.Repositories;
using GestaoClientesMSA.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GestaoClientesMSA.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly IRepository<Cliente> _clienteRepository;
        private readonly IMapper<Cliente, ClienteDto> _clienteMapper;

        //private static List<Cliente> Clientes = new List<Cliente> 
        //{
        //    new Cliente { 
        //        Nome = "Teste 1", 
        //        Email = "teste1@email.com", 
        //        DataNascimento = new DateTime(1994, 10, 5), 
        //        Telefones = new List<Telefone> 
        //        { 
        //            new Telefone { Numero = "21 995814400", Tipo = TelefoneTipo.Pessoal }  
        //        } 
        //    },
        //    new Cliente { 
        //        Nome = "Teste 2", 
        //        Email = "teste2@email.com", 
        //        DataNascimento = new DateTime(1997, 6, 15), 
        //        Telefones = new List<Telefone> 
        //        { 
        //            new Telefone {  Numero = "21 445819100", Tipo = TelefoneTipo.Pessoal },  
        //            new Telefone {  Numero = "21 585414413", Tipo = TelefoneTipo.Comercial }  
        //        } 
        //    },
        //};

        private readonly ILogger<ClientesController> _logger;

        public ClientesController(
            ILogger<ClientesController> logger,
            IMapper<Cliente, ClienteDto> clienteMapper,
            IRepository<Cliente> clienteRepository)
        {
            _logger = logger;
            _clienteMapper = clienteMapper;
            _clienteRepository = clienteRepository;
        }


        [HttpGet]
        public IEnumerable<ClienteDto> List()
        {
            var response = new List<ClienteDto>();

            foreach (var cliente in _clienteRepository.All())
            {
                var dto = new ClienteDto();

                _clienteMapper.Map(cliente, dto);

                response.Add(dto);
            }

            return response;
        }

        /// <summary>
        ///     Procura um cliente usando o ID passado como parâmetro
        /// </summary>
        /// <param name="id">ID do Cliente a ser procurado</param>
        /// <returns>Um Cliente encontrado</returns>
        /// <response code="404">Caso nenhum Cliente seja encontrado</response>
        [HttpGet("{id}")]
        public ActionResult<ClienteDto> Get(int id)
        {
            var response = new ClienteDto();

            var cliente = _clienteRepository.Get(id);

            _clienteMapper.Map(cliente, response);

            return cliente != null ? Ok(response) : NotFound(null);
        }

        [HttpPost("{id}")]
        public ClienteDto Update(int id, [FromBody]ClienteDto clienteDto)
        {
            Cliente cliente;

            if (id == 0) // new
            {
                cliente = new Cliente();
            }
            else
            {
                cliente = _clienteRepository.Get(id);
            }

            _clienteMapper.Map(clienteDto, cliente);

            _clienteRepository.Update(cliente);


            var response = new ClienteDto();

            cliente = _clienteRepository.Get(id);

            _clienteMapper.Map(cliente, response);

            return response;
        }

        [HttpDelete("{id}")]
        public MessageResponse Delete(int id)
        {
            MessageResponse response;

            var cliente = _clienteRepository.Get(id);

            // add method to repo in order to make add performance
            if (cliente  == null)
            {
                response = new MessageResponse($"Não foi possível encontrar nenhum Cliente com o ID: {id}", status: false);
            } 
            else
            {
                _clienteRepository.Delete(cliente);
                response = new MessageResponse("Cliente excluído com sucesso");
            }
            

            return response;
        }
    }
}
