public class Video
{
    private string _title;
    private string _author;
    private double _length;

    private List<Comment> _comments = new List<Comment>();

    public Video(string title, string author, double length)
    {
        _title = title;
        _author = author;
        _length = length;

    }

    public Video(string title, string author, double length, List<Comment> comments)
    {
        _title = title;
        _author = author;
        _length = length;
        _comments = new List<Comment>(comments);
    }

    public void Display()
    {
        Console.WriteLine($"Title: {_title}");
        Console.WriteLine($"Author: {_author}");
        Console.WriteLine($"Length: {_length}");
        Console.WriteLine($"Number of comments: {GetNumberOfComments()}");
        Console.WriteLine(new String('-', 50));
        Console.WriteLine("COMMENTS:");
        for (int i = 0; i < _comments.Count; i++)
        {
            Console.WriteLine(_comments[i].Display());

            if (i == _comments.Count - 1)
            {
                Console.WriteLine(new String('-', 50));
            }
            else
            {
                Console.WriteLine("---");
            }
        }
    }

    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    public int GetNumberOfComments()
    {
        return _comments.Count;
    }
}