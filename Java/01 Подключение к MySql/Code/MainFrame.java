package BD;
import java.sql.*;
import java.io.*;
import java.awt.*; 
import java.awt.event.*; //библиотека для исп событий 
import javax.swing.*; // для создания экранной формы
import javax.swing.table.DefaultTableModel;
import javax.swing.table.TableModel;
import java.util.ArrayList;


public class MainFrame extends javax.swing.JFrame
{	
	//секция кнопок
	JPanel ButtonPanel = new JPanel();	//контейнер для кнопок
	JButton B1Connect = new JButton(new ConnectAction());	
	JButton B2Add = new JButton(new AddAction());
	JButton B3Delete = new JButton(new DeleteAction());		//кнопки для формы
	JButton B4Change = new JButton(new ChangeAction());		//в качестве параметра - обработчик событий
	JButton B5Filter = new JButton(new FilterAction());
	//секция таблицы
	JPanel TablePanel = new JPanel();	//контейнер для таблицы
	JTable DataBaseTable = new JTable(0, 7);	//создаём таблицу с 0 строк и 7 колонками(столбцами)
	//секция Лейбл+ТекстФилд
	JPanel GridPanel = new JPanel();		//контейнер для лейблов и текстфилдов
	JTextField JTFfio = new JTextField();
	JTextField JTFcountry = new JTextField();
	JTextField JTFroles = new JTextField();
	JTextField JTFfilms = new JTextField();
	JTextField JTFhgon = new JTextField();
	JTextField JTFhar = new JTextField();		
	JLabel JLfio = new JLabel("ФИО");	
	JLabel JLcountry = new JLabel("Страна");
	JLabel JLroles = new JLabel("Сыгранные роли");
	JLabel JLfilms = new JLabel("Среж. фильмы");
	JLabel JLhgon = new JLabel("Наивысший гонорар");
	JLabel JLhar = new JLabel("Количество обвинений");
	//три строки для выполнения подключения
	String url = "jdbc:mysql://localhost/userdb";		//адрес сервера базы данных jdbc - драйвер, mysql - для чего драйвер, localhost - текущий пользователь, userdb - chema
	String user = "root";		//имя пользователя
	String password = "password";				//пароль
	
	Boolean Connection = false;							//переменная которая говорит о том, произошло ли подключение
	ArrayList<Unit> Units = new ArrayList<Unit>();		//список для строк из базы данных
	
	public MainFrame()		//конструктор

	{
		super("Работа с базами данных");		//задать заголовок форме
		setMaximumSize(new Dimension(800, 550));	
		setPreferredSize(new Dimension(800, 550));	//предпочтительный размер
		
		ButtonPanel.setLayout(new FlowLayout(FlowLayout.CENTER));	//задаем правило расположение FlowLayout
		//элементы располагаются слева направо, друг за другом, в порядке их помещения в контейнер
		ButtonPanel.setMaximumSize(new Dimension(700, 40));
		ButtonPanel.setPreferredSize(new Dimension(700, 40));									
		ButtonPanel.add(B1Connect); 	B1Connect.setText("Подключиться к БД");	//помещаем кнопку в контейнер; задаем кнопке текст
		ButtonPanel.add(B2Add);			B2Add.setText("Добавить запись");
		ButtonPanel.add(B3Delete);		B3Delete.setText("Удалить запись");
		ButtonPanel.add(B4Change);		B4Change.setText("Изменить запись");
		ButtonPanel.add(B5Filter);		B5Filter.setText("Обработать запрос");
		
		TablePanel.setLayout(new FlowLayout(FlowLayout.CENTER));	//задаем правило расположения FlowLayout	
		TablePanel.add(DataBaseTable);		//добавляем таблицу
		TablePanel.setSize(new Dimension(700, 400));		//задаем размеры для контейнера
		DataBaseTable.setPreferredScrollableViewportSize(new Dimension(700, 400));	//
		DataBaseTable.getColumnModel().getColumn(0).setPreferredWidth(50);	//устанавливаем ширину столбца
		DataBaseTable.getColumnModel().getColumn(0).setHeaderValue("ID");	//задаем текст столбца
		DataBaseTable.getColumnModel().getColumn(1).setPreferredWidth(200);
		DataBaseTable.getColumnModel().getColumn(1).setHeaderValue("Фамилия Имя Отчество");
		DataBaseTable.getColumnModel().getColumn(2).setPreferredWidth(100);
		DataBaseTable.getColumnModel().getColumn(2).setHeaderValue("Страна");
		DataBaseTable.getColumnModel().getColumn(3).setPreferredWidth(50);
		DataBaseTable.getColumnModel().getColumn(3).setHeaderValue("Роли");
		DataBaseTable.getColumnModel().getColumn(4).setPreferredWidth(50);
		DataBaseTable.getColumnModel().getColumn(4).setHeaderValue("Фильмы");
		DataBaseTable.getColumnModel().getColumn(5).setPreferredWidth(100);
		DataBaseTable.getColumnModel().getColumn(5).setHeaderValue("Гонорар");
		DataBaseTable.getColumnModel().getColumn(6).setPreferredWidth(50);
		DataBaseTable.getColumnModel().getColumn(6).setHeaderValue("Нападки");
		JScrollPane JSP = new JScrollPane(DataBaseTable,JScrollPane.VERTICAL_SCROLLBAR_ALWAYS, JScrollPane.HORIZONTAL_SCROLLBAR_NEVER);
		//создание прокрутки для таблицы, в качестве параметров - 1. что будет прокручиваться, 2. правило для вертикального ползунка - всегда
		//3. правило для горизонтального ползунка
		TablePanel.add(JSP);	//добавляем в контейнер с таблицей
		
		GridLayout TextLabelGrid = new GridLayout(2, 6, 5, 10);	//2 - количество строк, 6 - количество столбцов, 
		//5 - расстояние по Г между элементами, 10 - расстояние по В между элементами
		GridPanel.setLayout(TextLabelGrid);		//задаём правило расположения согласно указанной выше таблице
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
		
		getContentPane().setLayout(new BorderLayout());				//устанавливаем правило размещения
		getContentPane().setMaximumSize(new Dimension(800, 550));
		getContentPane().add(ButtonPanel, "North");
		getContentPane().add(TablePanel);
		getContentPane().add(GridPanel, "South");			
		
		pack();		//применяем указанные размеры
				
	}
		
