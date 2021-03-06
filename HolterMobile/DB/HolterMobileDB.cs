﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using HolterMobile.Models;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core.Objects;
using System.Data.SqlClient;
using System.Data;

namespace HolterMobile.DB
{
    public class HolterMobileDB : DbContext
    {
        public DbSet<Perfil> perfil { get; set; }
        public DbSet<Usuario> usuario { get; set; }
        public DbSet<Login> login { get; set; }
        public DbSet<Endereco> endereco { get; set; }
        public DbSet<LogAcesso> logAcesso { get; set; }
        public DbSet<Aparelho> aparelho { get; set; }
        public DbSet<Monitoramento> monitoramento { get; set; }
        public DbSet<PacienteMedico> pacienteMedico { get; set; }
        public DbSet<Atividade> atividades { get; set; }
        public DbSet<Responsaveis> responsaveis { get; set; }
        public DbSet<Chat> chat { get; set; }
        public DbSet<TempPress> tempPress { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
  
        }
    }
}