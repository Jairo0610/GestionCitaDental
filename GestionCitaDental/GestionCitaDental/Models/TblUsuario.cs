using System;
using System.Collections.Generic;

namespace GestionCitaDental.Models;

public partial class TblUsuario
{
    public int IdUsuario { get; set; }

    public string Usuario { get; set; } = null!;

    public string Contraseña { get; set; } = null!;

    public int IdCorreo { get; set; }

    public int IdTipoUsuario { get; set; }

    public virtual TblCorreo IdCorreoNavigation { get; set; } = null!;

    public virtual TblTipoUsuario IdTipoUsuarioNavigation { get; set; } = null!;
}
