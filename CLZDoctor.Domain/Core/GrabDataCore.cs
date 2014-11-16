using System.Collections.Generic;
using Ninject;
using CLZDoctor.Entities;

namespace CLZDoctor.Domain
{
    public class GrabDataCore : IGrabDataCore
    {
        private readonly static IKernel Kernel = new StandardKernel(new DomainModule());
        public int Add(GrabData grabData)
        {
            return Kernel.Get<IGrabDataRepo>().Add(grabData);
        }

        public IEnumerable<GrabData> Select()
        {
            return Kernel.Get<IGrabDataRepo>().Select();
        }
    }
}
