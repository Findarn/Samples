#include "EditArchiv.h"

int ChangeArchive()
{            
int Kod,Kod1,np;
unsigned char Cond=0;
DirectoryType Directory;
DynDirectory*Lp,*Rp;			
DynDirectory*Run;        
  if ( ! SignArchive )														 //�������� �������� ������
  {
		 printf("\n����� �� ������. ����� ����������.\n");
		 wait_press_key("\n��� ����������� ������� ����� �������\n");
		 return 1;
	}
	ReadFileOut(&np,&Lp,&Rp);												 //������ ��������� ����� ������ � ������������ ������� ��������
  printf("\n������� ��� ��� :");						//����������� �� ����� ����
	Kod=(int)ceil(GetNumber(0,99999,1,0,6,0));			//���� ���� � ���������� � ��������� ���������
  Kod1=Kod; printf("Kod = %6d",Kod1);					//���������� �������� ���
	Run=Lp; Cond=0;										//������������� Run �� Lp, �������� ���� Cond, ������� ����� �������� � ���, ���� �� ����������� ��������������
  while (Run!=NULL) 
  {
		if (Kod==Run->Inf.Code)																				//���� � ������� ���������� ������ � ����� �����
		{	
			Cond=1;																						//������� ���� Cond
			Directory = Run->Inf;																		//���������� �������������� ���� ����� �������� � Directory
			printf("\n          ������� ��������� ��������� ����� ������ :\n");
			printf("����� (�� 15 ��������), ����� ����, ����� ��������, ������� (����� ������).  \n");	//������� ����������� �� ����� ������ ��� ��������������
			printf("         ���� ����� ��������� �������� �����������, ������� 0  \n");
			MakeComponent(&Directory);								//���� � ������������ ���������� Directory ���������� � ���� �������
			Run->Inf= Directory;									//���������� Directiry � �������������� ���� ���� �� ��������
			WriteFileOut(Lp,Rp);									//�������������� �������� ���� ������
			printf("��������� ���������� � ������ ���������\n");
			break;													//���������� ������ �����
		} 
		Run=Run->Next;												//��������� � ���������� �������� �������
	}
  if (! Cond )	
    printf("\n� ������ ��� ���������� � ����� %d\n",Kod1);
    DisposeDirectory(Lp, Rp);											//������� �������
	wait_press_key("\n��� ����������� ������� ����� �������\n");
	return 0;
}	

void MakeComponent(DirectoryType *Directory)
{                    
	unsigned char k,n,Cond;
	int k1,k2;
	char Sa[80],Sb[80];	
	printf("������� ��������:\n");
	printf("����� - %s\n", Directory -> Street);
	printf("����� ���� - %d \n", Directory -> House);			//������� �� ����� ������� �������� ������������� ����������
	printf("����� �������� - %d \n", Directory -> Flat);
	if (Directory->Phone == 0)
	{
		printf("������� - �����������.\n", Directory->Phone / 10000, (Directory->Phone / 100) % 100, Directory->Phone % 100);	//���� ������� ����������� - ������� ��� ����� �������
	}
	else
	{
		printf("������� - %3d-%2d-%2d\n", Directory->Phone / 10000, (Directory->Phone / 100) % 100, Directory->Phone % 100);	//���� ������� ���� - ������� ����� ��������
	}
	clear_input_buffer();	//������� ����� �����
	gets_s(Sa, 80);			//��������� � ���������� �������� �������� � ������ Sa			
	Cond=1; k2=-1; k=0;
	while (Cond==1)	
	{								
		k1=NotSpace(Sa,k2+1);
		if (k1==-1) Cond=0;
		else
		{  
			k2=Space(Sa,k1+1);										//� ������� ������ ������� ����������� � ������������� �������� ��������� ����������� ������ �� �����
			if (k2==-1) { k2=strlen(Sa)+1; Cond=0; }
			k++; n=k2-k1;
			strncpy(Sb,&Sa[k1],n);
			Sb[n]='\0';           
			switch ( k )											//����� ����� - k, ���� ����� - � ������ Sb
			{
			 
				case 1:																
					strncpy(Directory->Street, &Sb[0], n);							//1-�� ����� - ��� �������� �����. �������� ��� � ��������������� ���� Street � ���������
					Directory->Street[n] = '\0';									//��������� ������ �������� ��� ������� ����� ������
					FillString(Directory->Street, 15, 1);				break;		//��������� ���������� ������� ���������
				case 2:sscanf_s(Sb,"%d",&Directory->House);				break;		//2-�� ����� - ��� ����� ����. ������ �������� �� ������ Sb � ���� House
				case 3:sscanf_s(Sb,"%d",&Directory->Flat);				break;		//3-� ����� - ��� ����� ��������. ������ �������� �� ������ Sb � ���� Flat
				case 4:sscanf_s(Sb,"%d",&Directory->Phone);				break;		//4-�� ����� - ��� ����� ��������. ������ �������� �� ������ Sb � ���� Phone
     
			}
		}
	}
} 
