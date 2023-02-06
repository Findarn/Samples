package streams;

import javax.swing.JPanel;

public class GiftView extends Thread
{
	boolean ended;
	JPanel panel;
	
	
	public GiftView(JPanel Panel)
	{
		this.panel = Panel;
		this.ended = false;
		this.setPriority(MAX_PRIORITY);
	}
	
	public void end()
	{
		this.ended = true;
	}
	
	@Override
	public void run()
	{
		while (true)
		{
			if (this.ended == true)
				break;
			this.panel.repaint();
			try
			{
				GiftView.sleep(10);
			}
			catch (InterruptedException ex)
			{
				System.out.println("Error: " + ex.getMessage());
			}
		}
	}
}