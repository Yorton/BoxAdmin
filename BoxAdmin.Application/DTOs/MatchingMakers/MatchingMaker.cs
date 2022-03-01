using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxAdmin.Application.DTOs.MatchingMakers
{
    public class MatchingMaker
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PictureUrl { get; set; }
        public string SignatureUrl { get; set; }
        public string SelfIntroduction { get; set; }
        public string Slogan { get; set; }
        public string LikeStyle { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Creator { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string Modifier { get; set; }
    }
}
