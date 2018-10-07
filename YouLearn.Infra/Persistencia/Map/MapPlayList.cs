﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using YouLearn.Domain.Entities;

namespace YouLearn.Infra.Persistencia.Map
{
    public class MapPlayList : IEntityTypeConfiguration<PlayList>
    {
        public void Configure(EntityTypeBuilder<PlayList> builder)
        {
            builder.ToTable("PlayList");
            //ForeignKey
            builder.HasOne(x => x.Usuario).WithMany().HasForeignKey("IdUsuario");

            //Propriedades
            builder.HasKey(X => X.Id);
            builder.Property(x => x.Nome).HasMaxLength(50).IsRequired();
        }
    }
}