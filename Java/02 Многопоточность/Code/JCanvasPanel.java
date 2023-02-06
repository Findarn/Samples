package streams;

import java.awt.*;
import javax.swing.*;
import java.io.IOException;
import javax.imageio.ImageIO;

// ����� ������������ ����� ���������� ����������� JPanel
// ��� ���������� ��� ������� � Canvas ������
// ����� paintComponent ���������� ������ ���,
// ����� ���������� ������������ ������
class JCanvasPanel extends JPanel 
{    
    Image GiftImage, GrinchImage; 
    Gift[] Gifts;
    Grinch[] Grinches;
    
    public JCanvasPanel()
    {
        try 
        {
            this.GiftImage = ImageIO.read(
                this.getClass().getResource("gift.png"));
            this.GrinchImage = ImageIO.read(
                this.getClass().getResource("grinch.png"));
        }
        catch (IOException ex)
        {
            System.out.println("Error: " + ex.getMessage());
        }
    }

    public void setParam(Gift[] gifts, Grinch[] grinches) 
    {
        this.Gifts = gifts;
        this.Grinches = grinches;
      
    }
    
    @Override
    public void paintComponent(Graphics g)
    {
        super.paintComponent(g);
        
        // ������� �����������
        g.setColor(this.getBackground());
        g.fillRect(0, 0, this.getHeight(), this.getWidth());
        
        
        
        // ������ �� ���� ��������� � ���������        
        if (this.Gifts != null)
            for (Gift gift : this.Gifts) 
            {
            	g.drawImage(this.GiftImage, gift.GetX(), gift.GetY(), null);
            }
        if (this.Grinches != null)
            for (Grinch grinch : this.Grinches) 
            {
            	g.drawImage(this.GrinchImage, grinch.GetX(), grinch.GetY(), null);
            }
    }
}