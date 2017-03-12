using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GameSharpApi.Commands;
using GameSharpApi.Queries;
using MediatR;
using System.Threading.Tasks;

namespace MyFirstApp.Controllers
{
    public class GamesController : Controller
    {
        private readonly ILogger Logger;
        private readonly IMediator IMediator;

        public GamesController(ILogger<GamesController> logger, IMediator iMediator)
        {
            Logger = logger;
            IMediator = iMediator;
        }

        public async Task<IActionResult> Index()
        {
            var games = await IMediator.Send(new GetAllGamesQuery());
            return View(games);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var game = await IMediator.Send(new GetGameByIdQuery(id));
            return View(game);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DoEdit(EditGameCmd cmd, Guid id)
        {
            await IMediator.Send(cmd);
            return RedirectToAction("Details", new { id = id });
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var game = await IMediator.Send(new GetGameByIdQuery(id));
            return View(game);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var game = await IMediator.Send(new GetGameByIdQuery(id));
            return View(game);
        }

        [HttpPost]
        public async Task<IActionResult> DoDelete(DeleteGameCmd cmd)
        {
            await IMediator.Send(cmd);
            return RedirectToAction("Index");
        }

    }
}
