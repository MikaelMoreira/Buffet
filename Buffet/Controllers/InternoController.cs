using Buffet.Models.Buffet.Cliente;
using Buffet.Models.Buffet.Evento;
using Buffet.Models.Buffet.Local;

using Buffet.Models.Buffet.Situações;


using Buffet.Models.Buffet.Tipos;
using Buffet.RequestModels.Cliente;
using Buffet.RequestModels.Evento;
using Buffet.RequestModels.Local;
using Buffet.ViewModels;
using Buffet.ViewModels.Cliente;
using Buffet.ViewModels.Evento;
using Buffet.ViewModels.Local;
using Buffet.ViewModels.Convidado;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using Buffet.RequestModels.Convidado;
using Buffet.Models.Buffet.Convidado;

namespace Buffet.Controllers
{
    
    public class InternoController : Controller
    {
        private readonly ILogger<InternoController> _logger;
        private readonly ClienteService _clienteService;
        private readonly TipoClienteService _tipoClienteService;
        private readonly LocalService _localService;
        private readonly EventoService _eventoService;
        private readonly SituacaoEventoService _situacaoEventoService;
        private readonly TipoEventoService _tipoEventoService;
        private readonly ConvidadoService _convidadoService;
        private readonly SituacaoConvidadoService _situacaoConvidadoService;
        


        public InternoController(ILogger<InternoController> logger, ClienteService clienteService, TipoClienteService tipoClienteService, 
        LocalService localService, EventoService eventoService, SituacaoEventoService situacaoEventoService, TipoEventoService  tipoEventoService, ConvidadoService convidadoService, SituacaoConvidadoService situacaoConvidadoService)
        {
            _logger = logger;
            _clienteService = clienteService;
            _tipoClienteService = tipoClienteService;
            _localService = localService;
            _eventoService = eventoService;
            _situacaoEventoService = situacaoEventoService;
            _tipoEventoService = tipoEventoService;
            _convidadoService = convidadoService;
            _situacaoConvidadoService = situacaoConvidadoService;
        }


        [Authorize]

        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult ListaCliente(ListaClienteRequest requestModel)
        {
            var viewModel = new ListaClienteViewModel();
            var Nome = requestModel.Nome;
            var CpfCNPJ = requestModel.CpfCNPJ;

            var clientes = _clienteService.ObterPorFiltro(Nome, CpfCNPJ);
            
            foreach (var ClienteEntity in clientes)
            {
                viewModel.clientes.Add(new ClienteEntity()
                {
                    Nome = ClienteEntity.Nome,
                    CPF_CNPJ = ClienteEntity.CPF_CNPJ
                });
            }

            
            return View(viewModel);
        }
        
        public IActionResult EditarCliente()
        {
            return View();
        }
        
        public IActionResult RemoverCliente()
        {
            return View();
        }
        

        public IActionResult Privacy()
        {
            return View();
        }
        
        
        public IActionResult Ajuda()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Cliente()
        {
            var viewModel = new ClienteViewModel();

            viewModel.mensagem_erro = (string[]) TempData["msg"];
            viewModel.mensagem_sucesso = (string) TempData["msg_sucesso"];
            
            
          var tipo = _tipoClienteService.ObterTodos();
                    foreach (var TipoClienteEntity in tipo)
                    {
                        viewModel.Tipo.Add(new TipoClienteEntity()
                        {
                            Id= TipoClienteEntity.Id,
                            Descricao = TipoClienteEntity.Descricao
                        });
                    }
  
            return View(viewModel);

        }


        [HttpGet]
        public IActionResult Eventos()
        {


            var viewModel = new EventoViewModel();

            viewModel.mensagem_erro = (string[])TempData["msg"];
            viewModel.mensagem_sucesso = (string)TempData["msg_sucesso"];


            var tipo = _tipoEventoService.ObterTodos();
            foreach (var TipoEventoEntity in tipo)
            {
                viewModel.Tipo.Add(new TipoEventoEntity()
                {
                    Id = TipoEventoEntity.Id,
                    Descricao = TipoEventoEntity.Descricao
                });
            }

            var cliente = _clienteService.ObterTodos();
            foreach (var ClienteEntity in cliente)
            {
                viewModel.Cliente.Add(new ClienteEntity()
                {
                    Id = ClienteEntity.Id,
                    Nome = ClienteEntity.Nome
                });
            }

            var situacao = _situacaoEventoService.ObterTodos();
                         foreach (var SituacaoEventoEntity in situacao)
                         {
                             viewModel.Situacao.Add(new SituacaoEventoEntity()
                             {
                                 Id = SituacaoEventoEntity.Id,
                                 Descricao = SituacaoEventoEntity.Descricao
                             });
                         }

            var local = _localService.ObterTodos();
            foreach (var LocalEntity in local)
            {
                viewModel.local.Add(new Models.Buffet.Local.LocalEntity()
                {
                    Id = LocalEntity.Id,
                    Descricao = LocalEntity.Descricao
                });
            }
            return View(viewModel);          

        }
        
        public IActionResult Locais()
        {

            var viewModel = new LocalViewModel();

            viewModel.mensagem_erro = (string[])TempData["msg"];
            viewModel.mensagem_sucesso = (string)TempData["msg_sucesso"];

       
            return View(viewModel);
         
        }
        
