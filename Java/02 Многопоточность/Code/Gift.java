package streams;


import java.awt.geom.Point2D;
import java.util.Random;
import java.awt.Point;

public class Gift extends Thread 
{
	int num;	
	int w = 32;
	int h = 32;
	int wp = 800;
	int hp = 800;
	//координаты рождения
	Point2D pS = new Point();
	// текущие координаты
	Point2D p0 = new Point();		
	// координаты цели
	Point2D p1 = new Point();
	// векторы смещения
	Point2D dp1 = new Point();	// вектор смещения к 1 углу - левый верхний угол
	Point2D dp2 = new Point();	// вектор смещения к 2 углу - правый верхний угол
	Point2D dp3 = new Point();	// вектор смещения к 3 углу - нижний левый угол
	Point2D dp4 = new Point();	// вектор смещения к 4 углу - нижний правый угол
	// координаты прямоугольника - области существования подарков
	Point2D LTp = new Point();	// левый верхний угол области
	Point2D RBp = new Point();	// правый нижний угол области
	int speed;		// скорость движения
	int dir;		// переменная выбора углов
	int dirTo;		// 1 - движение к углу, 0 - движение к точке рождения
	
	Main parent;
	
	boolean ended;
	
	public Gift(int num, Main parent)	// конструктор по умолчанию
	{
		super("Gift" + (num+1));
		this.num = num;
		this.ended = false;
		this.parent = parent;	
		this.dirTo = 1;
	}	
	
