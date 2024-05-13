using System;
using System.Collections.Generic;

namespace PorraGirona.DataLayer;

public partial class porres
{
    public int idporra { get; set; }

    public int? golslocal { get; set; }

    public int? golsvisitant { get; set; }

    public DateTime? data { get; set; }

    public string? idsgolejadorslocal { get; set; }

    public string? idsgolejadorsvisitant { get; set; }

    public int? idpenyista { get; set; }

    public int? idpartit { get; set; }

    public virtual partits? idpartitNavigation { get; set; }

    public virtual penyistes? idpenyistaNavigation { get; set; }
}
