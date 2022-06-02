using GodelTourAgensy.BLL.Interfaces;
using GodelTourAgensy.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System.Linq;
using X.PagedList;
using AutoMapper;
using GodelTourAgensy.BLL.Models;
using GodelTourAgensy.Models;
using Microsoft.AspNetCore.Authorization;
using GodelTourAgensy.Web.Identity;

namespace GodelTourAgensy.Web.Controllers
{
    /// <summary>
    /// Ralization class-controller AdditionalServiceController
    /// </summary>
    [Authorize(Roles = Roles.Admin)]
    public class ClientController : Controller
    {
        private readonly IMapper _mapper;

        private readonly IClientsService _clientsService;

        /// <summary>
        /// Realization user constructor
        /// </summary>
        /// <param name="context"></param>
        public ClientController(IClientsService clientsService, IMapper mapper)
        {
            _mapper = mapper;
            _clientsService = clientsService;
        }

        /// <summary>
        /// Method Delete
        /// </summary>
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var item = _clientsService.GetById(id);
            if (item == null)
            {
                RedirectToAction(nameof(Index));
            }
            return View(item);
        }

        [HttpPost]
        public IActionResult Delete(ClientEntity item)
        {
            _clientsService.Delete(item);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ClientEntity item)
        {
            var checkResult = _clientsService.Check(item);
            if (checkResult == null)
            {
                _clientsService.Create(item);
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction("ErrorIndex", "Home", new RouteValueDictionary{{ "RequestId", checkResult }});
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var item = _clientsService.GetById(id);
            if (item == null)
            {
                RedirectToAction(nameof(Index));
            }

            return View(item);
        }

        [HttpPost]
        public IActionResult Update(ClientEntity item)
        {
            var checkResult = _clientsService.Check(item);
            if (checkResult == null)
            {
                _clientsService.Update(item);
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction("ErrorIndex", "Home", new RouteValueDictionary{{"RequestId", checkResult}});}

        [HttpGet]
        public IActionResult Index(int? page)
        {
            var cleientsDtos = _clientsService.Get();

            var clientViewModels = cleientsDtos.Select(_mapper.Map<ClientModel, ClientViewModel>);

            var pageSize = 5;
            var pageNumber = (page ?? 1);

            return View(clientViewModels.ToPagedList(pageNumber, pageSize));
        }

        [HttpPost]
        public IActionResult Index(string search)
        {
            return View(_clientsService.Get(search));
        }
    }
}
    
