using XFrame.Aggregates.Entities;

namespace Globomantics.Domain.DomainModel.GlobomanticsModel.Entities
{
    public class Proposal : Entity<ProposalId>
    {
        #region Properties

        public ConferenceId ConferenceId { get; set; }
        public string Speaker { get; set; }
        public string Title { get; set; }
        public bool Approved { get; set; }

        #endregion
    }
}
