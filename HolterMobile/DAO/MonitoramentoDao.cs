using HolterMobile.DB;
using HolterMobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HolterMobile.DAO
{
    public class MonitoramentoDao
    {

        public List<Monitoramento> PegarBatimentos(int idPaciente, DateTime? dataInicial, DateTime? dataFinal)
        {
            List<Monitoramento> m = new List<Monitoramento>();

            HolterMobileDB db = new HolterMobileDB();

            m = db.monitoramento.Where(x => x.id_paciente == idPaciente && x.horario >= dataInicial && x.horario <= dataFinal).OrderBy(x => x.horario).ToList();

            return m;
        }

        public Monitoramento PegarUltimaLocalizacao(int idPaciente)
        {
            Monitoramento m = new Monitoramento();

            HolterMobileDB db = new HolterMobileDB();

            m = db.monitoramento.Where(x => x.id_paciente == idPaciente && x.longitude != "0.0" && x.latitude != "0.0").OrderByDescending(x => x.horario).ToList().First();

            return m;
        }

    }
}