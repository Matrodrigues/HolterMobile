using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HolterMobile.Models.ViewModel
{
    public class LoginVM : BaseVM
    {
        [Required(ErrorMessage = "Digite um usuário")]
        public string usuario { get; set; }

        [Required(ErrorMessage = "Insira uma senha")]
        public string senha { get; set; }

        [Required]
        public string area { get; set; }

        public IEnumerable<SelectListItem> AreaList
        {
            get
            {
                return new List<SelectListItem>
                {
                    new SelectListItem { Text = "Médico", Value = "1"},
                    new SelectListItem { Text = "Paciente", Value = "2"},
                    new SelectListItem { Text = "Responsável", Value = "3"}
                };
            }
        }
    }
}