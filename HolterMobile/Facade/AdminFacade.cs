using HolterMobile.DAO;
using HolterMobile.Models;
using HolterMobile.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HolterMobile.Facade
{
    public class AdminFacade
    {
        public ListaUsuarioVM ListaMedicos(int idAdm)
        {
            ListaUsuarioVM vm = new ListaUsuarioVM();

            UsuarioDao dao = new UsuarioDao();

            vm.usuarios = dao.ListaMedicos(idAdm);

            return vm;
        }

        public bool CadastrarMedico(CadastrarPacienteVM dados)
        {
            try
            {
                LoginDao loginDao = new LoginDao();
                Login login = new Login();

                UsuarioDao usuarioDao = new UsuarioDao();
                Usuario usuario = new Usuario();

                usuario.altura = 0;
                usuario.bpm_max = 0;
                usuario.bpm_min = 0;
                usuario.dt_nasc = Convert.ToDateTime(dados.dataNascto);
                usuario.nome = dados.primeiroNome;
                usuario.peso = 0;
                usuario.sexo = dados.sexo.ToString();
                usuario.sobrenome = dados.sobrenome;

                int idUsuario = usuarioDao.Inserir(usuario);

                if (idUsuario == 0)
                    return false;

                login.id_perfil = 1; // Código médico
                login.id_usuario = idUsuario;
                login.ds_senha = dados.senha;
                login.ds_username = dados.usuario;

                if (loginDao.TemDisponibilidade(login.ds_username))
                    loginDao.Inserir(login);
                else
                    return false;

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool AlterarMedico(CadastrarPacienteVM dados)
        {
            try
            {
                UsuarioDao usuarioDao = new UsuarioDao();
                LoginDao loginDao = new LoginDao();

                if (!usuarioDao.Alterar(dados))
                    throw new Exception("Erro ao alterar usuário");

                if (!loginDao.AlterarMedico(dados))
                    throw new Exception("Erro ao alterar login");

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}