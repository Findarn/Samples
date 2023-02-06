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
	//���������� ��������
	Point2D pS = new Point();
	// ������� ����������
	Point2D p0 = new Point();		
	// ���������� ����
	Point2D p1 = new Point();
	// ������� ��������
	Point2D dp1 = new Point();	// ������ �������� � 1 ���� - ����� ������� ����
	Point2D dp2 = new Point();	// ������ �������� � 2 ���� - ������ ������� ����
	Point2D dp3 = new Point();	// ������ �������� � 3 ���� - ������ ����� ����
	Point2D dp4 = new Point();	// ������ �������� � 4 ���� - ������ ������ ����
	// ���������� �������������� - ������� ������������� ��������
	Point2D LTp = new Point();	// ����� ������� ���� �������
	Point2D RBp = new Point();	// ������ ������ ���� �������
	int speed;		// �������� ��������
	int dir;		// ���������� ������ �����
	int dirTo;		// 1 - �������� � ����, 0 - �������� � ����� ��������
	
	Main parent;
	
	boolean ended;
	
	public Gift(int num, Main parent)	// ����������� �� ���������
	{
		super("Gift" + (num+1));
		this.num = num;
		this.ended = false;
		this.parent = parent;	
		this.dirTo = 1;
	}	
	
	public void SetGiftStart(Point LeftTop, Point RightBottom, Point Born, int speed)	//���������� ��������� ���������
	{
		pS = Born;
		LTp = LeftTop;
		RBp = RightBottom;
		p0 = new Point();
		p0.setLocation(pS);
		this.speed = speed;
		
		// ��������� �������� ��� �������� � ������ ����� 
		// ����� 1 - ����� ������� ����
			double len1 = Math.sqrt((this.LTp.getX() - this.pS.getX()) *
                (this.LTp.getX() - this.pS.getX()) +
                (this.LTp.getY() - this.pS.getY()) *
                (this.LTp.getY() - this.pS.getY()));
			double dx1 = speed * (this.LTp.getX() - this.pS.getX()) / len1;
			double dy1 = speed * (this.LTp.getY() - this.pS.getY()) / len1;
			dp1.setLocation(dx1, dy1);
		
		// ����� 2 - ������ ������� ����
			double len2 = Math.sqrt((this.RBp.getX() - this.pS.getX()) *
		        (this.RBp.getX() - this.pS.getX()) +
		        (this.LTp.getY() - this.pS.getY()) *
		        (this.LTp.getY() - this.pS.getY()));
			double dx2 = speed * (this.RBp.getX() - this.pS.getX()) / len2;
			double dy2 = speed * (this.LTp.getY() - this.pS.getY()) / len2;
			dp2.setLocation(dx2, dy2);
				
		// ����� 3 - ������ ����� ����
			double len3 = Math.sqrt((this.LTp.getX() - this.pS.getX()) *
		        (this.LTp.getX() - this.pS.getX()) +
		        (this.RBp.getY() - this.pS.getY()) *
		        (this.RBp.getY() - this.pS.getY()));
			double dx3 = speed * (this.LTp.getX() - this.pS.getX()) / len3;
			double dy3 = speed * (this.RBp.getY() - this.pS.getY()) / len3;
			dp3.setLocation(dx3, dy3);		

		// ����� 4 - ������ ������ ����
			double len4 = Math.sqrt((this.RBp.getX() - this.pS.getX()) *
				(this.RBp.getX() - this.pS.getX()) +
				(this.RBp.getY() - this.pS.getY()) *
				(this.RBp.getY() - this.pS.getY()));
			double dx4 = speed * (this.RBp.getX() - this.pS.getX()) / len4;
			double dy4 = speed * (this.RBp.getY() - this.pS.getY()) / len4;
			dp4.setLocation(dx4, dy4);	
			
		Random R = new Random();
		dir = R.nextInt(1,5);	//�������� ���� �� ������ �� 1 �� 4
		switch (dir)
		{
		case 1: p1.setLocation(LTp.getX(), LTp.getY()); break;
		case 2: p1.setLocation(RBp.getX(), LTp.getY()); break;	// � ������� �������� ��������� ���������� ����������
		case 3: p1.setLocation(LTp.getX(), RBp.getY()); break;	// ���������� ���������� ����
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
			case 2: dx = dp2.getX(); dy = dp2.getY(); break;	// � ����������� �� �������� �����������
			case 3: dx = dp3.getX(); dy = dp3.getY(); break;	// �������� ��� dx � dy �� ��� ������������ ��������
			case 4: dx = dp4.getX(); dy = dp4.getY(); break;
			}
			if (this.ended == true)
				break;
			
			if (this.p0.equals(this.p1))	// ���� �������� ���� �������� ����������
			{
				if (dirTo == 1)		// ��������� � ����
				{
					dirTo = 0;	// �������� �������� � ����� ���������
					p1.setLocation(pS);	// ������ �� ���������� ��� ��������					
				}
				else
				{
					if(dirTo == 0)	// ��������� � ����� ���������
					{
						dirTo = 1;	// �������� �������� � ����
						Random R = new Random();
						dir = R.nextInt(1,5);	//�������� ���� �� ������ �� 1 �� 4						
						switch (dir)
						{
						case 1: p1.setLocation(LTp.getX(), LTp.getY()); dx = dp1.getX(); dy = dp1.getY(); break;
						case 2: p1.setLocation(RBp.getX(), LTp.getY()); dx = dp2.getX(); dy = dp2.getY(); break;	// � ������� �������� ��������� ���������� ����������
						case 3: p1.setLocation(LTp.getX(), RBp.getY()); dx = dp3.getX(); dy = dp3.getY(); break;	// ���������� ���������� ����
						case 4: p1.setLocation(RBp.getX(), RBp.getY()); dx = dp4.getX(); dy = dp4.getY(); break;
						}
					}
				}
			}
			
			if (dirTo == 1)		//���� ��������� � ����, ���������� ������ ��������
			{
				if (Math.abs(this.p1.getX() - this.p0.getX()) < Math.abs(dx))	// ���� ������� ����� X ������������ ������ ���� dx
	                this.p0.setLocation(this.p1.getX(), this.p0.getY()); 		// ������� X ���������� �����������
	            else															
	            	this.p0.setLocation(this.p0.getX() + dx, this.p0.getY()); 	// ����� ��������� ���
	            
	            if (Math.abs(this.p1.getY() - this.p0.getY()) < Math.abs(dy))	// ���� ������� ����� Y ������������ ������ ���� dy
	                this.p0.setLocation(this.p0.getX(), this.p1.getY());		// ������� Y ���������� �����������
	            else
	                this.p0.setLocation(this.p0.getX(), this.p0.getY() + dy);	// ����� ��������� ���
			}
			else
				if (dirTo == 0)		//���� ��������� � ����� ��������, �������� ������ ��������
				{
					if (Math.abs(this.p1.getX() - this.p0.getX()) < Math.abs(dx))	// ���� ������� ����� X ������������ ������ ���� dx
		                this.p0.setLocation(this.p1.getX(), this.p0.getY()); 		// ������� X ���������� �����������
		            else
		            	this.p0.setLocation(this.p0.getX() - dx, this.p0.getY()); 	// ����� ��������� ���
		            
		            if (Math.abs(this.p1.getY() - this.p0.getY()) < Math.abs(dy))	// ���� ������� ����� Y ������������ ������ ���� dy
		                this.p0.setLocation(this.p0.getX(), this.p1.getY());		// ������� Y ���������� �����������
		            else
		                this.p0.setLocation(this.p0.getX(), this.p0.getY() - dy);	// ����� ��������� ���
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