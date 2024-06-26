﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmTrackerAPI.Application.Commands
{
    public record MarkMovieAsWatchedCommand(int MovieId, int watchListId, int UserId): IRequest<Unit>;
}
