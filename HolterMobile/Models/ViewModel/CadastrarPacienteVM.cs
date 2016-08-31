using HolterMobile.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HolterMobile.Models.ViewModel
{
    public class CadastrarPacienteVM : BaseVM
    {
        public int idPaciente { get; set; }

        [Required(ErrorMessage = "Favor inserir o nome")]
        public string primeiroNome { get; set; }

        [Required(ErrorMessage = "Favor inserir o sobrenome")]
        public string sobrenome { get; set; }

        [Required(ErrorMessage = "Favor selecione um sexo")]
        public Char sexo { get; set; }
        
        [Required(ErrorMessage = "Favor inserir a data de nascimento.")]
        [DataType(DataType.Date, ErrorMessage = "Data inválida")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? dataNascto { get; set; }

        [Required(ErrorMessage = "Favor inserir o peso.")]
        [ValidDouble(ErrorMessage = "Peso inválida")]
        public double peso { get; set; }

        [Required(ErrorMessage = "Favor inserir o peso.")]
        [ValidDouble(ErrorMessage = "Altura inválida")]
        public double altura { get; set; }

        [Required(ErrorMessage = "Favor inserir o batimento mínimo aceitável.")]
        [ValidInteger(ErrorMessage = "BPM mínimo inválido")]
        public int bpm_min { get; set; }

        [Required(ErrorMessage = "Favor inserir o batimento máximo aceitável.")]
        [ValidInteger(ErrorMessage = "BPM máximo inválido")]
        public int bpm_max { get; set; }

        [Required(ErrorMessage = "Favor inserir um nomé de usuário para acesso ao sistema.")]
        public string usuario { get; set; }

        [Required(ErrorMessage = "Favor inserir uma senha para acesso ao sistema.")]
        public string senha { get; set; }
    }
}