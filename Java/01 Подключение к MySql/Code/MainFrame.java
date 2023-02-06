package BD;
import java.sql.*;
import java.io.*;
import java.awt.*; 
import java.awt.event.*; //���������� ��� ��� ������� 
import javax.swing.*; // ��� �������� �������� �����
import javax.swing.table.DefaultTableModel;
import javax.swing.table.TableModel;
import java.util.ArrayList;


public class MainFrame extends javax.swing.JFrame
{	
	//������ ������
	JPanel ButtonPanel = new JPanel();	//��������� ��� ������
	JButton B1Connect = new JButton(new ConnectAction());	
	JButton B2Add = new JButton(new AddAction());
	JButton B3Delete = new JButton(new DeleteAction());		//������ ��� �����
	JButton B4Change = new JButton(new ChangeAction());		//� �������� ��������� - ���������� �������
	JButton B5Filter = new JButton(new FilterAction());
	//������ �������
	JPanel TablePanel = new JPanel();	//��������� ��� �������
	JTable DataBaseTable = new JTable(0, 7);	//������ ������� � 0 ����� � 7 ���������(���������)
	//������ �����+���������
	JPanel GridPanel = new JPanel();		//��������� ��� ������� � �����������
	JTextField JTFfio = new JTextField();
	JTextField JTFcountry = new JTextField();
	JTextField JTFroles = new JTextField();
	JTextField JTFfilms = new JTextField();
	JTextField JTFhgon = new JTextField();
	JTextField JTFhar = new JTextField();		
	JLabel JLfio = new JLabel("���");	
	JLabel JLcountry = new JLabel("������");
	JLabel JLroles = new JLabel("��������� ����");
	JLabel JLfilms = new JLabel("����. ������");
	JLabel JLhgon = new JLabel("��������� �������");
	JLabel JLhar = new JLabel("���������� ���������");
	//��� ������ ��� ���������� �����������
	String url = "jdbc:mysql://localhost/userdb";		//����� ������� ���� ������ jdbc - �������, mysql - ��� ���� �������, localhost - ������� ������������, userdb - chema
	String user = "root";		//��� ������������
	String password = "password";				//������
	
	Boolean Connection = false;							//���������� ������� ������� � ���, ��������� �� �����������
	ArrayList<Unit> Units = new ArrayList<Unit>();		//������ ��� ����� �� ���� ������
	
	public MainFrame()		//�����������

