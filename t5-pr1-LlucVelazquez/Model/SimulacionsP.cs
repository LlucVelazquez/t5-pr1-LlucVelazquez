namespace t5_pr1_LlucVelazquez.Model
{
    public enum TypeSim
    {
        SolarSystem,
        EolicSystem,
        HidroelectricSystem
    }
    public class SimulacionsP
    {
        public int Id { get; set; } 
        public TypeSim Type { get; set; }
        public double HoresSol { get; set; }
        public double VelocitatVent { get; set; }
        public double CabalAigua { get; set; }
        public double Rati { get; set; }
        public double EnergyGen { get; set; }
        public decimal CostTotal { get; set; }
        public decimal PreuTotal { get; set; }
        public DateTime Date { get; set; }
    }
}
