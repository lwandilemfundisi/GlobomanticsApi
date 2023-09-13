using Globomantics.Domain.DomainModel.GlobomanticsModel;
using Globomantics.Domain.DomainModel.GlobomanticsModel.Commands;

namespace Globomantics.Api.Models
{
    public class CreateConferenceModelRequest
    {
        public string ConferenceName { get; set; }
        public DateTime Start { get; set; }
        public string Location { get; set; }
        public int AttendeeCount { get; set; }

        #region Methods

        public CreateConferenceCommand ToCommand()
        {
            return new CreateConferenceCommand(
                ConferenceId.New,
                ConferenceName,
                Start,
                Location,
                AttendeeCount
                );
        }

        #endregion
    }
}
