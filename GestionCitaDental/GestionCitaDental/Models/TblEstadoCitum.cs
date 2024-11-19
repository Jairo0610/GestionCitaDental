using System;
using System.Collections.Generic;

namespace GestionCitaDental.Models;

public partial class TblEstadoCitum
{
    public int IdEstadoCita { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<TblCitum> TblCita { get; set; } = new List<TblCitum>();
}