	class ConnectAction extends AbstractAction		//нажатие на кнопку подключения
	{
		@Override
		public void actionPerformed(ActionEvent e) 
		{		
			if (Connection != true)	
			{
			Connection = false;	//соединения еще нет
			Units.clear();		//очищаем список значений из БД	
	    	try{
	            Class.forName("com.mysql.cj.jdbc.Driver").getDeclaredConstructor().newInstance();	//вызов драйвера для подключения к БД            
	        }
	        catch(Exception ex)
	    	{
	        	JOptionPane.showMessageDialog(null, "Ошибка подключения к БД! " + ex);		//аналог месседж бокса
	        	return;
	        }	
	    	try(Connection con = DriverManager.getConnection(url, user, password))	//пытаемся получить соединение с БД через драйвер
	    	{
	    		String sqlCommand = "SELECT * from actors";	   	//записываем в строку SQL команду   
	  	      	Statement state = con.createStatement();		//создаём заявление, привязанное к текущему подключению
	  	      	ResultSet rs = state.executeQuery(sqlCommand); 	//ResultSet формирует данные, полученные в результате запроса через заявление
	  	      	while(rs.next())	//изначально rs указывает на место перед первой записью
	  	      		//rs.next совершает шаг вперед по прочитанным записям из базы данных
		      {
		    	  Units.add(new Unit(rs.getInt("ID"), rs.getString("FIO"), rs.getString("Country"), rs.getInt("Roles"), rs.getInt("Films"), rs.getInt("HGon"), rs.getInt("Har")));
		      }
	  	      	//заполнение таблицы
	  	      for (int i = 0; i < Units.size(); i++)
	  	      {		//формируем ряд для добавления в таблицу
	  	    	  Object[] row = {Units.get(i).id, Units.get(i).FIO, Units.get(i).Country, Units.get(i).Roles, Units.get(i).Films, Units.get(i).Gonorar, Units.get(i).Rape}; 
	  	    	  DefaultTableModel mod = (DefaultTableModel) DataBaseTable.getModel();	//получили модель таблицы
	  	    	  mod.addRow(row);		//добавили строку со значениями в таблицу
	  	      }
	  	      Connection = true;	//соединение успешно установлено
	  	      rs.close();
	  	      state.close();	//закрываем связанные с соединением классы
	  	      con.close();
	    	}
	    	catch(Exception ex)
	    	{
	        	JOptionPane.showMessageDialog(null, "Ошибка чтения БД! " + ex);
	        	return;
	        }
	    	Connection = true;
			}
			else
			{
				JOptionPane.showMessageDialog(null, "Соединение уже установлено!");
			}
		}		
	}
	
