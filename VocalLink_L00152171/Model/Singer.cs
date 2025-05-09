
using SQLite;

namespace VocalLink_L00152171.Model
{
    public class Singer
    {
        [PrimaryKey]
        public string UserEmail { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public string Location { get; set; }    
        public string AboutMe { get; set; }
    }
}