using System;
using System.Collections.Generic;

namespace GestionCitaDental.Models;

public partial class TblCitum
{
    public int IdCita { get; set; }

    public int? IdPaciente { get; set; }

    public int? IdProcedimiento { get; set; }

    public int? IdOdontologo { get; set; }

    public int? IdEstadoCita { get; set; }

    public DateTime Fecha { get; set; }

    public virtual TblEstadoCitum? IdEstadoCitaNavigation { get; set; }

    public virtual TblOdontologo? IdOdontologoNavigation { get; set; }

    public virtual TblPaciente? IdPacienteNavigation { get; set; }

    public virtual TblProcedimiento? IdProcedimientoNavigation { get; set; }
}
