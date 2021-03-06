﻿using HolterMobile.DAO;
using HolterMobile.Models;
using HolterMobile.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HolterMobile.Facade
{
    public class MedicoFacade
    {
        public CadastrarPacienteVM CarregaDadosMedico(int idMedico)
        {
            CadastrarPacienteVM vm = new CadastrarPacienteVM();

            LoginDao lDao = new LoginDao();
            UsuarioDao uDao = new UsuarioDao();

            Login l = lDao.GetLogin(idMedico);

            Usuario u = uDao.PegaUsuario(idMedico);

            vm.dataNascto = u.dt_nasc;
            vm.nome = u.nome;
            vm.primeiroNome = u.nome;
            vm.senha = l.ds_senha;
            vm.sexo = Char.Parse(u.sexo);
            vm.sobrenome = u.sobrenome;
            vm.usuario = l.ds_username;

            return vm;
        }

        public bool Alterar(CadastrarPacienteVM vm)
        {
            try
            {
                UsuarioDao usuarioDao = new UsuarioDao();
                LoginDao loginDao = new LoginDao();

                if (!usuarioDao.Alterar(vm))
                    throw new Exception("Erro ao alterar usuário");

                if (!loginDao.AlterarPerfilMedico(vm))
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