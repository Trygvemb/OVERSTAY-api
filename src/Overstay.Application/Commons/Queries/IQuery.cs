using Overstay.Application.Commons.Results;

namespace Overstay.Application.Commons.Queries;

public interface IQuery<TResponse> : IRequest<Result<TResponse>> { }
