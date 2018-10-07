﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using YouLearn.Domain.Entities;

namespace YouLearn.Infra.Persistencia.Map
{
    public class MapCanal : IEntityTypeConfiguration<Canal>
    {
        public void Configure(EntityTypeBuilder<Canal> builder)
        {
            builder.ToTable("Canal");
            //ForeignKey
            builder.HasOne(x => x.Usuario).WithMany().HasForeignKey("IdUsuario");
            //Propriedades
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).HasMaxLength(50).IsRequired();
            builder.Property(x => x.UrlLogo).HasMaxLength(255).IsRequired();
        }
    }
}