	class AddAction extends AbstractAction			//нажатие на кнопку добавления
	{
		@Override
		public void actionPerformed(ActionEvent e) 
		{	
			if (Connection == true)
			{
				try(Connection con = DriverManager.getConnection(url, user, password))	//подключаемся к базе данных
		    	{
					Boolean t1 = false, t2 = false, t3 = false, t4 = false, t5 = false, t6 = false, cond = false;	
					//t1-t6 проверка текстфилдов на ввод, cond общая проверка
		    		t1 = JTFfio.getText() != "";		//если ФИО не пусто, то true
		    		t2 = JTFcountry.getText() != "";	//если страна не пусто, то true
		    		try
		    		{
		    			int a = Integer.parseInt(JTFroles.getText());	//пробуем привестри написанную строку к числу
		    			t3 = true;		//если получилось, то true
		    		}
		    		catch (Exception ex)	//если не получилось
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
		    		cond = t1 & t2 & t3 & t4 & t5 & t6;	//Объединяем все проверенные условия по И(&)
		    		
		    		if (!cond)	//если cond == false
		    		{
		    			JOptionPane.showMessageDialog(null, "Строка для добавления не соответствует формату!");
		    			con.close();
		    			return;		    			
		    		}
		    		else
		    		{
		    			Statement state = con.createStatement();
		    			String sqlCommand1 = "INSERT INTO actors (FIO, Country, Roles, Films, HGon, Har) VALUES ('"+ JTFfio.getText() +"', '"+ JTFcountry.getText() +"',"
		    			+ Integer.parseInt(JTFroles.getText()) +" , "+ Integer.parseInt(JTFfilms.getText()) +", "
		    			+ Integer.parseInt(JTFhgon.getText()) +", "+ Integer.parseInt(JTFhar.getText()) +")";
			  	      	state.execute(sqlCommand1); //так как ничего не возвращаем, используем execute а не executeQuery
			  	        String sqlCommand2 = "SELECT * from actors";	
			  	        ResultSet rs = state.executeQuery(sqlCommand2); 	//выполняем запрос
			  	        Units.clear();
			  	        while(rs.next())
			  	        {
			  	        	Units.add(new Unit(rs.getInt("ID"), rs.getString("FIO"), rs.getString("Country"), rs.getInt("Roles"), rs.getInt("Films"), rs.getInt("HGon"), rs.getInt("Har")));
			  	        }
			  	        DefaultTableModel mod1 = (DefaultTableModel) DataBaseTable.getModel();	//получаем модель таблицы
			  	        mod1.setRowCount(0);	//обнуляем количество строк
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
		        	JOptionPane.showMessageDialog(null, "Ошибка чтения БД! " + ex);
		        	return;
		        }
			}
			else
			{
				JOptionPane.showMessageDialog(null, "Соединение с БД не было установлено!");
			}
		}
		
	}
	
	class DeleteAction extends AbstractAction		//нажатие на кнопку удаления
	{
		@Override
		public void actionPerformed(ActionEvent e) 
		{			
			if (Connection == true)
			{
				try(Connection con = DriverManager.getConnection(url, user, password))
		    	{
					Boolean cond = false; int Nid = -1;		//изначально условие не соблюдено, удаляемый id = -1
					if (DataBaseTable.getSelectedRow() == -1)	//проверяем выбран ли какой-то ряд
					{
						cond = false;
					}
					else
					{
						cond = true;	//условие для удаления выполняется
						Nid = (int)DataBaseTable.getModel().getValueAt(DataBaseTable.getSelectedRow(), 0);	//получить значение ID в выбранном ряде
					}
		    		
		    		if (!cond || Nid < 0)
		    		{
		    			JOptionPane.showMessageDialog(null, "Строка для удаления не выбрана!");
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
		        	JOptionPane.showMessageDialog(null, "Ошибка чтения БД! " + ex);
		        	return;
		        }
			}
			else
			{
				JOptionPane.showMessageDialog(null, "Соединение с БД не было установлено!");
			}	
		}		
	}
	
	class ChangeAction extends AbstractAction		//нажатие на кнопку изменения
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
						JOptionPane.showMessageDialog(null, "Поля для ввода не соответствуют формату!");
		    			con.close();
		    			return;
					}
		    		
		    		if (!cond2 || Nid < 0)
		    		{
		    			JOptionPane.showMessageDialog(null, "Строка для изменения не выбрана!");
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
		        	JOptionPane.showMessageDialog(null, "Ошибка чтения БД! " + ex);
		        	return;
		        }
			}
			else
			{
				JOptionPane.showMessageDialog(null, "Соединение с БД не было установлено!");
			}	
		}		
	}
	
	class FilterAction extends AbstractAction		//нажатие на кнопку запроса
	{
		int mode = 0;	//режим нажатия
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
						String SQLM0 = "SELECT * from actors WHERE Country = 'Великобритания'";
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
			  	      mode = 1;		//переключаем режим кнопки
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
		        	JOptionPane.showMessageDialog(null, "Ошибка чтения БД! " + ex);
		        	return;
		        }
			}
			else
			{
				JOptionPane.showMessageDialog(null, "Соединение с БД не было установлено!");
			}	
		}		
	}
}
