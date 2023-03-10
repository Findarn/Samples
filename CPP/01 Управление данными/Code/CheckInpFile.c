#include "CheckInpFile.h"

void CheckFiles()
{							
	DirectoryArPtr   Directories, AddDirectories;						//?????????? ????????? ?? ?????? ???????? ??? ?????? input ? add
	if((FileError=fopen(FileErrorName,"wb+"))==NULL)					//????????? ???? ?????? ? ?????? ???????? ???????? wk+
		{	
		 printf("\n???? %s ?? ??????\n",FileErrorName);
		 wait_press_key("\n??? ?????????? ??????? ????? ???????\n");
		 exit(0);
		}	
	sprintf(Sr,"\n         ???????? ???????? ????????? ??????\n");		//?????????? ? ?????? Sr ?????????
	fwrite(Sr,sizeof(string80),1,FileError);							//?????????? ?????? Sr ? ????
    FatalError=0;														//???? ?????? ????????????? ? 0
	Sf=(FileStringAr *)malloc(sizeof(FileStringAr));					//???????? ?????? ??? ????????????? ??????? ????? ?????????? ?????
	
    Directories=(DirectoryAr *)malloc(sizeof(DirectoryAr));				//???????? ?????? ??? ??????? ???????? ????? input
	AddDirectories=(DirectoryAr *)malloc(sizeof(DirectoryAr));			//???????? ?????? ??? ??????? ???????? ????? add
	FormatFileDirectory(fArTxt,fArTxtName,&np,NfMax, Directories);		//???????? ??????? ???????? ??????? ??? ????? input
	FormatFileDirectory(fAddTxt,fAddTxtName,&nd,NfMax, AddDirectories);	//???????? ??????? ???????? ??????? ??? ????? add
	
  FormatFileKodif();													//???????? ??????? ???????? ??????? ????? ???????????? kodif
  
  if (FatalError==0)										//???? ??? ?????????? ????????? ?? ?????????? ??????
	{	
		CheckDireDiapason(fArTxtName,np, Directories);		//????????? ?????? ????? input ?? ???????????? ??????????
		CheckDireDiapason(fAddTxtName,nd,AddDirectories);	//????????? ?????? ????? add ?? ???????????? ??????????
		CheckKodifDiapason();								//????????? ?????? ????? kodif ?? ???????????? ??????????
	}

  if (! FatalError)										//???? ??? ?????????? ????????? ?? ?????????? ??????
	{	
		KodifParameters();								//?????????, ?? ??????????? ?? ???? ? ????????????
		SortKodif(nk);									//????????? ???????????
		DireParameters(Directories,np,fArTxtName);		//?????????, ?? ??????????? ?? ???? ? ????? input, ? ???? ?? ??????????????? ???? ? ???????????? kodif
		DireParameters(AddDirectories,nd,fAddTxtName);	//?????????, ?? ??????????? ?? ???? ? ????? add, ? ???? ?? ??????????????? ???? ? ???????????? kodif
    
	}
	if (FatalError)												//???? ?????? ???? ??????????
    sprintf(Sr,"\n?????????????? ???????? ?????\n");			//?????????? ? ?????? Sr ????????? ?? ???????
  else															//????? (???? ?????? ?? ??????????)
    sprintf(Sr,"\n? ???????? ?????? ?????? ?? ??????????\n");	//?????????? ? ?????? Sr ????????? ?? ?????????? ??????
	fwrite(Sr,sizeof(string80),1,FileError);					//???????? ?????? Sr ? ???? ??????
	ReadFileError();											//????????? ???? ?????? ? ??????? ??? ?? ?????. 
	free(Sf); Sf=NULL;											//??????????? ?????? ? ???????? ????????? ?? ???????????? ???????
    free(Directories);    Directories=NULL;
    free(AddDirectories); AddDirectories=NULL;
    fclose(FileError);											//????????? ???? ??????
} 

