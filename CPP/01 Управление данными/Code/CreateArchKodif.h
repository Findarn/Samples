//������ �������� ��������� ��������� ����� � ������� ������������
//����� �������� � ���� ������� ������ ������ �� ��������� ����� � ������� ������������ � ���� �������

#include "desunit.h"

//�������� �������� ����������

extern FILE *fArTxt;
extern FILE *fArBin;
extern FILE *fAddTxt;
extern FILE *fKodif;
extern FILE *fRes;

extern unsigned char SignArchive; //���� ��������� �������� ������

extern KodifType	Kodif,			//���� ������� ������������
					Kodifs[KMax];	//������ �������� ������������
extern int nk;						//���������� ����������� ������������

extern int Device;					//���� ������ � ���� ����������

//�������� ������� �������

extern void wait_press_key(char *msg);
extern int Space(char *s, int k);
extern int NotSpace(char *s, int k);
extern char *FillString(char *S,unsigned char len,unsigned char pk);
extern void WritelnString(char S[80]);
extern void SortKodif(int nk);

//������ � ��������� �������� ���� ������
void CreateArchive();
//��������� ������ �� ���������� ����� � ��������� �� �� ��������� ��������� ����
int ReadDirectory(FILE *f, DirectoryType *Directory);
//������� �� ����� (� �������� � ����) �������� ���� ������
int PrintArchive();
//��������� ������ ������������ �� ���������� �����
void MakeKodifs(int *nk);
//�������� �� ����� (� �������� � ����) ������ ������������
int PrintKodif(int nk);
