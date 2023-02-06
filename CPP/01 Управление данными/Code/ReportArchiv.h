//Модуль Report выполняет обработку архива в соответствии с заданным заданием. Обработка подразумевает печать не всего архива, а определенных заданных сведений

#include "desunit.h"
#include "time.h"			//задание включает в себя расчёт возраста, поэтому подключим библиотеку time.h, функции которой позволяют получать системное время.

//передача глобальных переменных 

extern unsigned char SignArchive;		//флаг создания архива
extern unsigned char FlagAdd;			//флаг дополнения архива
extern unsigned char FlagSort;			//флаг сортировки архива
extern unsigned char nk;				//количество элементов в массиве кодификатора
extern KodifType	Kodifs[KMax];		//массив кодификатора
extern int Device;						//флаг выводимого устройства
extern FILE *fRes;						//указатель на файл результата

//передача внешних функций

extern void wait_press_key(char *msg);
extern double GetNumber(double MinNumber, double MaxNumber, char m1,char n1,char m2,char n2);
extern void WritelnString(char S[80]);
extern int SearchKodif(int Kod, int nk);
extern int ReadFileOut(int *np, DynDirectory**Lp, DynDirectory**Rp);
extern void DisposeDirectory(DynDirectory*Lp, DynDirectory*Rp);

//основная функция модуля, которая реализует работу меню. предлагает пользователю выбор одного из трех режимов обработки
void WorkUpArchive();
//первый режим обработки - печатает сведения только о людях с заданной фамилией
void WorkUpSurname();
//второй режим обработки - печатает сведения только о людях старше заданного возраста(включительно)
void WorkUpAge();
//третий режим обработки - печатает сведения о трёх старейших людях
void WorkUpOldest();