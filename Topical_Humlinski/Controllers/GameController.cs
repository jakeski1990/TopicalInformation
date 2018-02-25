using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Topical_Humlinski.DAL;
using Topical_Humlinski.Models;
using PagedList;

namespace Topical_Humlinski.Controllers
{
    public class GameController : Controller
    {
        [HttpGet]
        public ActionResult Index(string sortOrder)//, int? page)
        {
            //Instantiate Repository
            GameRepository gameRepository = new GameRepository();

            ViewBag.Platforms = ListOfPlatforms();

            IEnumerable<Game> games;
            using (gameRepository)
            {
                games = gameRepository.SelectAll() as IList<Game>;
                
            }

            IOrderedEnumerable<Game> sortedGames;

            //Sort function
            switch (sortOrder)
            {
                case "Name":
                    sortedGames = games.OrderBy(g => g.Name);
                    break;
                case "Price":
                    sortedGames = games.OrderBy(g => g.Price);
                    break;
                default:
                    sortedGames = games.OrderBy(g => g.Id);
                    break;
            }

            //int pageSize = 5;
            //int pageNumber = (page ?? 1);
            //games = games.ToPagedList(pageNumber, pageSize);

            return View(sortedGames);
        }


        [HttpPost]
        public ActionResult Index(string searchCriteria, string platformFilter) //, int? page)
        {
            //Instantiate Repository
            GameRepository gameRepository = new GameRepository();

            ViewBag.Platforms = ListOfPlatforms();

            IEnumerable<Game> games;
            using (gameRepository)
            {
                games = gameRepository.SelectAll() as IList<Game>;

            }

            //Search function
            if (searchCriteria != null)
            {
                games = games.Where(g => g.Name.ToUpper().Contains(searchCriteria.ToUpper()));
            }

            //Filter function
            if (platformFilter != "" || platformFilter == null)
            {
                games = games.Where(g => g.Platform == platformFilter);
            }

            //int pageSize = 5;
            //int pageNumber = (page ?? 1);
            //games = games.ToPagedList(pageNumber, pageSize);

            return View(games);
        }

        // GET: Game/Details/5
        public ActionResult Details(int id)
        {
            //Instantiate Repository
            GameRepository gameRepository = new GameRepository();
            Game game = new Game();

            //Get a game with matching id
            using (gameRepository)
            {
                game = gameRepository.SelectOne(id);
            }

                return View(game);
        }

        // GET: Game/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Game/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Game/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Game/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Game/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Game/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [NonAction]
        private IEnumerable<string> ListOfPlatforms()
        {
            //Instantiate Repository
            GameRepository gameRepository = new GameRepository();

            IEnumerable<Game> games;
            using (gameRepository)
            {
                games = gameRepository.SelectAll() as IList<Game>;
            }

            var platforms = games.Select(g => g.Platform).Distinct().OrderBy(x => x);

            return platforms;

        }

        

    }
}
