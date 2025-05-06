using System;

namespace MonolitoDemo.Api.Exceptions;

public class ValidationException(List<string> errors) : Exception("Ocorreram erros de validação")
{
    public List<string> Errors { get; } = errors;
}
