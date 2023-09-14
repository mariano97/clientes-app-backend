using System;
using System.Collections.Generic;

namespace ClientesApi.Data.Models;

public partial class Cliente
{
    public int Idcliente { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Apellido { get; set; }

    public int Edad { get; set; }

    public string CorreoElectronico { get; set; } = null!;

    public virtual ICollection<Asesor> Asesors { get; set; } = new List<Asesor>();
}
