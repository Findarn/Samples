package BD;

public class Unit 
{
	public int id;				//номер записи
	public String FIO;			//ФИО актера
	public String Country;		//Стран
	public int Roles;			//сыгранные роли
	public int Films;			//срежисированные фильмы
	public int Gonorar;			//самый большой гонорар
	public int Rape;			//обвинения в харасменте
	
	
	Unit(int i, String FIO, String c, int r, int f, int g, int h)	//конструктор
	{
		this.id = i;
		this.FIO = FIO;
		this.Country = c;
		this.Roles = r;
		this.Films = f;
		this.Gonorar = g;
		this.Rape = h;					
	}
}