	{
		super("������ � ������ ������");		//������ ��������� �����
		setMaximumSize(new Dimension(800, 550));	
		setPreferredSize(new Dimension(800, 550));	//���������������� ������
		
		ButtonPanel.setLayout(new FlowLayout(FlowLayout.CENTER));	//������ ������� ������������ FlowLayout
		//�������� ������������� ����� �������, ���� �� ������, � ������� �� ��������� � ���������
		ButtonPanel.setMaximumSize(new Dimension(700, 40));
		ButtonPanel.setPreferredSize(new Dimension(700, 40));									
		ButtonPanel.add(B1Connect); 	B1Connect.setText("������������ � ��");	//�������� ������ � ���������; ������ ������ �����
		ButtonPanel.add(B2Add);			B2Add.setText("�������� ������");
		ButtonPanel.add(B3Delete);		B3Delete.setText("������� ������");
		ButtonPanel.add(B4Change);		B4Change.setText("�������� ������");
		ButtonPanel.add(B5Filter);		B5Filter.setText("���������� ������");
		
		TablePanel.setLayout(new FlowLayout(FlowLayout.CENTER));	//������ ������� ������������ FlowLayout	
		TablePanel.add(DataBaseTable);		//��������� �������
		TablePanel.setSize(new Dimension(700, 400));		//������ ������� ��� ����������
		DataBaseTable.setPreferredScrollableViewportSize(new Dimension(700, 400));	//
		DataBaseTable.getColumnModel().getColumn(0).setPreferredWidth(50);	//������������� ������ �������
		DataBaseTable.getColumnModel().getColumn(0).setHeaderValue("ID");	//������ ����� �������
		DataBaseTable.getColumnModel().getColumn(1).setPreferredWidth(200);
		DataBaseTable.getColumnModel().getColumn(1).setHeaderValue("������� ��� ��������");
		DataBaseTable.getColumnModel().getColumn(2).setPreferredWidth(100);
		DataBaseTable.getColumnModel().getColumn(2).setHeaderValue("������");
		DataBaseTable.getColumnModel().getColumn(3).setPreferredWidth(50);
		DataBaseTable.getColumnModel().getColumn(3).setHeaderValue("����");
		DataBaseTable.getColumnModel().getColumn(4).setPreferredWidth(50);
		DataBaseTable.getColumnModel().getColumn(4).setHeaderValue("������");
		DataBaseTable.getColumnModel().getColumn(5).setPreferredWidth(100);
		DataBaseTable.getColumnModel().getColumn(5).setHeaderValue("�������");
		DataBaseTable.getColumnModel().getColumn(6).setPreferredWidth(50);
		DataBaseTable.getColumnModel().getColumn(6).setHeaderValue("�������");
		JScrollPane JSP = new JScrollPane(DataBaseTable,JScrollPane.VERTICAL_SCROLLBAR_ALWAYS, JScrollPane.HORIZONTAL_SCROLLBAR_NEVER);
		//�������� ��������� ��� �������, � �������� ���������� - 1. ��� ����� ��������������, 2. ������� ��� ������������� �������� - ������
		//3. ������� ��� ��������������� ��������
		TablePanel.add(JSP);	//��������� � ��������� � ��������
		
		GridLayout TextLabelGrid = new GridLayout(2, 6, 5, 10);	//2 - ���������� �����, 6 - ���������� ��������, 
		//5 - ���������� �� � ����� ����������, 10 - ���������� �� � ����� ����������
		GridPanel.setLayout(TextLabelGrid);		//����� ������� ������������ �������� ��������� ���� �������
		GridPanel.setMaximumSize(new Dimension(780, 80));
		GridPanel.setPreferredSize(new Dimension(780, 40));
		GridPanel.add(JLfio);		JLfio.setFont(new Font("Consolas", Font.PLAIN, 10));
		GridPanel.add(JLcountry);	JLcountry.setFont(new Font("Consolas", Font.PLAIN, 10));
		GridPanel.add(JLroles);		JLroles.setFont(new Font("Consolas", Font.PLAIN, 10));
		GridPanel.add(JLfilms);		JLfilms.setFont(new Font("Consolas", Font.PLAIN, 10));
		GridPanel.add(JLhgon);		JLhgon.setFont(new Font("Consolas", Font.PLAIN, 10));
		GridPanel.add(JLhar);		JLhar.setFont(new Font("Consolas", Font.PLAIN, 10));
		
		GridPanel.add(JTFfio);		JTFfio.setFont(new Font("Consolas", Font.PLAIN, 10));		
		GridPanel.add(JTFcountry);	JTFcountry.setFont(new Font("Consolas", Font.PLAIN, 10));
		GridPanel.add(JTFroles);	JTFroles.setFont(new Font("Consolas", Font.PLAIN, 10));	
		GridPanel.add(JTFfilms);	JTFfilms.setFont(new Font("Consolas", Font.PLAIN, 10));
		GridPanel.add(JTFhgon);		JTFhgon.setFont(new Font("Consolas", Font.PLAIN, 10));
		GridPanel.add(JTFhar);		JTFhar.setFont(new Font("Consolas", Font.PLAIN, 10));
		
		getContentPane().setLayout(new BorderLayout());				//������������� ������� ����������
		getContentPane().setMaximumSize(new Dimension(800, 550));
		getContentPane().add(ButtonPanel, "North");
		getContentPane().add(TablePanel);
		getContentPane().add(GridPanel, "South");			
		
		pack();		//��������� ��������� �������
				
	}
		
