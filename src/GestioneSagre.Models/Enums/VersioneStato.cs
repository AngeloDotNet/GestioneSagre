using System.ComponentModel.DataAnnotations;

namespace GestioneSagre.Models.Enums;
public enum VersioneStato
{
    [Display(Name = "Attiva")]
    Attiva,

    [Display(Name = "Deprecata")]
    Deprecata
}