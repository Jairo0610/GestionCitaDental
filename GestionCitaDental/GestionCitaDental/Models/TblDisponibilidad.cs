using System;
using System.Collections.Generic;

namespace GestionCitaDental.Models;

public partial class TblDisponibilidad
{
    public int IdDisponibilidad { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<TblOdontologo> TblOdontologos { get; set; } = new List<TblOdontologo>();
}
