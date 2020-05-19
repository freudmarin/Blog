namespace Blog.Models.Comments
{
    public class SubComments:Comment
    {
        public int MainCommentId { get; set; }
    }
}