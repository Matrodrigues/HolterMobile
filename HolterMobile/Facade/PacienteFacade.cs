using HolterMobile.Models.ViewModel;
using HolterMobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HolterMobile.DAO;
using HolterMobile.Enum;

namespace HolterMobile.Facade
{
    public class PacienteFacade
    {
        // Método para efetuar o cadastro do paciente. Tanto na tabela de Usuário(TB_USUARIO)
        // quanto na tabela de login(TB_LOGIN)
        public bool CadastrarPaciente(CadastrarPacienteVM dados)
        {
            try
            {
                LoginDao loginDao = new LoginDao();
                Login login = new Login();

                PacienteMedicoDao pacienteMedicoDao = new PacienteMedicoDao();
                PacienteMedico pacienteMedico = new PacienteMedico();

                UsuarioDao usuarioDao = new UsuarioDao();
                Usuario usuario = new Usuario();

                usuario.altura = dados.altura;
                usuario.bpm_max = dados.bpm_max;
                usuario.bpm_min = dados.bpm_min;
                usuario.dt_nasc = Convert.ToDateTime(dados.dataNascto);
                usuario.nome = dados.primeiroNome;
                usuario.peso = dados.peso;
                usuario.sexo = dados.sexo;
                usuario.sobrenome = dados.sobrenome;

                int idUsuario = usuarioDao.Inserir(usuario);

                if (idUsuario == 0)
                    return false;

                login.id_perfil = 2; // Código paciente
                login.id_usuario = idUsuario;
                login.ds_senha = dados.senha;
                login.ds_username = dados.usuario;

                if (loginDao.TemDisponibilidade(login.ds_username))
                    loginDao.Inserir(login);
                else
                    return false;

                pacienteMedico.id_medico = dados.idLogado;
                pacienteMedico.id_paciente = idUsuario;

                if (!pacienteMedicoDao.Inserir(pacienteMedico))
                    return false;

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public ListaUsuarioVM ListaPacientes(int idMedico)
        {
            ListaUsuarioVM vm = new ListaUsuarioVM();

            UsuarioDao dao = new UsuarioDao();

            vm.usuarios = dao.ListaPacientes(idMedico);
            
            return vm;
        }
    }
}