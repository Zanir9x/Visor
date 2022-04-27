using VisorCartografia.Models;

namespace VisorCartografia.Services.Interfaces
{
    public interface IAppConfigurarionService
    {
        AppConfiguration ObtenConfiguracion(string ruta);
    }
}
