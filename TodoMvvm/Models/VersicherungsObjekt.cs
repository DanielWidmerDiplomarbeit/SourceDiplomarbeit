using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace ZeusMobile.Models
{



    public class Versicherungsobjekt
    {

        public enum enumBauart
        {
            Voll = 1,
            Teilweise = 2
        }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }


        [ForeignKey(typeof(Police))]
        public int PoliceId { get; set; }

        [ForeignKey(typeof(SchadenProtokoll))]
        public int SchadenProtokollId { get; set; }
        
        [MaxLength(10)]
        [Unique]
        public string ObjektId { get; set; }

        [MaxLength(50)]
        public string Bezeichnung { get; set; }
        
        public string Hydrant { get; set; }
        
        public enumBauart Bauart { get; set; }
    }
}