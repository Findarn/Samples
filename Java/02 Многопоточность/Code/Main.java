package lab5;

import java.awt.*;
import javax.swing.*;
import javax.swing.event.*;
import java.awt.event.*;
import java.awt.geom.Point2D;
import java.lang.Thread.State;
import java.util.Random;

public class Main implements ActionListener, ChangeListener, ItemListener{

    JFrame frame;    
    JCanvasPanel panel1;
    JPanel panel2, panel3;    
    
    JButton BStart = new JButton("Начало");
    JButton BStop = new JButton("Остановка");
    
    JLabel LCoordLTP = new JLabel("Координаты 1 точки");
    JLabel LCoordRBP = new JLabel("Координаты 2 точки");
    JLabel LCountGifts = new JLabel("Количество подарков");
    JLabel LCountGrinches = new JLabel("Количество чертей");
    JLabel LSpeed = new JLabel("Скорость анимации");
    JLabel LTimer = new JLabel("Время для чертей");
    
    JSpinner SCoordLTPx = new JSpinner();
    JSpinner SCoordLTPy = new JSpinner();
    JSpinner SCoordRBPx = new JSpinner();
    JSpinner SCoordRBPy = new JSpinner();
    
    JSlider SGifts = new JSlider();
    JSlider SGrinches = new JSlider();
    JSlider SSpeed = new JSlider();
    JSlider STimer = new JSlider();
    
    private Gift GiftsArray[];
    private GiftView GiftViewer;
    private Grinch GrinchesArray[];
    private GrinchView GrinchViewer;   
    
