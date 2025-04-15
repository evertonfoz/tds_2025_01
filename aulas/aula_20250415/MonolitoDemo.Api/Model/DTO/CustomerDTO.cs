using System;

namespace MonolitoDemo.Api.Model.DTO;

public class CustomerDTO()
{
    public required int? CustomerId { get;  set; }
    public required string Name { get; set; }
}
