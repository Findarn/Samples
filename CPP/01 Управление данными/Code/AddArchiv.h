//� ������ AddArchiv ����������� �������, ������� ������� � ��� ������������� ��������� ������ ������ �� ����� add.txt

#include "desunit.h"

//�������� �������� ����������

extern FILE *fArTxt;
extern FILE *fAddTxt;

//�������� ���������� ����������-������

extern unsigned char SignArchive;		//���� �������� ������
extern unsigned char FlagAdd;			//���� ���������� ������
extern unsigned char FlagSort;			//���� ���������� ������

//�������� ������� �������

extern void wait_press_key(char *msg);
extern int ReadFileOut(int *np, DynDirectory**Lp, DynDirectory**Rp);
extern int WriteFileOut(DynDirectory*Lp, DynDirectory*Rp);
extern void DisposeDirectory(DynDirectory*Lp, DynDirectory*Rp);
extern int ReadDirectory(FILE *f, DirectoryType * Directory);

//�������� ������� ������, ������� � ��������� �������� ��������� ����� ������� � �������� �����
int AddArchive();