	class ConnectAction extends AbstractAction		//������� �� ������ �����������
	{
		@Override
		public void actionPerformed(ActionEvent e) 
		{		
			if (Connection != true)	
			{
			Connection = false;	//���������� ��� ���
			Units.clear();		//������� ������ �������� �� ��	
	    	try{
	            Class.forName("com.mysql.cj.jdbc.Driver").getDeclaredConstructor().newInstance();	//����� �������� ��� ����������� � ��            
	        }
	        catch(Exception ex)
	    	{
	        	JOptionPane.showMessageDialog(null, "������ ����������� � ��! " + ex);		//������ ������� �����
	        	return;
	        }	
	    	try(Connection con = DriverManager.getConnection(url, user, password))	//�������� �������� ���������� � �� ����� �������
	    	{
	    		String sqlCommand = "SELECT * from actors";	   	//���������� � ������ SQL �������   
	  	      	Statement state = con.createStatement();		//������ ���������, ����������� � �������� �����������
	  	      	ResultSet rs = state.executeQuery(sqlCommand); 	//ResultSet ��������� ������, ���������� � ���������� ������� ����� ���������
	  	      	while(rs.next())	//���������� rs ��������� �� ����� ����� ������ �������
	  	      		//rs.next ��������� ��� ������ �� ����������� ������� �� ���� ������
		      {
		    	  Units.add(new Unit(rs.getInt("ID"), rs.getString("FIO"), rs.getString("Country"), rs.getInt("Roles"), rs.getInt("Films"), rs.getInt("HGon"), rs.getInt("Har")));
		      }
	  	      	//���������� �������
	  	      for (int i = 0; i < Units.size(); i++)
	  	      {		//��������� ��� ��� ���������� � �������
	  	    	  Object[] row = {Units.get(i).id, Units.get(i).FIO, Units.get(i).Country, Units.get(i).Roles, Units.get(i).Films, Units.get(i).Gonorar, Units.get(i).Rape}; 
	  	    	  DefaultTableModel mod = (DefaultTableModel) DataBaseTable.getModel();	//�������� ������ �������
	  	    	  mod.addRow(row);		//�������� ������ �� ���������� � �������
	  	      }
	  	      Connection = true;	//���������� ������� �����������
	  	      rs.close();
	  	      state.close();	//��������� ��������� � ����������� ������
	  	      con.close();
	    	}
	    	catch(Exception ex)
	    	{
	        	JOptionPane.showMessageDialog(null, "������ ������ ��! " + ex);
	        	return;
	        }
	    	Connection = true;
			}
			else
			{
				JOptionPane.showMessageDialog(null, "���������� ��� �����������!");
			}
		}		
	}
	
