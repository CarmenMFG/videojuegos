
namespace Videogames.Business.DOModels
{
   public class UserDO
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string User { get; set; }
       /* public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }*/
        public int IdRol { get; set; }
        public string Rol { get; set; }
        public string VideoGames { get; set; }
    }
}
