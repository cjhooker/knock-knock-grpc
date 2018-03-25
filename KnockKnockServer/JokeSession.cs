namespace KnockKnockServer
{
    public class JokeSession
    {
        public int JokeSessionId {get;set;}

        public Joke Joke {get;set;}

        public int LastLineIndex {get;set;}
    }
}