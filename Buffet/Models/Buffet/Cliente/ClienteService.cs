using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Buffet.DataBase;
using Buffet.Models.Buffet.Tipos;
using Microsoft.EntityFrameworkCore;
using static Buffet.Models.Buffet.Tipos.TipoClienteService;

namespace Buffet.Models.Buffet.Cliente
{
    public class ClienteService
    {

        private readonly DataBaseContext _databaseContext;
        private readonly TipoClienteService _tipoClienteService;

        public ClienteService(

            DataBaseContext databaseContext,
            TipoClienteService tipoClienteService
        )

        {
            _databaseContext = databaseContext;
            _tipoClienteService = tipoClienteService;
        }

        public List<ClienteEntity>ObterTodos()
        {
            return _databaseContext.Clientes
                .ToList();
        }
        
        public ClienteEntity ObterPorId(int id)
        {
            try {
                return _databaseContext.Clientes.Find(id);
            } catch {
                throw new Exception("Cliente de ID #" + id + " não encontrada");
            }
        }

        public List<ClienteEntity> ObterPorFiltro(string Nome, string CpfCNPJ)
        {
            var listaCliente = _databaseContext.Clientes
                .AsQueryable();

            if (Nome != null)
            {
                listaCliente = listaCliente.Where(c => c.Nome.Contains(Nome));


            }
            
            if ( CpfCNPJ != null)
            {
                listaCliente = listaCliente.Where(c => c.CPF_CNPJ.Contains(CpfCNPJ));


            }

            return listaCliente.ToList();

        }


        private ClienteEntity ValidarDadosBasicos(
            IDadosBasicosCliente dadosBasicos,
            ClienteEntity clienteExistente = null
            
        )
        {
           
            var entidade = clienteExistente ?? new ClienteEntity();
            
            entidade.Nome = dadosBasicos.Nome;

            entidade.Tipo = _tipoClienteService.ObterPorId(Convert.ToInt32(dadosBasicos.Tipo));

            entidade.DataDeNascimento = dadosBasicos.Data;
            
            entidade.CPF_CNPJ = dadosBasicos.CpfCnpj;

            entidade.Email = dadosBasicos.Email;

            entidade.Endereco = dadosBasicos.Endereco;

            entidade.Observacao = dadosBasicos.Observacao;



            var dataAdic = DateTime.Now;
            entidade.DataDeinsercao = dataAdic; 
            
            var dataModif = DateTime.Now;
            entidade.DataDeModificacao = dataModif; 
           

            
            return entidade;
        }
        
        public ClienteEntity Adicionar(IDadosBasicosCliente dadosBasicos)
        {
            var novoCliente = ValidarDadosBasicos(dadosBasicos); ;
            _databaseContext.Clientes.Add(novoCliente);
            _databaseContext.SaveChanges();

            return novoCliente;
        }
        
        public ClienteEntity Editar(
            int id,
            IDadosBasicosCliente dadosBasicos
        )
        {
            var clienteEntity = ObterPorId(id);
            clienteEntity = ValidarDadosBasicos(dadosBasicos, clienteEntity);
            _databaseContext.SaveChanges();

            return clienteEntity;
        }
        
        
        public ClienteEntity Remover(int id)
        {
            var clienteEntity = ObterPorId(id);
            _databaseContext.Clientes.Remove(clienteEntity);
            _databaseContext.SaveChanges();

            return clienteEntity;
        }
    }
    
    }

    
