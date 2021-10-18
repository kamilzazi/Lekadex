using AutoMapper;
using Lekadex.Core;
using Lekadex.Database.Entities;
using System.Collections.Generic;

namespace Lekadex
{
    public class ViewModelMapper
    {
        private IMapper mMapper;
        public ViewModelMapper()
        {
            mMapper = new MapperConfiguration(config =>
            {
                config.CreateMap<MedicineDto, MedicineViewModel>()
                .ReverseMap();
                config.CreateMap<PrescriptionDto, PrescriptionViewModel>()
                .ReverseMap();
                config.CreateMap<DoctorDto, DoctorViewModel>()
                .ReverseMap();
            }).CreateMapper();
        }

        #region Medicine Maps
        public MedicineViewModel Map(MedicineDto medicine) => mMapper.Map<MedicineViewModel>(medicine);
        public List<MedicineViewModel> Map(List<MedicineDto> medicines) => mMapper.Map<List<MedicineViewModel>>(medicines);

        public MedicineDto Map(MedicineViewModel medicine) => mMapper.Map<MedicineDto>(medicine);
        public List<MedicineDto> Map(List<MedicineViewModel> medicines) => mMapper.Map<List<MedicineDto>>(medicines);
        #endregion


        #region Prescription Maps
        public PrescriptionViewModel Map(PrescriptionDto prescription) => mMapper.Map<PrescriptionViewModel>(prescription);
        public List<PrescriptionViewModel> Map(List<PrescriptionDto> prescriptions) => mMapper.Map<List<PrescriptionViewModel>>(prescriptions);

        public PrescriptionDto Map(PrescriptionViewModel prescription) => mMapper.Map<PrescriptionDto>(prescription);
        public List<PrescriptionDto> Map(List<PrescriptionViewModel> prescriptions) => mMapper.Map<List<PrescriptionDto>>(prescriptions);
        #endregion


        #region Doctor Maps
        public DoctorViewModel Map(DoctorDto doctor) => mMapper.Map<DoctorViewModel>(doctor);
        public List<DoctorViewModel> Map(List<DoctorDto> doctors) => mMapper.Map<List<DoctorViewModel>>(doctors);

        public DoctorDto Map(DoctorViewModel doctor) => mMapper.Map<DoctorDto>(doctor);
        public List<DoctorDto> Map(List<DoctorViewModel> doctors) => mMapper.Map<List<DoctorDto>>(doctors);
        #endregion

    }
}