    // Конструктор
    public Main()
    {    	
        this.frame = new JFrame("Работа с потоками");        
        this.panel1 = new JCanvasPanel();
        this.panel2 = new JPanel();
        this.panel3 = new JPanel();        
    }
    // Метод подготовки интерфейса
    public void launchFrame()
    {   
    	this.BStart.addActionListener(this);
    	this.BStop.addActionListener(this);
    	
    	this.LCoordLTP.setPreferredSize(new Dimension(180, 24));
        this.LCoordLTP.setFont(new Font("Arial", Font.PLAIN, 12));
        this.LCoordLTP.setHorizontalAlignment(SwingConstants.CENTER);
        
        this.LCoordRBP.setPreferredSize(new Dimension(180, 24));
        this.LCoordRBP.setFont(new Font("Arial", Font.PLAIN, 12));
        this.LCoordRBP.setHorizontalAlignment(SwingConstants.CENTER);
        
        this.LCountGifts.setPreferredSize(new Dimension(180, 24));
        this.LCountGifts.setFont(new Font("Arial", Font.PLAIN, 12));
        this.LCountGifts.setHorizontalAlignment(SwingConstants.CENTER);
        
        this.LCountGrinches.setPreferredSize(new Dimension(180, 24));
        this.LCountGrinches.setFont(new Font("Arial", Font.PLAIN, 12));
        this.LCountGrinches.setHorizontalAlignment(SwingConstants.CENTER);
        
        this.LSpeed.setPreferredSize(new Dimension(180, 24));
        this.LSpeed.setFont(new Font("Arial", Font.PLAIN, 12));
        this.LSpeed.setHorizontalAlignment(SwingConstants.CENTER);
        
        this.LTimer.setPreferredSize(new Dimension(180, 24));
        this.LTimer.setFont(new Font("Arial", Font.PLAIN, 12));
        this.LTimer.setHorizontalAlignment(SwingConstants.CENTER);
    	
        
        
        this.SCoordLTPx.setPreferredSize(new Dimension(180, 24));
        this.SCoordLTPx.setBorder(BorderFactory.createLineBorder(Color.gray));
        this.SCoordLTPx.setFont(new Font("Arial", Font.PLAIN, 12));
        // Задаем начальное значение, минимум, максимум, шаг прироста
        this.SCoordLTPx.setModel(new SpinnerNumberModel(100, 10, 790, 1));
        this.SCoordLTPx.addChangeListener(this);        
        
        this.SCoordLTPy.setPreferredSize(new Dimension(180, 24));
        this.SCoordLTPy.setBorder(BorderFactory.createLineBorder(Color.gray));
        this.SCoordLTPy.setFont(new Font("Arial", Font.PLAIN, 12));
        // Задаем начальное значение, минимум, максимум, шаг прироста
        this.SCoordLTPy.setModel(new SpinnerNumberModel(100, 10, 790, 1));
        this.SCoordLTPy.addChangeListener(this);
        
        this.SCoordRBPx.setPreferredSize(new Dimension(180, 24));
        this.SCoordRBPx.setBorder(BorderFactory.createLineBorder(Color.gray));
        this.SCoordRBPx.setFont(new Font("Arial", Font.PLAIN, 12));
        // Задаем начальное значение, минимум, максимум, шаг прироста
        this.SCoordRBPx.setModel(new SpinnerNumberModel(400, 10, 790, 1));
        this.SCoordRBPx.addChangeListener(this);        
        
        this.SCoordRBPy.setPreferredSize(new Dimension(180, 24));
        this.SCoordRBPy.setBorder(BorderFactory.createLineBorder(Color.gray));
        this.SCoordRBPy.setFont(new Font("Arial", Font.PLAIN, 12));
        // Задаем начальное значение, минимум, максимум, шаг прироста
        this.SCoordRBPy.setModel(new SpinnerNumberModel(400, 10, 790, 1));
        this.SCoordRBPy.addChangeListener(this);
        
        this.SGifts.setPreferredSize(new Dimension(180, 45));
        this.SGifts.setMinimum(0);
        this.SGifts.setMaximum(100);
        this.SGifts.setValue(30);
        this.SGifts.setMajorTickSpacing(25);
        this.SGifts.setMinorTickSpacing(5);
        this.SGifts.setPaintTicks(true);
        this.SGifts.setPaintLabels(true);
        this.SGifts.setFont(new Font("Arial", Font.PLAIN, 12));
        this.SGifts.addChangeListener(this);
        
        this.SGrinches.setPreferredSize(new Dimension(180, 45));
        this.SGrinches.setMinimum(0);
        this.SGrinches.setMaximum(200);
        this.SGrinches.setValue(60);
        this.SGrinches.setMajorTickSpacing(50);
        this.SGrinches.setMinorTickSpacing(10);
        this.SGrinches.setPaintTicks(true);
        this.SGrinches.setPaintLabels(true);
        this.SGrinches.setFont(new Font("Arial", Font.PLAIN, 12));
        this.SGrinches.addChangeListener(this);
        
        this.SSpeed.setPreferredSize(new Dimension(180, 45));
        this.SSpeed.setMinimum(0);
        this.SSpeed.setMaximum(40);
        this.SSpeed.setValue(5);
        this.SSpeed.setMajorTickSpacing(5);
        this.SSpeed.setMinorTickSpacing(1);
        this.SSpeed.setPaintTicks(true);
        this.SSpeed.setPaintLabels(true);
        this.SSpeed.setFont(new Font("Arial", Font.PLAIN, 12));
        this.SSpeed.addChangeListener(this);
        
        this.STimer.setPreferredSize(new Dimension(180, 45));
        this.STimer.setMinimum(10);
        this.STimer.setMaximum(50);
        this.STimer.setValue(15);
        this.STimer.setMajorTickSpacing(5);
        this.STimer.setMinorTickSpacing(1);
        this.STimer.setPaintTicks(true);
        this.STimer.setPaintLabels(true);
        this.STimer.setFont(new Font("Arial", Font.PLAIN, 12));
        this.STimer.addChangeListener(this);
        
        this.panel1.setBorder(BorderFactory.createMatteBorder(1, 0, 0, 0, Color.GRAY));
        this.panel1.setBackground(Color.WHITE);                
        this.panel3.setPreferredSize(new Dimension(180, 30));        
        this.panel2.setBorder(BorderFactory.createMatteBorder(1, 1, 0, 0, Color.GRAY));
        this.panel2.setPreferredSize(new Dimension(200, -1));
        this.panel2.add(this.LCoordLTP, BorderLayout.NORTH);
        this.panel2.add(this.SCoordLTPx, BorderLayout.NORTH);
        this.panel2.add(this.SCoordLTPy, BorderLayout.NORTH);
        this.panel2.add(this.LCoordRBP, BorderLayout.NORTH);
        this.panel2.add(this.SCoordRBPx, BorderLayout.NORTH);
        this.panel2.add(this.SCoordRBPy, BorderLayout.NORTH);
        this.panel2.add(this.LCountGifts, BorderLayout.NORTH);
        this.panel2.add(this.SGifts, BorderLayout.NORTH);
        this.panel2.add(this.LCountGrinches, BorderLayout.NORTH); 
        this.panel2.add(this.SGrinches, BorderLayout.NORTH);
        this.panel2.add(this.LSpeed, BorderLayout.NORTH); 
        this.panel2.add(this.SSpeed, BorderLayout.NORTH); 
        this.panel2.add(this.LTimer, BorderLayout.NORTH); 
        this.panel2.add(this.STimer, BorderLayout.NORTH);        
        
        this.panel2.add(this.panel3, BorderLayout.NORTH);
        this.panel2.add(this.BStart, BorderLayout.NORTH);
        this.panel2.add(this.BStop, BorderLayout.NORTH);
        
        this.frame.add(this.panel1, BorderLayout.CENTER);
        this.frame.add(this.panel2, BorderLayout.EAST);
        // Размеры основной формы скорректированы так, чтобы размеры 
        // панели отображения были 800x800
        this.frame.setSize(1006,829);
        this.frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        this.frame.setLocationRelativeTo(null);
        this.frame.setResizable(false);
        this.frame.setVisible(true);
    }
    // Метод создания потоков
    public void initThreads()
    {
        Random r = new Random();
        
        int giftsCount = this.SGifts.getValue();	//количество подарков
        int grinchesCount = this.SGrinches.getValue();	//количество чертей
        
        this.GiftsArray = new Gift[giftsCount];
        this.GrinchesArray = new Grinch[grinchesCount];
        
        // Создаем поток отображения
        this.GiftViewer = new GiftView(this.panel1);
        this.GrinchViewer = new GrinchView(this.panel1);
        
        // Создаем потоки подарков
        Point A = new Point((int)this.SCoordLTPx.getValue(), (int)this.SCoordLTPy.getValue()); 
        Point B = new Point((int)this.SCoordRBPx.getValue(), (int)this.SCoordRBPy.getValue()); 
        for (int i=0; i<giftsCount; i++)
        {
        	Point C = new Point(A); //C.setLocation(A);
        	if (A.x >= B.x)
        	{
        		C.setLocation(r.nextInt(B.x+1, A.x-1), C.y);
        	}
        	else
        	{
        		C.setLocation(r.nextInt(A.x+1, B.x-1), C.y);
        	}
        	
        	if (A.y >= B.y)
        	{
        		C.setLocation(C.x, r.nextInt(B.y+1, A.y-1));
        	}
        	else
        	{
        		C.setLocation(C.x, r.nextInt(A.y+1, B.y-1));
        	}
        	
            this.GiftsArray[i] = new Gift(i, this);            
            this.GiftsArray[i].SetGiftStart(A, B, C, this.SSpeed.getValue());
        }
        
        //создаём потоки чертей
        for (int i=0; i<grinchesCount; i++)
        {
        	Point C = new Point(A); //C.setLocation(A);
        	C.x = r.nextInt(10, 790);
        	C.y = r.nextInt(10, 790);
        	this.GrinchesArray[i] = new Grinch(i, this);
        	this.GrinchesArray[i].SetStart(this.SSpeed.getValue(), ((double)this.STimer.getValue()/10), C);
        }
        
        this.panel1.setParam(this.GiftsArray,this.GrinchesArray);
        this.panel1.repaint();
    }
    // Обработчик кнопки Старт
    public void startAll()
    {   
    	this.SCoordLTPx.setEnabled(false);
    	this.SCoordLTPy.setEnabled(false);
    	this.SCoordRBPx.setEnabled(false);
    	this.SCoordRBPy.setEnabled(false);
    	this.SGifts.setEnabled(false);
    	this.SGrinches.setEnabled(false);
    	this.SSpeed.setEnabled(false);
    	this.STimer.setEnabled(false);
    	this.BStart.setEnabled(false);
    	this.BStop.setEnabled(true);
    	
    	if (this.SCoordLTPx.getValue() == this.SCoordRBPx.getValue() || this.SCoordLTPy.getValue() == this.SCoordRBPy.getValue())
    	{
    		return;
    	}
    	
           
        // Запуск потоков отображения
        this.GiftViewer.start();
        this.GrinchViewer.start();
        // Запуск потоков в работу
        for (int i=0; i<GiftsArray.length; i++)
            this.GiftsArray[i].start();
        for (int i=0; i<GrinchesArray.length; i++)
            this.GrinchesArray[i].start();
    }
    
