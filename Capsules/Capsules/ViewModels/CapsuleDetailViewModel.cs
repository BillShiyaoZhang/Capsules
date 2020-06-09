using System;

using Capsules.Models;

namespace Capsules.ViewModels
{
    public class CapsuleDetailViewModel : BaseViewModel
    {
        public Capsule Item { get; set; }
        public CapsuleDetailViewModel(Capsule item = null)
        {
            Title = item?.Title;
            Item = item;
        }
    }
}
