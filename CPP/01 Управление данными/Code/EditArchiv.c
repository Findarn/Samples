#include "EditArchiv.h"

int ChangeArchive()
{            
int Kod,Kod1,np;
unsigned char Cond=0;
DirectoryType Directory;
DynDirectory*Lp,*Rp;			
DynDirectory*Run;        
  if ( ! SignArchive )														 //проверка создания архива
  {
		 printf("\nАрхив не создан. Режим отменяется.\n");
		 wait_press_key("\nДля продолжения нажмите любую клавишу\n");
		 return 1;
	}
	ReadFileOut(&np,&Lp,&Rp);												 //чтение бинарного файла архива и формирование очереди структур
  printf("\nУкажите код ФИО :");						//приглашение ко вводу кода
	Kod=(int)ceil(GetNumber(0,99999,1,0,6,0));			//ввод кода с клавиатуры с проверкой диапазона
  Kod1=Kod; printf("Kod = %6d",Kod1);					//отображаем введённый код
	Run=Lp; Cond=0;										//устанавливаем Run на Lp, обнуляем флаг Cond, который будет сообщать о том, было ли произведено редактирование
  while (Run!=NULL) 
  {
		if (Kod==Run->Inf.Code)																				//если в очереди обнаружена запись с таким кодом
		{	
			Cond=1;																						//взводим влаг Cond
			Directory = Run->Inf;																		//записываем информационное поле этого элемента в Directory
			printf("\n          Укажите следующие реквизиты через пробел :\n");
			printf("Улица (до 15 символов), номер дома, номер квартиры, телефон (цифры слитно).  \n");	//выводим приглашение ко вводу данных для редактирования
			printf("         Если номер домашнего телефона отсутствует, введите 0  \n");
			MakeComponent(&Directory);								//ввод и формирование компонента Directory происходит в этой функции
			Run->Inf= Directory;									//записываем Directiry в информационное поле того же элемента
			WriteFileOut(Lp,Rp);									//перезаписываем бинарный файл архива
			printf("Изменение компонента в архиве закончено\n");
			break;													//прекращаем работу цикла
		} 
		Run=Run->Next;												//переходим к следующему элементу очереди
	}
  if (! Cond )	
    printf("\nВ архиве нет компонента с кодом %d\n",Kod1);
    DisposeDirectory(Lp, Rp);											//удаляем очередь
	wait_press_key("\nДля продолжения нажмите любую клавишу\n");
	return 0;
}	

void MakeComponent(DirectoryType *Directory)
{                    
	unsigned char k,n,Cond;
	int k1,k2;
	char Sa[80],Sb[80];	
	printf("Текущие значения:\n");
	printf("Улица - %s\n", Directory -> Street);
	printf("Номер дома - %d \n", Directory -> House);			//выводим на экран текущие значения редактируемых реквизитов
	printf("Номер квартиры - %d \n", Directory -> Flat);
	if (Directory->Phone == 0)
	{
		printf("Телефон - отсутствует.\n", Directory->Phone / 10000, (Directory->Phone / 100) % 100, Directory->Phone % 100);	//если телефон отсутствует - выводим это таким образом
	}
	else
	{
		printf("Телефон - %3d-%2d-%2d\n", Directory->Phone / 10000, (Directory->Phone / 100) % 100, Directory->Phone % 100);	//если телефон есть - выводим номер телефона
	}
	clear_input_buffer();	//очищаем буфер ввода
	gets_s(Sa, 80);			//введенное с клавиатуры значение попадает в строку Sa			
	Cond=1; k2=-1; k=0;
	while (Cond==1)	
	{								
		k1=NotSpace(Sa,k2+1);
		if (k1==-1) Cond=0;
		else
		{  
			k2=Space(Sa,k1+1);										//с помощью поиска индекса пробельного и непробельного символов разбиваем прочитанную строку на слова
			if (k2==-1) { k2=strlen(Sa)+1; Cond=0; }
			k++; n=k2-k1;
			strncpy(Sb,&Sa[k1],n);
			Sb[n]='\0';           
			switch ( k )											//номер слова - k, само слово - в строке Sb
			{
			 
				case 1:																
					strncpy(Directory->Street, &Sb[0], n);							//1-ое слово - это название улицы. Копируем его в соответствующее поле Street в структуре
					Directory->Street[n] = '\0';									//последний символ помечаем как признак конца строки
					FillString(Directory->Street, 15, 1);				break;		//заполняем оставшиеся символы пробелами
				case 2:sscanf_s(Sb,"%d",&Directory->House);				break;		//2-ое слово - это номер дома. Вносим значение из строки Sb в поле House
				case 3:sscanf_s(Sb,"%d",&Directory->Flat);				break;		//3-е слово - это номер квартиры. Вносим значение из строки Sb в поле Flat
				case 4:sscanf_s(Sb,"%d",&Directory->Phone);				break;		//4-ое слово - это номер телефона. Вносим значение из строки Sb в поле Phone
     
			}
		}
	}
} 
