using GodelTourAgensy.BLL.Models;
using GodelTourAgensy.BLL.Interfaces;
using GodelTourAgensy.DAL;
using GodelTourAgensy.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System.Collections.Generic;
using System.Linq;
using X.PagedList;
using GodelTourAgensy.DAL.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using GodelTourAgensy.Web.Identity;

namespace GodelTourAgensy.Web.Controllers
{
    public class TravelPackageController : Controller
    {
        private readonly IPackagesService _packagesService;

        private readonly IAdditionalsService _additionalServices;

        private readonly GodelTourAgensyContext _db;

        private static readonly Dictionary<int, OnPackageCreatingViewModel> data = new();

        private readonly IMapper _mapper;


        public TravelPackageController(GodelTourAgensyContext context, IPackagesService packagesService, IAdditionalsService additionalServices, IMapper mapper)
        {
            _db = context;
            _packagesService = packagesService;
            _additionalServices = additionalServices;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AddProduct(OnPackageCreatingViewModel curService, byte t)
        {
            data[curService.Value].Services.Add(
                _additionalServices.GetById(curService.CurrentService.Id));

            return RedirectToAction(nameof(Basket), new RouteValueDictionary
            {
                { "model", curService.Value },
                { "t", curService.Value }
            });
        }

        [HttpGet]
        public IActionResult AddProduct(int id)
        {
            ViewBag.Services = _db.AdditionalServiceEntitys.ToList();
            return View(data[id]);
        }

        [HttpGet]
        public IActionResult Basket(int model, int t)
        {
            if (!data.ContainsKey(model))
            {
                data.Add(data.Count + 1, new());
                data[data.Count].Value = data.Count;
                model = data.Count;
            }

            return View(data[model]);
        }

        [HttpPost]
        public IActionResult Basket(int id)
        {
            if (data[id].Services.Count == 0)
            {
                RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Create), new RouteValueDictionary
            {
                { "dataId", id }
            });
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TravelPackageEntity item)
        {
            var checkResult = _packagesService.Check(item);
            if (checkResult == null)
            {
                _packagesService.Create(item);
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction("ErrorIndex", "Home", new RouteValueDictionary
            {
                { "RequestId", checkResult }
            });
        }

        public IActionResult Delete(int id)
        {
            _packagesService.Delete(_packagesService.GetById(id));

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult CreatePackage(int id)
        {
            return View(new TravelPackageEntity() {RoomId = id });
        }

        [HttpPost]
        public IActionResult CreatePackage(TravelPackageEntity item)
        {
            var checkResult = _packagesService.Check(item);
            if (checkResult == null)
            {
                _packagesService.Create(item);
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction("ErrorIndex", "Home", new RouteValueDictionary
            {
                { "RequestId", checkResult }
            });
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpGet]
        public IActionResult Update(int id)
        {
            var item = _packagesService.GetById(id);
            if (item == null)
            {
                RedirectToAction(nameof(Index));
            }

            return View(item);
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpPost]
        public IActionResult Update(TravelPackageEntity item)
        {
            var checkResult = _packagesService.Check(item);
            if (checkResult == null)
            {
                _packagesService.Update(item);
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction("ErrorIndex", "Home", new RouteValueDictionary
            {
                { "RequestId", checkResult }
            });
        }
        public IActionResult IndexById()
        {
            var travelDtos = _packagesService.GetAllById(1);

            var travelViewModels = travelDtos.Select(_mapper.Map<TravelPackageModel, TravelPackageViewModel>);

            return View(travelViewModels.ToPagedList(1, 5));
        }

        public IActionResult Index(int? page)
        {
            var travelPacageDtos = _packagesService.Get();

            var travelViewModels = travelPacageDtos.Select(_mapper.Map<TravelPackageModel, TravelPackageViewModel>);

            var pageSize = 5;
            var pageNumber = (page ?? 1);

            return View(travelViewModels.ToPagedList(pageNumber, pageSize));
        }
    }
}
