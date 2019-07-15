using System.Collections.Generic;

namespace Clock.Model
{
    internal class ClockPart
    {
        /// <summary>
        /// Gets or sets the number
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Gets or sets the angle
        /// </summary>
        public int Angle { get; set; }

        public ClockPart() { }

        /// <summary>
        /// Creates a new instance of the <see cref="ClockPart"/>
        /// </summary>
        /// <param name="number">The number</param>
        /// <param name="angle">The angle</param>
        public ClockPart(string number, int angle)
        {
            Number = number;
            Angle = angle;
        }

        /// <summary>
        /// Gets the parts for the hours
        /// </summary>
        /// <returns>The list with the parts</returns>
        public static List<ClockPart> GetHourParts()
        {
            return GetParts(12);
        }

        /// <summary>
        /// Gets the parts for the seconds
        /// </summary>
        /// <returns>The list with the second parts</returns>
        public static List<ClockPart> GetSecondParts()
        {
            return GetParts(60);
        }

        /// <summary>
        /// Calculates the parts for the given amount
        /// </summary>
        /// <param name="amount">The amount (e.G. 60 for seconds, 12 for hours)</param>
        /// <returns>The list with the parts</returns>
        private static List<ClockPart> GetParts(int amount)
        {
            var tmpList = new List<ClockPart>();

            for (var i = 1; i < amount + 1; i++)
            {
                tmpList.Add(new ClockPart(i.ToString(), i * (360/amount)));
            }

            return tmpList;
        }
    }
}
