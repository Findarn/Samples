//������ edit ��������� ����� ������ �� ���� � ������ � �������� ����� ���������� � ���� ������

#include "desunit.h"

//�������� ���������� ����������

extern unsigned char SignArchive;	//���� �������� ������

//�������� �������

extern void wait_press_key(char *msg);
extern int Space(char *s, int k);
extern int NotSpace(char *s, int k);
extern char *FillString(char *S,unsigned char len,unsigned char pk);
extern double GetNumber(double MinNumber, double MaxNumber, char m1,char n1,char m2,char n2);
extern int ReadFileOut(int *np, DynDirectory**Lp, DynDirectory**Rp);
extern int WriteFileOut(DynDirectory*Lp, DynDirectory*Rp);
extern void DisposeDirectory(DynDirectory*Lp, DynDirectory*Rp);

//�������� ������� ������, ������� ��������� ����� ������ �� ����
int ChangeArchive();
//�������, ������� �������� ���� � ������
void MakeComponent(DirectoryType * Directory);
