//������ Delete �������� �� �������� ����� ��������� �� ���� ������ �� ��������� ������.

#include "desunit.h"

//�������� ���������� ����������

extern unsigned char SignArchive; //���� �������� ������
extern int nk;					  //���������� ��������� � ������� ������������

//�������� ���������� ���������� ������������ � ������� �������������

extern KodifType	Kodif,
Kodifs[KMax];

//�������� ������� �������

extern void wait_press_key(char *msg);
extern double GetNumber(double MinNumber, double MaxNumber, char m1,char n1,char m2,char n2);
extern int ReadFileOut(int *np, DynDirectory **Lp, DynDirectory**Rp);
extern int WriteFileOut(DynDirectory*Lp, DynDirectory*Rp);
extern void DisposeDirectory(DynDirectory*Lp, DynDirectory*Rp);

//�������� ������� ������, ������� ��������� ����� � �������� ������ ������
int DeleteArchive();
