using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HolterMobile.Models.ViewModel
{
    public class RelatorioVM
    {

        public int idPaciente { get; set; }

        [Required(ErrorMessage = "Favor insera a data de início.")]
        [DataType(DataType.Date, ErrorMessage = "Data inválida")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime dataInicial { get; set; }

        [Required(ErrorMessage = "Favor inserir a data final .")]
        [DataType(DataType.Date, ErrorMessage = "Data inválida")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime dataFinal { get; set; }

        public List<Monitoramento> listaMedidas { get; set; }

        public Usuario usuario { get; set; }

        public int idade { get; set; }

        public RelatorioVM()
        {
            if (listaMedidas == null)
                listaMedidas = new List<Monitoramento>();
        }

    }
}