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
                usuario.sexo = dados.sexo.ToString();
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

        public CadastrarPacienteVM CarregaPaciente(int idUsuario)
        {
            CadastrarPacienteVM vm = new CadastrarPacienteVM();

            LoginDao lDao = new LoginDao();
            UsuarioDao uDao = new UsuarioDao();

            Login l = lDao.GetLogin(idUsuario);

            Usuario u = uDao.PegaUsuario(idUsuario);

            vm.altura = u.altura;
            vm.bpm_max = u.bpm_max;
            vm.bpm_min = u.bpm_min;
            vm.dataNascto = u.dt_nasc;
            vm.nome = u.nome;
            vm.peso = u.peso;
            vm.primeiroNome = u.nome;
            vm.senha = l.ds_senha;
            vm.sexo = Char.Parse(u.sexo);
            vm.sobrenome = u.sobrenome;
            vm.usuario = l.ds_username;

            return vm;
        }

        public bool AlterarPaciente(CadastrarPacienteVM dados)
        {
            try
            {
                UsuarioDao usuarioDao = new UsuarioDao();
                LoginDao loginDao = new LoginDao();

                if (!usuarioDao.Alterar(dados))
                    throw new Exception("Erro ao alterar usuário");

                if (!loginDao.Alterar(dados))
                    throw new Exception("Erro ao alterar login");

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool ExcluirPaciente(int idPaciente)
        {
            try
            {
                UsuarioDao uDao = new UsuarioDao();

                if (!uDao.Excluir(idPaciente))
                    throw new Exception("Erro ao deletar paciente");

                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public RelatorioVM CarregaRelatorio(RelatorioVM dados)
        {
            #region Pega dados de Batimento Cardíaco

            MonitoramentoDao dao = new MonitoramentoDao();

            List<Monitoramento> mediaPorDia = new List<Monitoramento>();

            List<Monitoramento> medicoes = dao.PegarBatimentos(dados.idPaciente, dados.dataInicial, dados.dataFinal);

            IEnumerable<string> datasDistintas = medicoes.Select(x => x.horario.ToShortDateString()).Distinct();

            foreach (string d in datasDistintas)
            {
                Monitoramento monitor = new Monitoramento();

                List<Monitoramento> medicoesDoDia = medicoes.Where(x => x.horario.ToShortDateString() == d).ToList();

                int bpmModa = medicoesDoDia.GroupBy(x => x.bpm).OrderByDescending(x => x.Count()).First().Key;

                monitor.bpm = bpmModa;
                monitor.horario = Convert.ToDateTime(d);

                mediaPorDia.Add(monitor);
            }

            dados.listaMedidas = mediaPorDia;

            #endregion

            TempPressDao tmpPressaoDao = new TempPressDao();
            List<TempPress> listaTotal = tmpPressaoDao.PegarTempPress(dados.idPaciente, dados.dataInicial, dados.dataFinal);

            #region Pega Dados de Temperatura

            List<TempPress> listaTemperatura = listaTotal.Where(x => x.temperatura != 0).ToList();            
            List<TempPress> listaTemperaturaPorDia = new List<TempPress>();

            IEnumerable<string> datasDistintasTemperatura = listaTemperatura.Select(x => x.horario.ToShortDateString()).Distinct();
            IEnumerable<string> datasDistintasPressao = listaTemperatura.Select(x => x.horario.ToShortDateString()).Distinct();

            foreach (string d in datasDistintasTemperatura)
            {
                TempPress temp = new TempPress();

                List<TempPress> tempDoDia = listaTemperatura.Where(x => x.horario.ToShortDateString() == d).ToList();

                double tempModa = tempDoDia.GroupBy(x => x.temperatura).OrderByDescending(x => x.Count()).First().Key;

                temp.temperatura = tempModa;
                temp.horario = Convert.ToDateTime(d);

                listaTemperaturaPorDia.Add(temp);
            }

            dados.listaTemperatura = listaTemperaturaPorDia;

            #endregion

            #region Pega Dados de Pressão

            List<TempPress> listaPressao = listaTotal.Where(x => x.pressao_max != 0 && x.pressao_min != 0).ToList();
            List<TempPress> listaPressaoPorDia = new List<TempPress>();

            foreach (string d in datasDistintasPressao)
            {
                TempPress press = new TempPress();

                List<TempPress> pressDoDia = listaPressao.Where(x => x.horario.ToShortDateString() == d).ToList();

                //double tempModa = pressDoDia.GroupBy(x => x.pressao_max ).OrderByDescending(x => x.Count()).First().Key;

                double pressMaxModa = pressDoDia.GroupBy(x => new { x.pressao_max, x.pressao_min }).OrderByDescending(x => x.Count()).First().Key.pressao_max;
                double pressMinModa = pressDoDia.GroupBy(x => new { x.pressao_max, x.pressao_min }).OrderByDescending(x => x.Count()).First().Key.pressao_min;

                press.pressao_max = pressMaxModa;
                press.pressao_min = pressMinModa;
                press.horario = Convert.ToDateTime(d);

                listaPressaoPorDia.Add(press);
            }

            dados.listaPressao = listaPressaoPorDia;

            #endregion

            return dados;
        }

        public LocalizacaoVM PegarLocalizacao(LocalizacaoVM vm)
        {
            MonitoramentoDao mDao = new MonitoramentoDao();

            Monitoramento m = mDao.PegarUltimaLocalizacao(vm.idPaciente);

            vm.latitude = m.latitude;
            vm.longitude = m.longitude;
            vm.horario = m.horario.ToString();

            return vm;
        }

        public RelatorioVM CarregaRelatorioDetalhado(RelatorioVM vm)
        {
            MonitoramentoDao dao = new MonitoramentoDao();

            List<Monitoramento> medicoes = dao.PegarBatimentos(vm.idPaciente, vm.dataInicial, vm.dataFinal);

            vm.listaMedidas = medicoes;

            return vm;
        }
    }
}