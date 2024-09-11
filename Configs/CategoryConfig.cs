using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Web_Api_JWT.Models;

namespace Web_Api_JWT.Configs
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(

                new Category()
                {
                    Id=1,Name="sebze",Description="Cok faydalılar yeşiller"
                },
                 new Category()
                 {
                     Id=2,Name="meyve",Description="Lezzetlidir"
                 },
                 new Category()
                 {
                     Id=3,Name="Temizlik Malzemeleri",Description="hijyenli"
                 }

                );
        }
    }
}
