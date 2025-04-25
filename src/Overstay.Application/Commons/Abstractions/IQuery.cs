using Overstay.Application.Commons.Results;

namespace Overstay.Application.Commons.Abstractions;

public interface IQuery<TResponse> : IRequest<Result<TResponse>> { }
