using Overstay.Application.Commons.Results;

namespace Overstay.Application.Commons.Abstractions;

public interface ICommand : IRequest<Result> { }

public interface ICommand<TResponse> : IRequest<Result<TResponse>> { }
