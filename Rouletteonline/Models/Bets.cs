using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Rouletteonline
{
    public class Bets
    {
        /// <summary>
        /// Position of the squares 0-36
        /// </summary>
        [Range(0, 36)]
        public int position { get; set; }

        /// <summary>
        /// range money
        /// </summary>
        [Range(0.5, maximum: 10000)]
        public double money { get; set; }
    }
}
