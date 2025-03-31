# 📦 FastZip - Utilitaire de Compression Rapide

**FastZip** est un outil de compression simple et efficace écrit en C# qui vous permet de compresser rapidement des fichiers et des dossiers sous Windows. Transformez n'importe quel fichier ou répertoire en archive ZIP avec une simple commande.

![Banner](https://o2cloud.fr/logo/o2Cloud.png)

## ✨ Fonctionnalités

- 🚀 **Compression rapide** - Compressez des fichiers et dossiers en quelques secondes
- 📂 **Support de fichier unique ou dossier complet** - Versatilité pour tous vos besoins
- 💻 **Interface en ligne de commande** - Idéal pour l'automatisation et les scripts
- 🛠️ **Installation simple** - Exécutable autonome sans dépendances externes
- 🔄 **Remplacement automatique** - Remplace automatiquement les archives existantes
- 📋 **Sortie détaillée** - Affiche des informations sur le processus de compression
- 🔍 **Gestion d'erreurs robuste** - Messages d'erreur clairs pour faciliter le débogage

## 📋 Pré-requis

- Système d'exploitation Windows
- .NET Framework 4.8 ou supérieur

## 🚀 Utilisation

1. Téléchargez l'exécutable FastZip.exe
2. Utilisez la ligne de commande avec la syntaxe suivante :

   ```bash
   FastZip.exe -i "chemin/vers/source" -o "chemin/vers/destination.zip"
   ```

### Exemples

Compresser un fichier unique :
```bash
FastZip.exe -i "C:\Documents\rapport.docx" -o "C:\Archives\rapport.zip"
```

Compresser un dossier complet :
```bash
FastZip.exe -i "C:\Projets\MonProjet" -o "C:\Archives\MonProjet.zip"
```

## 📚 Documentation

FastZip utilise la bibliothèque System.IO.Compression de .NET pour effectuer les opérations de compression. Le programme gère les cas suivants :

- Compression d'un fichier unique (conserve le nom du fichier dans l'archive)
- Compression d'un dossier complet (inclut tous les sous-dossiers et fichiers)
- Création automatique du répertoire de destination si nécessaire
- Remplacement des archives existantes

## 👨‍💻 Auteurs

- [@o2Cloud-fr](https://www.github.com/o2Cloud-fr)

## 🔖 Badges

[![MIT License](https://img.shields.io/badge/License-MIT-green.svg)](https://opensource.org/licenses/MIT)
[![Windows](https://img.shields.io/badge/Platform-Windows-0078D6?logo=windows)](https://github.com/o2Cloud-fr/FastZip)
[![C#](https://img.shields.io/badge/Language-CSharp-239120?logo=c-sharp)](https://github.com/o2Cloud-fr/FastZip)

## 🤝 Contribution

Les contributions sont toujours les bienvenues !

N'hésitez pas à ouvrir une issue ou à proposer une pull request pour améliorer cet outil.

## 💬 Feedback

Si vous avez des commentaires ou des suggestions, n'hésitez pas à ouvrir une issue sur notre dépôt GitHub.

## 🔗 Liens

[![linkedin](https://img.shields.io/badge/linkedin-0A66C2?style=for-the-badge&logo=linkedin&logoColor=white)](https://www.linkedin.com/in/remi-simier-2b30142a1/)
[![github](https://img.shields.io/badge/github-181717?style=for-the-badge&logo=github&logoColor=white)](https://github.com/o2Cloud-fr)

## 🛠️ Compétences

- C#
- .NET Framework
- Manipulation de fichiers et compression

## 📝 Licence

[MIT License](https://opensource.org/licenses/MIT)

## 🗺️ Feuille de route

- Implémenter différents niveaux de compression
- Ajouter le support pour d'autres formats d'archive (RAR, 7z, etc.)
- Implémenter un mode "test" pour vérifier l'intégrité des archives

## 🆘 Support

Pour obtenir de l'aide, ouvrez une issue sur notre dépôt GitHub ou contactez-nous par email : github@o2cloud.fr

## 💼 Utilisé par

Ce projet est idéal pour :
- Les administrateurs système automatisant des sauvegardes
- Les développeurs intégrant la compression dans leurs workflows
- Les utilisateurs cherchant un outil de compression simple et efficace
