using System;
using System.Collections.Generic;

namespace GestionCitaDental.Models;

public partial class TblOdontologo
{
    public int IdOdontologo { get; set; }

    public string? Nombre { get; set; }

    public string? Telefono { get; set; }

    public int? IdCorreo { get; set; }

    public int? IdDisponible { get; set; }

    public virtual TblCorreo? IdCorreoNavigation { get; set; }

    public virtual TblDisponibilidad? IdDisponibleNavigation { get; set; }

    public virtual ICollection<TblCitum> TblCita { get; set; } = new List<TblCitum>();
}
