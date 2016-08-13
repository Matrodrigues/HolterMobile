using HolterMobile.DB;
using HolterMobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HolterMobile.DAO
{
    public class UsuarioDao
    {
        // Método para pegar todos os usuários que são cadastrados do médico logado
        public List<Usuario> ListaPacientes (int idMedico)
        {
            HolterMobileDB db = new HolterMobileDB();

            List<int> idsPaciente = new PacienteMedicoDao().PegarIdsPacientes(idMedico);

            return db.usuario.Where(x => idsPaciente.Contains(x.id_usuario)).ToList();

        }

        public int Inserir(Usuario u)
        {
            try
            {
                HolterMobileDB db = new HolterMobileDB();

                db.usuario.Add(u);

                db.SaveChanges();

                return u.id_usuario;
            }
            catch(Exception ex)
            {
                return 0;
            }
        }
    }
}