void FormatFileDirectory(FILE *F, char *FileName, int *nf,
                           int Nmax, DirectoryAr *Dire)
{       
	DirectoryType Directory;							 
	char  k,k1,k2,n,Cond;								
	int  i,Code;
	string80 Sa,Sb;
	ReadAndCheckSpaces(F,FileName,nf,Nmax);						//????????? ??????????? ?????? ?????, ????????? ?? ?????????? ?????????? ?????, ??????? ?????? ??????		
  if (FatalError) return;										//???? ??? ???????? ???????? ??????, ??????? ?? ???????
  for (i=0; i<(*nf); i++)										//?????????????? ???? ???????? ?????. i ? ?????? ????? ????? ????????? ?? ????? ??????
	{
		strcpy(Sa,(*Sf)[i]);				//???????? i-?? ?????? ?? ????? ? ?????? Sa	
		k=strlen(Sa);						//?????????? ????? ?????? Sa ? ?????????? 	
		if (Sa[k-1]==10) Sa[k-1]='\0';		//???? ????????? ?????? ?????? ??? 10 (??????? ?? ????????? ??????), ???????? ??? "\0" - ??????? ????? ??????
    Cond=1; k2=-1; k=0;						//????????????? ????? Cond, k2, k. k - ??? ????? ????? ? ??????? ??????
    while (Cond)							//?????????????? ???? ? ???????????? (???? Cond != 0)	
		{
		k1=NotSpace(Sa,k2+1);				//? k1 ?????????? ?????? ??????? ???????, ?? ??????????? ????????
		if (k1==-1)							//???? ?????? ??????? ??? (??? ?????? ??????? ?? ????????)
        Cond=0;								//???????? ???? Cond
	  else
	  {
		  k2 = Space(Sa, k1 + 1);										//? k2 ?????????? ?????? ??????? ???????, ??????????? ????????
		  if (k2 == -1)													//???? ?????? ??????? ?? (? ?????? ??? ????????)
		  { k2 = strlen(Sa) + 1;										//? k2 ????????? ????? ?????? Sa + 1
			Cond = 0; }													//???? Cond ?????????? ? ????
		  k++;															//???? ?????? ???? ????????, ??????????? ?????????? ??????????? ????
																		//????? ????? - ??? ????????? (????? ??????) ? ??????, ??????? ?????????? ?????????/????????? ????????? ??????
		  if (k > 7)													//???? ? ??????? ????? ?????????? ???????????? ???? ???????? ?????? ????
		  {
			  FatalError = 1;
			  sprintf(Sr, "???? %s : ? ?????? %d ????? 7 ?????????\n",	//??????? ????????? ?? ?????? ? ?????????? ??? ? ????
				  FileName, i + 1);			  
			  fwrite(Sr, sizeof(string80), 1, FileError);
		  }
		  n = k2 - k1;													//? k2 ????????? ?????? ??????????? ???????, ? k1 - ?????? ????????????? ???????.
																		//??????? k2-k1 ??????? ????? ?????
		  strncpy(Sb, &Sa[k1], n);										//???????? n ???????? ?? ?????? Sa ??????? ? ??????? k1 ? ?????? Sb
		  Sb[n] = '\0';													//? ????? ?????? Sb ????????? ??????? ????????? ??????           
		  switch (k)													//?????? ????? ??????????? ?? ???????????? ?????? ???????
		  {	
		  case 1:
			  if (strlen(Sb) > 6)																				//????????? ?????? ????? - ??? ????? ?????? ? ??????? - 2 ????? ? 4 ?????
			  {																									//??? ??? ?????? ?????? - char, ???????????? ??????????? ???????? ? ??????
				  FatalError = 1;																				//???????? ????????? ????? ???????? ??????, ? ??????? ?????????????? ?????????? ?????
				  sprintf(Sr, "???? %s : ? ?????? %d  ????? ???????? 1 ????? 6 ????????\n", FileName, i + 1);	//??????? char-???? ????? ????????? ?? ???????????? ????? - ? ?????? ?????? 6 ????????
				  fwrite(Sr, sizeof(string80), 1, FileError);													//???? ??????????? ????? ??????? 6 ???????? - ???????? ?? ??????, ???????? ?????? ? ????? ?????
			  }
			  strncpy(Directory.Num, &Sb[0], n);																//???? ??????????? ????? ????????????? ?????, ???????? n ???????? ?? ?????? Sb ? ??????????????? ???? ?????????
			  Directory.Num[n] = '\0';																			//??????? ?????? ???????? ??? ??????? ????????? ??????
			  FillString(Directory.Num, 6, 1);						break;										//??? ????, ????? ??? ?????? ??????? ????????, ????????? ?????????? ? ?????? ????????? ????? ????????? ??????
		  case 2:Code = sscanf_s(Sb, "%d", &Directory.Code);														//????????? ?????? ????? - ??? ??? ??????? ? ?????????. ??????? sscanf ?????????? scanf
			  if (Code < 1)																							//?? ?????? ???????????? ????? ? ?????????? ????????? ?????????? ?? ?????????? ?????????	
			  {	  FatalError = 1;																					//? ?????? ?????? - ?? ?????? Sb. ??? ?????????? ?????????? ?????, ??????? ??????? ????????? ????????
				  sprintf(Sr, "???? %s : ? ?????? %d ???????????? ?????? ???????? 1 (%s)\n", FileName, i + 1, Sb);	//?.?. ? ???????? ?????? ??? ?????? 1. ???? ?? ??? ?????? ??????? ???????? - ??? ??????? ??????
				  fwrite(Sr, sizeof(string80), 1, FileError);														//? ??????? ????????? ?????????. ???????? ???? ????? ????????? ? ???? ????????? Code.
			  }														break;
		  case 3:Code = sscanf_s(Sb, "%d", &Directory.Birthday);													//????????? ?????? ????? - ???? ????????
			  if (Code < 1)																							//???????? ????????? case 2
			  {
				  FatalError = 1;
				  sprintf(Sr, "???? %s : ? ?????? %d ???????????? ?????? ???????? 1 (%s)\n", FileName, i + 1, Sb);
				  fwrite(Sr, sizeof(string80), 1, FileError);
			  }														break;
		  case 4:																								//????????? ????????? ????? - ?????. ??? ????? ??????, ??? ??????? ????????????? 15 ????????
			  if (strlen(Sb) > 15)																				//???????? ????????? case 1, ??????? ?????? ? ????? ?????
			  {
				  FatalError = 1;
				  sprintf(Sr, "???? %s : ? ?????? %d  ????? ???????? 1 ????? 15 ????????\n", FileName, i + 1);
				  fwrite(Sr, sizeof(string80), 1, FileError);
			  }
			  strncpy(Directory.Street, &Sb[0], n);
			  Directory.Street[n] = '\0';
			  FillString(Directory.Street, 15, 1);						break;
		  case 5:Code = sscanf_s(Sb, "%d", &Directory.House);												//????????? ????? ????? - ????? ????
			  if (Code < 1)																					//???????? ????????? case 2, 3
			  {
				  FatalError = 1;
				  sprintf(Sr,
					  "???? %s : ? ?????? %d ???????????? ?????? ???????? 1 (%s)\n", FileName, i + 1, Sb);
				  fwrite(Sr, sizeof(string80), 1, FileError);
			  }														break;
		  case 6:Code = sscanf_s(Sb, "%d", &Directory.Flat);												//????????? ?????? ????? - ????? ????????
			  if (Code < 1)																					//???????? ????????? case 2, 3, 5
			  {
				  FatalError = 1;
				  sprintf(Sr,
					  "???? %s : ? ?????? %d ???????????? ?????? ???????? 1 (%s)\n", FileName, i + 1, Sb);
				  fwrite(Sr, sizeof(string80), 1, FileError);
			  }														break;
		  case 7:Code = sscanf_s(Sb, "%d", &Directory.Phone);												//????????? ??????? ????? - ????? ????????
			  if (Code < 1)																					//???????? ????????? case 2, 3, 5, 6
			  {
				  FatalError = 1;
				  sprintf(Sr,
					  "???? %s : ? ?????? %d ???????????? ?????? ???????? 1 (%s)\n", FileName, i + 1, Sb);
				  fwrite(Sr, sizeof(string80), 1, FileError);
			  }														break;

		  }
	  }
        
		}
    if (k<7)																	//????? ????, ??? ????????? ?????? ??????, ??????????? ?????????? ??????????? ????
		{																		//?????? ????? ????????? ???????? ?? ?????, ??????????? ???? ????, ????? - ???????? ?? ??????? ????? ????
      FatalError=1;
      sprintf(Sr, "???? %s : ? ?????? %d ?????? 7 ?????????\n",FileName,i+1);	//???? ???? ?????? ???? - ???????? ????????? ?? ??????		
      fwrite(Sr,sizeof(string80),1,FileError);
		}
    (*Dire)[i]=Directory;														//Dire - ?????? ?????????? ?? ????????? ???? Directory, ??????? ??????????? ? ???????? ?????? ??????
	}																			//?? ??????? ???? ????? ?????????? ??????? ?????????????? ??????? ? i-?? ??????
}   

