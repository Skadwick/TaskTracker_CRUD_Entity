namespace TaskTracker_CRUD.Server.Models
{
    public class RedditComments
    {
        public int Id { get; set; }
        public string Postid { get; set; }
        public string Permalink { get; set; }
        public string Date { get; set; }
        public string Ip {  get; set; }
        public string Subreddit { get; set; }
        public int Gildings { get; set; }
        public string Link {  get; set; }
        public string Parent {  get; set; }
        public string Body {  get; set; }
        public string Media { get; set; }
    }
}
