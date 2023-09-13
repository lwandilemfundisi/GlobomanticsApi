using Microsoft.Extensions.DependencyInjection.Extensions;
using XFrame.AggregateEventPublisher;
using XFrame.Aggregates;
using XFrame.Aggregates.Commands;
using XFrame.Aggregates.Events;
using XFrame.Aggregates.Events.Serializers;
using XFrame.Aggregates.Queries;
using XFrame.AggregateStores;
using XFrame.Jobs;
using Globomantics.Domain.Extensions;
using Globomantics.Persistence;
using XFrame.Persistence.EFCore.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.TryAddTransient<ICommandBus, CommandBus>();
builder.Services.TryAddSingleton<ICommandDefinitionService, CommandDefinitionService>();
builder.Services.TryAddTransient<IAggregateStore, AggregateStore>();
builder.Services.TryAddTransient<IAggregateFactory, AggregateFactory>();
builder.Services.TryAddTransient<IQueryProcessor, QueryProcessor>();
builder.Services.TryAddSingleton<IEventDefinitionService, EventDefinitionService>();
builder.Services.TryAddSingleton<IJobDefinitionService, JobDefinitionService>();
builder.Services.TryAddTransient<IEventJsonSerializer, EventJsonSerializer>();
builder.Services.TryAddTransient<IJobScheduler, InstantJobScheduler>();
builder.Services.TryAddTransient<IJobRunner, JobRunner>();
builder.Services.TryAddTransient<IDomainEventPublisher, DomainEventPublisher>();
builder.Services.TryAddTransient<IDispatchToEventSubscribers, DispatchToEventSubscribers>();
builder.Services.TryAddSingleton<IDomainEventFactory, DomainEventFactory>();

builder.Services
    .ConfigureGlobomanticsDomain()
    .ConfigurePersistence<GlobomanticsContext, GlobomanticsContextProvider>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
