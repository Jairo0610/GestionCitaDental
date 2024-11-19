using System;
using System.Collections.Generic;

namespace GestionCitaDental.Models;

public partial class TblProcedimiento
{
    public int IdProcedimiento { get; set; }

    public string Descripcion { get; set; } = null!;

    public double Costo { get; set; }

    public virtual ICollection<TblCitum> TblCita { get; set; } = new List<TblCitum>();
}
