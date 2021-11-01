using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockBuster
{
    class VHSTape
    {
        private string _movieName;
        private int _movieLength, _playedTime;
        private bool _isRented;
        public string MovieName
        {
            get { return _movieName; }
            set
            {
                _movieName = value;
            }
        }
        public int MovieLength
        {
            get { return _movieLength; }
            set
            {
                _movieLength = value;
            }
        }
        public int PlayedTime
        {
            get { return _playedTime; }
            set
            {
                _playedTime = value;
            }
        }
        public bool IsRented
        {
            get { return _isRented; }
            set
            {
                _isRented = value;
            }
        }
        public VHSTape()
        {

        }
        public VHSTape(string name, int length)
        {
            this.MovieName = name;
            this.MovieLength = length;
            this.IsRented = false;
            this.PlayedTime = 0;
        }
    }
}