	public void SetGiftStart(Point LeftTop, Point RightBottom, Point Born, int speed)	//обозначаем стартовые параметры
	{
		pS = Born;
		LTp = LeftTop;
		RBp = RightBottom;
		p0 = new Point();
		p0.setLocation(pS);
		this.speed = speed;
		
		// вычисляем смещение для движения в каждую точку 
		// точка 1 - левый верхний угол
			double len1 = Math.sqrt((this.LTp.getX() - this.pS.getX()) *
                (this.LTp.getX() - this.pS.getX()) +
                (this.LTp.getY() - this.pS.getY()) *
                (this.LTp.getY() - this.pS.getY()));
			double dx1 = speed * (this.LTp.getX() - this.pS.getX()) / len1;
			double dy1 = speed * (this.LTp.getY() - this.pS.getY()) / len1;
			dp1.setLocation(dx1, dy1);
		
		// точка 2 - правый верхний угол
			double len2 = Math.sqrt((this.RBp.getX() - this.pS.getX()) *
		        (this.RBp.getX() - this.pS.getX()) +
		        (this.LTp.getY() - this.pS.getY()) *
		        (this.LTp.getY() - this.pS.getY()));
			double dx2 = speed * (this.RBp.getX() - this.pS.getX()) / len2;
			double dy2 = speed * (this.LTp.getY() - this.pS.getY()) / len2;
			dp2.setLocation(dx2, dy2);
				
		// точка 3 - нижний левый угол
			double len3 = Math.sqrt((this.LTp.getX() - this.pS.getX()) *
		        (this.LTp.getX() - this.pS.getX()) +
		        (this.RBp.getY() - this.pS.getY()) *
		        (this.RBp.getY() - this.pS.getY()));
			double dx3 = speed * (this.LTp.getX() - this.pS.getX()) / len3;
			double dy3 = speed * (this.RBp.getY() - this.pS.getY()) / len3;
			dp3.setLocation(dx3, dy3);		

		// точка 4 - нижний правый угол
			double len4 = Math.sqrt((this.RBp.getX() - this.pS.getX()) *
				(this.RBp.getX() - this.pS.getX()) +
				(this.RBp.getY() - this.pS.getY()) *
				(this.RBp.getY() - this.pS.getY()));
			double dx4 = speed * (this.RBp.getX() - this.pS.getX()) / len4;
			double dy4 = speed * (this.RBp.getY() - this.pS.getY()) / len4;
			dp4.setLocation(dx4, dy4);	
			
		Random R = new Random();
		dir = R.nextInt(1,5);	//выбираем угол по номеру от 1 до 4
		switch (dir)
		{
		case 1: p1.setLocation(LTp.getX(), LTp.getY()); break;
		case 2: p1.setLocation(RBp.getX(), LTp.getY()); break;	// в качесте конечных координат записываем координаты
		case 3: p1.setLocation(LTp.getX(), RBp.getY()); break;	// случайного выбранного угла
		case 4: p1.setLocation(RBp.getX(), RBp.getY()); break;
		}
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
		while (true)
		{
			double dx = 0;
			double dy = 0;
			switch (this.dir)
			{
			case 1: dx = dp1.getX(); dy = dp1.getY(); break;
			case 2: dx = dp2.getX(); dy = dp2.getY(); break;	// в зависимости от текущего направления
			case 3: dx = dp3.getX(); dy = dp3.getY(); break;	// выбираем шаг dx и dy из уже подсчитанных значений
			case 4: dx = dp4.getX(); dy = dp4.getY(); break;
			}
			if (this.ended == true)
				break;
			
			if (this.p0.equals(this.p1))	// если конечная цель маршрута достигнута
			{
				if (dirTo == 1)		// двигались к углу
				{
					dirTo = 0;	// начинаем движение к точке появления
					p1.setLocation(pS);	// задаем ее координаты как конечные					
				}
				else
				{
					if(dirTo == 0)	// двигались к точке появления
					{
						dirTo = 1;	// начинаем движение к углу
						Random R = new Random();
						dir = R.nextInt(1,5);	//выбираем угол по номеру от 1 до 4						
						switch (dir)
						{
						case 1: p1.setLocation(LTp.getX(), LTp.getY()); dx = dp1.getX(); dy = dp1.getY(); break;
						case 2: p1.setLocation(RBp.getX(), LTp.getY()); dx = dp2.getX(); dy = dp2.getY(); break;	// в качесте конечных координат записываем координаты
						case 3: p1.setLocation(LTp.getX(), RBp.getY()); dx = dp3.getX(); dy = dp3.getY(); break;	// случайного выбранного угла
						case 4: p1.setLocation(RBp.getX(), RBp.getY()); dx = dp4.getX(); dy = dp4.getY(); break;
						}
					}
				}
			}
			
			if (dirTo == 1)		//если двигаемся к углу, прибавляем вектор движения
			{
				if (Math.abs(this.p1.getX() - this.p0.getX()) < Math.abs(dx))	// если разница между X координатами меньше шага dx
	                this.p0.setLocation(this.p1.getX(), this.p0.getY()); 		// считаем X координату достигнутой
	            else															
	            	this.p0.setLocation(this.p0.getX() + dx, this.p0.getY()); 	// иначе выполняем шаг
	            
	            if (Math.abs(this.p1.getY() - this.p0.getY()) < Math.abs(dy))	// если разница между Y координатами меньше шага dy
	                this.p0.setLocation(this.p0.getX(), this.p1.getY());		// считаем Y координату достигнутой
	            else
	                this.p0.setLocation(this.p0.getX(), this.p0.getY() + dy);	// иначе выполняем шаг
			}
			else
				if (dirTo == 0)		//если двигаемся к точке рождения, отнимаем вектор движения
				{
					if (Math.abs(this.p1.getX() - this.p0.getX()) < Math.abs(dx))	// если разница между X координатами меньше шага dx
		                this.p0.setLocation(this.p1.getX(), this.p0.getY()); 		// считаем X координату достигнутой
		            else
		            	this.p0.setLocation(this.p0.getX() - dx, this.p0.getY()); 	// иначе выполняем шаг
		            
		            if (Math.abs(this.p1.getY() - this.p0.getY()) < Math.abs(dy))	// если разница между Y координатами меньше шага dy
		                this.p0.setLocation(this.p0.getX(), this.p1.getY());		// считаем Y координату достигнутой
		            else
		                this.p0.setLocation(this.p0.getX(), this.p0.getY() - dy);	// иначе выполняем шаг
				}
			try 
			{
                Gift.sleep(30);
            } catch (InterruptedException ex) {
                System.out.println("Error: " + ex.getMessage());
            }			
		}		
	}
}