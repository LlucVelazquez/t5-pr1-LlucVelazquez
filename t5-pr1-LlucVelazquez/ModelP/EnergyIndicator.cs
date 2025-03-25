using CsvHelper.Configuration.Attributes;
using System.ComponentModel.DataAnnotations;

namespace t5_pr1_LlucVelazquez.ModelP
{
	public class EnergyIndicator
	{
		[Key]
		public int Id { get; set; }
		public int Year { get; set; }
		public decimal ProdNeta { get; set; }
		public decimal ConsumGasoil { get; set; }
		public decimal DemandaElectr { get; set; }
		public decimal ProdDisp { get; set; }
	}
}