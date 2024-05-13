using System;
using System.Collections.Generic;

namespace PorraGirona.DataLayer;

public partial class penyistes
{
    public int idpenyista { get; set; }

    public string? nom { get; set; }

    public string? cognoms { get; set; }

    public string? nif { get; set; }

    public string? numsoci { get; set; }

    public string? rol { get; set; }

    public string? alias { get; set; }

    public string? password { get; set; }

    public DateTime? dataalta { get; set; }

    public byte[]? imatge { get; set; }

    public int? idpenya { get; set; }

    public virtual penyes? idpenyaNavigation { get; set; }

    public virtual ICollection<porres> porres { get; set; } = new List<porres>();
}
