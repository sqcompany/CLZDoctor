using System.Collections.Generic;
using System.Linq;
using CLZDoctor.Entities;
using Ninject;

// ReSharper disable once CheckNamespace
namespace CLZDoctor.Domain
{
    public class PrescriptTypeCore : IPrescriptTypeCore
    {
        private readonly static IKernel Kernel = new StandardKernel(new DomainModule());
        public List<PrescripType> Insert(List<PrescripType> list)
        {
            var conficts = new List<PrescripType>();
            foreach (var prescripType in list)
            {
                try
                {
                    Kernel.Get<IPrescripTypeRepo>().Insert(prescripType);
                }
                catch
                {
                    conficts.Add(prescripType);
                }
            }
            return conficts;
        }

        public int Insert(PrescripType prescrip)
        {
            return Kernel.Get<IPrescripTypeRepo>().Insert(prescrip);
        }

        public List<PrescripType> SelectPrescripTypes()
        {
            return Kernel.Get<IPrescripTypeRepo>().SelectPrescripTypes().ToList();
        }

        public PrescripType SelectPrescripType(int id)
        {
            return Kernel.Get<IPrescripTypeRepo>().SelectPrescripType(id);
        }

        public bool Update(PrescripType prescrip)
        {
            return Kernel.Get<IPrescripTypeRepo>().Update(prescrip);
        }
    }
}
