using System.ComponentModel.DataAnnotations;

namespace t5_pr1_LlucVelazquez.ModelP
{
    public class WaterConsume
    {
        [Key]
		public int Id { get; set; }
        public string Region { get; set; }
        public string Town { get; set; }
		public int Year { get; set; }
        public int Consume { get; set; }
    }
}