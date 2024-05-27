
using Swashbuckle.AspNetCore.SwaggerUI;

namespace SocialNetwork.Infrastructure.API.Extensions
{
    public static class AppExtensions
    {
        public static void UseSwaggerExtension(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "SocialNetwork");
                options.DefaultModelRendering(ModelRendering.Model);
            });
        }

      
    }
}
