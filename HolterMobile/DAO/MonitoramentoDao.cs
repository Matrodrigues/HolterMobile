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

    }
}