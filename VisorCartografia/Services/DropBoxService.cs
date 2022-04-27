using Dropbox.Api;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using VisorCartografia.Services.Interfaces;

namespace VisorCartografia.Services
{
    public class DropBoxService:IDropBoxService
    {
        private readonly DropboxClient _client;
        
        
        public DropBoxService(string app,string key,string refresh_token)
        {
            _client = ObtenCliente(app, key, refresh_token);
        }
       
        private string ObtenToken(string app,string key,string refresh_token)
        {
            try
            {
                var encoding = new UTF8Encoding();
                string url = $"https://api.dropbox.com";
                var client = new RestClient(url);
                var request = new RestRequest("oauth2/token", Method.Post);
                string auth = Convert.ToBase64String(encoding.GetBytes($"{app}:{key}"));
                request.AddHeader("Authorization", $"Basic {auth}");
                request.AddParameter("grant_type", "refresh_token");
                request.AddParameter("refresh_token", refresh_token);
                var result = client.ExecuteAsync(request).GetAwaiter().GetResult().Content;
                var objt = JsonConvert.DeserializeObject<Dictionary<string, string>>(result);
                return objt["access_token"];
            }
            catch
            {
                return null;
            }
        }

        private DropboxClient ObtenCliente(string app,string key,string code)
        {

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            string token = ObtenToken(app, key,code);
            if (token != null)
            {
                var client = new DropboxClient(token);

                return client;
            }
            else
                return null;
        }


        public async Task<Dictionary<string, string>> ListaDirectorios()
        {
            try
            {
                var rootFolder = await _client.Files.ListFolderAsync(string.Empty);
                Dictionary<string, string> dirs = new Dictionary<string, string>();
                foreach (var data in rootFolder.Entries.Where(w => w.IsFolder))
                {
                    dirs.Add(data.Name.Replace("_", " ").ToUpper(), data.Name);
                }
                return dirs;
            }
            catch
            {
                return null;
            }
        }

        public async Task<string> DescargarFichero(string fileName, string path)
        {   
            try
            {
                var downloaded = await _client.Files.DownloadAsync(fileName);
                FileStream fichero = File.Create(path);
                downloaded.GetContentAsStreamAsync().Result.CopyTo(fichero);
                fichero.Close();
                fichero.Dispose();
                return path;
            }
            catch
            {
                return null;
            }
        }


        public async Task<Dictionary<string, string>> ListaFicheros(string folder, string filter = "")
        {
            try
            {
                Dictionary<string, string> ficheros = new Dictionary<string, string>();
                var rootFolder = await _client.Files.ListFolderAsync("/" + folder + "/");

                foreach (var data in rootFolder.Entries.Where(w => w.IsFile))
                {
                    if (filter.Length == 0)
                    {
                        string fKey = data.Name.Replace("_", " ").ToLower();
                        fKey = fKey.Substring(0, fKey.IndexOf('.'));
                        ficheros.Add(fKey, data.Name);
                    }
                    else
                    {
                        string fKey = data.Name.Replace("_", " ").ToLower();
                        if (fKey.IndexOf(filter) != -1)
                        {
                            fKey = fKey.Substring(0, fKey.IndexOf('.'));
                            ficheros.Add(fKey, data.Name);
                        }
                    }

                }
                return ficheros;
            }
            catch
            {
                return null;
            }

        }


    }
}
