using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.Json;

namespace Timer.Server.Negocio;

public class User
{
    public static User Crear(
        int id,
        string nombre,
        string constrasena)
    {
        return new User(id, nombre, constrasena);   
    }
    private User(int id, string nombre, string contrasena)
    {
        Id = id;
        Nombre = nombre;
        Contrasena = contrasena;
        Timers = new List<Timer>();
    }

    public int Id { get;  }
    public string Nombre { get; }  
    public string Contrasena { get; }
    
    public ICollection<Timer> Timers { get;}
    
    
    
    
    
    
    
}