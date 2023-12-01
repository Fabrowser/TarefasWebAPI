using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosTarefasDAL.Models;

namespace UsuariosTarefasDAL.Repositorios.Interfaces
{
    public interface IUsuarioRepositorio
    {

        Task<List<UsuarioModel>> BuscarTodosUsuarios();
        
        Task<UsuarioModel> BuscarPorId(int id);

        Task<UsuarioModel> Adicionar(UsuarioModel usuario);

        Task<UsuarioModel> Atualizar(UsuarioModel usuario);

        Task<bool> Apagar(int id);


    }
}
