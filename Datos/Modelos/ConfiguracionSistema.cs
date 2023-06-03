using System;
using System.Collections.Generic;

namespace Datos.Modelos;

/// <summary>
/// Configuración de mensaje de mensaje de bienvenida.
/// </summary>
public partial class ConfiguracionSistema
{
    /// <summary>
    /// Identificador del registro de configuración.
    /// </summary>
    public int ConfiguracionSistemaId { get; set; }

    /// <summary>
    /// Mensaje de bienvenida en el portal FIMPES
    /// </summary>
    public string MensajeBienvenida { get; set; } = null!;

    /// <summary>
    /// URL donde se puedes descargar el manual de la plataforma FIMPES
    /// </summary>
    public string UrlManual { get; set; } = null!;
}
