using BusinessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer
{
    public class GenreContext : IDB<Genre, int>
    {
        private GamesDbContext _context;

        public GenreContext(GamesDbContext context)
        {
            _context = context;
        }

        public void Create(Genre item)
        {
            try
            {
                _context.Genres.Add(item);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(int id)
        {
            try
            {
                _context.Genres.Remove(Read(id));
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Genre Read(int key, bool noTracking = false, bool useNavigationProperties = false)
        {
            try
            {
                IQueryable<Genre> query = _context.Genres;

                if (noTracking)
                {
                    query = query.AsNoTrackingWithIdentityResolution();
                }

                if (useNavigationProperties)
                {
                    query = query.Include(g => g.Users);
                }

                return query.SingleOrDefault(g => g.ID == key);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Genre> ReadAll(bool useNavigationProperties = false)
        {
            try
            {
                IQueryable<Genre> query = _context.Genres.AsNoTracking();

                if (useNavigationProperties)
                {
                    query = query.Include(g => g.Users);
                }

                return query.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(Genre item, bool useNavigationProperties = false)
        {
            try
            {
                Genre genreFrom = Read(item.ID);

                _context.Entry(genreFrom).CurrentValues.SetValues(item);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
