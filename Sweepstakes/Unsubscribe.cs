using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepstakes
{
    internal class Unsubscribe : IDisposable
    {
        private Dictionary<int, Contestant> contestants;
        private Contestant contestant;

        internal Unsubscribe(Dictionary<int, Contestant> contestants, Contestant contestant)
        {
            this.contestants = contestants;
            this.contestant = contestant;
        }

        public void Dispose()
        {
            int indexOfContestant = 0;
            for (int i = 0; i < contestants.Count; i++)
            {
                indexOfContestant = i;
                if (contestants[i] == contestant)
                {
                    contestants.Remove(i);
                    break;
                }
            }
            //Re-sort dictionary so there are no gaps in incremental numeric key continuity
            for(int i = indexOfContestant; i < contestants.Count + 1; i++)
            {
                Contestant temporaryContestant = contestants[i + 1];
                contestants.Remove(i + 1);
                contestants.Add(i, temporaryContestant);
            }
        }
    }
}
