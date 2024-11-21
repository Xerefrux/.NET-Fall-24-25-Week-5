using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Television_Channel_Program.CustomAnnotations;
using Television_Channel_Program.EF;

namespace Television_Channel_Program.DTOs
{
    public class ChannelDTO
    {
        public int ChannelId { get; set; }

        [Required]
        [StringLength(100)]
        public string ChannelName { get; set; }

        [Required]
        [EstablishedYearAnnotations]
        public int EstablishedYear { get; set; }

        [Required]
        [StringLength(50)]
        public string Country { get; set; }

        public virtual ICollection<Program> Programs { get; set; }
    }
}