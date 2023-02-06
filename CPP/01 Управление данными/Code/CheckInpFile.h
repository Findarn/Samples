//������ Check Input File �������� �� ��������� �������� �������� ������ input.txt, add.txt, kodif.txt
#include "desunit.h"

//�������� ���������� �������� ����������

extern FILE *fArTxt;
extern FILE *fArBin;
extern FILE *fAddTxt;
extern FILE *fKodif;
extern FILE *fRes;

//�������� ���������� ���������� ������������ � ������� �������������

extern KodifType	Kodif, 
					Kodifs[KMax];  

//�������� ������� �� ������ baseunit

extern void wait_press_key(char *msg);
extern int Space(char *s, int k);
extern int NotSpace(char *s, int k);
extern void SortKodif(int nk);
extern char *FillString(char *S, unsigned char len,	unsigned char pk);
extern int SearchKodif(int Kod, int nk);



typedef char string80[80];                  //����������� ������� �������� (������)						
typedef string80 FileStringAr[PMax];	    //����������� ������� �����
typedef FileStringAr *FileStringArPtr;      //����������� ��������� �� ������ �����
typedef DirectoryType  DirectoryAr[PMax];   //����������� ������� ������� ������
typedef DirectoryAr * DirectoryArPtr;       //����������� ��������� �� ������ ������� ������


FILE *FileError;                            //������ ���������� �������� ���������� ��� ����� ������
char *FileErrorName="Error.dat";            //������ �������� ����� ������
int const  NfMax = PMax;                    //���������� ������������ ���������� ����� � ��������� �����
int 
	np,                                     //����������, ������������ ���������� ����� � ����� input
    nd,                                     //����������, ������������ ���������� ����� � ����� add
    nk,				                        //����������, ������������ ���������� ����� � ����� kodif
    FatalError;                             //����, ������������ ������� ������ � �������� ������ (1 - ������ ������������, 0 - ������ ���)

string80	Sr;				                //������ ��� ������ ��������� �� ������
FileStringArPtr Sf;                         //������ ����� ���������� �����

//�������� ������� ������ �������� �������� ������, �� ������� ���������� ��������� �������
void CheckFiles();
//�������� �������� ������ input � add. ������� ��������� �� ����� F ������ �������� ��������� DirectiryT, 
//����� ���� ����������� ��������� ������ ��� ����� �� ������������ ��������� � desunit �����
void FormatFileDirectory(FILE *F, char *FileName, int *nf, int Nmax, DirectoryAr *Dire);
//�������� �������� ����� kodif
void FormatFileKodif();
//�������� ����������� ������ �����, �������� ���������� ����� (�� ��������� �� ������������� ��������), �������� ������ �����
void ReadAndCheckSpaces(FILE *F, char *FileName, int *nf, int Nmax);
//�������� ��������� ��������� �������� input � add
void CheckDireDiapason(char *FileName, int nf, DirectoryAr *Dire);
//�������� ��������� ��������� �������� kodif
void CheckKodifDiapason();
//�������� ������������ ������� � kodif (�������� �� ������������� ����)
void KodifParameters();
//�������� ������������ ������� � input � add (�������� �� ������������� ����), ����� ��������� ������� ���� �� ����� � ������������
void DireParameters(DirectoryAr *Dire, int n, char *FileName);
//������������ ������ �� ������ ��������� �������������� ���� � �� ������ � ������� (� �������� � ����)
void ReportError1(char *FileName, int i, int k, int d1,int d2);
//������ ����� ������ � ����� ��� �� �����
void ReadFileError();

