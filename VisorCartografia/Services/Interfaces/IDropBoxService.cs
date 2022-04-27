using System.Collections.Generic;
using System.Threading.Tasks;

namespace VisorCartografia.Services.Interfaces
{
    public interface IDropBoxService
    {
        Task<Dictionary<string, string>> ListaDirectorios();
        Task<string> DescargarFichero(string fileName, string path);
        Task<Dictionary<string, string>> ListaFicheros(string folder, string filter = "");
    }
}
