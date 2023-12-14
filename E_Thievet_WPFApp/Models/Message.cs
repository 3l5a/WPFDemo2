using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Thievet_WPFApp.Models
{
    public class Message : INotifyPropertyChanged
    {
        public string Content { get; set; } = null!;
        public string Emitter { get; set; } 
        public DateTime Date { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public override string ToString()
        {
            return "Le "+Date+ ", vous avez reçu un message de "+Emitter+". Iel vous dit : "+Content;
        }

        public Message()
        {
            Content = ""; 
            Emitter = string.Empty;
            Date = DateTime.Now;
        }
    }
}
