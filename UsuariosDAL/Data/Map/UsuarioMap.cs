using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using UsuariosTarefasDAL.Models;

namespace UsuariosTarefasDAL.Data.Map
{
    public class UsuarioMap : IEntityTypeConfiguration<UsuarioModel>
    {

        public void Configure(EntityTypeBuilder<UsuarioModel> builder)
        {

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(150);
        }
    }

}