void  FormatFileKodif()
{              
	char k,k1,k2,n,Cond;
	int i, Code;
  string80 Sa,Sb,S1;
	ReadAndCheckSpaces(fKodif,fKodifName,&nk,NfMax);						//? ?????????? ??????? ????????????? ?????? ??????? ?? ?????? input ? add 
  if (FatalError) return;													//? ??? ??????? ???????? ?????? ????????????
  for (i=0; i<nk; i++)														//?????? ?????? - ??????????? ???????? ?????????? ? ???????????? ???????? - ????? ????? ??
	{	
		strcpy(Sa,(*Sf)[i]);
 		k=strlen(Sa);				
		if (Sa[k-1]==10) Sa[k-1]='\0';
		Cond=1; k2=-1; k=0;
    while (Cond)
		{
			k1=NotSpace(Sa,k2+1); 
			if (k1==-1)
				Cond=0;
			else
			{
				k2=Space(Sa,k1+1);	
				if (k2==-1)
				{
					k2=strlen(Sa)+1;
					Cond=0;
				}
				k++;
				if (k>2) 
				{
					FatalError=1;
					sprintf(Sr,	"???? Kodif.txt : ? ?????? %d ????? 2 ?????????\n",i+1);	//? ???????????? ??????? ????????? ????? ??? ????? ? ?????? - ??? ??? ? ??????????????? ???
					fwrite(Sr,sizeof(string80),1,FileError);
				}
				n=k2-k1;							
				strncpy(Sb,&Sa[k1],n);
				Sb[n]='\0';          
				 switch (k)
				{
					case 1:Code=sscanf_s(Sb,"%d",&Kodif.Code);																//????????? ?????? ????? - ??? ????????????? ????????
						if (Code<1)
							{
								FatalError=1;
								sprintf(Sr,	"???? Kodif.txt : ? ?????? %d ???????????? ?????? ???????? 1 (%s)\n", i+1,Sb);
								fwrite(Sr,sizeof(string80),1,FileError);
							}																						break;
					case 2:																									//????????? ?????? ????? - ??? ?????? ?? 25 ????????
						if (strlen(Sb)>20) 
							{ 
								FatalError=1;
								sprintf(Sr, "???? Kodif.txt : ? ?????? %d ????? ???????? 2 ????? 20 ????????\n", i+1);
								fwrite(Sr,sizeof(string80),1,FileError);
							}
							strncpy(Kodif.FIO,&Sb[0],n);    
							Kodif.FIO[n]=' ';
							Kodif.FIO[n+1]='\0'; break;          
				}
			}
		}
    if (k<2)																//????????? ?? ??????? ?????????? ????
		{	
      FatalError=1;
			sprintf(Sr,
			"???? Kodif.txt : ? ?????? %d ?????? 2 ?????????\n",i+1);
      fwrite(Sr,sizeof(string80),1,FileError);
		}    
    Kodifs[i]=Kodif;						//??? ???????????? ?????????? ??????? ?????? - ? i-?? ??????? ??????? ??????? ?????????????? ?????????
	}
}   

