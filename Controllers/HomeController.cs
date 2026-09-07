using Microsoft.AspNetCore.Mvc;
using TPLOCAL1.Models;

// Attention : en MVC, le nom du contrôleur DOIT se terminer par "Controller".
namespace TPLOCAL1.Controllers
{
    public class HomeController : Controller
    {
        // Permet de connaître le dossier racine du projet, pour aller y lire le fichier XML.
        private readonly IWebHostEnvironment _environment;

        public HomeController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        /// <summary>
        /// Méthode appelée "naturellement" par le routeur (voir Program.cs).
        /// L'URL /Home/Index/Form passe "Form" dans le paramètre id.
        /// </summary>
        public ActionResult Index(string? id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                // Aucun paramètre : on affiche la page d'accueil Views/Home/Index.cshtml
                return View();
            }

            switch (id)
            {
                case "OpinionList":
                    // Construction du chemin vers le fichier XML fourni
                    string cheminFichier = Path.Combine(
                        _environment.ContentRootPath, "XlmFile", "DataAvis.xml");

                    // Lecture du fichier via la classe fournie dans Models/Opinion.cs
                    OpinionList lecteur = new OpinionList();
                    List<Opinion> avis = lecteur.GetAvis(cheminFichier);

                    // On appelle la vue OpinionList.cshtml en lui passant la liste
                    return View(id, avis);

                case "Form":
                    // On appelle la vue Form.cshtml avec un modèle vide
                    return View(id, new FormModel());

                default:
                    return View();
            }
        }

        /// <summary>
        /// Méthode appelée par le bouton "Validation" du formulaire.
        /// ASP.NET remplit automatiquement l'objet "model" avec les champs saisis.
        /// </summary>
        [HttpPost]
        public ActionResult ValidationFormulaire(FormModel model)
        {
            // Contrôle supplémentaire, non exprimable par un attribut simple :
            // la date de début de formation doit être antérieure au 01/01/2021.
            if (model.TrainingStartDate.HasValue
                && model.TrainingStartDate.Value >= new DateTime(2021, 1, 1))
            {
                ModelState.AddModelError(nameof(model.TrainingStartDate),
                    "La date de début de formation doit être antérieure au 01/01/2021.");
            }

            // ModelState.IsValid vaut false dès qu'un contrôle du modèle est en échec.
            if (!ModelState.IsValid)
            {
                // On réaffiche le formulaire, avec les données saisies et TOUS les messages d'erreur.
                return View("Form", model);
            }

            // Tous les contrôles sont OK : on affiche la page de validation avec le même modèle.
            return View("ValidationForm", model);
        }
    }
}