using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebMVC_Samborns.Models.Entities;

public partial class Area
{
    public int Id { get; set; }

    [Required(ErrorMessage = "{0} es obligatorio")]
    [Display(Name = "Nombre del puesto")]
    public string Nombre { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<Empleados>? Empleados { get; set; } = new List<Empleados>();
}