    public void stopAll()
    {
    	this.SCoordLTPx.setEnabled(true);
    	this.SCoordLTPy.setEnabled(true);
    	this.SCoordRBPx.setEnabled(true);
    	this.SCoordRBPy.setEnabled(true);
    	this.SGifts.setEnabled(true);
    	this.SGrinches.setEnabled(true);
    	this.SSpeed.setEnabled(true);
    	this.STimer.setEnabled(true);
    	this.BStart.setEnabled(true);
    	this.BStop.setEnabled(false);
        
        for (int i=0; i<GiftsArray.length; i++)
            this.GiftsArray[i].end();
        for (int i=0; i<GrinchesArray.length; i++)
            this.GrinchesArray[i].end();
        this.GiftViewer.end();
        this.GrinchViewer.end();        
    }
    // Обработчик кнопок
    @Override
    public void actionPerformed(ActionEvent ae) {
        if (ae.getSource() == this.BStart)
            this.startAll();
        else
        	if (ae.getSource() == this.BStop)
        {
        	this.stopAll();
        	this.initThreads();
        }
    }
    // Обработчик ползунков и прокрутки
    @Override
    public void stateChanged(ChangeEvent ce) 
    {    	
    	if ((int)this.SCoordLTPx.getValue() == (int)this.SCoordRBPx.getValue() || (int)this.SCoordLTPy.getValue() == (int)this.SCoordRBPy.getValue())
    	{
    		
    	}
    	else
    	{
    		this.initThreads();	//переинициилизировать потоки
    	}
    }
    
    // Обработчик изменения направления очереди
    @Override
    public void itemStateChanged(ItemEvent ie) 
    {
        this.initThreads();
    } 
    
    public static void main(String[] args)
    {
        Main frame = new Main();
        frame.launchFrame();
        frame.initThreads();
    }
}