#include "CreateArchKodif.h"

void CreateArchive()
{
	DirectoryType Directory;
	if (SignArchive == 1)												//���� ����� ��� ��� ������
	{
		printf("\n����� ��� ������. ����� ����������.\n");
		wait_press_key("\n��� ����������� ������� ����� �������\n");	//������� �� ������� - ��������� ����� �� ����
		return 0;
	}
	
	if((fArTxt=fopen(fArTxtName,"rt"))==NULL)									//��������� ��������� ���� input � ������ ������ ���������� ����� rt
		{
		 printf("\n���� %s �� ������\n",fArTxtName);
		 wait_press_key("\n��� ���������� ��������� ������� ����� �������\n");	//� ������ ������ �������� ���������
		 exit(0);
		}
		if((fArBin=fopen(fArBinName,"wb"))==NULL)								//��������� �������� ���� ������ � ������ ������ ��������� ����� wb
		{
		 printf("\n���� %s �� ������\n",fArTxtName);
		 wait_press_key("\n��� ���������� ��������� ������� ����� �������\n");	//� ������ ������ �������� ���������
		 exit(0);
		}
	do															//���� � ������������
	{ 
		if (ReadDirectory(fArTxt,&Directory)==0)				//�������, ������� ��������� ���������, � ������ ��������� ���������� ������ ���������� 0
			fwrite(&Directory,sizeof(DirectoryType),1,fArBin);	//���� ������ ��������� ���� ������� ����������� �� ����� fArTxt � Directory, �� � fArBin ���������� ���� ������ ��������
																//sizeof(DirectoryType), ������ �� Directiry
	}
	while ( ! feof(fArTxt) );									//���� �����������, ���� �� ��������� ����� ���������� �����	
	fclose(fArTxt); fArTxt=NULL;								//����� ���������� ������ ����� �����������, � ��������� �� ����� ����������
	fclose(fArBin); fArBin=NULL;	
	MakeKodifs(&nk);					//����������� ������ ������������
	SortKodif(nk);						//����� ���� �����������
	SignArchive=1;						//���� �������� ������ ������������� � �������
	printf("\n	����� ������\n");
	wait_press_key("\n��� ����������� ������� ����� �������\n");
}	

int ReadDirectory(FILE *f,DirectoryType *Directory)
{
	char sIn[80];		
	char slovo[30];	
	unsigned char Cond=0;	
	int k1,k2,k,i,n;
	if ( fgets(sIn, 80, f) != NULL )	
	{	
		k=strlen(sIn);	
		if (sIn[k-1]==10) sIn[k-1]='\0';	//���������� ������� � ������ CheckInpFile ���������� ������ ������ �� ���������� ����� - � ������������ �������� ������������ � ���������� ��������
		i=0; k=0; Cond=1; k2=-1;	
		while(Cond)
		{
			k1=NotSpace(sIn,k2+1); 
			if(k1==-1) 
				Cond = 0;    
			else
			{
				k2=Space(sIn,k1+1);	
				if (k2==-1)					
				{
					k2=strlen(sIn); 
					Cond = 0;				
				}
				n=k2-k1;										
				strncpy(slovo,&sIn[k1],n);	
				slovo[n]='\0';							
				k++;																	//� ����� ������� ����������� ����� ����������� � ������ slovo
				switch ( k )															//� ����� ����� � ������ - � ���������� k
					{	
					 case 1:
						 strncpy(Directory->Num, &slovo[0], n);						//1-�� ����� - ����� ������. ������ �� 6 ��������. �������� � � ���� Num
						 Directory->Num[n] = '\0';									//��������� �������� � ���� Num �������� ������� ��������� ������
						 FillString(Directory->Num, 6, 1);					break;	//��������� ���������� ����� ���������
					 case 2:sscanf_s(slovo,"%d", &Directory->Code);			break;	//2-�� ����� - ��� ���. ������� �������� �� slovo � ���� Code
					 case 3:sscanf_s(slovo,"%d", &Directory->Birthday);		break;	//3-� ����� - ���� ��������. ������� �������� �� slovo � ���� Birthday
					 case 4:														
						 strncpy(Directory->Street, &slovo[0], n);					//4-�� ����� - �������� �����. ������ �� 15 ��������. �������� � � ���� Street
						 Directory->Street[n] = '\0';								//��������� �������� � ���� Street �������� ������� ��������� ������
						 FillString(Directory->Street, 15, 1);				break;	//��������� ���������� ����� ���������
					 case 5:sscanf_s(slovo,"%d", &Directory->House);		break;	//5-�� ����� - ����� ����. ������� �������� �� slovo � ���� House
					 case 6:sscanf_s(slovo, "%d", &Directory->Flat);		break;	//6-�� ����� - ����� ��������. ������� �������� �� slovo � ���� Flat
					 case 7:sscanf_s(slovo, "%d", &Directory->Phone);		break;	//7-�� ����� - ����� ��������. ������� �������� �� slovo � ���� Phone
					}
			}
		}
		return 0;		//� ������ ��������� ������������ ��������� ���������� ����
	}
	else return 1;		//����� ���������� ����
}	

