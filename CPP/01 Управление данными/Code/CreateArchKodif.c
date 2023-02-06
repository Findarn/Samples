#include "CreateArchKodif.h"

void CreateArchive()
{
	DirectoryType Directory;
	if (SignArchive == 1)												//если архив уже был создан
	{
		printf("\nАрхив уже создан. Режим отменяется.\n");
		wait_press_key("\nДля продолжения нажмите любую клавишу\n");	//выходим из функции - создавать архив не надо
		return 0;
	}
	
	if((fArTxt=fopen(fArTxtName,"rt"))==NULL)									//открываем текстовый файл input в режиме чтения текстового файла rt
		{
		 printf("\nФайл %s не найден\n",fArTxtName);
		 wait_press_key("\nДля завершения программы нажмите любую клавишу\n");	//в случае ошибки печатаем сообщение
		 exit(0);
		}
		if((fArBin=fopen(fArBinName,"wb"))==NULL)								//открываем бинарный файл архива в режиме записи бинарного файла wb
		{
		 printf("\nФайл %s не создан\n",fArTxtName);
		 wait_press_key("\nДля завершения программы нажмите любую клавишу\n");	//в случае ошибки печатаем сообщение
		 exit(0);
		}
	do															//цикл с постусловием
	{ 
		if (ReadDirectory(fArTxt,&Directory)==0)				//функция, которая формирует структуру, в случае успешного завершения работы возвращает 0
			fwrite(&Directory,sizeof(DirectoryType),1,fArBin);	//если чтение структуры было успешно произведено из файла fArTxt в Directory, то в fArBin помещается один объект размером
																//sizeof(DirectoryType), взятый из Directiry
	}
	while ( ! feof(fArTxt) );									//цикл выполняется, пока не обнаружен конец текстового файла	
	fclose(fArTxt); fArTxt=NULL;								//после завершения работы файлы закрываются, а указатели на файлы обнуляются
	fclose(fArBin); fArBin=NULL;	
	MakeKodifs(&nk);					//формируется массив кодификатора
	SortKodif(nk);						//после чего сортируется
	SignArchive=1;						//флаг создания архива устанавливаем в единицу
	printf("\n	Архив создан\n");
	wait_press_key("\nДля продолжения нажмите любую клавишу\n");
}	

int ReadDirectory(FILE *f,DirectoryType *Directory)
{
	char sIn[80];		
	char slovo[30];	
	unsigned char Cond=0;	
	int k1,k2,k,i,n;
	if ( fgets(sIn, 80, f) != NULL )	
	{	
		k=strlen(sIn);	
		if (sIn[k-1]==10) sIn[k-1]='\0';	//аналогично функции в модуле CheckInpFile производим чтение строки из текстового файла - с определением индексов непробельных и пробельных символов
		i=0; k=0; Cond=1; k2=-1;	
		while(Cond)
		{
			k1=NotSpace(sIn,k2+1); 
			if(k1==-1) 
				Cond = 0;    
			else
			{
				k2=Space(sIn,k1+1);	
				if (k2==-1)					
				{
					k2=strlen(sIn); 
					Cond = 0;				
				}
				n=k2-k1;										
				strncpy(slovo,&sIn[k1],n);	
				slovo[n]='\0';							
				k++;																	//в итоге текущее прочитанное слово оказывается в строке slovo
				switch ( k )															//а номер слова в строке - в переменной k
					{	
					 case 1:
						 strncpy(Directory->Num, &slovo[0], n);						//1-ое слово - номер записи. Строка из 6 символов. Копируем её в поле Num
						 Directory->Num[n] = '\0';									//последним символов в поле Num помещаем признак окончания строки
						 FillString(Directory->Num, 6, 1);					break;	//заполняем оставшееся место пробелами
					 case 2:sscanf_s(slovo,"%d", &Directory->Code);			break;	//2-ое слово - код ФИО. Заносим значение из slovo в поле Code
					 case 3:sscanf_s(slovo,"%d", &Directory->Birthday);		break;	//3-е слово - дата рождения. Заносим значение из slovo в поле Birthday
					 case 4:														
						 strncpy(Directory->Street, &slovo[0], n);					//4-ое слово - название улицы. Строка из 15 символов. Копируем её в поле Street
						 Directory->Street[n] = '\0';								//последним символов в поле Street помещаем признак окончания строки
						 FillString(Directory->Street, 15, 1);				break;	//заполняем оставшееся место пробелами
					 case 5:sscanf_s(slovo,"%d", &Directory->House);		break;	//5-ое слово - номер дома. Заносим значение из slovo в поле House
					 case 6:sscanf_s(slovo, "%d", &Directory->Flat);		break;	//6-ое слово - номер квартиры. Заносим значение из slovo в поле Flat
					 case 7:sscanf_s(slovo, "%d", &Directory->Phone);		break;	//7-ое слово - номер телефона. Заносим значение из slovo в поле Phone
					}
			}
		}
		return 0;		//в случае успешного формирования структуры возвращаем ноль
	}
	else return 1;		//иначе возвращаем один
}	

