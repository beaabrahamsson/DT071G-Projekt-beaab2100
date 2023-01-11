using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuestBook.Models
{
    internal class About
    {
        public string Title => AppInfo.Name;
        public string Version => AppInfo.VersionString;
        public string MoreInfoUrl => "https://aka.ms/maui";
        public string Message => "Detta är en Gästbok skapad för kursen Programmering i C#.NET. Appen är skapad med XAML och C# med .NET MAUI. För mer information samt källkod, se länk nedan.";
    }
}