int PrintArchive()
{
	DirectoryType Directory;
	int i,p=1;		
	char s[90];
	char slovo[90]="";
	if (SignArchive==0)													//���������, ������ �� �����
	{
		 printf("\n����� �� ������. ����� ����������.\n");
		 wait_press_key("\n��� ����������� ������� ����� �������\n");	//���� �� ������ - �������� ��������� �� ������
		 return 0;
	}	
	if((fArBin=fopen(fArBinName,"rb"))==NULL)							//��������� �������� ���� ������ � ������ ��������� ������ rb
	{
		 printf("\n���� %s �� ������. ����� ����������.\n",fArBinName);
		 wait_press_key("\n��� ����������� ������� ����� �������\n");	//���� �� ������� ������� ���� - �������� ��������� �� ������
		 SignArchive=0;
		 return 0;
	}
	
	

  WritelnString("               A���� �������� � ���������� ����");
  WritelnString(
      " ------------------------------------------------------------------------------ ");
  WritelnString(
	  "|��/� |  ����� |  ���  |   ����     |      �����     | ��� | � ��. |  �������  |");			//� ������� WriteInString ������� ���������, ������� ���������� ����������
  WritelnString(
      "|     | ������ |  ���  |  ��������  |                |     |       |           |");			//��� ����� ������� 
  WritelnString(
      "|------------------------------------------------------------------------------|");
  
	i=0;																								//i - ��� ����� ������ � ������
	if( p=fread(&Directory,sizeof(DirectoryType),1,fArBin)<1) p=EOF;									//������ �� fArBin ���� ������ �������� sizeof(DirectoryType) � ��������� Directory
	while (p != EOF)																					//���� ��� ������ �� �������� ����� �����
	{	i++; s[0] = '|'; s[1] = '\0';																	//��������� ������ s ��� ������
		sprintf(slovo, "%3d", i); strcat(s, slovo); strcat(s, ". | ");									//������������ � ����� ������ s �������� i
		strcat(s, Directory.Num);		strcat(s, " | ");												//������������ � ����� ������ s �������� Num
		sprintf(slovo, "%5d", Directory.Code); strcat(s, slovo); strcat(s, " | ");						//������������ � ����� ������ s �������� Code
		sprintf(slovo, "%02d", (Directory.Birthday / 100) % 100); strcat(s, slovo); strcat(s, ".");		//���� ������� ��� ����� ����������� - ������ ������������ � ����� ������ s ���� �������� � �����
		sprintf(slovo, "%02d", Directory.Birthday % 100); strcat(s, slovo); strcat(s, ".");				//����� ������������ � ����� ������ s ����� �������� � �����
		sprintf(slovo, "%4d", Directory.Birthday / 10000); strcat(s, slovo); strcat(s, " | ");			//� ����� ������������ � ����� ������ ��� ��������
		strcat(s, Directory.Street);		strcat(s, " | ");											//������������ � ����� ������ ����� 
		sprintf(slovo, "%3d", Directory.House); strcat(s, slovo); strcat(s, " | ");						//������������ � ����� ������ ����� ����
		sprintf(slovo, "%5d", Directory.Flat); strcat(s, slovo); strcat(s, " | ");						//������������ � ����� ������ ����� ��������
		if (Directory.Phone == 0)																		//���������, ���� �� �������� ������� � ������ � ������
		{
			strcat(s, "    -    ");		strcat(s, " | ");												//���� ���, �� ������� �������
		}
		else																							//���� ����, ��, ��� � � �����, ������� ����� �������� � ����� ���������� ����
		{
			sprintf(slovo, "%03d", Directory.Phone / 10000); strcat(s, slovo); strcat(s, "-");			//������������ � ����� ������ ������ ��� ����� ������ �������� � -
			sprintf(slovo, "%02d", (Directory.Phone / 100) % 100); strcat(s, slovo); strcat(s, "-");	//������������ � ����� ������ ��������� ��� ����� ������ �������� � -
			sprintf(slovo, "%02d", Directory.Phone % 100); strcat(s, slovo); strcat(s, " | ");			//������������ � ����� ������ ���������� ��� ����� ������ ��������
		}
		WritelnString(s);																				//�������� �������������� ������ s
		if (p = fread(&Directory, sizeof(DirectoryType), 1, fArBin) < 1) p = EOF;						//��������� ������� ��������� ����
	}
	WritelnString(
		"|______________________________________________________________________________|\n");			//�������� ����������� ����� ������� �����
	fclose(fArBin);														//��������� �������� ����
	wait_press_key("\n��� ����������� ������� ����� �������\n");

	return 0;

}	

