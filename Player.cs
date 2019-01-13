﻿using MusicPlayer.extentions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer
{
    public class Player
    {
        const int MIN_VOLUME = 0;
        const int MAX_VOLUME = 100;

        private bool _isLocked;

        private bool _isPlaying;
         

        private int _volume;
        public int Volume
        {
            get
            {
                return _volume;
            }

            private set
            {
                if (value < MIN_VOLUME)
                {
                    _volume = MIN_VOLUME;
                }
                else if (value > MAX_VOLUME)
                {
                    _volume = MAX_VOLUME;
                }
                else
                {
                    _volume = value;
                }
            }
        }

        public List<Song> Songs { get; private set; } = new List<Song>();

        public void VolumeUp()
        {
            if (_isLocked == false)
            {
                Volume++;
            }
        }

        public void VolumeDown()
        {
            if (_isLocked == false)
            {
                Volume--;
            }
        }

        public void VolumeChange( int step)
        {
            if (_isLocked == false)
            {
                Volume += step;
            }
        }

        public void Play()
        {
            if (_isLocked)
            {
                return;
            }
            _isPlaying = true;
            for (int i = 0; i < Songs.Count; i++)
            {
                if (i % 2 == 0) { Songs[i].DisLike(); }                
                if (Songs[i]._isLiked == true)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Player is playing: {Songs[i].Name}, duration: {Songs[i].Duration}");
                    System.Threading.Thread.Sleep(1000);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Player is playing: {Songs[i].Name}, duration: {Songs[i].Duration}");
                    System.Threading.Thread.Sleep(1000);
                }

            }
        }

        public void Stop()
        {
            if (_isLocked)
            {
                return;
            }
            _isPlaying = false;
            Console.WriteLine("Player has stopped");
        }

        public void Locked()
        {
            _isLocked = true;
            Console.WriteLine("Player is locked");
        }
        public void Unlock()
        {
            _isLocked = false;
            Console.WriteLine("Player is unlocked");
        }

        public void Add(params Song[] songArr)
        {
            Songs.AddRange(songArr);
        }

        //SHUFFLE
        public void Shuffle()
        {
            this.Songs.Shuffle();
            
        }

        public void Sort()
        {

            Songs.Sort();


        }
    }
}
