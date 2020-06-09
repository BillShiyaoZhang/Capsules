using System;
using System.ComponentModel.DataAnnotations;

namespace Capsules.Models
{
    public class Capsule
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Due { get; set; }
        public bool IsDraft { get; set; }
    }
}