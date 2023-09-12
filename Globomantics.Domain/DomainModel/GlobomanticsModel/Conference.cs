using Globomantics.Domain.DomainModel.GlobomanticsModel.Entities;
using XFrame.Aggregates;

namespace Globomantics.Domain.DomainModel.GlobomanticsModel
{
    public class Conference 
        : AggregateRoot<Conference, ConferenceId>
    {
        #region Constructors

        public Conference()
            : base(null)
        {

        }

        public Conference(ConferenceId eventCatalogId)
            : base(eventCatalogId)
        {

        }

        #endregion

        #region Properties

        public string ConferenceName { get; set; }
        public DateTime Start { get; set; }
        public string Location { get; set; }
        public int AttendeeCount { get; set; }
        public IList<Proposal> Proposals { get; set; }

        #endregion
    }
}
