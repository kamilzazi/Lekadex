using AutoMapper;
using Lekadex.Database.Entities;
using System.Collections.Generic;

namespace Lekadex.Core
{
    public class DtoMapper
    {
        private IMapper mMapper;
        public DtoMapper()
        {
            mMapper = new MapperConfiguration(config =>
            {
                config.CreateMap<Medicine, MedicineDto>()
                .ForMember(x => x.PriceInTotal, opt => opt.MapFrom(y => y.Price * y.Amount))
                .ReverseMap();
                config.CreateMap<Prescription, PrescriptionDto>()
                .ReverseMap();
                config.CreateMap<Doctor, DoctorDto>()
                .ReverseMap();
            }).CreateMapper();
        }

        #region Medicine Maps
        public MedicineDto Map(Medicine medicine) => mMapper.Map<MedicineDto>(medicine);
        public List<MedicineDto> Map(List<Medicine> medicines) => mMapper.Map<List<MedicineDto>>(medicines);

        public Medicine Map(MedicineDto medicine) => mMapper.Map<Medicine>(medicine);
        public List<Medicine> Map(List<MedicineDto> medicines) => mMapper.Map<List<Medicine>>(medicines);
        #endregion


        #region Prescription Maps
        public PrescriptionDto Map(Prescription prescription) => mMapper.Map<PrescriptionDto>(prescription);
        public List<PrescriptionDto> Map(List<Prescription> prescriptions) => mMapper.Map<List<PrescriptionDto>>(prescriptions);

        public Prescription Map(PrescriptionDto prescription) => mMapper.Map<Prescription>(prescription);
        public List<Prescription> Map(List<PrescriptionDto> prescriptions) => mMapper.Map<List<Prescription>>(prescriptions);
        #endregion


        #region Doctor Maps
        public DoctorDto Map(Doctor doctor) => mMapper.Map<DoctorDto>(doctor);
        public List<DoctorDto> Map(List<Doctor> doctors) => mMapper.Map<List<DoctorDto>>(doctors);

        public Doctor Map(DoctorDto doctor) => mMapper.Map<Doctor>(doctor);
        public List<Doctor> Map(List<DoctorDto> doctors) => mMapper.Map<List<Doctor>>(doctors);
        #endregion

    }
}
