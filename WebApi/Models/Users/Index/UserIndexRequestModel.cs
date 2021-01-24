namespace WebApi.Models.Users.Index
{
    public class UserIndexRequestModel
    {
        public int Page { get; set; }
        public int DisplayCount { get; set; }
        public string Search { get; set; }
    }
}