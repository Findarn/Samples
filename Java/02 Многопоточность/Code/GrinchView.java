package streams;

import javax.swing.JPanel;

public class GrinchView extends Thread
{
	boolean ended;
	JPanel Panel;
	
	public GrinchView(JPanel panel)
	{
		this.Panel = panel;
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
			this.Panel.repaint();
			try
			{
				GrinchView.sleep(10);
			}
			catch (InterruptedException ex)
			{
				System.out.println("Error: " + ex.getMessage());
			}
		}
	}
}