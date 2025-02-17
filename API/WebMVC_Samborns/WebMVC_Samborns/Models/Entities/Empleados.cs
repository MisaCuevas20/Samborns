using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace WebMVC_Samborns.Models.Entities;

public partial class Empleados
{
    public int Id { get; set; }

    [Required(ErrorMessage = "{0} es obligatorio")]
    public string Nombre { get; set; } = null!;

    [Required(ErrorMessage = "{0} es obligatorio")]
    public int Edad { get; set; }

    [Required(ErrorMessage = "{0} es obligatorio")]
    public int IdArea { get; set; }

    [Required(ErrorMessage = "{0} es obligatorio")]
    public DateOnly FechaIngreso { get; set; }

    [JsonProperty("area")]
    [Display(Name = "Puesto")]
    public virtual Area? IdAreaNavigation { get; set; }

}
