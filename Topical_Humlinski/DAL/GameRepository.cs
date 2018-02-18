using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Topical_Humlinski.Models;

namespace Topical_Humlinski.DAL
{
    public class GameRepository : IGameRepository, IDisposable
    {
        private List<Game> _games;

        public GameRepository()
        {
            GameXmlDataServices gameXmlDataService = new GameXmlDataServices();

            using (gameXmlDataService)
            {
                _games = gameXmlDataService.Read() as List<Game>;
            }
        }

        public IEnumerable<Game> SelectAll()
        {
            return _games;
        }

        public Game SelectOne(int id)
        {
            //Game selectedGame =
            //(from game in _games
            // where game.Id == id
            // select game).FirstOrDefault();

            Game selectedGame = _games.Where(p => p.Id == id).FirstOrDefault();

            return selectedGame;
        }

        public void Insert(Game game)
        {
            game.Id = NextIdValue();
            _games.Add(game);

            Save();
        }

        private int NextIdValue()
        {
            int currentMaxId = _games.OrderByDescending(b => b.Id).FirstOrDefault().Id;
            return currentMaxId + 1;
        }

        public void Update(Game UpdateGame)
        {
            var oldGame = _games.Where(b => b.Id == UpdateGame.Id).FirstOrDefault();

            if (oldGame != null)
            {
                _games.Remove(oldGame);
                _games.Add(UpdateGame);
            }

            Save();
        }
        public void Delete(int id)
        {
            var game = _games.Where(b => b.Id == id).FirstOrDefault();

            if (game != null)
            {
                _games.Remove(game);
            }

            Save();
        }

        public void Save()
        {
            GameXmlDataServices gameXmlDataService = new GameXmlDataServices();

            using (gameXmlDataService)
            {
                gameXmlDataService.Write(_games);
            }
        }

        public void Dispose()
        {
            _games = null;
        }


    }
}