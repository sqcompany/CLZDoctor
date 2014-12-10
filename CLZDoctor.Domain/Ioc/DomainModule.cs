using Ninject.Modules;

// ReSharper disable once CheckNamespace
namespace CLZDoctor.Domain
{
    public class DomainModule:NinjectModule
    {

        public override void Load()
        {
            Bind<IBaseRepo>().To<SqlBaseRepo>();

            Bind<IPrescriptionRepo>().To<PrescriptionRepo>();
            Bind<IMaterialsRepo>().To<MaterialsRepo>();
            Bind<IRecipeRepo>().To<RecipeRepo>();
            Bind<IPrescripTypeRepo>().To<PrescripTypeRepo>();
            Bind<IGrabDataRepo>().To<GrabDataRepo>();
            Bind<IMedicalRepo>().To<MedicalRepo>();
            Bind<IFavoriteRepo>().To<FavoriteRepo>();
            Bind<IAccountRepo>().To<AccountRepo>();
        }
    }
}
