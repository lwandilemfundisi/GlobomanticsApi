using Newtonsoft.Json;
using XFrame.Ids;
using XFrame.ValueObjects.SingleValueObjects;

namespace Globomantics.Domain.DomainModel.GlobomanticsModel
{
    [JsonConverter(typeof(SingleValueObjectConverter))]
    public class ConferenceId : Identity<ConferenceId>
    {
        public ConferenceId(string value) : base(value)
        {
        }
    }
}
