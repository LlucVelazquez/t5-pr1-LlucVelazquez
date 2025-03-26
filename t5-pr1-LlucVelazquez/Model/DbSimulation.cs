using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace t5_pr1_LlucVelazquez.Model
{
	public class DbSimulation
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public string TypeSim { get; set; }
		public float HoresSol { get; set; }
		public float VelocitatVent { get; set; }
		public float CabalAigua { get; set; }
		public float Rati { get; set; }
		public float EnergyGen { get; set; }
		public float CostTotal { get; set; }
		public float PreuTotal { get; set; }
		public DateTime DateT { get; set; }
	}
}
