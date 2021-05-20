using Buffet.DataBase;
using Buffet.Models.Buffet.Cliente;
using Buffet.Models.Buffet.Local;
using Buffet.Models.Buffet.Situações;
using Buffet.Models.Buffet.Tipos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buffet.Models.Buffet.Evento
{
    public class EventoService
    {

        private readonly DataBaseContext _databaseContext;
        private readonly ClienteService _clienteService;
        private readonly LocalService _localService;
        private readonly SituacaoEventoService _situacaoEventoService;
        private readonly TipoEventoService _tipoEventoService;

        public EventoService(

            DataBaseContext databaseContext,
            ClienteService ClienteService,
            LocalService LocalService,
            SituacaoEventoService SituacaoEventoService,
            TipoEventoService tipoEventoService
        )

        {
            _databaseContext = databaseContext;
            _clienteService = ClienteService;
            _localService = LocalService;
            _situacaoEventoService = SituacaoEventoService;
            _tipoEventoService = tipoEventoService;
        }




        public List<EventoEntity> ObterTodos()
        {
            return _databaseContext.Eventos
                .ToList();
        }

        public EventoEntity ObterPorId(int id)
        {
            try
            {
                return _databaseContext.Eventos.Find(id);
            }
            catch
            {
                throw new Exception("Evento de ID #" + id + " não encontrada");
            }
        }


        private EventoEntity ValidarDadosBasicos(
            IDadosBasicosEvento dadosBasicos
        )
        {

            var entidade = new EventoEntity();

            entidade.Tipo = _tipoEventoService.ObterPorId(Convert.ToInt32(dadosBasicos.Tipo));

            entidade.Descricao = dadosBasicos.Descricao;

            entidade.DataInic = dadosBasicos.DataInic;

            entidade.HoraInic = dadosBasicos.HoraInic;

            entidade.DataFim = dadosBasicos.DataFim;

            entidade.HoraFim = dadosBasicos.HoraFim;

            entidade.Cliente = _clienteService.ObterPorId(Convert.ToInt32(dadosBasicos.Cliente));

            entidade.Situacao = _situacaoEventoService.ObterPorId(Convert.ToInt32(dadosBasicos.Situacao));

            entidade.Local = _localService.ObterPorId(Convert.ToInt32(dadosBasicos.local));

            entidade.Observacao = dadosBasicos.Observacao;

            var dataAdic = DateTime.Now;
            entidade.DataDeinsercao = dataAdic;

            var dataModif = DateTime.Now;
            entidade.DataDeModificacao = dataModif;



            return entidade;
        }

        public EventoEntity Adicionar(IDadosBasicosEvento dadosBasicos)
        {
            var novoEvento = ValidarDadosBasicos(dadosBasicos); ;
            _databaseContext.Eventos.Add(novoEvento);
            _databaseContext.SaveChanges();

            return novoEvento;
        }

        public interface IDadosBasicosEvento
        {

            public string Tipo { get; set; }

            public string Descricao { get; set; }

            public string DataInic { get; set; }

            public string HoraInic { get; set; }

            public string DataFim { get; set; }

            public string HoraFim { get; set; }

            public string Cliente { get; set; }

            public string Situacao { get; set; }

            public string local { get; set; }

            public string Observacao { get; set; }

            public DateTime DataDeinsercao { get; set; }

            public DateTime DataDeModificacao { get; set; }

        }

    }
}
