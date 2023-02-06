//в модуле AddArchiv описываются функции, которые добавят к уже существующему бинарному архиву записи из файла add.txt

#include "desunit.h"

//передача файловых переменных

extern FILE *fArTxt;
extern FILE *fAddTxt;

//передача глобальных переменных-флагов

extern unsigned char SignArchive;		//флаг создания архива
extern unsigned char FlagAdd;			//флаг дополнения архива
extern unsigned char FlagSort;			//флаг сортировки архива

//передача внешних функций

extern void wait_press_key(char *msg);
extern int ReadFileOut(int *np, DynDirectory**Lp, DynDirectory**Rp);
extern int WriteFileOut(DynDirectory*Lp, DynDirectory*Rp);
extern void DisposeDirectory(DynDirectory*Lp, DynDirectory*Rp);
extern int ReadDirectory(FILE *f, DirectoryType * Directory);

//Основная функция модуля, которая и выполняет действие включения новых записей в бинарный архив
int AddArchive();
