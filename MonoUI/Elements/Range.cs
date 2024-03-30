namespace MonoUI.Elements
{
    /// <summary>
    /// Defines a range of values.
    /// </summary>
    internal readonly struct Range
    {
        public float Min { get; }
        public float Max { get; }
        /// <summary>
        /// Define a new range of values.
        /// </summary>
        public Range(float min, float max)
        {
            Min = min;
            Max = max;
        }

        public float Lerp(float value) => Min * (1 - value) + Max * value;

        /// <summary>
        /// Returns true if <paramref name="value"/> exists within range. Consider using the <![CDATA[>]]> or <![CDATA[>=]]> operators instead.
        /// </summary>
        public bool Includes(float value) => Min <= value && Max >= value;
        /// <summary>
        /// Returns true if <paramref name="value"/> doesn't exist within range. Consider using the <![CDATA[<]]> or <![CDATA[<=]]> operators instead.
        /// </summary>
        public bool Excludes(float value) => Min > value && Max < value;

        /// <summary>
        /// Evaluates whether the given value <paramref name="f"/> exists within the given <see cref="Range"/> <paramref name="r"/>. (Exclusive)
        /// </summary>
        public static bool operator >(float f, Range r) => f > r.Min && f < r.Max;
        /// <summary>
        /// Evaluates whether the given value <paramref name="f"/> does not exist within the given <see cref="Range"/> <paramref name="r"/>. (Exclusive)
        /// </summary>
        public static bool operator <(float f, Range r) => !(f >= r);
        /// <summary>
        /// Evaluates whether the given value <paramref name="f"/> exists within the given <see cref="Range"/> <paramref name="r"/>. (Inclusive)
        /// </summary>
        public static bool operator >=(float f, Range r) => f >= r.Min && f <= r.Max;
        /// <summary>
        /// Evaluates whether the given value <paramref name="f"/> does not exist within the given <see cref="Range"/> <paramref name="r"/>. (Inclusive)
        /// </summary>
        public static bool operator <=(float f, Range r) => !(f > r);
    }
}
