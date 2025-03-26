using CsvHelper.Configuration.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace t5_pr1_LlucVelazquez.ModelP
{
	public class EnergyIndicator
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public int Year { get; set; }
		public float ProdNeta { get; set; }
		public float ConsumGasoil { get; set; }
		public float DemandaElectr { get; set; }
		public float ProdDisp { get; set; }
	}
}