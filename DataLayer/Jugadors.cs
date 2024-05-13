using System;
using System.Collections.Generic;

namespace PorraGirona.DataLayer;

public partial class jugadors
{
    public int idjugador { get; set; }

    public string? nom { get; set; }

    public int? idequip { get; set; }

    public string? temporada { get; set; }

    public virtual equips? idequipNavigation { get; set; }
}
