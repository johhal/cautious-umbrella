
public class PlayerStats{
    public float Max_Stamina;
    public float Current_Stamina;
    public float Stamina_Regen;

    public PlayerStats(float Max_Stamina, float Current_Stamina, float Stamina_Regen)
    {
        this.Max_Stamina = Max_Stamina;
        this.Current_Stamina = Current_Stamina;
        this.Stamina_Regen = Stamina_Regen;
    }
    
	public void Regenerate_Stamina()
    {
        Current_Stamina += Stamina_Regen;
        if (Current_Stamina > Max_Stamina)
        {
            Current_Stamina = Max_Stamina;
        }
    }
}
