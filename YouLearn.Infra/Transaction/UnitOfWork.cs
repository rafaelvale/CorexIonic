﻿using System;
using System.Collections.Generic;
using System.Text;
using YouLearn.Infra.Persistencia.EF;

namespace YouLearn.Infra.Transaction
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly YouLearnContext _context;

        public UnitOfWork(YouLearnContext  context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
