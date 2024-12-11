using Application.Interfaces;
using Application.Interfaces.Repository;
using Application.Interfaces.Service;
using Application.Mapper;
using Application.Service;
using Domain.Entities;
using Infrastructure.Context;
using Infrastructure.Persistence;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace Presentation;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        
        //disable csrf api
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", policy =>
                policy.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
        });
        
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        
        //đăng ký kết nối database(Postgres)
        builder.Services.AddDbContext<DatabaseContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
        
        //đăng ký UnitOfWork
        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
        
        //dđăng ký các Repository
        builder.Services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
        builder.Services.AddScoped<IBookRepository, BookRepository>();
        builder.Services.AddScoped<IBookCatalogueRepository, BookCatalogueRepository>();
        builder.Services.AddScoped<ICatalogueRepository, CatalogueRepository>();
        builder.Services.AddScoped<IGenreRepository, GenreRepository>();
        builder.Services.AddScoped<ICartRepository, CartRepository>();
        builder.Services.AddScoped<ICartDetailRepository, CartDetailRepository>();
        builder.Services.AddScoped<IBookImagesRepository, BookImagesRepository>();
        
        //đăng ký các service
        builder.Services.AddScoped<IBookService, BookService>();
        builder.Services.AddScoped<IBookCatalogueService, BookCatalogueService>();
        builder.Services.AddScoped<ICatalogueService, CatalogueService>();
        builder.Services.AddScoped<IGenreService, GenreService>();
        builder.Services.AddScoped<ICartService, CartService>();
        builder.Services.AddScoped<ICartDetailService, CartDetailService>();
        builder.Services.AddScoped<IBookImagesService, BookImagesService>();
        
        //dang ký AutoMapper
        builder.Services.AddAutoMapper(typeof(MappingProfile));

        var app = builder.Build();
        
        //cấu hình tự động chạy migration
        // using (var scope = app.Services.CreateScope())
        // {
        //     var services = scope.ServiceProvider;
        //     var context = services.GetRequiredService<DatabaseContext>();
        //     context.Database.Migrate();
        // }

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        
        //thêm cors ==> disable csrf
        app.UseCors("AllowAll");

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
