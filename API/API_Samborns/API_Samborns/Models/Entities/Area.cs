using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace API_Samborns.Models.Entities;

public partial class Area
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<Empleados>? Empleados { get; set; } = new List<Empleados>();
}
