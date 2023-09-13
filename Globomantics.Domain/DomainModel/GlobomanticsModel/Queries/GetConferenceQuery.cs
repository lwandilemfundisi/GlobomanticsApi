using XFrame.Aggregates.Queries;
using XFrame.Persistence;
using XFrame.Persistence.EFCore.Queries.CriteriaQueries;

namespace Globomantics.Domain.DomainModel.GlobomanticsModel.Queries
{
    public class GetConferenceQuery
        : EFCoreCriteriaDomainQuery<Conference>, IQuery<Conference>
    {
        #region Constructors

        public GetConferenceQuery(ConferenceId conferenceId)
        {
            Id = conferenceId;
        }

        #endregion

        #region Virtual Members

        protected override bool FailOnNoCriteriaSpecified => true;

        #endregion
    }

    public class GetConferenceQueryHandler
        : EFCoreCriteriaDomainQueryHandler<Conference>, IQueryHandler<GetConferenceQuery, Conference>
    {
        #region Constructors

        public GetConferenceQueryHandler(IPersistenceFactory persistenceFactory)
            : base(persistenceFactory)
        {
        }

        #endregion

        #region Virtual Methods

        public Task<Conference> ExecuteQueryAsync(
            GetConferenceQuery query,
            CancellationToken cancellationToken)
        {
            return Find(query);
        }

        #endregion
    }
}
