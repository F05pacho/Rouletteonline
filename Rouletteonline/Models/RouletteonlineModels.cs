using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rouletteonline.Models
{
    public class Rouletteonline
    {
        [Serializable]
        public class Rouletteonline
        {
            //variable id string
            public string Id { get; set; }

            //variable Isopen bool
            public bool IsOpen { get; set; }

            //variable Openbet Datatime
            public DateTime? Openbet { get; set; }

            //variable Openbet Datatime
            public DateTime? Closebet { get; set; }

            //variable board Idictionary
            public IDictionary<string, double>[] board {get; set;} = new IDictionary<string, double>[39];

            public Rouletteonline()
            {
                this.Init();
            }

            private void Init()
            {
                for(int i = 0;i < board.Length;i++)
                {
                    board[i] = new Dictionary<string, double>();

                }
            }

    
    }
}
