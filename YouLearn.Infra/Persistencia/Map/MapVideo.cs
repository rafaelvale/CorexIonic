﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using YouLearn.Domain.Entities;

namespace YouLearn.Infra.Persistencia.Map
{
    public class MapVideo : IEntityTypeConfiguration<Video>
    {
        public void Configure(EntityTypeBuilder<Video> builder)
        {
            builder.ToTable("Video");
            //ForeignKey
            builder.HasOne(x => x.UsuarioSugerido).WithMany().HasForeignKey("IsUsuario");
            builder.HasOne(x => x.Canal).WithMany().HasForeignKey("IdCanal");
            builder.HasOne(x => x.PlayList).WithMany().HasForeignKey("IdPlayList");

            //Propriedades
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Titulo).HasMaxLength(200).IsRequired();
            builder.Property(x => x.Descricao).HasMaxLength(255).IsRequired();
            builder.Property(x => x.Tags).HasMaxLength(100).IsRequired();
            builder.Property(x => x.OrdemNaPlayList);
            //builder.Property(x => x.UrlLogo).HasMaxLength(200).IsRequired();
            builder.Property(x => x.IdVideo).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Status).IsRequired();


        }
    }
}
