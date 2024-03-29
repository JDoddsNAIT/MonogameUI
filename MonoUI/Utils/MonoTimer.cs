using Microsoft.Xna.Framework;
using System;

namespace JDoddsUI
{
    public class MonoTimer
    {
        #region Fields
        private double _timerLength;
        private double _timerValue;
        private TimeUnits _timeUnits;
        private bool _isRunning = false;
        #endregion

        #region Properties
        /// <summary>
        /// The amount of time the timer will run for.
        /// </summary>
        public double TimerLength
        {
            get => _timerLength;
            private set => _timerLength = value;
        }

        /// <summary>
        /// The amount of time elapsed since the timer started.
        /// </summary>
        public double TimeElapsed
        {
            get => _timerValue;
            private set => _timerValue = value > _timerLength ? _timerLength : value;
        }

        /// <summary>
        /// The amount of time remaining.
        /// </summary>
        public double TimeRemaining => TimerLength - TimeElapsed;
        //
        /// <summary>
        /// The units of time the timer will count in.
        /// </summary>
        public TimeUnits Units
        {
            get => _timeUnits;
            private set => _timeUnits = value;
        }

        /// <summary>
        /// Returns the time remaining represented as a <see cref="double"/> from 0 - 1.
        /// </summary>
        public double RemainingRange => TimeRemaining / TimerLength;

        /// <summary>
        /// The amount of time elapsed represented as a value from 0 - 1.
        /// </summary>
        public double ElapsedRange => TimeElapsed / TimerLength;
        public bool TimerFinished => TimeElapsed == TimerLength;

        public static TimeUnits Milliseconds => TimeUnits.Milliseconds;
        public static TimeUnits Seconds => TimeUnits.Seconds;

        public bool IsRunning { get => _isRunning; private set => _isRunning = value; }
        #endregion

        #region Methods
        /// <summary>
        /// Instantiate a new <see cref="MonoTimer"/> with a <paramref name="length"/> in <see cref="TimeUnits"/>
        /// </summary>
        /// <param name="length">The length of the timer.</param>
        /// <param name="units">The units to count in.</param>
        public MonoTimer(double length, TimeUnits units)
        {
            TimerLength = length;
            _timeUnits = units;
            Reset();
        }

        #region Monogame Methods
        /// <summary>
        /// Increments the <see cref="TimeElapsed"/> by <paramref name="gameTime"/>
        /// </summary>
        /// <param name="gameTime"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void Update(GameTime gameTime)
        {
            if (gameTime is null)
            {
                throw new ArgumentNullException(nameof(gameTime));
            }

            if (IsRunning)
            {
                TimeElapsed += AddTimeInUnits(gameTime.ElapsedGameTime, Units);
                IsRunning = !TimerFinished;
            }
        }
        #endregion

        private static double AddTimeInUnits(TimeSpan time, TimeUnits units) => units switch
        {
            TimeUnits.Seconds => time.TotalSeconds,
            TimeUnits.Milliseconds => time.TotalMilliseconds,
            _ => throw new ArgumentOutOfRangeException(nameof(units)),
        };
        /// <summary>
        /// Starts/resumes the current timer.
        /// </summary>
        public void Start() => IsRunning = true;

        /// <summary>
        /// Pauses the current timer.
        /// </summary>
        public void Stop() => IsRunning = false;

        /// <summary>
        /// Resets the timer to 0.
        /// </summary>
        public void Reset() => TimeElapsed = 0;

        public override string ToString()
        {
            return $"{TimeElapsed}/{TimerLength}\n{TimeRemaining}/{TimerLength}";
        }
        #endregion
    }
}
