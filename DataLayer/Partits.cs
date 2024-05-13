using System;
using System.Collections.Generic;

namespace PorraGirona.DataLayer;

public partial class partits
{
    public int idpartit { get; set; }

    public int? idequiplocal { get; set; }

    public int? idequipvisitant { get; set; }

    public DateTime? datainici { get; set; }

    public int? jornada { get; set; }

    public int? golslocal { get; set; }

    public int? golsvisitant { get; set; }

    public string? finalitzat { get; set; }

    public string? temporada { get; set; }

    public string? idsjugadorslocal { get; set; }

    public string? idsjugadorsvisitant { get; set; }

    public virtual equips? idequiplocalNavigation { get; set; }

    public virtual equips? idequipvisitantNavigation { get; set; }

    public virtual ICollection<porres> porres { get; set; } = new List<porres>();
}
