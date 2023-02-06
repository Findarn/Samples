package streams;

import java.awt.geom.Point2D;
import java.util.Random;
import java.awt.Point;

public class Grinch extends Thread
{
	int num;	
	int w = 32;
	int h = 32;
	int wp = 800;
	int hp = 800;
	// текущие координаты
	Point2D p0 = new Point();
	// координаты вектора смещения
	double bx = 1.0;	// так как направление движения хаотично, конечной цели движения нет
	double by = 1.0;	// значит вектор смещения нужно задать произвольно
	double dx;
	double dy;
	
	int speed;			// скорость движения
	int dir;			// направление движения от 0 до 8 включительно
	int timer;			// время, через которое меняется направление
	
	Main parent;
	boolean ended;
	
	public Grinch(int num, Main parent)
	{
		super("Gift" + (num+1));
		this.num = num;
		this.ended = false;
		this.parent = parent;
		this.dir = 0;
		
	}
	
	public void SetStart(int speed, double timer, Point2D Start)
	{
		p0 = Start;
		this.timer = (int)(timer * 1000);
		dx = bx * (double)speed * 2;
		dy = by * (double)speed * 2;
	}
	
	public void end()
	{
		this.ended = true;
	}
	
	public int GetX()
	{
		return (int)Math.round(this.p0.getX() - this.w / 2.0);
	}
	
	public int GetY()
	{
		return (int)Math.round(this.p0.getY() - this.h / 2.0);
	}
	
	@Override
	public void run()
	{
		int N = 0;
		while (true)
		{
			if (this.ended == true)
				break;
			
			if (N >= this.timer)
			{
				Random R = new Random();
				this.dir = R.nextInt(0,9);
				N = 0;
			}
			switch (dir)
			{
			case 0: break;
			case 1: if (this.p0.getY() + dy <= 790)
				this.p0.setLocation(this.p0.getX(), this.p0.getY() + dy); break;
			case 2: if (this.p0.getY() - dy >= 10)
				this.p0.setLocation(this.p0.getX(), this.p0.getY() - dy); break;
			case 3: if (this.p0.getX() + dx <= 790)
				this.p0.setLocation(this.p0.getX() + dx, this.p0.getY()); break;
			case 4: if (this.p0.getY() + dy <= 790 && this.p0.getX() + dx <= 790)
				this.p0.setLocation(this.p0.getX() + dx, this.p0.getY() + dy); break;
			case 5: if (this.p0.getY() - dy >= 10 && this.p0.getX() + dx <= 790)
				this.p0.setLocation(this.p0.getX() + dx, this.p0.getY() - dy); break;
			case 6: if (this.p0.getX() - dx >= 10)
				this.p0.setLocation(this.p0.getX() - dx, this.p0.getY()); break;
			case 7: if (this.p0.getY() + dy <= 790 && this.p0.getX() - dx >= 10)
				this.p0.setLocation(this.p0.getX() - dx, this.p0.getY() + dy); break;
			case 8: if (this.p0.getY() - dy >= 10 && this.p0.getX() - dx >= 10)
				this.p0.setLocation(this.p0.getX() - dx, this.p0.getY() - dy); break;
			}
			try 
			{
				Grinch.sleep(30); N += 30;
			}
			catch (InterruptedException ex)
			{
				System.out.println("Error: " + ex.getMessage());
			}
		}
	}
}
