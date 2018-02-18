using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Topical_Humlinski.Models;

namespace Topical_Humlinski.DAL
{
    public interface IGameRepository
    {
        IEnumerable<Game> SelectAll();
        Game SelectOne(int id);
        void Insert(Game game);
        void Update(Game game);
        void Delete(int id);
    }
}