void ReadAndCheckSpaces(FILE *F, char *FileName, int *nf, int Nmax)
{
	char  i,j,k;													
	char  SignSpace;   
	string80 sw;

	if((F=fopen(FileName,"rt"))==NULL)								//????????? ???? ? ?????? ?????? ?????????? ????? rt ? ????????? ?????????? ??? ????????
		{
		 sprintf(Sr,"??????????? ???????? ???? %s\n",FileName);
		 FatalError=1;												//? ?????? ??????? ???????? ????????? ?? ??????
		 fwrite(Sr,sizeof(string80),1,FileError);
		 return;
		}
  *nf=0;															//??????????, ???????????? ?????????? ????? ? ?????			
  while (fgets(sw,80,F)!=NULL)										//??????? fgets ????????? ?? 80 ???????? ?? ????? F ? ???????? ?? ? ?????? ???????? sw. ?????????? ?????????? ?? ??? ???, ????
	{																//?? ?????????? ?????? "????? ??????", ????? ????? ???? ?? ??????????? ?????? ? 80 ????????. ????? ??????????? ????? ??????????
		if ((*nf)<PMax)												//???? ??? ?????????? ??????? ??????? NULL - ????????? ??? ??????
			strcpy((*Sf)[*nf],sw);		//???? ????? ??????? ?????? ?? ????????? ????????????? ?????????, ?? ??????? ????????? ?????? ?????????? ? nf-?? ??????? ??????? ?????
			(*nf)++;					//??????????? ?????????? ??????????? ????? ? ?????
	}
  fclose(F);		//????? ?????? ? ?????? ????????? ???

  if (*nf==0)												//???? ??????????? ?????????? ????? ????? ????
	{
     FatalError=1;
     sprintf(Sr,"???????? ????  %s   ??????\n",FileName);	//????????????? ???? ??????, ???????? ????????? ?? ??????
		 fwrite(Sr,sizeof(string80),1,FileError);
     return;
	}

  if (*nf>NfMax)													//???? ?????????? ??????????? ????? ?????? ????????? ????????? ?????
	{
      FatalError=1;
			sprintf(Sr,
				"? ???????? ?????  %s  ?????  %d  ????? (%d)\n",	//????????????? ???? ??????, ???????? ????????? ?? ??????
				FileName,NfMax,*nf);
			fwrite(Sr,sizeof(string80),1,FileError);
      return;
	}

  SignSpace=0;									//????, ???????????? ??????? ?????? ?????
  i=0;
  while (i<(*nf))								//???? ? ???????????? ?? i=0 ?? ?????????? ??????????? ????? ? ?????
	{
      k=NotSpace((*Sf)[i],0);					//? k ???????? ?????? ??????? ????????????? ????????
      if ((k==-1) || ((*Sf)[i][k]==10))			//???? ????????????? ???????? ? ?????? ???, ???? ???????????? ??????? ??? ?????? ????????? ?????? - ?? ?????? ??????, ?.?. ??????? ?? ????????
			{	
          for (j=i; j<(*nf)-1; j++)				//?????????????? ???? - ????????????? ?????? ?? ??????? ?? ????????????? ???????, ???????????? ?? ????
            strcpy((*Sf)[j],(*Sf)[j+1]);		//???????? ??????? ??????, ???????? ??, ??????? ???? ??????
          (*nf)--;								//????????? ???????? ?????????? ????? ? ?????
          SignSpace=1;							//??????? ???? ????????? ?????? ?????? - ??? ???????? ???? ??????????? ??? ???????? ?????, ? ?? ??? ??????. ???????????? ???? ????? ????? ????????????
			}
      else
        i++;									//?????????? ?????? ??????? ??????
	}
  if (SignSpace)								//???? ?????? ?????? ???? ?????????? ? ??????? ? ??????? ????? ?????
	{	
		if((F=fopen(FileName,"wt"))==NULL)								//????????? ???? ? ?????? ?????? ?????????? ????? wt - ??? ?????? ? ??? ?????????? ?????????
		{
		 sprintf(Sr,
			 "?? ??????? ??????? ???? %s ??? ???????? ?????? ?????\n",
			 FileName);													//???? ?? ??????? ??????? ????, ???????? ????????? ?? ??????
		 FatalError=1;
		 fwrite(Sr,sizeof(string80),1,FileError);
		 return;
		}
    for (i=0; i<(*nf);i++)							//?????????????? ???? ?? i=0 ?? ?????????? ????? ? ????? (??? ?????? ?????)
		 fputs((*Sf)[i],F);							//?????????? ????????? ?????? ?????? ? ????
    fclose(F);										//????????? ???? ????? ?????? ? ???
	}

} 

