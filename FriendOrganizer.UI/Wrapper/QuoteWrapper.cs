using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FriendOrganizer.Model;

namespace FriendOrganizer.UI.Wrapper
{
    public class QuoteWrapper : ModelWrapper<Quote>
    {
        public QuoteWrapper(Quote model) : base(model)
        {
        }

        public string Author
        {
            get => GetValue<string>();
            set => SetValue(value);
        }

        public string QuoteText
        {
            get => GetValue<string>();
            set => SetValue(value);
        }
    }
}
