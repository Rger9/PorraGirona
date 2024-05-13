using System;
using System.Collections.Generic;

namespace PorraGirona.DataLayer;

public partial class equips
{
    public int idequip { get; set; }

    public string? nom { get; set; }

    public byte[]? imatge { get; set; }

    public virtual ICollection<jugadors> jugadors { get; set; } = new List<jugadors>();

    public virtual ICollection<partits> partitsidequiplocalNavigation { get; set; } = new List<partits>();

    public virtual ICollection<partits> partitsidequipvisitantNavigation { get; set; } = new List<partits>();
}
