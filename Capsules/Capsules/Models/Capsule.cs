using System;
using System.ComponentModel.DataAnnotations;

namespace Capsules.Models
{
    public class Capsule
    {
        public string Id { get; private set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Due { get; set; }
        public bool IsDraft { get; set; }
        public string DisplayDue => Due.ToString("f");
        public bool IsSealable
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(Id) &&
                    Id != default(string) &&
                    !string.IsNullOrWhiteSpace(Title) &&
                    Title != default(string) &&
                    Due != default(DateTime))
                    return true;
                return false;
            }
        }

        public Capsule()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}