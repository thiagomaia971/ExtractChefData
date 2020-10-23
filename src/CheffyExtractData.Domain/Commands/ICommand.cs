using MediatR;

namespace CheffyExtractData.Domain.Commands
{
    public interface ICommand<TResult> : IRequest<CommandResult<TResult>>
    {
    }
}