using Globomantics.Domain.DomainModel.GlobomanticsModel.Entities;
using Globomantics.Domain.DomainModel.GlobomanticsModel.Events;
using XFrame.Aggregates;
using XFrame.Common.Extensions;
using XFrame.Specifications.Extensions;

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

        #region Methods

        internal void Create(
            string conferenceName,
            DateTime start,
            string location,
            int attendeeCount)
        {
            AggregateSpecifications
                .AggregateIsNew
                .ThrowDomainErrorIfNotSatisfied(this);

            ConferenceName = conferenceName;
            Start = start;
            Location = location;
            AttendeeCount = attendeeCount;

            Emit(new CreatedConferenceEvent(
                conferenceName,
                start,
                location,
                attendeeCount));
        }


        internal void AddProposal(
            string speaker,
            string title,
            bool approved)
        {
            AggregateSpecifications
                .AggregateIsCreated
                .ThrowDomainErrorIfNotSatisfied(this);

            if(!Proposals.HasItems())
                Proposals = new List<Proposal>();

            Proposals.Add(new Proposal 
            {
                Id = ProposalId.New,
                Speaker = speaker,
                Title = title,
                Approved = approved
            });

            Emit(new AddedProposalEvent(
                speaker,
                title,
                approved));
        }

        #endregion
    }
}
