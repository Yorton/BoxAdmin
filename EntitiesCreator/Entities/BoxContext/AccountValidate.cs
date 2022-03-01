using System;
using System.Collections.Generic;

#nullable disable

namespace BoxAdmin.Domain.Entities.BoxContext
{
    public partial class AccountValidate
    {
        public string Account { get; set; }
        public string ValidateCode { get; set; }
        public int ValidateCodeSendCount { get; set; }
        public DateTime ValidateCodeSendDate { get; set; }
        public int ValidateCheckCount { get; set; }
        public bool Valid { get; set; }
        public int ValidateType { get; set; }
    }
}
