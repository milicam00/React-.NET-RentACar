﻿using OnlineLibary.Modules.Catalog.Application.Configuration.Commands;
using OnlineLibary.Modules.Catalog.Application.Contracts;
using OnlineRentCar.BuildingBlocks.Infrastructure;

namespace OnlineRentCar.Modules.Catalog.Infrastructure.Configuration.Processing
{
    public class UnitOfWorkCommandHandlerDecorator<T> : ICommandHandler<T>
            where T : ICommand
    {
        private readonly ICommandHandler<T> _decorated;
        private readonly IUnitOfWork _unitOfWork;

        public UnitOfWorkCommandHandlerDecorator(
            ICommandHandler<T> decorated,
            IUnitOfWork unitOfWork)
        {
            _decorated = decorated;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(T command, CancellationToken cancellationToken)
        {
            await _decorated.Handle(command, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);
        }
    }
}
