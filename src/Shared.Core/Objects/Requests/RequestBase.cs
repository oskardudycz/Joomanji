using Shared.Core.Context;
using Shared.Core.Validation;
using System.Runtime.Serialization;

namespace Shared.Core.Objects.Requests
{
    [DataContract]
    public abstract class RequestBase : ValidatableObjectBase, IRequest
    {
        protected RequestBase()
        {
            //RequesterUserID = StaticManager.User.Id;
            RequesterCultureName = System.Threading.Thread.CurrentThread.CurrentCulture.Name;
            RequesterIP = UserContext.ClientIP;
            RequesterDNS = UserContext.ClientDNS;
            RequesterBrowser = UserContext.ClientBrowser;
        }

        //[DataMember(Order = 0)]
        //public Guid RequesterUserID { get; set; }

        [DataMember]
        public string RequesterCultureName { get; set; }

        [DataMember]
        public string RequesterIP = string.Empty;

        [DataMember]
        public string RequesterDNS = string.Empty;

        [DataMember]
        public string RequesterBrowser = string.Empty;
    }
}