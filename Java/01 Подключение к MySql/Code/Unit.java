package BD;

public class Unit 
{
	public int id;				//����� ������
	public String FIO;			//��� ������
	public String Country;		//�����
	public int Roles;			//��������� ����
	public int Films;			//��������������� ������
	public int Gonorar;			//����� ������� �������
	public int Rape;			//��������� � ����������
	
	
	Unit(int i, String FIO, String c, int r, int f, int g, int h)	//�����������
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
