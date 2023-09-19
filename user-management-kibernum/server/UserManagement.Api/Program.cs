using UserManagement.Infrastructure.Context;

var builder = WebApplication.CreateBuilder(args);

//Add Cors
builder.Services.AddCors();

// add Context
builder.Services.AddDbContext<UserManagementContext>();

//Add GraphQL
builder.Services
        .AddGraphQLServer()
        .AddQueryType()
        .AddMutationType()
        .AddUserManagementGraphQLTypes()
        .AddProjections()
        .AddFiltering()
        .AddSorting();

var app = builder.Build();

app.UseCors(c => c.AllowAnyHeader().WithMethods("POST").AllowAnyOrigin());

app.MapGraphQL();

app.Run();
