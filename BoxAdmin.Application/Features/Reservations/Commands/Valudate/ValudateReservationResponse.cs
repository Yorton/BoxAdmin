using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Annotations;

namespace BoxAdmin.Application.Features.Reservations.Commands.Valudate
{
    public class ValudateReservationResponse
    {
        [SwaggerSchema("異常清單")]
        public IList<ValudateReservationResponse_ValidateResult> ValidateResults { get; set; } = new List<ValudateReservationResponse_ValidateResult>();
    }

    public class ValudateReservationResponse_ValidateResult
    {
        [SwaggerSchema("商品編號")] public string Sku { get; set; }
        [SwaggerSchema("商品名稱")] public string Name { get; set; }
        [SwaggerSchema("說明")] public string Reason { get; set; }
        public ValudateReservationResponse_ValidateResult() { }
        public ValudateReservationResponse_ValidateResult(string sku, string name, string reason)
        {
            Sku = sku;
            Name = name;
            Reason = reason;
        }
    }
}
