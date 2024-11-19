using System;
using System.Collections.Generic;

namespace GestionCitaDental.Models;

public partial class TblCitum
{
    public int IdCita { get; set; }

    public int IdPaciente { get; set; }

    public int IdProceso { get; set; }

    public int IdOdontologo { get; set; }

    public DateOnly FechaCita { get; set; }

    public int IdEstado { get; set; }

    public virtual TblEstadoCitum IdEstadoNavigation { get; set; } = null!;

    public virtual TblOdontologo IdOdontologoNavigation { get; set; } = null!;

    public virtual TblPaciente IdPacienteNavigation { get; set; } = null!;

    public virtual TblProcedimiento IdProcesoNavigation { get; set; } = null!;
}
