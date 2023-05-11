using System;
using System.Collections.Generic;

namespace CriasApp.Models;

public class RegistroCria
{
    public int IdCria { get; set; }

    public DateTime Fecha { get; set; }

    public int? Peso { get; set; }

    public int? Costo { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }
}
