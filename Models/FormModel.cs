using System.ComponentModel.DataAnnotations;

namespace TPLOCAL1.Models
{
    /// <summary>
    /// Modèle portant les données saisies dans le formulaire d'évaluation.
    /// Les attributs entre crochets ([Required], [RegularExpression]...) sont
    /// les contrôles de saisie : ils sont vérifiés automatiquement par ASP.NET
    /// lors de la soumission du formulaire.
    /// </summary>
    public class FormModel
    {
        // ---------- Informations personnelles ----------

        [Required(ErrorMessage = "Le nom est obligatoire.")]
        [Display(Name = "Nom")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Le prénom est obligatoire.")]
        [Display(Name = "Prénom")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Veuillez sélectionner un genre.")]
        [Display(Name = "Genre")]
        public string? Gender { get; set; }

        [Required(ErrorMessage = "L'adresse est obligatoire.")]
        [Display(Name = "Adresse")]
        public string? Address { get; set; }

        // Expression régulière : exactement 5 caractères numériques
        [Required(ErrorMessage = "Le code postal est obligatoire.")]
        [RegularExpression(@"^[0-9]{5}$",
            ErrorMessage = "Le code postal doit contenir exactement 5 chiffres.")]
        [Display(Name = "Code postal")]
        public string? PostalCode { get; set; }

        [Required(ErrorMessage = "La ville est obligatoire.")]
        [Display(Name = "Ville")]
        public string? City { get; set; }

        // Expression régulière fournie dans le sujet du TP
        [Required(ErrorMessage = "L'adresse mail est obligatoire.")]
        [RegularExpression(@"^([\w]+)@([\w]+)\.([\w]+)$",
            ErrorMessage = "L'adresse mail n'est pas au bon format (exemple : nom@domaine.fr).")]
        [Display(Name = "Adresse mail")]
        public string? Email { get; set; }

        // ---------- Informations sur la formation suivie ----------

        [Required(ErrorMessage = "La date de début de formation est obligatoire.")]
        [DataType(DataType.Date)]
        [Display(Name = "Date de début de formation")]
        public DateTime? TrainingStartDate { get; set; }

        [Required(ErrorMessage = "Veuillez sélectionner une formation.")]
        [Display(Name = "Type de formation")]
        public string? TrainingType { get; set; }

        // ---------- Avis sur la formation ----------

        [Display(Name = "Formation Cobol")]
        public string? CobolOpinion { get; set; }

        [Display(Name = "Formation C#")]
        public string? CsharpOpinion { get; set; }
    }
}