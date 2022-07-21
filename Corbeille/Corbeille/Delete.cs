using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Corbeille
{
    internal class Delete
    {
        private string? path;
        private DateTime? date;
        private int compteur;
        private int nombreFichier;
        private int vitesse;
        public Delete()
        {
            path = string.Empty;
            compteur = 0;
            nombreFichier = 0;
            vitesse = 0;
        }

        public Delete(string? path, int nombreFichier, int vitesse )
        {
            this.path = path;
            this.nombreFichier = nombreFichier;
            this.vitesse = vitesse;
        }

        public void Launch()
        {
            GoCreate();
            GoDelete();
            Console.Clear();
            
        }

        private bool GoCreate()
        {
            compteur++;
            Thread.Sleep(vitesse);
            CreateFile(compteur);

            if (compteur < nombreFichier)
                return GoCreate();
            else
                return false;
            
        }

        private bool GoDelete()
        {
            compteur++;
            Thread.Sleep(vitesse);
            deleteFile();

            if (compteur < nombreFichier)
                return GoDelete();
            else
                return false;

        }
        private void CreateFile(int file)
        {
            string paths = path + "\\" +  file + ".txt";
            Directory.CreateDirectory(path + "\\" + file);
            string Text = "Hello, Hi, ByeBye";
            File.WriteAllText(paths, Text);
            Console.WriteLine($"Creation du fichier : {paths}\n");
        }

        private void deleteFile()
        {
            string[] files = Directory.GetFiles(path, "*");
            foreach (var file in files)
            {
                File.Delete(file);
                Directory.Delete(path + "\\", true);
                Console.Beep(500,vitesse);
                Console.WriteLine($"Suppression du fichier : {file}\n");
            }
        }
    }
}
