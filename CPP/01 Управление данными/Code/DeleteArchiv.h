//модуль Delete отвечает за удаление одной выбранной по коду записи из бинарного архива.

#include "desunit.h"

//передача глобальной переменной

extern unsigned char SignArchive; //флаг создания архива
extern int nk;					  //количество элементов в массиве кодификатора

//передача глобальных переменных кодификатора и массива кодификаторов

extern KodifType	Kodif,
Kodifs[KMax];

//передача внешних функций

extern void wait_press_key(char *msg);
extern double GetNumber(double MinNumber, double MaxNumber, char m1,char n1,char m2,char n2);
extern int ReadFileOut(int *np, DynDirectory **Lp, DynDirectory**Rp);
extern int WriteFileOut(DynDirectory*Lp, DynDirectory*Rp);
extern void DisposeDirectory(DynDirectory*Lp, DynDirectory*Rp);

//основная функция модуля, которая выполняет поиск и удаление нужной записи
int DeleteArchive();
