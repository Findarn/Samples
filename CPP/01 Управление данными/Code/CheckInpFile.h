//Модуль Check Input File отвечает за различные проверки исходных файлов input.txt, add.txt, kodif.txt
#include "desunit.h"

//передача глобальных файловых переменных

extern FILE *fArTxt;
extern FILE *fArBin;
extern FILE *fAddTxt;
extern FILE *fKodif;
extern FILE *fRes;

//передача глобальных переменных кодификатора и массива кодификаторов

extern KodifType	Kodif, 
					Kodifs[KMax];  

//передача функций из модуля baseunit

extern void wait_press_key(char *msg);
extern int Space(char *s, int k);
extern int NotSpace(char *s, int k);
extern void SortKodif(int nk);
extern char *FillString(char *S, unsigned char len,	unsigned char pk);
extern int SearchKodif(int Kod, int nk);



typedef char string80[80];                  //определение массива символов (строки)						
typedef string80 FileStringAr[PMax];	    //определение массива строк
typedef FileStringAr *FileStringArPtr;      //определение указателя на массив строк
typedef DirectoryType  DirectoryAr[PMax];   //определение массива записей архива
typedef DirectoryAr * DirectoryArPtr;       //определение указателя на массив записей архива


FILE *FileError;                            //Вводим глобальную файловую переменную для файла ошибок
char *FileErrorName="Error.dat";            //Задаем название файлу ошибок
int const  NfMax = PMax;                    //Определяем максимальное количество строк в текстовом файле
int 
	np,                                     //переменная, определяющая количество строк в файле input
    nd,                                     //переменная, определяющая количество строк в файле add
    nk,				                        //переменная, определяющая количество строк в файле kodif
    FatalError;                             //флаг, определяющий наличие ошибки в исходных данных (1 - ошибки присутствуют, 0 - ошибок нет)

string80	Sr;				                //строка для вывода сообщений об ошибке
FileStringArPtr Sf;                         //массив строк текстового файла

//Основная функция модуля проверки исходных файлов, из которой вызываются остальные функции
void CheckFiles();
//Проверка форматов файлов input и add. Функция считывает из файла F объект размером структуры DirectiryT, 
//после чего анализирует побайтово каждое его слово на соответствие указанным в desunit полям
void FormatFileDirectory(FILE *F, char *FileName, int *nf, int Nmax, DirectoryAr *Dire);
//Проверка форматов файла kodif
void FormatFileKodif();
//Проверка возможности чтения файла, контроль количества строк (не превышает ли максимального значения), удаление пустых строк
void ReadAndCheckSpaces(FILE *F, char *FileName, int *nf, int Nmax);
//Проверка диапазона численных значений input и add
void CheckDireDiapason(char *FileName, int nf, DirectoryAr *Dire);
//Проверка диапазона численных значений kodif
void CheckKodifDiapason();
//Проверка дублирования записей в kodif (проверка на повторяющиеся коды)
void KodifParameters();
//Проверка дублирования записей в input и add (проверка на повторяющиеся коды), также проверяет наличие этих же кодов в кодификаторе
void DireParameters(DirectoryAr *Dire, int n, char *FileName);
//формирование строки об ошибке диапазона целочисленного типа и ее печать в консоль (и возможно в файл)
void ReportError1(char *FileName, int i, int k, int d1,int d2);
//чтение файла ошибок и вывод его на экран
void ReadFileError();

