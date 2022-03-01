using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Annotations;

namespace BoxAdmin.Application.Features.Reservations.Queries.GetCardMessageTemplate
{
    public class GetCardMessageTemplateResponse
    {
        public List<CardMessageTemplateListItem> Items { get; set; } = new List<CardMessageTemplateListItem>();
    }

    public class CardMessageTemplateListItem
    {
        [SwaggerSchema("標題")] public string Title { get; set; }
        [SwaggerSchema("說明")] public string MessageText { get; set; }
    }
}