int PrintArchive()
{
	DirectoryType Directory;
	int i,p=1;		
	char s[90];
	char slovo[90]="";
	if (SignArchive==0)													//проверяем, создан ли архив
	{
		 printf("\nАрхив не создан. Режим отменяется.\n");
		 wait_press_key("\nДля продолжения нажмите любую клавишу\n");	//если не создан - печатаем сообщение об ошибке
		 return 0;
	}	
	if((fArBin=fopen(fArBinName,"rb"))==NULL)							//открываем бинарный файл архива в режиме бинарного чтения rb
	{
		 printf("\nФайл %s не найден. Режим отменяется.\n",fArBinName);
		 wait_press_key("\nДля продолжения нажмите любую клавишу\n");	//если не удалось открыть файл - печатаем сообщение об ошибке
		 SignArchive=0;
		 return 0;
	}
	
	

  WritelnString("               AРХИВ СВЕДЕНИЙ О СПРАВОЧНОМ БЮРО");
  WritelnString(
      " ------------------------------------------------------------------------------ ");
  WritelnString(
	  "|№п/п |  Номер |  Код  |   Дата     |      Улица     | Дом | № кв. |  Телефон  |");			//в функцию WriteInString передаём сообщение, которое необходимо напечатать
  WritelnString(
      "|     | записи |  ФИО  |  рождения  |                |     |       |           |");			//это шапка таблицы 
  WritelnString(
      "|------------------------------------------------------------------------------|");
  
	i=0;																								//i - это номер записи в архиве
	if( p=fread(&Directory,sizeof(DirectoryType),1,fArBin)<1) p=EOF;									//читаем из fArBin один объект размером sizeof(DirectoryType) в структуру Directory
	while (p != EOF)																					//пока при чтении не достигли конца файла
	{	i++; s[0] = '|'; s[1] = '\0';																	//формируем строку s для печати
		sprintf(slovo, "%3d", i); strcat(s, slovo); strcat(s, ". | ");									//присоединяем к концу строки s значение i
		strcat(s, Directory.Num);		strcat(s, " | ");												//присоединяем к концу строки s значение Num
		sprintf(slovo, "%5d", Directory.Code); strcat(s, slovo); strcat(s, " | ");						//присоединяем к концу строки s значение Code
		sprintf(slovo, "%02d", (Directory.Birthday / 100) % 100); strcat(s, slovo); strcat(s, ".");		//Дату выводим уже более читабельной - сперва присоединяем к концу строки s день рождения и точку
		sprintf(slovo, "%02d", Directory.Birthday % 100); strcat(s, slovo); strcat(s, ".");				//затем присоединяем к концу строки s месяц рождения и точку
		sprintf(slovo, "%4d", Directory.Birthday / 10000); strcat(s, slovo); strcat(s, " | ");			//и затем присоединяем к концу строки год рождения
		strcat(s, Directory.Street);		strcat(s, " | ");											//присоединяем к концу строки улицу 
		sprintf(slovo, "%3d", Directory.House); strcat(s, slovo); strcat(s, " | ");						//присоединяем к концу строки номер дома
		sprintf(slovo, "%5d", Directory.Flat); strcat(s, slovo); strcat(s, " | ");						//присоединяем к концу строки номер квартиры
		if (Directory.Phone == 0)																		//проверяем, есть ли домашний телефон у записи в архиве
		{
			strcat(s, "    -    ");		strcat(s, " | ");												//если нет, то выводим прочерк
		}
		else																							//если есть, то, как и с датой, выводим номер телефона в более приемлимом виде
		{
			sprintf(slovo, "%03d", Directory.Phone / 10000); strcat(s, slovo); strcat(s, "-");			//присоединяем к концу строки первые три цифры номера телефона и -
			sprintf(slovo, "%02d", (Directory.Phone / 100) % 100); strcat(s, slovo); strcat(s, "-");	//присоединяем к концу строки следующие две цифры номера телефона и -
			sprintf(slovo, "%02d", Directory.Phone % 100); strcat(s, slovo); strcat(s, " | ");			//присоединяем к концу строки оставшиеся две цифры номера телефона
		}
		WritelnString(s);																				//печатаем сформированную строку s
		if (p = fread(&Directory, sizeof(DirectoryType), 1, fArBin) < 1) p = EOF;						//повторяем попытку прочитать файл
	}
	WritelnString(
		"|______________________________________________________________________________|\n");			//печатаем закрывающую линию таблицы снизу
	fclose(fArBin);														//закрываем бинарный файл
	wait_press_key("\nДля продолжения нажмите любую клавишу\n");

	return 0;

}	

