//������ Sort ��������� ���������� ��������� ������ �������� �������

#include "desunit.h"

//�������� �������� ���������

extern FILE *fArBin;

//�������� ���������� ����������-������

extern unsigned char SignArchive;	//���� �������� ������
extern unsigned char FlagSort;		//���� ���������� ������

//�������� ������� �������

extern void wait_press_key(char *msg);
extern int ReadFileOut(int *np, DynDirectory**Lp, DynDirectory**Rp);
extern int WriteFileOut(DynDirectory*Lp, DynDirectory*Rp);
extern void DisposeDirectory(DynDirectory*Lp, DynDirectory*Rp);

//�������� ������� ������, ����������� ���������� ������
int SortArchive();
