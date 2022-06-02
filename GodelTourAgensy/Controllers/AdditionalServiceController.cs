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
    /// <summary>
    /// Ralization class-controller AdditionalServiceController
    /// </summary>
    public class AdditionalServiceController : Controller
    {
        private readonly IMapper _mapper;

        private readonly IAdditionalsService _additionalsService;

        /// <summary>
        /// Realization user constructor
        /// </summary>
        /// <param name="context"></param>
        public AdditionalServiceController(IAdditionalsService additionalsService, IMapper mapper)
        {
            _mapper = mapper;
            _additionalsService = additionalsService;
        }

        /// <summary>
        /// Method Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var item = _additionalsService.GetById(id);

            if (item == null)
            {
                RedirectToAction(nameof(Index));
            }
            return View(item);
        }

        [HttpPost]
        public IActionResult Delete(AdditionalServiceEntity item)
        {
            try
            {
                _additionalsService.Delete(item);
            }
            catch
            {

            }
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Realization Method Create
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(AdditionalServiceEntity item)
        {
            var checkResult = _additionalsService.Check(item);
            if (checkResult == null)
            {
                _additionalsService.Create(item);
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction("ErrorIndex", "Home", new RouteValueDictionary
            {
                { "RequestId", checkResult }
            });
        }

        /// <summary>
        /// Realiation Method Update 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Update(int id)
        {
            var item = _additionalsService.GetById(id);
            if (item == null)
            {
                RedirectToAction(nameof(Index));
            }

            return View(item);
        }

        [HttpPost]
        public IActionResult Update(AdditionalServiceEntity item)
        {
            var checkResult = _additionalsService.Check(item);

            if (checkResult == null)
            {
                _additionalsService.Update(item);
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction("ErrorIndex", "Home", new RouteValueDictionary
            {
                { "RequestId", checkResult }
            });
        }

        /// <summary>
        /// Realization method Index for using search in program
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index(int? page)
        {
            var additionalServiceDtos = _additionalsService.Get();

            var additionalServiceViewModels = additionalServiceDtos.Select(_mapper.Map<AdditionalServiceModel, AdditionalServiceViewModel>);

            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(additionalServiceViewModels.ToPagedList(pageNumber, pageSize));
        }

        [HttpPost]
        public IActionResult Index(string search)
        {
            return View(_additionalsService.Get(search));
        }
    }
}