	class AddAction extends AbstractAction			//������� �� ������ ����������
	{
		@Override
		public void actionPerformed(ActionEvent e) 
		{	
			if (Connection == true)
			{
				try(Connection con = DriverManager.getConnection(url, user, password))	//������������ � ���� ������
		    	{
					Boolean t1 = false, t2 = false, t3 = false, t4 = false, t5 = false, t6 = false, cond = false;	
					//t1-t6 �������� ����������� �� ����, cond ����� ��������
		    		t1 = JTFfio.getText() != "";		//���� ��� �� �����, �� true
		    		t2 = JTFcountry.getText() != "";	//���� ������ �� �����, �� true
		    		try
		    		{
		    			int a = Integer.parseInt(JTFroles.getText());	//������� ��������� ���������� ������ � �����
		    			t3 = true;		//���� ����������, �� true
		    		}
		    		catch (Exception ex)	//���� �� ����������
		    		{
		    			t3 = false;
		    		}
		    		try
		    		{
		    			int a = Integer.parseInt(JTFfilms.getText());
		    			t4 = true;
		    		}
		    		catch (Exception ex)
		    		{
		    			t4 = false;
		    		}
		    		try
		    		{
		    			int a = Integer.parseInt(JTFhgon.getText());
		    			t5 = true;
		    		}
		    		catch (Exception ex)
		    		{
		    			t5 = false;
		    		}
		    		try
		    		{
		    			int a = Integer.parseInt(JTFhar.getText());
		    			t6 = true;
		    		}
		    		catch (Exception ex)
		    		{
		    			t6 = false;
		    		}
		    		cond = t1 & t2 & t3 & t4 & t5 & t6;	//���������� ��� ����������� ������� �� �(&)
		    		
		    		if (!cond)	//���� cond == false
		    		{
		    			JOptionPane.showMessageDialog(null, "������ ��� ���������� �� ������������� �������!");
		    			con.close();
		    			return;		    			
		    		}
		    		else
		    		{
		    			Statement state = con.createStatement();
		    			String sqlCommand1 = "INSERT INTO actors (FIO, Country, Roles, Films, HGon, Har) VALUES ('"+ JTFfio.getText() +"', '"+ JTFcountry.getText() +"',"
		    			+ Integer.parseInt(JTFroles.getText()) +" , "+ Integer.parseInt(JTFfilms.getText()) +", "
		    			+ Integer.parseInt(JTFhgon.getText()) +", "+ Integer.parseInt(JTFhar.getText()) +")";
			  	      	state.execute(sqlCommand1); //��� ��� ������ �� ����������, ���������� execute � �� executeQuery
			  	        String sqlCommand2 = "SELECT * from actors";	
			  	        ResultSet rs = state.executeQuery(sqlCommand2); 	//��������� ������
			  	        Units.clear();
			  	        while(rs.next())
			  	        {
			  	        	Units.add(new Unit(rs.getInt("ID"), rs.getString("FIO"), rs.getString("Country"), rs.getInt("Roles"), rs.getInt("Films"), rs.getInt("HGon"), rs.getInt("Har")));
			  	        }
			  	        DefaultTableModel mod1 = (DefaultTableModel) DataBaseTable.getModel();	//�������� ������ �������
			  	        mod1.setRowCount(0);	//�������� ���������� �����
			  	        for (int i = 0; i < Units.size(); i++)
			  	        {
			  	    	  Object[] row = {Units.get(i).id, Units.get(i).FIO, Units.get(i).Country, Units.get(i).Roles, Units.get(i).Films, Units.get(i).Gonorar, Units.get(i).Rape}; 
			  	    	  DefaultTableModel mod2 = (DefaultTableModel) DataBaseTable.getModel();
			  	    	  mod2.addRow(row);
			  	        }
			  	      rs.close();
			  	      state.close();
			  	      con.close();
		    		}	
		    	}
		    	catch(Exception ex)
		    	{
		        	JOptionPane.showMessageDialog(null, "������ ������ ��! " + ex);
		        	return;
		        }
			}
			else
			{
				JOptionPane.showMessageDialog(null, "���������� � �� �� ���� �����������!");
			}
		}
		
	}
	
	class DeleteAction extends AbstractAction		//������� �� ������ ��������
	{
		@Override
		public void actionPerformed(ActionEvent e) 
		{			
			if (Connection == true)
			{
				try(Connection con = DriverManager.getConnection(url, user, password))
		    	{
					Boolean cond = false; int Nid = -1;		//���������� ������� �� ���������, ��������� id = -1
					if (DataBaseTable.getSelectedRow() == -1)	//��������� ������ �� �����-�� ���
					{
						cond = false;
					}
					else
					{
						cond = true;	//������� ��� �������� �����������
						Nid = (int)DataBaseTable.getModel().getValueAt(DataBaseTable.getSelectedRow(), 0);	//�������� �������� ID � ��������� ����
					}
		    		
		    		if (!cond || Nid < 0)
		    		{
		    			JOptionPane.showMessageDialog(null, "������ ��� �������� �� �������!");
		    			con.close();
		    			return;		    			
		    		}
		    		else
		    		{
		    			Statement state = con.createStatement();
		    			String sqlCommand1 = "DELETE FROM actors WHERE Id = " + Nid;
			  	      	state.execute(sqlCommand1); 
			  	        String sqlCommand2 = "SELECT * from actors";	
			  	        ResultSet rs = state.executeQuery(sqlCommand2); 
			  	        Units.clear();
			  	        while(rs.next())
			  	        {
			  	        	Units.add(new Unit(rs.getInt("ID"), rs.getString("FIO"), rs.getString("Country"), rs.getInt("Roles"), rs.getInt("Films"), rs.getInt("HGon"), rs.getInt("Har")));
			  	        }
			  	        DefaultTableModel mod1 = (DefaultTableModel) DataBaseTable.getModel();
			  	        mod1.setRowCount(0);			  	        
			  	        for (int i = 0; i < Units.size(); i++)
			  	        {
			  	    	  Object[] row = {Units.get(i).id, Units.get(i).FIO, Units.get(i).Country, Units.get(i).Roles, Units.get(i).Films, Units.get(i).Gonorar, Units.get(i).Rape}; 
			  	    	  DefaultTableModel mod2 = (DefaultTableModel) DataBaseTable.getModel();
			  	    	  mod2.addRow(row);
			  	        }
			  	      rs.close();
			  	      state.close();
			  	      con.close();
		    		}	
		    	}
		    	catch(Exception ex)
		    	{
		        	JOptionPane.showMessageDialog(null, "������ ������ ��! " + ex);
		        	return;
		        }
			}
			else
			{
				JOptionPane.showMessageDialog(null, "���������� � �� �� ���� �����������!");
			}	
		}		
	}
	
