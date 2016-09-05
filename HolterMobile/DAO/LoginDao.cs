using HolterMobile.DB;
using HolterMobile.Models;
using HolterMobile.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HolterMobile.DAO
{
    public class LoginDao
    {
        //public List<Login> GetLogins()
        //{
        //    HolterMobileDB db = new HolterMobileDB();
        //    return db.login.ToList();
        //}

        public Login GetLogin(string usuario, string senha, int area)
        {
            Login login = new Login();

            HolterMobileDB db = new HolterMobileDB();

            login = db.login.Where(x => x.ds_username == usuario && x.ds_senha == senha && x.id_perfil == area).FirstOrDefault();

            return login;
        }

        public Login GetLogin(int idUsuario)
        {
            Login login = new Login();

            HolterMobileDB db = new HolterMobileDB();

            login = db.login.Where(x => x.id_usuario == idUsuario).FirstOrDefault();

            return login;
        }

        public bool Inserir(Login l)
        {
            try
            {
                HolterMobileDB db = new HolterMobileDB();

                db.login.Add(l);

                db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        
        public bool TemDisponibilidade(string usuario)
        {
            try
            {
                HolterMobileDB db = new HolterMobileDB();

                Login l = db.login.Where(x => x.ds_username == usuario).FirstOrDefault();

                if (l == null)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Alterar(CadastrarPacienteVM dados)
        {
            try
            {
                HolterMobileDB db = new HolterMobileDB();

                Login login = db.login.Where(x => x.id_usuario == dados.idPaciente).FirstOrDefault();

                login.id_perfil = 2; // Código paciente
                login.ds_senha = dados.senha;
                login.ds_username = dados.usuario;

                db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool AlterarPerfilMedico(CadastrarPacienteVM dados)
        {
            try
            {
                HolterMobileDB db = new HolterMobileDB();

                Login login = db.login.Where(x => x.id_usuario == dados.idPaciente).FirstOrDefault();

                login.id_perfil = 1; // Código médico
                login.ds_senha = dados.senha;
                login.ds_username = dados.usuario;

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