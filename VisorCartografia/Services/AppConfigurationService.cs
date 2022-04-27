using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using VisorCartografia.Models;
using VisorCartografia.Services.Interfaces;

namespace VisorCartografia.Services
{
    public class AppConfigurationService:IAppConfigurarionService
    {
        public AppConfiguration ObtenConfiguracion(string ruta)
        {
            try 
            { 
            string rootPath = ruta;
            string rutaC = rootPath + "\\config.app";

            StreamReader lector = new StreamReader(rutaC);
            string linea;
            Dictionary<string, string> ficheros = new Dictionary<string, string>();
            string app = ConfigurationManager.AppSettings.AllKeys.Contains("AppId") ? ConfigurationManager.AppSettings["AppId"].ToString() : null;
            string key = ConfigurationManager.AppSettings.AllKeys.Contains("AppSecret") ? ConfigurationManager.AppSettings["AppSecret"].ToString() : null;
            string refresh_token = ConfigurationManager.AppSettings.AllKeys.Contains("AppToken") ? ConfigurationManager.AppSettings["AppToken"].ToString() : null;
            int lineaAct = 0;
            while ((linea = lector.ReadLine()) != null)
            {
                if (linea != null && linea.Length > 0 && linea.IndexOf(',') != -1 && lineaAct != 0)
                {
                    string[] inf = linea.Split(',');
                    ficheros.Add(inf[0], inf[1]);
                }
                lineaAct++;
            }

            if (app != null && key != null && refresh_token != null && ficheros.Count > 0)
            {

                return new AppConfiguration
                {
                    App = app,
                    Key = key,
                    RefreshToken = refresh_token,
                    Files = ficheros
                };
            }
            else
                return null;

            }
            catch
            {
                return null;
            }

        }



    }
}
