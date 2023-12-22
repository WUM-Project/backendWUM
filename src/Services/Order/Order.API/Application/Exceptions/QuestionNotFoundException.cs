using System;


namespace Order.Api.Application.Exceptions
{
    public sealed class QuestionNotFoundException : NotFoundException
    {
        public QuestionNotFoundException(int Id)
            : base($"The question with the identifier {Id} was not found")
        {
        }
    }
}