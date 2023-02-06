//Модуль edit выполняет поиск записи по коду в архиве и изменяет часть реквизитов в этой записи

#include "desunit.h"

//передача глобальных переменных

extern unsigned char SignArchive;	//флаг создания архива

//передача функций

extern void wait_press_key(char *msg);
extern int Space(char *s, int k);
extern int NotSpace(char *s, int k);
extern char *FillString(char *S,unsigned char len,unsigned char pk);
extern double GetNumber(double MinNumber, double MaxNumber, char m1,char n1,char m2,char n2);
extern int ReadFileOut(int *np, DynDirectory**Lp, DynDirectory**Rp);
extern int WriteFileOut(DynDirectory*Lp, DynDirectory*Rp);
extern void DisposeDirectory(DynDirectory*Lp, DynDirectory*Rp);

//основная функция модуля, которая выполняет поиск записи по коду
int ChangeArchive();
//функция, которая изменяет поля в записи
void MakeComponent(DirectoryType * Directory);
