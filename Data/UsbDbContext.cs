using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using usb.Model;

namespace usb.Data
{
    public class UsbDbContext : DbContext
    {
        public DbSet<UsbDevice> UsbDevices { get; set; }

        public UsbDbContext() : base("name=UsbDbContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsbDevice>().ToTable("UsbDevices");
        }
    }
}
