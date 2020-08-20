using FluentValidation;
using HungryPizza.Infra.Shared.Interfaces;
using HungryPizza.Infra.Shared.Models;
using System.Collections.Generic;
using System.Linq;

namespace HungryPizza.Infra.Shared.CommandQuery
{
    public class CommandQuery: ICommandQuery
    {
        private readonly IList<Error> _errors;
        private readonly AppSettings _appSettings;
        public CommandQuery(AppSettings appSettings)
        {
            Valid = true;
            _appSettings = appSettings;
            _errors = new List<Error>();
        }
        public bool Valid { get; private set; }
        public object Data { get; private set; }
        public IReadOnlyCollection<Error> Errors { get { return _errors.ToArray(); } }

        public void AddError(Error error)
        {
            Valid = false;
            _errors.Add(error);
            SetData(_errors);
        }

        public void AddError(int errorCode)
        {
            Valid = false;
            string msg = _appSettings.Errors.FirstOrDefault(f => f.Key == errorCode.ToString()).Value;
            _errors.Add(new Error(errorCode, msg));
            SetData(_errors);
        }

        public void SetData(object data)
        {
            Data = data;
        }

        public void Validate<T>(T entity, AbstractValidator<T> validator)
        {
            var val = validator.Validate(entity);
            if (!val.IsValid)
            {
                val.Errors.ToList().ForEach(e =>
                {
                    int code = int.Parse(e.ErrorCode);
                    string msg = _appSettings.Errors.FirstOrDefault(f => f.Key == e.ErrorCode).Value;
                    AddError(new Error(code, msg));
                });
                SetData(_errors);
            }
        }

        public bool HasError(int errorCode)
        {
            return Errors.Any(f => f.Code == errorCode);
        }
    }
}
