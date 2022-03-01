using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Annotations;

namespace BoxAdmin.Application.Features.Customers.Queries.GetCustomerById
{
    public class GetCustomerByIdResponse
    {
        [SwaggerSchema("會員ID")] public Guid Id { get; set; }
        [SwaggerSchema("姓名")] public string Name { get; set; }
        [SwaggerSchema("性別(男/女)")] public string Sex { get; set; }
        [SwaggerSchema("生日")] public DateTime Birthday { get; set; }
        [SwaggerSchema("電話")] public string Mobile { get; set; }
        [SwaggerSchema("Email")] public string Email { get; set; }
        [SwaggerSchema("郵遞區號")] public string Zip { get; set; }
        [SwaggerSchema("城市")] public string City { get; set; }
        [SwaggerSchema("地區")] public string Region { get; set; }
        [SwaggerSchema("地址")] public string Address { get; set; }
        [SwaggerSchema("國家")] public string Country { get; set; }
        [SwaggerSchema("問卷記錄")] public List<CustomerSurveyGroup> SurveyGroups { get; set; }
    }

    public class CustomerSurveyGroup
    {
        [SwaggerSchema("問卷編號")]
        public string Id { get; set; }
        [SwaggerSchema("名稱")]
        public string GroupName { get; set; }
        [SwaggerSchema("Items")]
        public List<CustomerSurvey> Items { get; set; }
    }

    public class CustomerSurvey
    {
        public string Title { get; set; }
        public string Answer { get; set; }
    }
}
