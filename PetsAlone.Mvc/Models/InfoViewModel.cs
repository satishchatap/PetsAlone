using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetsAlone.Mvc.Models
{
    public class InfoViewModel
    {
        public string Message { get; set; } = string.Empty;
        public InfoType Type { get; set; }
        public string Title { get; set; } = string.Empty;
        public bool IsMessageEmpty => string.IsNullOrEmpty(Message);
        public string CssClass => $"text-{ Type.ToString().ToLower()}";

        public InfoViewModel(string message,InfoType infoType, string title = "")
        {
            Message = message;
            Title = title;
            Type = infoType;
        }
    }
    public enum InfoType
    {
        Error=0,
        Info=1,
        Warning=2
    }
}
