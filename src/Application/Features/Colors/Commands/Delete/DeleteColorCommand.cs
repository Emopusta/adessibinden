﻿using Core.Application.Pipelines;
using Core.Utilities.Results;

namespace Application.Features.Colors.Commands.Delete
{
    public class DeleteColorCommand : ICommandRequest<DeletedColorResponse>
    {
        public int Id { get; set; }


    }
}