	class ChangeAction extends AbstractAction		//������� �� ������ ���������
	{
		@Override
		public void actionPerformed(ActionEvent e) 
		{			
			if (Connection == true)
			{
				try(Connection con = DriverManager.getConnection(url, user, password))
		    	{
					Boolean t1 = false, t2 = false, t3 = false, t4 = false, t5 = false, t6 = false, cond1 = false, cond2 = false;		    		
		    		t1 = JTFfio.getText() != "";
		    		t2 = JTFcountry.getText() != "";
		    		try
		    		{
		    			int a = Integer.parseInt(JTFroles.getText());
		    			t3 = true;
		    		}
		    		catch (Exception ex)
		    		{
		    			t3 = false;
		    		}
		    		try
		    		{
		    			int a = Integer.parseInt(JTFfilms.getText());
		    			t4 = true;
		    		}
		    		catch (Exception ex)
		    		{
		    			t4 = false;
		    		}
		    		try
		    		{
		    			int a = Integer.parseInt(JTFhgon.getText());
		    			t5 = true;
		    		}
		    		catch (Exception ex)
		    		{
		    			t5 = false;
		    		}
		    		try
		    		{
		    			int a = Integer.parseInt(JTFhar.getText());
		    			t6 = true;
		    		}
		    		catch (Exception ex)
		    		{
		    			t6 = false;
		    		}
		    		cond1 = t1 & t2 & t3 & t4 & t5 & t6;
					cond2 = false; int Nid = -1;
					if (DataBaseTable.getSelectedRow() == -1)
					{
						cond2 = false;
					}
					else
					{
						cond2 = true;	
						Nid = (int)DataBaseTable.getModel().getValueAt(DataBaseTable.getSelectedRow(), 0);
					}
					
					if (!cond1)
					{
						JOptionPane.showMessageDialog(null, "���� ��� ����� �� ������������� �������!");
		    			con.close();
		    			return;
					}
		    		
		    		if (!cond2 || Nid < 0)
		    		{
		    			JOptionPane.showMessageDialog(null, "������ ��� ��������� �� �������!");
		    			con.close();
		    			return;		    			
		    		}
		    		else
		    		{
		    			Statement state = con.createStatement();
		    			String sqlCommand1 = "UPDATE actors SET FIO = '"+JTFfio.getText()+"'"
		    					+ ", Country = '"+JTFcountry.getText()+"', Roles = "+ Integer.parseInt(JTFroles.getText()) +
		    					", Films = "+ Integer.parseInt(JTFfilms.getText()) +", HGon = "+ Integer.parseInt(JTFhgon.getText()) +
		    					", Har = "+ Integer.parseInt(JTFhar.getText()) +" WHERE Id = " + Nid;
			  	      	state.execute(sqlCommand1); 
			  	        String sqlCommand2 = "SELECT * from actors";	
			  	        ResultSet rs = state.executeQuery(sqlCommand2); 
			  	        Units.clear();
			  	        while(rs.next())
			  	        {
			  	        	Units.add(new Unit(rs.getInt("ID"), rs.getString("FIO"), rs.getString("Country"), rs.getInt("Roles"), rs.getInt("Films"), rs.getInt("HGon"), rs.getInt("Har")));
			  	        }
			  	        DefaultTableModel mod1 = (DefaultTableModel) DataBaseTable.getModel();
			  	        mod1.setRowCount(0);			  	        
			  	        for (int i = 0; i < Units.size(); i++)
			  	        {
			  	    	  Object[] row = {Units.get(i).id, Units.get(i).FIO, Units.get(i).Country, Units.get(i).Roles, Units.get(i).Films, Units.get(i).Gonorar, Units.get(i).Rape}; 
			  	    	  DefaultTableModel mod2 = (DefaultTableModel) DataBaseTable.getModel();
			  	    	  mod2.addRow(row);
			  	        }
			  	      rs.close();
			  	      state.close();
			  	      con.close();
		    		}	
		    	}
		    	catch(Exception ex)
		    	{
		        	JOptionPane.showMessageDialog(null, "������ ������ ��! " + ex);
		        	return;
		        }
			}
			else
			{
				JOptionPane.showMessageDialog(null, "���������� � �� �� ���� �����������!");
			}	
		}		
	}
	