        public IActionResult Configuracoes()
        {
            return View();
        }
        
       
        public IActionResult Termo()
        {
            return View();
        }
        
        
        public IActionResult Painel()
        {

            return View();
        }
        

        [HttpGet]
        public IActionResult Convidado()
        {


            var viewModel = new ConvidadoViewModel();

            viewModel.mensagem_erro = (string[])TempData["msg"];
            viewModel.mensagem_sucesso = (string)TempData["msg_sucesso"];

            var situacao = _situacaoConvidadoService.ObterTodos();
            foreach (var situacaoConvidadoEntity in situacao)
            {
                viewModel.Situacao.Add(new SituacaoConvidadoEntity()
                {
                    Id = situacaoConvidadoEntity.Id,
                    Descricao = situacaoConvidadoEntity.Descricao
                });
            }
          
            

            var eventos = _eventoService.ObterTodos();
            foreach (var EventoEntity in eventos)
            {
                viewModel.Eventos.Add(new EventoEntity()
                {
                    Id = EventoEntity.Id,
                    Descricao = EventoEntity.Descricao
                });
            }

            return View(viewModel);

        }


        [HttpPost]
        public RedirectToActionResult Convidado(AdicionarConvidadoRequestModel requestModel)
        {


            var Nome = requestModel.Nome;
            var CPF = requestModel.CPF;
            var DataDeNascimento = requestModel.DataDeNascimento;           
            var Email = requestModel.Email;
            var evento = requestModel.Evento;
            var Situacao = requestModel.Situacao;
            var Observacao = requestModel.Observacao;
            var DataIN = requestModel.DataDeinsercao;
            var DataMod = requestModel.DataDeModificacao;




            try
            {
                _convidadoService.Adicionar(requestModel);
                TempData["msg_sucesso"] = "Convidado adicionado com sucesso!";

                return RedirectToAction("Convidado");
            }
            catch (Exception exception)
            {
                TempData["msg"] = new List<string> { exception.Message };

                return RedirectToAction("Convidado");
            }
        }




        [HttpPost]
        public RedirectToActionResult Cliente(AdicionarClienteRequestModel requestModel)
        {
            var Nome = requestModel.Nome;
            var Tipo = requestModel.Tipo;
            var Email = requestModel.Email;
            var Data = requestModel.Data;
            var Endereco = requestModel.Endereco;
            var Observacao = requestModel.Observacao;
            var CpfCnpj = requestModel.CpfCnpj;
            
            try
            {
                _clienteService.Adicionar(requestModel);
                TempData["msg_sucesso"] = "Cliente adicionado com sucesso!";

                return RedirectToAction("Cliente");
            }
            catch (Exception exception)
            {
                TempData["msg"] = new List<string> { exception.Message };

                return RedirectToAction("Cliente");
            }
        }
        
        public RedirectToActionResult EditarCliente(int id, AdicionarClienteRequestModel requestModel)
        {

            var listaDeErros = requestModel.ValidarEFiltrar();
            if (listaDeErros.Count > 0) {
                TempData["formMensagensErro"] = listaDeErros;

                return RedirectToAction("EditarCliente");
            }
            try {
                _clienteService.Editar(id, requestModel);
                TempData["formMensagemSucesso"] = "Cliente editado com sucesso!";

                return RedirectToAction("ListaCliente");
            } catch (Exception exception) {
                TempData["formMensagensErro"] = new List<string> {exception.Message};

                return RedirectToAction("EditarCliente");
            }
        }
        
        public RedirectToActionResult RemoverCliente(int id, object requestModel)
        {
            try {
                _clienteService.Remover(id);
                TempData["formMensagemSucesso"] = "Cliente removido com sucesso!";

                return RedirectToAction("ListaCliente");
            } catch (Exception exception) {
                TempData["formMensagensErro"] = new List<string> {exception.Message};

                return RedirectToAction("RemoverCliente");
            }
        }

        [HttpPost]
        public RedirectToActionResult Locais(CadastroLocalRequestModel requestModel)
        {
            var Descricao = requestModel.Descricao;          
            var Endereco = requestModel.Endereco;
            
            try
            {
                _localService.Adicionar(requestModel);
                TempData["msg_sucesso"] = "Local adicionado com sucesso!";

                return RedirectToAction("Locais");
            }
            catch (Exception exception)
            {
                TempData["msg"] = new List<string> { exception.Message };

                return RedirectToAction("Locais");
            }
        }


        [HttpPost]
        public RedirectToActionResult Eventos(AdicionarEventoRequestModel requestModel)
        {
          
            var Tipo = requestModel.Tipo;
            var Descricao = requestModel.Descricao;
            var DataInic = requestModel.DataInic;
            var HoraInic = requestModel.HoraInic;
            var DataFim = requestModel.DataFim;
            var HoraFim = requestModel.HoraFim;
            var Cliente = requestModel.Cliente;
            var Situacao = requestModel.Situacao;
            var Observacao = requestModel.Observacao;
            var local = requestModel.local;

       
            try
            {
                _eventoService.Adicionar(requestModel);
                TempData["msg_sucesso"] = "Evento adicionado com sucesso!";

                return RedirectToAction("Eventos");
            }
            catch (Exception exception)
            {
                TempData["msg"] = new List<string> { exception.Message };

                return RedirectToAction("Eventos");
            }
        }
        
        


    }
}