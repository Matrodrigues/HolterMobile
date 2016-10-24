using HolterMobile.DB;
using HolterMobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HolterMobile.DAO
{
    public class TempPressDao
    {

        public List<TempPress> PegarTempPress(int idPaciente, DateTime? dataInicial, DateTime? dataFinal)
        {
            List<TempPress> list = new List<TempPress>();

            HolterMobileDB db = new HolterMobileDB();

            list = db.tempPress.Where(x => x.id_usuario == idPaciente && x.horario >= dataInicial && x.horario <= dataFinal).OrderBy(x => x.horario).ToList();

            return list;
        }

    }
}