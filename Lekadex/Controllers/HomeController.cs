using Lekadex.Core;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Lekadex.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDoctorManager mDoctorManager;
        private readonly ViewModelMapper mViewModelMapper;
        //private int DoctorId { get; set; }
        public HomeController(IDoctorManager doctorManager, ViewModelMapper viewModelMapper)
        {
            mDoctorManager = doctorManager;
            mViewModelMapper = viewModelMapper;
        }

        public IActionResult Index(string filterString)
        {
            var doctorsDtos = mDoctorManager.GetAllDoctors(filterString);
            var doctorViewModel = mViewModelMapper.Map(doctorsDtos);
            return View(doctorViewModel);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(DoctorViewModel doctorVm)
        {
            var dto = mViewModelMapper.Map(doctorVm);
            mDoctorManager.AddNewDoctor(dto);

            return RedirectToAction("Index");
        }

        public IActionResult View(int doctorId)
        {
            TempData["DoctorId "] = doctorId;
            return RedirectToAction("Index", "Prescription", new { doctorId = int.Parse(TempData["DoctorId "].ToString()) });
        }

        public IActionResult Delete(int doctorId)
        {
            mDoctorManager.DeleteDoctor(new DoctorDto { Id = doctorId });
            var doctorsDtos = mDoctorManager.GetAllDoctors(null);
            var doctorViewModel = mViewModelMapper.Map(doctorsDtos);
            return View("Index", doctorViewModel);
        }
    }
}
