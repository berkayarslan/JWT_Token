using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Web_Api_JWT.Models;

namespace Web_Api_JWT.Configs
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(new User() { Id = 1, Password = "123", UserName = "ikbal" });
        }
    }
}
