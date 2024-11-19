using System;
using System.Collections.Generic;

namespace GestionCitaDental.Models;

public partial class TblTipoUsuario
{
    public int IdTipoUsuario { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<TblUsuario> TblUsuarios { get; set; } = new List<TblUsuario>();
}
