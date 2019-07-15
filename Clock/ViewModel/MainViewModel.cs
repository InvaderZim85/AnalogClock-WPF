using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Timers;
using System.Windows.Navigation;
using System.Windows.Threading;
using Clock.Model;
using ZimLabs.WpfBase;

namespace Clock.ViewModel
{
    internal class MainViewModel : ObservableObject
    {
        /// <summary>
        /// Contains the timer for the clock
        /// </summary>
        private readonly DispatcherTimer _timer = new DispatcherTimer();

        /// <summary>
        /// Contains the timer for the clock
        /// </summary>
        private readonly Timer _clockTimer = new Timer(1000);

        #region Properties for the view
        /// <summary>
        /// Gets or sets the hour parts
        /// </summary>
        public List<ClockPart> HourParts { get; set; }

        /// <summary>
        /// Get sor sets the second parts
        /// </summary>
        public List<ClockPart> SecondParts { get; set; }

        /// <summary>
        /// Backing field for <see cref="AngleHour"/>
        /// </summary>
        private double _angleHour;
        /// <summary>
        /// Gets or sets the angle of the hour hand
        /// </summary>
        public double AngleHour
        {
            get => _angleHour;
            set => SetField(ref _angleHour, value);
        }

        /// <summary>
        /// Backing field for <see cref="AngleMin"/>
        /// </summary>
        private double _angleMin;
        /// <summary>
        /// Gets or sets the angle of the minute hand
        /// </summary>
        public double AngleMin
        {
            get => _angleMin;
            set => SetField(ref _angleMin, value);
        }

        /// <summary>
        /// Backing field for <see cref="AngleSec"/>
        /// </summary>
        private double _angleSec;
        /// <summary>
        /// Gets or sets the angle of the seconds hand
        /// </summary>
        public double AngleSec
        {
            get => _angleSec;
            set => SetField(ref _angleSec, value);
        }

        /// <summary>
        /// Backing field for <see cref="DateTime"/>
        /// </summary>
        private string _dateTimeValue = DateTime.Now.ToString("G"); 

        /// <summary>
        /// Gets or sets the current date / time
        /// </summary>
        public string DateTimeValue
        {
            get => _dateTimeValue;
            set => SetField(ref _dateTimeValue, value);
        }
        #endregion

        /// <summary>
        /// Creates a new instance of the <see cref="MainViewModel"/>
        /// </summary>
        public MainViewModel()
        {
            HourParts = ClockPart.GetHourParts();

            SecondParts = ClockPart.GetSecondParts();

            _clockTimer.Elapsed += _clockTimer_Elapsed;
            _clockTimer.Start();
        }

        /// <summary>
        /// Occurs when the timer elapsed
        /// </summary>
        private void _clockTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            var time = DateTime.Now;
            DateTimeValue = time.ToString("G");
            AngleHour = GetAccurateAngle(time, true);
            AngleMin = GetAccurateAngle(time, false);
            AngleSec = time.Second * (360 / 60);
        }

        /// <summary>
        /// Calculates the accurate angle for the hour
        /// </summary>
        /// <param name="time">The current time</param>
        /// <param name="hour">true to calculate the hour, false to calculate the minutes</param>
        /// <returns>The angle</returns>
        private double GetAccurateAngle(DateTime time, bool hour)
        {
            var decimalValue = hour ? 1d / 60 * time.Minute : 1d / 60 * time.Second;

            double result;
            if (hour)
                result = (time.Hour + decimalValue) * (360d / 12);
            else
                result = (time.Minute + decimalValue) * (360d / 60);

            return result;
        }
    }
}
