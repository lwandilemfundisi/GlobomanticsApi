using XFrame.Aggregates.Events.AggregateEvents;
using XFrame.Aggregates.Events;

namespace Globomantics.Domain.DomainModel.GlobomanticsModel.Events
{
    [EventVersion("CreatedConferenceEvent", 1)]
    public class CreatedConferenceEvent
        : AggregateEvent<Conference, ConferenceId>
    {
        #region Constructors

        public CreatedConferenceEvent(
            string conferenceName,
            DateTime start,
            string location,
            int attendeeCount)
        {
            ConferenceName = conferenceName;
            Start = start;
            Location = location;
            AttendeeCount = attendeeCount;
        }

        #endregion

        #region Properties

        public string ConferenceName { get; }
        public DateTime Start { get; }
        public string Location { get; }
        public int AttendeeCount { get; }

        #endregion
    }
}
