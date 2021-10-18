using Lekadex.Core;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Lekadex.Controllers
{
    public class PrescriptionController : Controller
    {
        private readonly IDoctorManager mDoctorManager;
        private readonly ViewModelMapper mViewModelMapper;
        public PrescriptionController(IDoctorManager doctorManager, ViewModelMapper viewModelMapper)
        {
            mDoctorManager = doctorManager;
            mViewModelMapper = viewModelMapper;
        }

        public IActionResult Index(int doctorId, string filterString)
        {
            TempData["DoctorId "] = doctorId;

            var doctorDto = mDoctorManager.GetAllDoctors(null)
                                          .FirstOrDefault(x => x.Id == doctorId);
            var prescriptionDtos = mDoctorManager.GetAllPrescriptionForADoctor(doctorId, filterString);

            var doctorViewModel = mViewModelMapper.Map(doctorDto);
            doctorViewModel.Prescriptions = mViewModelMapper.Map(prescriptionDtos);

            return View(doctorViewModel);
        }
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(PrescriptionViewModel prescriptionVm)
        {
            var dto = mViewModelMapper.Map(prescriptionVm);
            mDoctorManager.AddNewPrescription(dto, int.Parse(TempData["DoctorId "].ToString()));
            return RedirectToAction("Index", new { doctorId = int.Parse(TempData["DoctorId "].ToString()) });
        }
        public IActionResult View (int prescriptionId)
        {
            return RedirectToAction("Index", "Medicine", new { doctorId = int.Parse(TempData["DoctorId "].ToString()), prescriptionId = prescriptionId });
        }

        public IActionResult Delete(int prescriptionId)
        {
            mDoctorManager.DeletePrescription(new PrescriptionDto { Id = prescriptionId });
            return RedirectToAction("Index", new { doctorId = int.Parse(TempData["DoctorId "].ToString()) });
        }
    }
}