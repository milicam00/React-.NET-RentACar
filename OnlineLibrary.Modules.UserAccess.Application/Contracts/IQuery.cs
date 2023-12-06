using MediatR;

namespace OnlineRentCar.Modules.UserAccess.Application.Contracts
{
    public interface IQuery<out TResult> : IRequest<TResult>
    {
    }
}
