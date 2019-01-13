using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer
{
    public class Song : IComparable
    {
        public int Duration;
        public string Name;
        public Artist Artist;
        public Album Album;

        public int CompareTo(object obj)
        {
            return this.Name?.CompareTo((obj as Song).Name) ?? 0;
            
        }

        [Flags]
        enum Genres {
            Rock = 0b00000001,
            Classic = 0b00000010,
            Rap = 0b00000100,
            Electro = 0b00001000,
            Country = 0b00010000
        };


       

    }
}
