using System;
using System.Collections.Generic;

namespace GestionCitaDental.Models;

public partial class TblCorreo
{
    public int IdCorreo { get; set; }

    public string Correo { get; set; } = null!;

    public virtual ICollection<TblOdontologo> TblOdontologos { get; set; } = new List<TblOdontologo>();

    public virtual ICollection<TblPaciente> TblPacientes { get; set; } = new List<TblPaciente>();

    public virtual ICollection<TblUsuario> TblUsuarios { get; set; } = new List<TblUsuario>();
}
