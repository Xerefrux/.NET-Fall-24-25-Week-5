//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Television_Channel_Program.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class Channel
    {
        public Channel()
        {
            this.Programs = new HashSet<Program>();
        }
    
        public int ChannelId { get; set; }
        public string ChannelName { get; set; }
        public int EstablishedYear { get; set; }
        public string Country { get; set; }
    
        public virtual ICollection<Program> Programs { get; set; }
    }
}
