using System;
using System.Collections.Generic;

namespace ClientesApi.Data.Models;

public partial class Asesor
{
    public int Idasesor { get; set; }

    public string Nombre { get; set; } = null!;

    public string CorreoElectronico { get; set; } = null!;

    public int ClienteId { get; set; }

    public virtual Cliente Cliente { get; set; } = null!;
}
