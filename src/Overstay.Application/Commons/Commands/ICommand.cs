using Overstay.Application.Commons.Results;

namespace Overstay.Application.Commons.Commands;

public interface ICommand : IRequest<Result> { }

public interface ICommand<TResponse> : IRequest<Result<TResponse>> { }
