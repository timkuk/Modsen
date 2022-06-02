using GodelTourAgensy.BLL.Models;
using GodelTourAgensy.BLL.Interfaces;
using GodelTourAgensy.DAL.Entities;
using GodelTourAgensy.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System.Linq;
using X.PagedList;
using AutoMapper;

namespace GodelTourAgensy.Web.Controllers
{
    public class RoomController : Controller
    {
        private readonly IMapper _mapper;

        private readonly IRoomsService _roomsService;

        /// <summary>
        /// Realization user constructor
        /// </summary>
        public RoomController(IRoomsService roomsService, IMapper mapper)
        {
            _roomsService = roomsService;
            _mapper = mapper;
        }

        /// <summary>
        /// Method Delete
        /// </summary>
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var item = _roomsService.GetById(id);
            if (item == null)
            {
                RedirectToAction(nameof(Index));
            }
            return View(item);
        }

        [HttpPost]
        public IActionResult Delete(RoomEntity item)
        {
            _roomsService.Delete(item);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(RoomEntity item)
        {
            var checkResult = _roomsService.Check(item);
            if (checkResult == null)
            {
                _roomsService.Create(item);
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction("ErrorIndex", "Home", new RouteValueDictionary
            {
                { "RequestId", checkResult }
            });
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var item = _roomsService.GetById(id);
            if (item == null)
            {
                RedirectToAction(nameof(Index));
            }

            return View(item);
        }

        [HttpPost]
        public IActionResult Update(RoomEntity item)
        {
            var checkResult = _roomsService.Check(item);
            if (checkResult == null)
            {
                _roomsService.Update(item);
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction("ErrorIndex", "Home", new RouteValueDictionary
            {
                { "RequestId", checkResult }
            });
        }

        [HttpGet]
        public IActionResult Index(int? page)
        {
            var roomDtos = _roomsService.Get();

            var roomViewModels = roomDtos.Select(_mapper.Map <RoomModel, RoomViewModel>);

            var pageSize = 5;
            var pageNumber = (page ?? 1);
            return View(roomViewModels.ToPagedList(pageNumber, pageSize));
        }

        [HttpPost]
        public IActionResult Index(string search)
        {
            return View(_roomsService.Get(search));
        }
    }
}

