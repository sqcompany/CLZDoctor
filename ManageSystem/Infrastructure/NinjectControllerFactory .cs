using System;
using System.Web.Mvc;
using System.Web.Routing;
using CLZDoctor.Domain;
using Ninject;

// ReSharper disable once CheckNamespace
namespace ManageSystem
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private readonly IKernel _ninjectKernel;
        public NinjectControllerFactory()
        {
            _ninjectKernel = new StandardKernel();
            AddBindings();
        }
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null
                ? null
                : (IController)_ninjectKernel.Get(controllerType);
        }

        private void AddBindings()
        {
            _ninjectKernel.Bind<IPrescriptionCore>().To<PrescriptionCore>();
            _ninjectKernel.Bind<IPrescriptTypeCore>().To<PrescriptTypeCore>();
            _ninjectKernel.Bind<IMedicalCore>().To<MedicalCore>();
        }
    }
}