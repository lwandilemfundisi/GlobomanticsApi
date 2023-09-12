using Globomantics.Domain.DomainModel.GlobomanticsModel;
using Globomantics.Domain.DomainModel.GlobomanticsModel.Entities;
using Microsoft.EntityFrameworkCore;
using XFrame.Persistence.EFCore.ValueObjectConverters;

namespace Globomantics.Persistence.Mappings
{
    public static class GlobomanticsModelMapping
    {
        public static ModelBuilder GlobomanticsModelMap(this ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Conference>()
                .Property(o => o.Id)
                .HasConversion(new SingleValueObjectIdentityValueConverter<ConferenceId>());

            modelBuilder
                .Entity<Proposal>()
                .Property(o => o.Id)
                .HasConversion(new SingleValueObjectIdentityValueConverter<ProposalId>());

            modelBuilder
                .Entity<Proposal>()
                .Property(o => o.ConferenceId)
                .HasConversion(new SingleValueObjectIdentityValueConverter<ConferenceId>());

            #region Relationships

            modelBuilder
                .Entity<Proposal>()
                .HasOne<Conference>()
                .WithMany(c => c.Proposals)
                .HasForeignKey(f => f.ConferenceId);

            #endregion

            return modelBuilder;
        }
    }
}
