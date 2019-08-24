using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace BankAppSample
{
    class BankContext:DbContext
    {


        public BankContext()
        {

        }
        public DbSet<UserRegistration> UserRegistrations { get; set; }
        public DbSet<AccountHolderDetails> AccountHolderDetails { get; set; }
        public DbSet<UserTransactions> UserTransaction { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"data source=DESKTOP-T5OH97U\SQLEXPRESS;initial catalog=BankDatabase;User ID=sa;Password=123456");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        }
       
    }

}
