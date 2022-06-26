using Graphql.Net.EntityFramework;
using Graphql.Net.Graphql.Mutations;
using Graphql.Net.Graphql.Queries;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<GraphqlDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Postgresql")));

builder.Services
    .AddGraphQLServer()
    .AddFiltering()
    .AddSorting()
    .RegisterDbContext<GraphqlDbContext>()
    .AddQueryType<BookQueries>()
    .AddMutationType<BookMutations>();

var app = builder.Build();

app.MapGraphQL();

app.UseHttpsRedirection();

app.Run();
