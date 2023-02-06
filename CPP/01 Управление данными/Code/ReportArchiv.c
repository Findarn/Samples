#include "ReportArchiv.h"

void WorkUpArchive()
{
    int KeyRegime;                                              //���������� ��� ������ ������ ����
    if (!SignArchive)		                                    //��������� ������ �� �����
    {
        printf("�������� ���� �� ������. ����� ����������\n");
        return;
    }
    do                                                                  //���� � ������������
    {
        printf("\n      ������� ����� ��������� ������:");
        printf("\n      0 - ����� ���������;");
        printf("\n      1 - ������ �� �������� �������;");      
        printf("\n      2 - ������ ������ ��������� ��������;");        //�������� ����
        printf("\n      3 - ������ ��� ��������� ������� ������\n");
        
        KeyRegime = (int)ceil(GetNumber(0, 3, 1, 0, 1, 0));             //���� ������� ������ � ���������� ��������� ���������
        switch (KeyRegime)                                              //������ ��������� �������
        {
            case 0:;		            break;          //�����
            case 1: WorkUpSurname();	break;          //1-�� �����
            case 2: WorkUpAge();        break;          //2-�� �����
            case 3: WorkUpOldest();		break;          //3-�� �����
        }
    } while (KeyRegime != 0);                           //����� ����� ��������������� �� �������� 0

	wait_press_key("\n��� ����������� ������� ����� �������\n");
} 

void WorkUpSurname()
{   //��������� �� �������� �������
    DynDirectory *Lp, *Rp;
    DynDirectory *Run;
    int np, i=0, j=1;
    char surname[18], s[90], slovo[90];
    ReadFileOut(&np, &Lp, &Rp);                                    //��������� �������� ���� ������ � ��������� ������� ��������
    if ((FlagAdd == 0) || (FlagSort == 0))                         //��� ���������� ������ ������� ��������� ����� �������������� ���� ��������� ���������� ������ � ��� ����������
    {
        printf("����� ���������� ������ ������ ��������� ���������� ������ � ��� ����������� ����������\n");    //���� ���-�� �� ����� �� ���� ���������, ������� �� ������� ������ ���������
        return;
    }
    printf("������� ��������� ������ �� �������� �������. ������� �������:\n");     //����������� �� ����� �������
    clear_input_buffer();           //������� ������� �����
    gets(surname);                  //��������� � ���������� �������� �������� � ������ surname
    FillString(surname, 18, 1);     //��������� ������ surname ��������� �� �����. ������������ ������ FIO ����� ����������� 20 ,
                                    //1 ������ ������ �� ���, 1 �� ���������. ��� ��������� - ��� ������� � �������.
    Run = Lp;                       //������������� Run �� Lp
    WritelnString("               A���� �������� �� �������� �������");
    WritelnString(
        " ------------------------------------------------------------------------------ ");
    WritelnString(
        "|��/� |  ����� |  ���  |   ����     |      �����     | ��� | � ��. |  �������  |");        //������� ����� �������
    WritelnString(
        "|     | ������ |  ���  |  ��������  |                |     |       |           |");
    WritelnString(
        "|------------------------------------------------------------------------------|");
    while (Run != NULL)
    {
        if (strcmp(surname, Kodifs[i].FIO+2) == 0)      //���������� ������ surname � ���� FIO. 
                                                        //������ Kodifs[i].FIO+2 ������� � ���, ��� ������ FIO ����� �������� �� ������� �������, ��������� ��������
                                                        //������� strcmp ���������� ��� ������ � ���������� 0, ���� ��� ����������
        {
            s[0] = '|'; s[1] = '\0';
            sprintf(slovo, "%3d", j); strcat(s, slovo); strcat(s, ". | ");
            strcat(s, Run->Inf.Num);		strcat(s, " | ");
            sprintf(slovo, "%5d", Run->Inf.Code); strcat(s, slovo); strcat(s, " | ");
            sprintf(slovo, "%02d", (Run->Inf.Birthday / 100) % 100); strcat(s, slovo); strcat(s, ".");
            sprintf(slovo, "%02d", Run->Inf.Birthday % 100); strcat(s, slovo); strcat(s, ".");
            sprintf(slovo, "%4d", Run->Inf.Birthday / 10000); strcat(s, slovo); strcat(s, " | ");           //������������ ������ s
            strcat(s, Run->Inf.Street);		strcat(s, " | ");
            sprintf(slovo, "%3d", Run->Inf.House); strcat(s, slovo); strcat(s, " | ");
            sprintf(slovo, "%5d", Run->Inf.Flat); strcat(s, slovo); strcat(s, " | ");
            if (Run->Inf.Phone == 0)
            {
                strcat(s, "    -    ");		strcat(s, " | ");
            }
            else
            {
                sprintf(slovo, "%03d", Run->Inf.Phone / 10000); strcat(s, slovo); strcat(s, "-");
                sprintf(slovo, "%02d", (Run->Inf.Phone / 100) % 100); strcat(s, slovo); strcat(s, "-");
                sprintf(slovo, "%02d", Run->Inf.Phone % 100); strcat(s, slovo); strcat(s, " | ");
            }
            WritelnString(s);                                                                               //������ ������ s
            j++;                                                                                            
        }
        i++;
        Run = Run->Next;
    }
    if (j == 1)                                                                                             //���� j �� ���� �� �������������, ������ ���������� �� �������
    {
        WritelnString(
            "|                    �������� ������� � ������ �� ����������                   |");
    }
        WritelnString(
            "|______________________________________________________________________________|\n"); 

        DisposeDirectory(Lp, Rp);       //������� �������
}

