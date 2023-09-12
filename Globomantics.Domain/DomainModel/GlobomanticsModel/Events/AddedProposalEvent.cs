using XFrame.Aggregates.Events;
using XFrame.Aggregates.Events.AggregateEvents;

namespace Globomantics.Domain.DomainModel.GlobomanticsModel.Events
{
    [EventVersion("AddedProposalEvent", 1)]
    public class AddedProposalEvent
        : AggregateEvent<Conference, ConferenceId>
    {
        #region Constructors

        public AddedProposalEvent(
            string speaker,
            string title,
            bool approved)
        {
            Speaker = speaker;
            Title = title;
            Approved = approved;
        }

        #endregion

        #region Properties

        public string Speaker { get; set; }
        public string Title { get; set; }
        public bool Approved { get; set; }

        #endregion
    }
}
