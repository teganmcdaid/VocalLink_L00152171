using Microsoft.Maui.Controls;
using SQLite;

namespace VocalLink_L00152171.Model
{
    public class Booking
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string SingerEmail { get; set; }
        public string SingerName { get; set; }
        public string BusinessEmail { get; set; }
        public DateTime Date { get; set; }

        //to check status of booking 
        public String Status { get; set; }

    }
}