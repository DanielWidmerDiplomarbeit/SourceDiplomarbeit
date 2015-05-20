using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace ZeusMobile.Models
{
	public class SchadensExperte
	{
        [MaxLength(20)]
        [ForeignKey (typeof(Subject)) ]
        public int Id { get; set; }

        [OneToOne(CascadeOperations = CascadeOperation.All)]
        public Subject Subject { get; set; }
        
        [MaxLength(20)]
		public int ExpertenNr { get; set; }
	}
}