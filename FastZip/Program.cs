using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;

namespace FastZip
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Afficher les arguments reçus pour le débogage
                Console.WriteLine("Arguments reçus:");
                for (int i = 0; i < args.Length; i++)
                {
                    Console.WriteLine($"Arg {i}: {args[i]}");
                }

                string inputPath = null;
                string outputPath = null;
                string rawCommandLine = Environment.CommandLine;

                Console.WriteLine($"\nLigne de commande complète: {rawCommandLine}");

                // Analyse des arguments
                for (int i = 0; i < args.Length; i++)
                {
                    if ((args[i] == "-i" || args[i] == "/i") && i + 1 < args.Length)
                    {
                        inputPath = args[i + 1].Trim('"', '\'');
                        i++;
                    }
                    else if ((args[i] == "-o" || args[i] == "/o") && i + 1 < args.Length)
                    {
                        outputPath = args[i + 1].Trim('"', '\'');
                        i++;
                    }
                }

                // Vérification des paramètres obligatoires
                if (string.IsNullOrEmpty(inputPath) || string.IsNullOrEmpty(outputPath))
                {
                    // Essayer de récupérer les arguments à partir de la ligne de commande brute
                    if (inputPath == null)
                    {
                        int iIndex = rawCommandLine.IndexOf(" -i ");
                        if (iIndex >= 0)
                        {
                            string afterI = rawCommandLine.Substring(iIndex + 4).Trim();
                            int nextSpace = afterI.IndexOf(" -");
                            if (nextSpace > 0)
                            {
                                inputPath = afterI.Substring(0, nextSpace).Trim('"', '\'');
                            }
                        }
                    }

                    if (outputPath == null)
                    {
                        int oIndex = rawCommandLine.IndexOf(" -o ");
                        if (oIndex >= 0)
                        {
                            string afterO = rawCommandLine.Substring(oIndex + 4).Trim();
                            int nextSpace = afterO.IndexOf(" -");
                            if (nextSpace > 0)
                            {
                                outputPath = afterO.Substring(0, nextSpace).Trim('"', '\'');
                            }
                            else
                            {
                                outputPath = afterO.Trim('"', '\'');
                            }
                        }
                    }

                    // Si toujours pas trouvé
                    if (string.IsNullOrEmpty(inputPath) || string.IsNullOrEmpty(outputPath))
                    {
                        Console.WriteLine("\nErreur: Les paramètres -i et -o sont obligatoires.");
                        ShowUsage();
                        return;
                    }
                }

                Console.WriteLine($"\nChemin source: {inputPath}");
                Console.WriteLine($"Chemin destination: {outputPath}");

                // Vérification de l'existence du chemin d'entrée
                if (!File.Exists(inputPath) && !Directory.Exists(inputPath))
                {
                    Console.WriteLine($"\nErreur: Le fichier ou dossier '{inputPath}' n'existe pas.");
                    return;
                }

                // Compression
                Compress(inputPath, outputPath);
                Console.WriteLine($"\nCompression terminée avec succès: '{outputPath}'");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nErreur: {ex.Message}");
            }

            // Pause pour voir les résultats
            Console.WriteLine("\nAppuyez sur une touche pour continuer...");
            Console.ReadKey();
        }

        static void ShowUsage()
        {
            Console.WriteLine("Usage: FastZip.exe [/compress] -i <fichier ou dossier source> -o <fichier zip de sortie>");
        }

        static void Compress(string sourcePath, string destinationPath)
        {
            try
            {
                // Création du répertoire de destination si nécessaire
                string destDir = Path.GetDirectoryName(destinationPath);
                if (!string.IsNullOrEmpty(destDir) && !Directory.Exists(destDir))
                {
                    Directory.CreateDirectory(destDir);
                }

                // Suppression du fichier zip existant s'il existe
                if (File.Exists(destinationPath))
                {
                    File.Delete(destinationPath);
                }

                if (File.Exists(sourcePath))
                {
                    // Compression d'un seul fichier
                    using (FileStream destinationStream = File.Create(destinationPath))
                    using (ZipArchive archive = new ZipArchive(destinationStream, ZipArchiveMode.Create))
                    {
                        string fileName = Path.GetFileName(sourcePath);
                        ZipArchiveEntry entry = archive.CreateEntry(fileName);

                        using (Stream entryStream = entry.Open())
                        using (FileStream sourceStream = File.OpenRead(sourcePath))
                        {
                            sourceStream.CopyTo(entryStream);
                        }
                    }
                }
                else if (Directory.Exists(sourcePath))
                {
                    // Compression d'un dossier
                    ZipFile.CreateFromDirectory(sourcePath, destinationPath);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur pendant la compression: {ex.Message}");
                throw;
            }
        }
    }
}