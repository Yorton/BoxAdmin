using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxAdmin.Application.Features.Subscribes.Queries.GetSubscribeById
{
    public class GetSubscribeByIdResponse
    {
        public Guid Id { get; set; }
        public string SubscribeNo { get; set; }
        public int SubscriptionPlanId { get; set; }
        public Guid CustomerId { get; set; }
        public string CreatedMethod { get; set; }
        public string DueDate { get; set; }
        public string State { get; set; }
        public string Suspend { get; set; }
        public string SuspendDate { get; set; }
        public string CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedAt { get; set; }
        public string ModifiedBy { get; set; }
        public List<SubscribeReservation> Reservations { get; set; }
    }

    public class SubscribeReservation
    {
        public Guid Id { get; set; }
        public string BoxNo { get; set; }
    }
}
