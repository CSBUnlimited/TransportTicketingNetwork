using AutoMapper;

namespace Modules.Main.Common.Configurations
{
    public class AutoMapperProfileConfiguration : Profile
    {
        public AutoMapperProfileConfiguration()
        {
            CreateMapsModelsToViewModels();
            CreateMapViewModelsToModels();
        }

        private void CreateMapsModelsToViewModels()
        {
            
        }

        private void CreateMapViewModelsToModels()
        {
            
        }
    }
}
