using System.Collections.Generic;

namespace KnockKnockServer
{
    public class Joke
    {
        public int JokeId { get; set; }
        public List<Line> Lines { get; set; }
    }

    public class Line
    {
        public string Request { get; set; }
        public string Response { get; set; }
    }
}