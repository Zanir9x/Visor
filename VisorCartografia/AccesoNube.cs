using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using VisorCartografia.Services;
using VisorCartografia.Services.Interfaces;

namespace VisorCartografia
{
    public partial class AccesoNube : Form
    {
        private string archivoActual;
        private Dictionary<string, string> archivos;
        private Timer ejecucion;
        private IDropBoxService _dropBoxService;

        private void Ejecuta(EventHandler m)
        {
            ejecucion=new Timer();
            ejecucion.Interval = 1;
            ejecucion.Tick += new EventHandler(m);
            ejecucion.Start();
        }

        public AccesoNube()
        {
            InitializeComponent();
        }



          

        private void Execute(string fileName, ProgressBar progress)
        {

                string path = Path.GetTempPath() + "temp" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".kmz";
                archivoActual = path;

                progress.Visible = true;
                progress.Style = ProgressBarStyle.Marquee;

                string ficheroDescarga = "/" + fileName;
                var ficheroObtenido=_dropBoxService.DescargarFichero(ficheroDescarga,path);

                Ejecuta((object s, EventArgs ev) => {

                    if (ficheroObtenido.IsCompleted)
                    {
                        ejecucion.Stop();
                        if (ficheroObtenido.Result != null)
                        {
                            progress.Style = ProgressBarStyle.Continuous;
                            progress.Visible = false;
                            if (Registry.ClassesRoot.OpenSubKey(".kmz", false) != null)
                            {
                                var p = new Process();
                                p.StartInfo = new ProcessStartInfo(ficheroObtenido.Result.ToString())
                                {
                                    UseShellExecute = true
                                };
                                p.Start();
                            }
                            else
                                MessageBox.Show(null, "no se encuentra google earth instalado o no se asociado con la extension kmz".ToUpper(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show(null, "no se pudo obtener el archivo solicitado".ToUpper(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                   
                });              
        }



        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
                if (File.Exists(archivoActual))
                {
                    try
                    {
                        File.Delete(archivoActual);
                    }
                    catch
                    {
                        MessageBox.Show(null, "NO SE PUDO BORRAR EL ARCHIVO TEMPORAL OBTENIDO", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var appConfig= new AppConfigurationService();
            var config = appConfig.ObtenConfiguracion(Application.StartupPath);

            if (config != null)
            {
                _dropBoxService = new DropBoxService(config.App, config.Key, config.RefreshToken);
                        if (config.Files.Count > 0)
                        {
                            archivos =config.Files;
                            foreach (KeyValuePair<string, string> elemento in config.Files)
                            {
                                listaArchivos.Items.Add(elemento.Key);
                            }
                        }
                        else
                        {
                            if(MessageBox.Show(null, "NO SE ENCONTRO INFORMACIÓN QUE VISUALIZAR", "", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                            Dispose();
                        }  
            }
            else
            {
                if(MessageBox.Show(null, "NO SE ENCONTRO EL ARCHIVO DE CONFIGURACIÓN", "", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                Dispose();
            }
        }

     

        private void listaArchivos_DoubleClick(object sender, EventArgs e)
        {
            if(listaArchivos.SelectedItem != null)
            {
                Execute(archivos[listaArchivos.SelectedItem.ToString()], progresoCarga);
            }
        }

    
    }
    }

