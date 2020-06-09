using Capsules.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capsules.Services
{
    public class Repo : DbContext, IDataStore<Capsule>
    {
        private string _dbPath;
        public Repo(string dbPath)
        {
            _dbPath = dbPath;
            Database.EnsureCreated();
        }
        public DbSet<Capsule> Capsules { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={_dbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Capsule>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Capsule>()
                .Property(c => c.IsDraft)
                .IsRequired();
#if DEBUG
            modelBuilder.Entity<Capsule>()
                .HasData(
                    new Capsule { Id = Guid.NewGuid().ToString(), Title = "Title 1", Description = "Description 1", Due = new DateTime(2020, 12, 12) },
                    new Capsule { Id = Guid.NewGuid().ToString(), Title = "Title 2", Description = "Description 2", Due = new DateTime(2020, 12, 23) },
                    new Capsule { Id = Guid.NewGuid().ToString(), Title = "Title 3", Description = "Description 3", Due = new DateTime(2020, 12, 31) }
                );
#endif
        }

        #region IDataStore methods
        async Task<bool> IDataStore<Capsule>.AddItemAsync(Capsule item)
        {
            await Capsules.AddAsync(item).ConfigureAwait(false);
            try
            {
                await SaveChangesAsync().ConfigureAwait(false);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        async Task<bool> IDataStore<Capsule>.DeleteItemAsync(string id)
        {
            var capsule = await Capsules.FindAsync(id).ConfigureAwait(false);
            if (capsule == null)
                return false;
            Capsules.Remove(capsule);
            try
            {
                await SaveChangesAsync().ConfigureAwait(false);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }


        async Task<Capsule> IDataStore<Capsule>.GetItemAsync(string id)
        {
            // return null if no item with the specific id existed in database
            return await Capsules.FindAsync(id).ConfigureAwait(false);
        }

        async Task<IEnumerable<Capsule>> IDataStore<Capsule>.GetItemsAsync(bool forceRefresh = false)
        {
            // ignore force refresh for now
            return await Capsules.ToListAsync().ConfigureAwait(false);
        }

        async Task<bool> IDataStore<Capsule>.UpdateItemAsync(Capsule item)
        {
            Capsules.Update(item);
            try
            {
                await SaveChangesAsync().ConfigureAwait(false);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        #endregion

    }
}