void WorkUpAge()
{
    DynDirectory* Lp, * Rp;
    DynDirectory* Run;
    int np, age, arch_age, j = 1;
    struct tm* current_date;            //���������� ��� tm*, ��������� � ���������� time.h. �� ��������� ����������� ������� ����� ������� � ���� ���������
    time_t It;                          //time_t �� ���������� time.h - ��� �������������� ��� ��� ������������� �������
    It = time(NULL);
    current_date = localtime(&It);      //�������� � ��������� current_date �������� �������� ���������� �������
    int year, month, day;                   //���������� ����������: ���, ����� � ���� ���������� �������
    year = current_date->tm_year + 1900;        //� ��������� ����� �������� ����������� - ��������, ���� ����� ���� �� 1900 ����. �������, ����� �������� �������� ������� 
    month = current_date->tm_mon + 1;           //������ � ��������� ���������� � ���� �� 11
    day = current_date->tm_mday;                //��� ������ ���������� � 1 �� 31, ��� ��� ��������
    char s[90], slovo[90];
    ReadFileOut(&np, &Lp, &Rp);                    //��������� �������� ���� ������ � ������� ������� ��������
    if (FlagAdd == 0)                                                               //��� ������ ��������� ����������, ����� ����� ��� ��� ��������
    {
        printf("����� ���������� ������ ������ ��������� ���������� ������\n");
        return;
    }
    printf("������� ��������� ������ �� ��������� ��������. ������� �������:\n");   //����������� �� ����� ��������
    age = (int)ceil(GetNumber(0, 120, 1, 0, 1, 0));                                 //���� �������� � ���������� � ��������� ���������
    
    Run = Lp;                                                                       //������������� Run �� Lp
    WritelnString("               A���� �������� �� ��������� ��������");
    WritelnString(
        " ------------------------------------------------------------------------------ ");
    WritelnString(
        "|��/� |  ����� |  ���  |   ����     |      �����     | ��� | � ��. |  �������  |");
    WritelnString(
        "|     | ������ |  ���  |  ��������  |                |     |       |           |");        //�������� ����� �������
    WritelnString(
        "|------------------------------------------------------------------------------|");
    while (Run != NULL)
    {
        arch_age = year - Run->Inf.Birthday / 10000;                //��������� ������� �������� �� ������� ������. �������� �� �������� ���� ��� ��������
        if (month < Run->Inf.Birthday % 100)                        //�� ������������ ���������� ������ ���. ���� ���� �������� �������� � ���� ���� ��� �� �������� - ��� �����������
            arch_age = arch_age - 1;                                //���������, ��� �� � ���� ���� ����� ��������, ���� �� ��� - �������� ���� ���
        else
            if ((month == Run->Inf.Birthday % 100) && (day < (Run->Inf.Birthday / 100) % 100))  //����� �� �������� �������������� ��� ��� ��������
                arch_age = arch_age - 1;
        if (arch_age >= age)                                                                            //���������� �������� ������� � ������������ ��������� ��������
        {
            s[0] = '|'; s[1] = '\0';
            sprintf(slovo, "%3d", j); strcat(s, slovo); strcat(s, ". | ");                              //���� �� ������ ���������, ��������� ������ s
            strcat(s, Run->Inf.Num);		strcat(s, " | ");
            sprintf(slovo, "%5d", Run->Inf.Code); strcat(s, slovo); strcat(s, " | ");
            sprintf(slovo, "%02d", (Run->Inf.Birthday / 100) % 100); strcat(s, slovo); strcat(s, ".");
            sprintf(slovo, "%02d", Run->Inf.Birthday % 100); strcat(s, slovo); strcat(s, ".");
            sprintf(slovo, "%4d", Run->Inf.Birthday / 10000); strcat(s, slovo); strcat(s, " | ");
            strcat(s, Run->Inf.Street);		strcat(s, " | ");
            sprintf(slovo, "%3d", Run->Inf.House); strcat(s, slovo); strcat(s, " | ");
            sprintf(slovo, "%5d", Run->Inf.Flat); strcat(s, slovo); strcat(s, " | ");
            if (Run->Inf.Phone == 0)
            {
                strcat(s, "    -    ");		strcat(s, " | ");
            }
            else
            {
                sprintf(slovo, "%03d", Run->Inf.Phone / 10000); strcat(s, slovo); strcat(s, "-");
                sprintf(slovo, "%02d", (Run->Inf.Phone / 100) % 100); strcat(s, slovo); strcat(s, "-");
                sprintf(slovo, "%02d", Run->Inf.Phone % 100); strcat(s, slovo); strcat(s, " | ");
            }
            WritelnString(s);                                                                           //� �������� �
            j++;
        }
        Run = Run->Next;
    }
    if (j == 1)                                                                                         //���� j �� ������������, ������ ����� ��������� �������� � ������ ���
    {
        WritelnString(
        "|             ���� ������ ��������� �������� ����������� � �����������         |");
    }
    WritelnString(
        "|______________________________________________________________________________|\n");

    DisposeDirectory(Lp, Rp);                   //������� �������
}

