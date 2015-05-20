using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace ZeusMobile.Models
{
    public class Subject
    {
        [MaxLength(20)]
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(20)]
        public string Rolle { get; set; }
        
        [MaxLength(20)]
        public string Name { get; set; }


        //[MaxLength(20)]
        //[ForeignKey(typeof(Versicherter))]
        //public int VersicherterId { get; set; }

        //[MaxLength(20)]
        //[ForeignKey(typeof(SchadensExperte))]
        //public int SchadensExperteId { get; set; }

        //[OneToOne]
        //public Versicherter Versicherter { get; set; }

        //[OneToOne]
        //public SchadensExperte SchadensExperte { get; set; }
    }
}