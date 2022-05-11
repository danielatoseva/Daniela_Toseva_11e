using BusinessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer
{
    class GameContext : IDB<Game, int>
    {
        private GamesDbContext _context;

        public GameContext(GamesDbContext context)
        {
            _context = context;
        }

        public void Create(Game item)
        {
            try
            {
                _context.Games.Add(item);
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
                _context.Games.Remove(Read(id));
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
        public Game Read(int key, bool noTracking = false, bool useNavigationProperties = false)
        {
            try
            {
                IQueryable<Game> query = _context.Games;

                if (noTracking)
                {
                    query = query.AsNoTrackingWithIdentityResolution();
                }

                if (useNavigationProperties)
                {
                    query = query.Include(g => g.Users).Include(g => g.Genres);
                }

                return query.SingleOrDefault(g => g.ID == key);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Game> ReadAll(bool useNavigationProperties = false)
        {
            try
            {
                IQueryable<Game> query = _context.Games.AsNoTracking();

                if (useNavigationProperties)
                {
                    query = query.Include(g => g.Users).Include(g => g.Genres);
                }

                return query.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(Game item, bool useNavigationProperties = false)
        {
            try
            {
                Game gameFromDB = Read(item.ID, useNavigationProperties);

                if (useNavigationProperties)
                {
                    List<User> users = new List<User>();

                    foreach(User user in item.Users)
                    {
                        User userFromDB = _context.Users.Find(user.ID);

                        if (userFromDB != null)
                        {
                            users.Add(userFromDB);
                        }
                        else
                        {
                            users.Add(user);
                        }
                    }
                    gameFromDB.Users = users;

                    List<Genre> genres = new List<Genre>();

                    foreach (Genre genre in item.Genres)
                    {
                        Genre genreFromDB = _context.Genres.Find(genre.ID);

                        if (genreFromDB != null)
                        {
                            genres.Add(genreFromDB);
                        }
                        else
                        {
                            genres.Add(genre);
                        }
                    }

                    gameFromDB.Genres = genres;
                }

                _context.Entry(gameFromDB).CurrentValues.SetValues(item);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