void WorkUpOldest()
{
    DynDirectory *Lp, *Rp;
    DynDirectory *Runi, *Runj;
    DirectoryType buf;
    int np, arch_age_i, arch_age_j, j = 1, buf_age;
    struct tm* current_date;
    time_t It;
    It = time(NULL);
    current_date = localtime(&It);                      //�������� ��������� �����
    int year, month, day;
    year = current_date->tm_year + 1900;                //��������������� ��� � ������� ����
    month = current_date->tm_mon + 1;                   //��������������� ����� � ������� ����
    day = current_date->tm_mday;
    char s[90], slovo[90];
    ReadFileOut(&np, &Lp, &Rp);                         //��������� �������� ���� ������ � ��������� ������� ��������
    if (FlagAdd == 0)                                                           //����� ���������� ������ ���� ��������� ���������� ������
    {
        printf("����� ���������� ������ ������ ��������� ���������� ������\n");
        return;
    }
    printf("������ ����� ���� ��������� �������\n");

    for (Runi = Lp; Runi->Next != NULL; Runi = Runi->Next)                                              //���������� ���������� ���������� ������� �� �������� ��������
    {
        arch_age_i = year - Runi->Inf.Birthday / 10000;
        if (month < Runi->Inf.Birthday % 100)
            arch_age_i = arch_age_i - 1;                                                                //������������ ������� � Runi-�� ������ � ������ �������� ������
        else
            if ((month == Runi->Inf.Birthday % 100) && (day < (Runi->Inf.Birthday / 100) % 100))
                arch_age_i = arch_age_i - 1;
        for (Runj = Runi->Next; Runj != NULL; Runj = Runj->Next)
        {
            arch_age_j = year - Runj->Inf.Birthday / 10000;
            if (month < Runj->Inf.Birthday % 100)
                arch_age_j = arch_age_j - 1;                                                            //������������ ������� � Runj-�� ������ � ������ �������� ������
            else
                if ((month == Runj->Inf.Birthday % 100) && (day < (Runj->Inf.Birthday / 100) % 100))
                    arch_age_j = arch_age_j - 1;
            if (arch_age_i < arch_age_j)                                                                //���������� ������� �����
            {
                buf = Runi->Inf;
                Runi->Inf = Runj->Inf;
                Runj->Inf = buf;                                                                        //������ � ���������� ��������� ��������� ������
                buf_age = arch_age_i;                                                                   //����� �������, ���������� ���������� �� ��������
                arch_age_i = arch_age_j;
                arch_age_j = buf_age;
            }
        }
    }
        

    Runi = Lp;                                                  //������������� Run �� Lp                                                                           
    WritelnString("               ���� ��������� ������� ");
    WritelnString(
        " ------------------------------------------------------------------------------ ");
    WritelnString(
        "|��/� |  ����� |  ���  |   ����     |      �����     | ��� | � ��. |  �������  |");        //������ ����� �������
    WritelnString(
        "|     | ������ |  ���  |  ��������  |                |     |       |           |");
    WritelnString(
        "|------------------------------------------------------------------------------|");
    while (Runi != NULL && j < 4)                                                                           //� ����� ������ ������������� ����������� �� ����� ������ ��� �������
    {
        
            s[0] = '|'; s[1] = '\0';
            sprintf(slovo, "%3d", j); strcat(s, slovo); strcat(s, ". | ");
            strcat(s, Runi->Inf.Num);		strcat(s, " | ");
            sprintf(slovo, "%5d", Runi->Inf.Code); strcat(s, slovo); strcat(s, " | ");                      //��������� ������ s
            sprintf(slovo, "%02d", (Runi->Inf.Birthday / 100) % 100); strcat(s, slovo); strcat(s, ".");
            sprintf(slovo, "%02d", Runi->Inf.Birthday % 100); strcat(s, slovo); strcat(s, ".");
            sprintf(slovo, "%4d", Runi->Inf.Birthday / 10000); strcat(s, slovo); strcat(s, " | ");
            strcat(s, Runi->Inf.Street);		strcat(s, " | ");
            sprintf(slovo, "%3d", Runi->Inf.House); strcat(s, slovo); strcat(s, " | ");
            sprintf(slovo, "%5d", Runi->Inf.Flat); strcat(s, slovo); strcat(s, " | ");
            if (Runi->Inf.Phone == 0)
            {
                strcat(s, "    -    ");		strcat(s, " | ");
            }
            else
            {
                sprintf(slovo, "%03d", Runi->Inf.Phone / 10000); strcat(s, slovo); strcat(s, "-");
                sprintf(slovo, "%02d", (Runi->Inf.Phone / 100) % 100); strcat(s, slovo); strcat(s, "-");
                sprintf(slovo, "%02d", Runi->Inf.Phone % 100); strcat(s, slovo); strcat(s, " | ");
            }
            WritelnString(s);                                                                               //������ ������ s
            j++;
        
        Runi = Runi->Next;                      //������� � ���������� �������� �������
    }
    WritelnString(
        "|______________________________________________________________________________|\n");

    DisposeDirectory(Lp, Rp);                       //������� �������
}
