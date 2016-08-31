using HolterMobile.DB;
using HolterMobile.Models;
using HolterMobile.Models.ViewModel;
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

        public Usuario PegaUsuario(int idUsuario)
        {
            HolterMobileDB db = new HolterMobileDB();

            return db.usuario.Where(x => x.id_usuario == idUsuario).FirstOrDefault();
        }

        public bool Alterar(CadastrarPacienteVM dados)
        {
            try
            {
                HolterMobileDB db = new HolterMobileDB();

                Usuario u = db.usuario.Where(x => x.id_usuario == dados.idPaciente).FirstOrDefault();

                u.altura = dados.altura;
                u.bpm_max = dados.bpm_max;
                u.bpm_min = dados.bpm_min;
                u.dt_nasc = Convert.ToDateTime(dados.dataNascto);
                u.nome = dados.primeiroNome;
                u.peso = dados.peso;
                u.sexo = dados.sexo.ToString();
                u.sobrenome = dados.sobrenome;

                db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
           
        }
    }
}