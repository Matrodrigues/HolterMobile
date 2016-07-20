using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HolterMobile.Models.ViewModel
{
    public class CadastrarPacienteVM : BaseVM
    {
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
    }
}