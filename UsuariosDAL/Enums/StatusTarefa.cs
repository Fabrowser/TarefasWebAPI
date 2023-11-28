
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuariosTarefasDAL.Enums
{
    public enum StatusTarefa
    {
        [Description("A Fazer")]
        AFazer = 1,

        [Description("Em Andamento")]
        EmAndamento = 2,

        [Description("Concluído")]
        Concluido = 3 
    }
}
