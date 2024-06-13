using AutoMapper;
using System.Reflection;

namespace HappyDo.ApplicationService.AutoMapperSettings.Settings
{
    public class AutoMapperFactoryConfiguration
    {
        public static IMapper? Mapper { get; private set; }
        private static MapperConfiguration? Configuration { get; set; }
        private static bool Initialized { get; set; }

        public static void Initialize()
        {
            if (!Initialized)
            {
                Configuration = new MapperConfiguration(config =>
                {
                    var profiles = Assembly
                        .GetExecutingAssembly()
                        .GetExportedTypes()
                        .Where(x => x.IsClass && typeof(Profile).IsAssignableFrom(x));

                    foreach (var profile in profiles)
                    {
                        config.AddProfile((Profile)Activator.CreateInstance(profile)!);
                    }
                });

                Initialized = true;
            }

            Mapper = Configuration!.CreateMapper();
        }
    }

}
