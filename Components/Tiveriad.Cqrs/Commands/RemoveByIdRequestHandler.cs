using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Tiveriad.Cqrs.Requests;
using Tiveriad.Repositories;

namespace Tiveriad.Cqrs.Commands
{
    public class RemoveByIdRequestHandler<TEntity, TKey> : IRequestHandler<RemoveByIRequest<TEntity, TKey>, bool>
        where TEntity : IEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        private readonly IRepository<TEntity, TKey> _repository;

        public RemoveByIdRequestHandler(IRepository<TEntity, TKey> repository)
        {
            _repository = repository;
        }

        public Task<bool> Handle(RemoveByIRequest<TEntity, TKey> request, CancellationToken cancellationToken)
        {
            return Task.Run(
                () =>
                {
                    var result = _repository.DeleteOne(request.Key);
                    return result == 1;
                }, cancellationToken);
        }
    }
}