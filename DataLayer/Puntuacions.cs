using System;
using System.Collections.Generic;

namespace PorraGirona.DataLayer;

public partial class puntuacions
{
    public int idpuntuacio { get; set; }

    public int idpenyista { get; set; }

    public string alias { get; set; } = null!;

    public int? puntuacio { get; set; }

    public string? temporada { get; set; }
}
