//модуль Sort выполн€ет сортировку бинарного архива заданным методом

#include "desunit.h"

//передача файловой переменой

extern FILE *fArBin;

//передача глобальных переменных-флагов

extern unsigned char SignArchive;	//флаг создани€ архива
extern unsigned char FlagSort;		//флаг сортировки архива

//передача внешних функций

extern void wait_press_key(char *msg);
extern int ReadFileOut(int *np, DynDirectory**Lp, DynDirectory**Rp);
extern int WriteFileOut(DynDirectory*Lp, DynDirectory*Rp);
extern void DisposeDirectory(DynDirectory*Lp, DynDirectory*Rp);

//основна€ функци€ модул€, выполн€юща€ сортировку архива
int SortArchive();
