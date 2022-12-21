﻿using System.Collections.Generic;

namespace GCModels
{
    /// <summary>
    /// Representa un partido del campeonato.
    /// </summary>
    /// <remarks>
    /// En inglés => MatchupModel
    /// </remarks>

    public class PartidoModel
    {
        /// <summary>
        /// El conjunto de equipos que intervienen en este partido.
        /// </summary>
        /// <remarks>
        /// En inglés => MatchupEntryModel
        /// </remarks>
        public List<PartidoJugadorModel> Participantes { get; set; } = new List<PartidoJugadorModel>();

        /// <summary>
        /// El ganador del partido.
        /// </summary>
        /// <remarks>
        /// En inglés => Winner
        /// </remarks>
        public EquipoModel Ganador { get; set; } = new EquipoModel();

        /// <summary>
        /// De qué ronda forma parte este partido.
        /// </summary>
        /// <remarks>
        /// En inglés => MatchupRound
        /// </remarks>
        public int Ronda { get; set; } = new int();
    }
}
