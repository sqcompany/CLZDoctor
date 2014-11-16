using System;
using System.Collections.Generic;
using Ninject;

namespace CLZDoctor.Domain
{
    public class MedicalCore:IMedicalCore
    {
        private readonly static IKernel Kernel = new StandardKernel(new DomainModule());
        public int Insert(Entities.Medical medical)
        {
            return Kernel.Get<IMedicalRepo>().Insert(medical);
        }

        public IEnumerable<Entities.Medical> SelectMedicals()
        {
            return Kernel.Get<IMedicalRepo>().SelectMedicals();
        }

        public IEnumerable<Entities.Medical> SelectMedicals(int take, int skip,out int count)
        {
            count = Kernel.Get<IMedicalRepo>().Size();
            return Kernel.Get<IMedicalRepo>().SelectMedicals(take, skip);
        }

        public bool Update(int id, int isVisit)
        {
            return Kernel.Get<IMedicalRepo>().Update(id, isVisit);
        }
    }
}
