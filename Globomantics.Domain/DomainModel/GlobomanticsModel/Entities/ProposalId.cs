using Newtonsoft.Json;
using XFrame.Ids;
using XFrame.ValueObjects.SingleValueObjects;

namespace Globomantics.Domain.DomainModel.GlobomanticsModel.Entities
{
    [JsonConverter(typeof(SingleValueObjectConverter))]
    public class ProposalId : Identity<ProposalId>
    {
        public ProposalId(string value) : base(value)
        {
        }
    }
}
