using System;
using System.Collections.Generic;

#nullable disable

namespace BoxAdmin.Domain.Entities.BoxContext
{
    public partial class SubscriptionPlanInfo
    {
        public int Id { get; set; }
        public string PictureUrl { get; set; }
        public string Name { get; set; }
        public int? SetPrice { get; set; }
        public int SellingPrice { get; set; }
        public string ProductDescrption { get; set; }
        public int Type { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Creator { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string Modifier { get; set; }
    }
}
