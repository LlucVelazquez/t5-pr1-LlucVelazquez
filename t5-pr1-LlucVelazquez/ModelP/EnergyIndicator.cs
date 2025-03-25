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
		public decimal ProdNeta { get; set; }
		public decimal ConsumGasoil { get; set; }
		public decimal DemandaElectr { get; set; }
		public decimal ProdDisp { get; set; }
	}
}