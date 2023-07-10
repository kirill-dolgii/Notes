using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Notes.API.Application.Notes.Queries.GetNoteDetailsQuery;

public class GetNoteDetailsQuery : IRequest<NoteDetailsVm>
{
    public Guid UserId { get; }
    public Guid Id     { get; }
}