void CheckDireDiapason(char *FileName, int nf, DirectoryAr *Dire)
{          
int i;
  for (i=0; i<nf; i++)																	//????????? ?????? ???????? ????????? ?? ???????????? ????????? ???????????
	{
    if (((*Dire)[i].Code<0) || ((*Dire)[i].Code>99999))							//??? ??? ???????? ??????????? ? ?????????????, ????????????? ?? ?????? ????????? ? ????????? ?? 0 ?? 99999
      ReportError1(FileName,i,2,0,99999);										//???? ?? ?? ????????????? ??????? ?????????, ?? ??????? ????????? ?? ??????
	if (((*Dire)[i].Birthday < 19000101) || ((*Dire)[i].Birthday > 20202004))	//???? ???????? ???????????? ? ?????? ? ??????? ????????. ???????, ??? ??????????? ???? ???????? - 1 ?????? 1900 ????
		ReportError1(FileName, i, 3, 19000101, 20200420);						//???????????? - 20 ?????? 2020 ????. ????? ???????, ?? ??????? ???? ????? ????? ?? ??????
	if (((*Dire)[i].Birthday % 100 < 1) || ((*Dire)[i].Birthday % 100 > 12))	//?? ????? ? ???? ????? ????????? ?????? ???????????? ????????. ??????? ???????, ??????? ??????????? ????, ? ?????? ? ???????? ??????
	{																			//????? ????? ?????? ???? ? ?????????? ?? 1 ?? 12
		FatalError = 1;
		sprintf(Sr, "???? %s:? ???? ???????? ???????? ? %d ???????? ?????? ? ?????? ????????\n", FileName, i);		//%100 - ??? ????????? ??????? ?? ???????. ???? ????? ? ???????? ???????? ????????? ?? 100
		fwrite(Sr, sizeof(string80), 1, FileError);																	//? ????? ??????? ?? ???????, ?? ??????? ?????? ?? - ?? ???? ?????
	}
	if ((((*Dire)[i].Birthday / 100) % 100 < 1) || (((*Dire)[i].Birthday / 100) % 100 > 31))				//? ???? ?? 1 ?? 31
	{																										//????? ???????? ???? ? ??????? ???????? ?? ?????? ???????? ??? ?? 100 ??? ???????: ????????/100
		FatalError = 1;																						//????? ?????? ??????????? ? ??????, ? ???????? ????? ????????? %100 ? ???????? ????? ??????? ?? - ????
		sprintf(Sr, "???? %s:? ???? ???????? ???????? ? %d ???????? ?????? ? ??? ????????\n", FileName, i);
		fwrite(Sr, sizeof(string80), 1, FileError);
	}
	if (((*Dire)[i].House < 1) || ((*Dire)[i].House > 300))
			ReportError1(FileName, i, 5, 1, 300);
	if (((*Dire)[i].Flat < 1) || ((*Dire)[i].Flat > 400))				//????? ???? ? ???????? ????????? ? ????????? ?? 1 ?? 300-400
			ReportError1(FileName, i, 6, 1, 400);
	if (((*Dire)[i].Phone < 0) || ((*Dire)[i].Phone > 9999999))			//????? ???????? ??? ??????????? ????? ????????, ?????? 0 ?????????? ?????????? ????????. ?? 0 ?? 9999999
			ReportError1(FileName, i, 7, 0, 9999999);    
	}
}  

