namespace Timer.Server.Negocio;

public class Timer
{

    private Timer(int id, User user)
    {
        Id = id;
        User = user;
    }
    public  int Id { get; }
    public int UserId { get; set; }

    public User User { get; set; }
    
    
    
}