using System;
using System.Collections.Generic;

namespace GestionCitaDental.Models;

public partial class TblPaciente
{
    public int IdPaciente { get; set; }

    public string Nombre { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public string Dui { get; set; } = null!;

    public int IdCorreo { get; set; }

    public virtual TblCorreo IdCorreoNavigation { get; set; } = null!;

    public virtual ICollection<TblCitum> TblCita { get; set; } = new List<TblCitum>();
}