void CheckKodifDiapason()
{
	int i;													//? ????? ???????????? ?????? ???? ????????? ???????? - ??? ???
  for (i=0; i<nk; i++)
		if ((Kodifs[i].Code<0) || (Kodifs[i].Code>99999))	//??????? ????????? ? ????? ? ?????? input ? add
		{
			FatalError=1;
			sprintf(Sr,
				"???? Kodif.txt: ? ?????? %d ??????? 1 "
				"??? ???????? 0..100\n",i+1);
		  fwrite(Sr,sizeof(string80),1,FileError);
		}
}    

void KodifParameters()
{          
int  i,j,Kod;				//??????? ????????? ?????????? i, j
  for (i=0; i<nk-1; i++)
	{
    Kod=Kodifs[i].Code;
    for (j=i+1; j<nk; j++)
      if (Kod==Kodifs[j].Code)												//????????????? ??????? ? ?????????? ?????, ? ??????? ?????????? ??? ???????? ????????????
			{																//? ?????????? ?? ???? ? ??????. ???? ????????? ?????????? ??? - ?????? ??????
        FatalError=1;
				sprintf(Sr,
"???? Kodif.txt: ?????? ???????? Code ? ??????? %d ? %d (%d)\n",
				i+1,j+1,Kod);
				fwrite(Sr,sizeof(string80),1,FileError);
			}
	}
} 

