using CLZDoctor.Domain;
using Ninject.Modules;

// ReSharper disable once CheckNamespace
namespace GrabData.Domain
{
    public class DomainModule:NinjectModule
    {

        public override void Load()
        {
            Bind<IPrescriptionCore>().To<PrescriptionCore>();
            Bind<IGrabDataCore>().To<GrabDataCore>();
            Bind<IGrabDataRepo>().To<GrabDataRepo>();
        }
    }
}
