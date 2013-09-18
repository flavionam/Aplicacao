using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace DAL
{
    public class Contexto:DbContext
    {
        public DbSet<Usuario> Usuario { get; set; }

        public Contexto()
        {
            this.Database.CreateIfNotExists();
        }
    }
}
