﻿using MediatR;
using OnlineRentCar.Modules.UserAccess.Application.Contracts;

namespace OnlineRentCar.Modules.UserAccess.Application.Configuration.Commands
{
    public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand>
       where TCommand : ICommand
    {
    }

    public interface ICommandHandler<in TCommand, TResult> :
        IRequestHandler<TCommand, TResult>
        where TCommand : ICommand<TResult>
    {
    }
}
