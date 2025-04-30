
using SQLite;

namespace VocalLink_L00152171.Model
{
    public class User
    {
        [PrimaryKey]
        public string UserEmail { get; set; }
        public string Password { get; set; }
        public bool IsSinger { get; set; }
    }
}
