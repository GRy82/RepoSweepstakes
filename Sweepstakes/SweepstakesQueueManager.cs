﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepstakes
{
    public class SweepstakesQueueManager : ISweepstakesManager
    {
        public Queue<Sweepstakes> queue = new Queue<Sweepstakes> { };
        public void InsertSweepstakes(Sweepstakes sweepstakes)
        {

        }

        public Sweepstakes GetSweepstakes()
        {
            Sweepstakes sweepstakes;
            return sweepstakes;

        }
    }
}
