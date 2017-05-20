using Covalence.API.Tags;
using Covalence.Authentication;

namespace Covalence.API
{
    public class ExpertUserTag
    {
        public virtual string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        
        public virtual int TagId { get; set; }
        public virtual Tag Tag { get; set; }
    }
}