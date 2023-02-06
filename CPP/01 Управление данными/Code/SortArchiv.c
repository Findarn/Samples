#include "SortArchiv.h"

int SortArchive() 
{
	int np;
	DirectoryType buf;			
	DynDirectory *Runi, *Runj;	 
	DynDirectory *Lp, *Rp;			
	if (!SignArchive)												//проверяем, создан ли архив
	{
		printf("\nАрхив не создан. Режим отменяется.\n");
		wait_press_key("\nДля продолжения нажмите любую клавишу\n");
		return 1;
	}

	ReadFileOut(&np, &Lp, &Rp);										//считывание бинарного файла архива и формирование очереди структур
	
	//сортировка модифицированным школьным методом
	for (Runi = Lp; Runi != NULL; Runi = Runi->Next)				//организовываем внешний цикл, который перебирает элементы от первого до последнего		
		for (Runj = Runi->Next; Runj != NULL; Runj = Runj->Next)	//организовываем внутренний цикл, который перебирает элементы от i-ого до последнего
			if (Runi->Inf.Code > Runj->Inf.Code)					//если i-ый элемент больше j-ого
				
			{
				buf = Runi->Inf;
				Runi->Inf = Runj->Inf;								//происходит обмен информационными полями между этими элементами структуры
				Runj->Inf = buf;									//сортировка выполняется по возрастанию
			}

	WriteFileOut(Lp, Rp);											//бинарный файл архива перезаписывается отсортированной очередью	
	DisposeDirectory(Lp, Rp);										//удаляем очередь
	FlagSort = 1;													//флаг сортировки утснавливается в 1
	printf("\nСортировка архива закончена.\n");
	wait_press_key("\nДля продолжения нажмите любую клавишу\n");
	return 0;
}