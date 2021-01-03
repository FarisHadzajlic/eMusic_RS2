using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using eMusic.Database;
using eMusic.Filters;
using eMusic.Interface;
using eMusic.Model;
using eMusic.Model.Request;
using eMusic.Security;
using eMusic.Service;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace eMusic
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(x => x.Filters.Add<ErrorFilter>());
            services.AddAutoMapper(typeof(Startup));

            services.AddDbContext<eMusicContext>(options =>
               options.UseSqlServer(Configuration.GetConnectionString("eMusic")));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "eMusic API", Version = "v1" });
                c.AddSecurityDefinition("basic", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "basic",
                    In = ParameterLocation.Header
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                          {
                              Reference = new OpenApiReference
                              {
                                  Type = ReferenceType.SecurityScheme,
                                  Id = "basic"
                              }
                          },
                          new string[] {}
                    }
                });
            });

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAlbumService, AlbumService>();
            services.AddScoped<IArtistService, ArtistService>();
            services.AddScoped<IReviewService, ReviewService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IPlaylistService, PlaylistService>();
            services.AddScoped<IBaseService<MRole, object>, RoleService>();
            services.AddScoped<IRecommendationService, RecommendationService>();
            services.AddScoped<ICRUDService<MTrack, TrackSearchRequest, TrackUpsertRequest, TrackUpsertRequest>, TrackService>();
            services.AddScoped<ICRUDService<MGenre, GenreSearchRequest, GenreUpsertRequest, GenreUpsertRequest>, GenreService>();
            services.AddScoped<ICRUDService<MBuyAlbum, BuyAlbumSearchRequest, BuyAlbumRequest, BuyAlbumRequest>, BuyAlbumService>();

            services.AddAuthentication("BasicAuthentication")
               .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            app.UseRouting();            

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "eMusic API");
            });

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
