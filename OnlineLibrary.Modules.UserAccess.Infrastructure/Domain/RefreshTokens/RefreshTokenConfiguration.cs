﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineRentCar.Modules.UserAccess.Domain.Users;

namespace OnlineRentCar.Modules.UserAccess.Infrastructure.Domain.RefreshTokens
{
    public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure(EntityTypeBuilder<RefreshToken> builder)
        {
            builder.HasKey(x => x.TokenId);

            builder.HasOne(b => b.User)
                .WithMany(l => l.RefreshTokens)
                .HasForeignKey(B => B.UserId);

        }
    }
}