void MakeKodifs(int *nk)
{ 
	char Sa[80],Sb[80];
	unsigned char  n,k,Cond;
	int k1,k2;	
	if((fKodif=fopen(fKodifName,"rt"))==NULL)
		{
		 printf("\n���� %s �� ������\n",fArTxtName);
		 wait_press_key("\n��� ���������� ��������� ������� ����� �������\n");
		 exit(0);
		}
  
  *nk=0;	
  while (fgets(Sa,80,fKodif)!=NULL) 
	{
		n=strlen(Sa); 
		if (Sa[n-1]==10) 	Sa[n-1]='\0'; 
		Cond=1; k2=-1; k=0;
		while (Cond) 
			{
				k1=NotSpace(Sa,k2+1);
				if (k1==-1) Cond=0;
				else
				{
					k2=Space(Sa,k1+1);
					if (k2==-1) { k2=strlen(Sa); Cond=0; }					//���������� �������� ����� �� ����� kodif � ������������ � ������ ����
					k++;
					n=k2-k1;
					strncpy(Sb,&Sa[k1],n);									//������� ����� ��������� � ������ Sb
					Sb[n]='\0';												//����� �������� ����� � ���������� k
					switch (k)
					{	
						case 1:sscanf_s(Sb,"%d",&Kodif.Code);	break;		//1-�� ����� - ��� ���. ������� �������� �� Sb � ���� Code
						case 2:strncpy(Kodif.FIO,&Sb[0],n);					//2-�� ����� - ���. ������ �� 20 ��������. �������� � � ���� FIO
							   Kodif.FIO[n]='\0';							//��������� ������ ������ ��� ������� ��������� ������
							   FillString(Kodif.FIO,20,1);	break;			//��������� ���������� �������������� ������� ���������
					}
				}
			}			
			Kodifs[*nk]=Kodif;
      (*nk)++;					
	}
  fclose(fKodif);
}	

int PrintKodif(int nk)
{
	char s[80];
	char slovo[80]="";
	int i,j=0;	
  if (SignArchive==0)													//���������, ������ �� �����
	{
		 printf("\n����� �� ������. ����� ����������.\n");
		 wait_press_key("\n��� ����������� ������� ����� �������\n");	//���� ����� �� ������ - �������� ��������� �� ������
		 return 0;
	}
  WritelnString(
"\n           ����������� ���������");
  WritelnString(
"|-----------------------------------------|");					//������ ����� ������� ������������
  WritelnString(
"| N�/� | ��� ��� |         ���            |");					//��������� ���������� ���������� �������
  WritelnString(
"|-----------------------------------------|");
  j=0;
  for (i = 0; i < nk; i++)
  {
	  Kodif = Kodifs[i];
	  j++; s[0] = '|'; s[1] = '\0';
	  sprintf(slovo, "%3d", j); strcat(s, slovo); strcat(s, ".  |  ");				//�������� ������ s ��� ������
	  sprintf(slovo, "%05d", Kodif.Code); strcat(s, slovo); strcat(s, "  | ");
	  strcat(s, Kodif.FIO + 2);		strcat(s, " ");
	  strncat(s, Kodif.FIO, 1);		strcat(s, ".");
	  strncat(s, Kodif.FIO + 1, 1);		strcat(s, ". |");
	  WritelnString(s);																//�������� ������ s
  }
		
  WritelnString(
"|-----------------------------------------|");
	wait_press_key("\n��� ����������� ������� ����� �������\n");
	return 0;
}	