void MakeKodifs(int *nk)
{ 
	char Sa[80],Sb[80];
	unsigned char  n,k,Cond;
	int k1,k2;	
	if((fKodif=fopen(fKodifName,"rt"))==NULL)
		{
		 printf("\nФаил %s не найден\n",fArTxtName);
		 wait_press_key("\nДля завершения программы нажмите любую клавишу\n");
		 exit(0);
		}
  
  *nk=0;	
  while (fgets(Sa,80,fKodif)!=NULL) 
	{
		n=strlen(Sa); 
		if (Sa[n-1]==10) 	Sa[n-1]='\0'; 
		Cond=1; k2=-1; k=0;
		while (Cond) 
			{
				k1=NotSpace(Sa,k2+1);
				if (k1==-1) Cond=0;
				else
				{
					k2=Space(Sa,k1+1);
					if (k2==-1) { k2=strlen(Sa); Cond=0; }					//аналогично читаются слова из файла kodif и записываются в нужные поля
					k++;
					n=k2-k1;
					strncpy(Sb,&Sa[k1],n);									//текущее слово находится в строке Sb
					Sb[n]='\0';												//номер текущего слова в переменной k
					switch (k)
					{	
						case 1:sscanf_s(Sb,"%d",&Kodif.Code);	break;		//1-ое слово - код ФИО. Заносим значение из Sb в поле Code
						case 2:strncpy(Kodif.FIO,&Sb[0],n);					//2-ое слово - ФИО. Строка из 20 символов. Копируем её в поле FIO
							   Kodif.FIO[n]='\0';							//последний символ задаем как признак окончания строки
							   FillString(Kodif.FIO,20,1);	break;			//заполняем оставшиеся неопределенные символы пробелами
					}
				}
			}			
			Kodifs[*nk]=Kodif;
      (*nk)++;					
	}
  fclose(fKodif);
}	

int PrintKodif(int nk)
{
	char s[80];
	char slovo[80]="";
	int i,j=0;	
  if (SignArchive==0)													//проверяем, создан ли архив
	{
		 printf("\nАрхив не создан. Режим отменяется.\n");
		 wait_press_key("\nДля продолжения нажмите любую клавишу\n");	//если архив не создан - печатаем сообщение об ошибке
		 return 0;
	}
  WritelnString(
"\n           КОДИФИКАТОР ИНИЦИАЛОВ");
  WritelnString(
"|-----------------------------------------|");					//печать шапки таблицы кодификатора
  WritelnString(
"| Nп/п | Код ФИО |         ФИО            |");					//полностью аналогично предыдущей таблице
  WritelnString(
"|-----------------------------------------|");
  j=0;
  for (i = 0; i < nk; i++)
  {
	  Kodif = Kodifs[i];
	  j++; s[0] = '|'; s[1] = '\0';
	  sprintf(slovo, "%3d", j); strcat(s, slovo); strcat(s, ".  |  ");				//собираем строку s для печати
	  sprintf(slovo, "%05d", Kodif.Code); strcat(s, slovo); strcat(s, "  | ");
	  strcat(s, Kodif.FIO + 2);		strcat(s, " ");
	  strncat(s, Kodif.FIO, 1);		strcat(s, ".");
	  strncat(s, Kodif.FIO + 1, 1);		strcat(s, ". |");
	  WritelnString(s);																//печатаем строку s
  }
		
  WritelnString(
"|-----------------------------------------|");
	wait_press_key("\nДля продолжения нажмите любую клавишу\n");
	return 0;
}	
