//в модуле kurs содержитс€ основна€ программа, котора€ вызывает другие функции. язык — позвол€ет выполн€ть раздельную компил€цию модулей
//поэтому существуют способы передачи глобальных переменных файлам программы. дл€ этого используетс€ ключевое слово extern
#include "desunit.h"

extern FILE *fRes;			//передача глобальной файловой переменной, котора€ указывает на файл, содержащий результаты работы программы 
extern int nk;				//передача глобальной переменной, котора€ содержит количество записей в кодификаторе          
extern int SignArchive;		//передача глобальной переменной-флага создани€ бинарного файла архива (1 - создан, 0 не создан)
extern int Device;			//передача глобальной переменной-флага, котора€ отображает необходимость вывода результатов в соответствующий файл (1 - выводить, 0 - не выводить)

//передача функций из модул€ baseunit

extern void wait_press_key(char *msg);	
extern void UsesDevice();
extern double GetNumber(double MinNumber, double MaxNumber, char m1,char n1,char m2,char n2);

//передача функций из соответствующих им модулей

extern void CreateArchive();
extern int PrintArchive();
extern int PrintKodif(int nk);
extern int SortArchive();
extern void CheckFiles();
extern int AddArchive();
extern int DeleteArchive();
extern int ChangeArchive();
extern void WorkUpArchive();
