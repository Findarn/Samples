//Модуль создания архивного бинарного файла и массива кодификатора
//Также включает в себя функции печати архива из бинарного файла и массива кодификатора в виде таблицы

#include "desunit.h"

//передача файловых переменных

extern FILE *fArTxt;
extern FILE *fArBin;
extern FILE *fAddTxt;
extern FILE *fKodif;
extern FILE *fRes;

extern unsigned char SignArchive; //флаг состояния создания архива

extern KodifType	Kodif,			//один элемент кодификатора
					Kodifs[KMax];	//массив элеметов кодификатора
extern int nk;						//количество компонентов кодификатора

extern int Device;					//флаг вывода в файл результата

//передача внешних функций

extern void wait_press_key(char *msg);
extern int Space(char *s, int k);
extern int NotSpace(char *s, int k);
extern char *FillString(char *S,unsigned char len,unsigned char pk);
extern void WritelnString(char S[80]);
extern void SortKodif(int nk);

//создаёт и заполняет бинарный файл архива
void CreateArchive();
//считывает строку из текстового файла и формирует из неё структуру заданного типа
int ReadDirectory(FILE *f, DirectoryType *Directory);
//выводит на экран (и возможно в файл) бинарный файл архива
int PrintArchive();
//формирует массив кодификатора из текстового файла
void MakeKodifs(int *nk);
//печатает на экран (и возможно в файл) массив кодификатора
int PrintKodif(int nk);
