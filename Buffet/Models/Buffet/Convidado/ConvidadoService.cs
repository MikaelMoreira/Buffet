using Buffet.DataBase;
using Buffet.Models.Buffet.Evento;
using Buffet.Models.Buffet.Situações;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buffet.Models.Buffet.Convidado
{
    public class ConvidadoService
    {
        private readonly DataBaseContext _databaseContext;
        private readonly EventoService _EventoService;
        private readonly SituacaoConvidadoService _situacaoConvidadoService;
       

        public ConvidadoService(

           DataBaseContext databaseContext,  
           SituacaoEventoService SituacaoEventoService,
           EventoService EventoService,
           SituacaoConvidadoService situacaoConvidadoService
           
       )

        {
            _databaseContext = databaseContext;      
            _situacaoConvidadoService = situacaoConvidadoService;
            _EventoService = EventoService;
            
        }

        public List<ConvidadoEntity> ObterTodos()
        {
            return _databaseContext.Convidados
                .ToList();
        }

        public ConvidadoEntity ObterPorId(int id)
        {
            try
            {
                return _databaseContext.Convidados.Find(id);
            }
            catch
            {
                throw new Exception("Convidados de ID #" + id + " não encontrada");
            }
        }

        private ConvidadoEntity ValidarDadosBasicos(
         IDadosBasicosConvidado dadosBasicos
     )
        {

            var entidade = new ConvidadoEntity();

            entidade.Nome = dadosBasicos.Nome;

            entidade.CPF = dadosBasicos.CPF;
            
            entidade.DataDeNascimento = dadosBasicos.DataDeNascimento;

            entidade.Email = dadosBasicos.Email;

            entidade.Evento = _EventoService.ObterPorId(Convert.ToInt32(dadosBasicos.Evento));

            entidade.Situacao = _situacaoConvidadoService.ObterPorId(Convert.ToInt32(dadosBasicos.Situacao));

            entidade.Observacao = dadosBasicos.Observacao;

            var DataIN = DateTime.Now;
            entidade.DataDeinsercao = DataIN;

            var DataMod = DateTime.Now;
            entidade.DataDeModificacao = DataMod;

            return entidade;
        }



        public ConvidadoEntity Adicionar(IDadosBasicosConvidado dadosBasicos)
        {
            var novoConvidado = ValidarDadosBasicos(dadosBasicos);
            _databaseContext.Convidados.Add(novoConvidado);
            _databaseContext.SaveChanges();

            return novoConvidado;
        }



        public interface IDadosBasicosConvidado
        {

            public string Nome { get; set; }

            public string CPF { get; set; }

            public string DataDeNascimento { get; set; }

            public string Email { get; set; }

            public string Evento { get; set; }

            public string Situacao { get; set; }

            public string Observacao { get; set; }

            public DateTime DataDeinsercao { get; set; }

            public DateTime DataDeModificacao { get; set; }

        }


    }
}
