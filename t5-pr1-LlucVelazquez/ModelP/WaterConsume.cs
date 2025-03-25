using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace t5_pr1_LlucVelazquez.ModelP
{
    public class WaterConsume
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
        public string Region { get; set; }
        public string Town { get; set; }
		public int Year { get; set; }
        public int Consume { get; set; }
    }
}