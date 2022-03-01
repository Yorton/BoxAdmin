using System;
using System.Collections.Generic;

#nullable disable

namespace BoxAdmin.Domain.Entities.BoxContext
{
    public partial class Reservation
    {
        public Reservation()
        {
            ReservationCards = new HashSet<ReservationCard>();
            ReservationLineItemGroups = new HashSet<ReservationLineItemGroup>();
            ReservationLineItems = new HashSet<ReservationLineItem>();
        }

        public Guid Id { get; set; }
        public Guid SubscribeId { get; set; }
        public Guid CustomerId { get; set; }
        public string BoxNo { get; set; }
        public int BoxType { get; set; }
        public int State { get; set; }
        public int FlowState { get; set; }
        public Guid MatchmakerId { get; set; }
        public bool AllowanceAgree { get; set; }
        public bool AddPurchase { get; set; }
        public int DeliveryMethod { get; set; }
        public DateTime? DeliveryExpected { get; set; }
        public DateTime? PreviewDueDate { get; set; }
        public string TaxIdNumber { get; set; }
        public int InvDevice { get; set; }
        public string InvDeviceCode { get; set; }
        public string InvDonateCode { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public string ModifiedBy { get; set; }

        public virtual ReservationCustomer ReservationCustomer { get; set; }
        public virtual ReservationRecipient ReservationRecipient { get; set; }
        public virtual ICollection<ReservationCard> ReservationCards { get; set; }
        public virtual ICollection<ReservationLineItemGroup> ReservationLineItemGroups { get; set; }
        public virtual ICollection<ReservationLineItem> ReservationLineItems { get; set; }
    }
}
