using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosTarefasDAL.Enums;

namespace UsuariosTarefasDAL.Models
{
    public class TarefaModel
    {

        public int Id { get; set; }

        public string? Nome { get; set; }

        public string? Descricao { get; set; }

        public StatusTarefa Status { get; set;}

    }
}
