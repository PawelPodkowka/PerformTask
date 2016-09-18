

namespace PerformTask.Common.Model
{
    public class Connection
    {
        public int From { get; private set; }
        public int To { get; private set; }

        public Connection(int from, int to)
        {
            From = from;
            To = to;
        }
    }
}
