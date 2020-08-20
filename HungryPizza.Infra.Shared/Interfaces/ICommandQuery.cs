using FluentValidation;
using HungryPizza.Infra.Shared.Models;
using MediatR;
using System.Collections.Generic;

namespace HungryPizza.Infra.Shared.Interfaces
{
    public interface ICommandQuery: IRequest<ICommandQuery>
    {
        object Data { get; }
        IReadOnlyCollection<Error> Errors { get; }
        bool Valid { get; }

        void AddError(Error error);
        void AddError(int errorCode);
        bool HasError(int errorCode);
        void SetData(object data);
        void Validate<T>(T entity, AbstractValidator<T> validator);
    }
}
