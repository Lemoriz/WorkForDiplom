namespace DiplomApi
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Repo = Repositories;

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
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            //Сервис для документов
            services.AddTransient<Repo.Document.IDocumentRepository, Repo.Document.DocumentRepository>();
            //Сервис для работников
            services.AddTransient<Repo.Employee.IEmployeeRepository, Repo.Employee.EmployeeRepository>();
            //Сервис для позиций
            services.AddTransient<Repo.Position.IPositionRepository, Repo.Position.PositionRepository>();
            //Сервис для подразделений
            services.AddTransient<Repo.Subdivision.ISubdivisionRepository, Repo.Subdivision.SubdivisionRepository>();
            //Сервис для авторизации
            services.AddTransient<Repo.AuthorizInfo.IAuthorizInfoRepository, Repo.AuthorizInfo.AuthorizInfoRepository>();
            //Сервис для загрузки документа
            services.AddTransient<Repo.UploadFile.IUploadFileRepository, Repo.UploadFile.UploadFileRepository>();
            //Сервис для типов документа
            services.AddTransient<Repo.DocumentType.IDocumentTypeRepository, Repo.DocumentType.DocumentTypeRepository>();
            //Сервис для получения файла
            services.AddTransient<Repo.DownloadFile.IDownloadFileRepository, Repo.DownloadFile.UploadFileRepository>();
            //Сервис для обновления файла
            services.AddTransient<Repo.ReplaceUploadedFile.IReplaceUploadedFileRepository, Repo.ReplaceUploadedFile.ReplaceUploadedFileRepository>();
            //Сервис для добавления записи в историю действий
            services.AddTransient<Repo.SendDocumentForApproval.ISendDocumentForApprovalRepository, Repo.SendDocumentForApproval.SendDocumentForApprovalRepository>();
            //Сервис для добавления записи в историю действий
            services.AddTransient<Repo.ActionHistory.IActionHistoryRepository, Repo.ActionHistory.ActionHistoryRepository>();
            //Сервис для добавления записи в историю действий
            services.AddTransient<Repo.ActionStatus.IActionStatusRepository, Repo.ActionStatus.ActionStatusRepository>();
            //Сервис для добавления записи в историю действий
            services.AddTransient<Repo.Action.IActionRepository, Repo.Action.ActionRepository>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            app.UseCors("MyPolicy");
        }
    }
}
