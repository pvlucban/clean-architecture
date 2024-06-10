using Clean_Architecture.Infrastructure.Data;
using Clean_Architecture.Infrastructure.Identity;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Clean_Architecture.Core.Application;
using Clean_Architecture.Core.Application.Queries;
using Clean_Architecture.Core.Domain.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
IConfiguration config = builder.Configuration;
builder.Services.AddDataAccess(config);
builder.Services.AddIdentityStore(config);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

builder.Services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddFluentValidationAutoValidation();

builder.Services.AddApplicationServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/api/token", async (SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, IValidator<LoginModel> validator, [FromBody] LoginModel loginModel) =>
{

    var validationResult = await validator.ValidateAsync(loginModel);
    if (!validationResult.IsValid)
    {
        return Results.BadRequest(validationResult.Errors);
    }

    //var user = await userManager.FindByNameAsync(loginDto.UserName);

    // if (user is null)
    // {
    //     return Results.Unauthorized();
    // }

    // ssignInManager.PasswordSignInAsync()

    return Results.Ok(new { test = "123" });
});

app.MapGet("/api/{id}", async (IMediator mediatR, int id) =>
{
    var query = new GetAccountByIdQuery { Id = id };
    var result = await mediatR.Send(query);
    if (result is null)
    {
        return Results.NotFound();
    }
    return Results.Ok(result);
});

app.Run();
