using CleanArch.Domain.Core.Bus;
using CleanArch.Infrastructure.Bus;
using CleanArch.Notes.Application.Interfaces;
using CleanArch.Notes.Application.Services;
using CleanArch.Notes.Data.Context;
using CleanArch.Notes.Data.Repositories;
using CleanArch.Notes.Domain.CommandHandlers;
using CleanArch.Notes.Domain.Commands;
using CleanArch.Notes.Domain.Events;
using CleanArch.Stash.Application.Interfaces;
using CleanArch.Stash.Application.Services;
using CleanArch.Stash.Data.Context;
using CleanArch.Stash.Domain.EventHandlers;
using CleanArch.Stash.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArch.Infrastructure.IoC
{
    public static class DependencyContainter
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Interface Bus
            services.AddSingleton<IEventBus, MessageBus>(serviceProvider =>
            {
                var scopeFactory = serviceProvider.GetRequiredService<IServiceScopeFactory>();
                return new MessageBus(serviceProvider.GetService<IMediator>(), scopeFactory);
            });

            // Subscriptions
            services.AddTransient<NoteCreatedEventHandler>();

            // Domain Events
            services.AddTransient<IEventHandler<Stash.Domain.EventHandlers.NoteCreatedEvent>, NoteCreatedEventHandler>();

            // Domain Note Commands
            services.AddTransient<IRequestHandler<CreateNoteCommand, bool>, CreateNoteCommandHandler>();

            // Application Layer
            services.AddTransient<INotesService, NotesService>();
            services.AddTransient<INoteStashService, NoteStashService>();

            // Data Layer
            services.AddTransient<INotesRepository, NotesRepository>();
            services.AddTransient<INoteStashRepository, NoteStashRepository>();
            services.AddTransient<NotesDbContext>();
            services.AddTransient<NoteStashDbContext>();
        }
    }
}
