//������ Report ��������� ��������� ������ � ������������ � �������� ��������. ��������� ������������� ������ �� ����� ������, � ������������ �������� ��������

#include "desunit.h"
#include "time.h"			//������� �������� � ���� ������ ��������, ������� ��������� ���������� time.h, ������� ������� ��������� �������� ��������� �����.

//�������� ���������� ���������� 

extern unsigned char SignArchive;		//���� �������� ������
extern unsigned char FlagAdd;			//���� ���������� ������
extern unsigned char FlagSort;			//���� ���������� ������
extern unsigned char nk;				//���������� ��������� � ������� ������������
extern KodifType	Kodifs[KMax];		//������ ������������
extern int Device;						//���� ���������� ����������
extern FILE *fRes;						//��������� �� ���� ����������

//�������� ������� �������

extern void wait_press_key(char *msg);
extern double GetNumber(double MinNumber, double MaxNumber, char m1,char n1,char m2,char n2);
extern void WritelnString(char S[80]);
extern int SearchKodif(int Kod, int nk);
extern int ReadFileOut(int *np, DynDirectory**Lp, DynDirectory**Rp);
extern void DisposeDirectory(DynDirectory*Lp, DynDirectory*Rp);

//�������� ������� ������, ������� ��������� ������ ����. ���������� ������������ ����� ������ �� ���� ������� ���������
void WorkUpArchive();
//������ ����� ��������� - �������� �������� ������ � ����� � �������� ��������
void WorkUpSurname();
//������ ����� ��������� - �������� �������� ������ � ����� ������ ��������� ��������(������������)
void WorkUpAge();
//������ ����� ��������� - �������� �������� � ��� ��������� �����
void WorkUpOldest();