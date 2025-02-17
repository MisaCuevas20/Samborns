using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace API_Samborns.Models.Entities;

public partial class Empleados
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public int Edad { get; set; }

    public int IdArea { get; set; }

    public DateOnly FechaIngreso { get; set; }

    [JsonIgnore]
    public virtual Area? IdAreaNavigation { get; set; } = null!;
}
