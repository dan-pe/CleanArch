using CleanArch.Domain.Core.Bus;
using CleanArch.Infrastructure.Bus;
using CleanArch.Notes.Application.Interfaces;
using CleanArch.Notes.Application.Services;
using CleanArch.Notes.Data.Context;
using CleanArch.Notes.Data.Repositories;
using CleanArch.Stash.Application.Interfaces;
using CleanArch.Stash.Application.Services;
using CleanArch.Stash.Data.Context;
using CleanArch.Stash.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArch.Infrastructure.IoC
{
    public static class DependencyContainter
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Interface Bus
            services.AddTransient<IEventBus, MessageBus>();

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
