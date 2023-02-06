#include "SortArchiv.h"

int SortArchive() 
{
	int np;
	DirectoryType buf;			
	DynDirectory *Runi, *Runj;	 
	DynDirectory *Lp, *Rp;			
	if (!SignArchive)												//���������, ������ �� �����
	{
		printf("\n����� �� ������. ����� ����������.\n");
		wait_press_key("\n��� ����������� ������� ����� �������\n");
		return 1;
	}

	ReadFileOut(&np, &Lp, &Rp);										//���������� ��������� ����� ������ � ������������ ������� ��������
	
	//���������� ���������������� �������� �������
	for (Runi = Lp; Runi != NULL; Runi = Runi->Next)				//�������������� ������� ����, ������� ���������� �������� �� ������� �� ����������		
		for (Runj = Runi->Next; Runj != NULL; Runj = Runj->Next)	//�������������� ���������� ����, ������� ���������� �������� �� i-��� �� ����������
			if (Runi->Inf.Code > Runj->Inf.Code)					//���� i-�� ������� ������ j-���
				
			{
				buf = Runi->Inf;
				Runi->Inf = Runj->Inf;								//���������� ����� ��������������� ������ ����� ����� ���������� ���������
				Runj->Inf = buf;									//���������� ����������� �� �����������
			}

	WriteFileOut(Lp, Rp);											//�������� ���� ������ ���������������� ��������������� ��������	
	DisposeDirectory(Lp, Rp);										//������� �������
	FlagSort = 1;													//���� ���������� �������������� � 1
	printf("\n���������� ������ ���������.\n");
	wait_press_key("\n��� ����������� ������� ����� �������\n");
	return 0;
}