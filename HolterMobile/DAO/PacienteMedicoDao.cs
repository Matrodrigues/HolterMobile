using HolterMobile.DB;
using HolterMobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HolterMobile.DAO
{
    public class PacienteMedicoDao
    {
        public bool Inserir(PacienteMedico pm)
        {
            try
            {
                HolterMobileDB db = new HolterMobileDB();

                db.pacienteMedico.Add(pm);

                db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<int> PegarIdsPacientes(int id_medico)
        {
            HolterMobileDB db = new HolterMobileDB();

            List<PacienteMedico> pm = db.pacienteMedico.Where(x => x.id_medico == id_medico).ToList();

            List<int> idsPacientes = new List<int>();

            foreach (PacienteMedico p in pm)
                idsPacientes.Add(p.id_paciente);

            return idsPacientes;
        }
    }
}