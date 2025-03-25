﻿using System.ComponentModel.DataAnnotations;

namespace t5_pr1_LlucVelazquez.ModelP
{
	public class Simulation
	{
		[Key]
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