void DireParameters(DirectoryAr *Dire, int n, char *FileName)
{     
	
int  i,j,k,Kod,Cond;
char Meas[5];

  for (i=0; i<n-1; i++)
	{
    Kod=(*Dire)[i].Code;
    for (j=i+1; j<n; j++)
      if (Kod==(*Dire)[j].Code)
			{															//?????????? ????????????, ? ?????? input ? add ?????????? ????????? ????? 
        FatalError=1;													//??? ??????????? ?????????? ?????, ???????? ??????
				sprintf(Sr,
	"???? %s : ?????? ???????? Code ? ??????? %d ? %d (%d)\n",
					FileName,i+1,j+1,Kod);
				fwrite(Sr,sizeof(string80),1,FileError);
			}
	}


  for (i=0; i<n; i++)
	{
    Kod=(*Dire)[i].Code;
    k=SearchKodif(Kod,nk);												//????????????? ????, ? ??????? ????????????? ?????? ??????? input ? add
    if (k==-1)															//??? ??????? ???????? ???????? ??????? SearcjKodif, ??????? ???? ??????????????? ??? ? ????????????
		{	
      FatalError=1;
			sprintf(Sr,
"???? %s : ??? ??? %d (?????? %d) ??????????? ? ????????????\n",	//???? ??? ?????-???? ?????? ??????????? ?????????? ???, ??????? ????????? ?? ??????
					FileName,Kod,i+1);
			fwrite(Sr,sizeof(string80),1,FileError);
		}
	}
} 

void ReportError1(char *FileName, int i, int k, int d1,int d2)
{
  FatalError=1;																//??????? ?????? ?? ?????????? ?????????? ????????? ?????? ??? ?????? ?? ?????? ????????? ?????
	sprintf(Sr,
		"???? %s : ? ?????? %d ??????? %d  ??? ???????? %d .. %d\n",
		FileName,i+1,k,d1,d2);
  fwrite(Sr,sizeof(string80),1,FileError);

} 

void ReadFileError()
{             
	char i=1;												//?????????? ?????????? ??? ?????????? ????? ??????
  rewind(FileError);										//??????? rewind ?????????? ????????? ?? ?????? ?????. ?.?. ? ???? ?????? ????????? ?????????? ????? ????????? ? ???? ??????, ??? ???
															//??????????? ????????? ?????????? ??????? ? ??? ??????
	while (i!=EOF)											//i ??????? ??????? ??? 1, ?.?. ? ????? ?????? ?????-?? ?????? ? ????? ?????? ???? ???????
	{
			i=fread(Sr,sizeof(string80),1,FileError);		//????????? ?????? ?? ????? ?????? ? ?????? Sr
			if (i<1) i = EOF;								//???? ?????? ??????? ?? ???????, ???????? i ??? EOF
			else printf("%s",Sr);							//????? - ???????? ?????? ?? ????? ?????? ? ???????
	}
	wait_press_key("\n??? ??????????? ??????? ????? ???????\n");	//????? ??????? ?? ??????? ??????? ??????? ???????
}	

