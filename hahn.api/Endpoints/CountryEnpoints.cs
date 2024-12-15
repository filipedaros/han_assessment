using Azure.Core;
using hahn.application.commands;
using hahn.application.queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace hahn.api.Endpoints;

public static class CountryEnpoints
{
    public static void MapCountryEnpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("api/countries", async (ISender sender) => await sender.Send(new QueryCountriesRequest())).WithName("Get");
    }
}