	class FilterAction extends AbstractAction		//������� �� ������ �������
	{
		int mode = 0;	//����� �������
		@Override
		public void actionPerformed(ActionEvent e) 
		{			
			if (Connection == true)
			{
				try(Connection con = DriverManager.getConnection(url, user, password))
		    	{
					switch(mode)
					{
					case 0:
					{
						String SQLM0 = "SELECT * from actors WHERE Country = '��������������'";
						Statement state = con.createStatement();
						ResultSet rs = state.executeQuery(SQLM0); 
						Units.clear();
			  	        while(rs.next())
			  	        {
			  	        	Units.add(new Unit(rs.getInt("ID"), rs.getString("FIO"), rs.getString("Country"), rs.getInt("Roles"), rs.getInt("Films"), rs.getInt("HGon"), rs.getInt("Har")));
			  	        }
			  	        DefaultTableModel mod1 = (DefaultTableModel) DataBaseTable.getModel();
			  	        mod1.setRowCount(0);
			  	        for (int i = 0; i < Units.size(); i++)
			  	        {
			  	    	  Object[] row = {Units.get(i).id, Units.get(i).FIO, Units.get(i).Country, Units.get(i).Roles, Units.get(i).Films, Units.get(i).Gonorar, Units.get(i).Rape}; 
			  	    	  DefaultTableModel mod2 = (DefaultTableModel) DataBaseTable.getModel();
			  	    	  mod2.addRow(row);
			  	        }
			  	      rs.close();
			  	      state.close();
			  	      con.close();
			  	      mode = 1;		//����������� ����� ������
					}break;
					case 1:
					{
						String SQLM0 = "SELECT * from actors";
						Statement state = con.createStatement();
						ResultSet rs = state.executeQuery(SQLM0); 
						Units.clear();
			  	        while(rs.next())
			  	        {
			  	        	Units.add(new Unit(rs.getInt("ID"), rs.getString("FIO"), rs.getString("Country"), rs.getInt("Roles"), rs.getInt("Films"), rs.getInt("HGon"), rs.getInt("Har")));
			  	        }
			  	        DefaultTableModel mod1 = (DefaultTableModel) DataBaseTable.getModel();
			  	        mod1.setRowCount(0);
			  	        for (int i = 0; i < Units.size(); i++)
			  	        {
			  	    	  Object[] row = {Units.get(i).id, Units.get(i).FIO, Units.get(i).Country, Units.get(i).Roles, Units.get(i).Films, Units.get(i).Gonorar, Units.get(i).Rape}; 
			  	    	  DefaultTableModel mod2 = (DefaultTableModel) DataBaseTable.getModel();
			  	    	  mod2.addRow(row);
			  	        }
			  	      rs.close();
			  	      state.close();
			  	      con.close();
			  	      mode = 0;
					}break;
					}
		    	}
		    	catch(Exception ex)
		    	{
		        	JOptionPane.showMessageDialog(null, "������ ������ ��! " + ex);
		        	return;
		        }
			}
			else
			{
				JOptionPane.showMessageDialog(null, "���������� � �� �� ���� �����������!");
			}	
		}		
	}
}
