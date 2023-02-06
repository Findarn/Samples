#include "ReportArchiv.h"

void WorkUpArchive()
{
    int KeyRegime;                                              //переменная для выбора пункта меню
    if (!SignArchive)		                                    //проверяем создан ли архив
    {
        printf("Архивный файл не создан. Режим отменяется\n");
        return;
    }
    do                                                                  //цикл с постусловием
    {
        printf("\n      Укажите режим обработки архива:");
        printf("\n      0 - конец обработки;");
        printf("\n      1 - печать по заданной фамилии;");      
        printf("\n      2 - печать старше заданного возраста;");        //печатаем меню
        printf("\n      3 - печать трёх старейших жителей города\n");
        
        KeyRegime = (int)ceil(GetNumber(0, 3, 1, 0, 1, 0));             //ввод нужного режима с клавиатуры заданного диапазона
        switch (KeyRegime)                                              //анализ введенной клавиши
        {
            case 0:;		            break;          //выход
            case 1: WorkUpSurname();	break;          //1-ый режим
            case 2: WorkUpAge();        break;          //2-ой режим
            case 3: WorkUpOldest();		break;          //3-ий режим
        }
    } while (KeyRegime != 0);                           //выбор будет предоставляться до введения 0

	wait_press_key("\nДля продолжения нажмите любую клавишу\n");
} 

void WorkUpSurname()
{   //обработка по заданной фамилии
    DynDirectory *Lp, *Rp;
    DynDirectory *Run;
    int np, i=0, j=1;
    char surname[18], s[90], slovo[90];
    ReadFileOut(&np, &Lp, &Rp);                                    //считываем бинарный файл архива и формируем очередь структур
    if ((FlagAdd == 0) || (FlagSort == 0))                         //для корректной работы функции требуется чтобы предварительно были выполнены дополнение архива и его сортировка
    {
        printf("Перед обработкой архива должно произойти дополнение архива и его последующая сортировка\n");    //если что-то из этого не было выполнено, выходим из данного режима обработки
        return;
    }
    printf("Выбрана обработка архива по заданной фамилии. Введите фамилию:\n");     //приглашение ко вводу фамилии
    clear_input_buffer();           //очищаем входной буфер
    gets(surname);                  //введенное с клавиатуры значение помещаем в строку surname
    FillString(surname, 18, 1);     //заполняем строку surname пробелами до конца. Оригинальная строка FIO имеет разрядность 20 ,
                                    //1 символ уходит на имя, 1 на отчетство. Все остальное - это фамилия и пробелы.
    Run = Lp;                       //устанавливаем Run на Lp
    WritelnString("               AРХИВ СВЕДЕНИЙ ПО ЗАДАННОЙ ФАМИЛИИ");
    WritelnString(
        " ------------------------------------------------------------------------------ ");
    WritelnString(
        "|№п/п |  Номер |  Код  |   Дата     |      Улица     | Дом | № кв. |  Телефон  |");        //выводим шапку таблицы
    WritelnString(
        "|     | записи |  ФИО  |  рождения  |                |     |       |           |");
    WritelnString(
        "|------------------------------------------------------------------------------|");
    while (Run != NULL)
    {
        if (strcmp(surname, Kodifs[i].FIO+2) == 0)      //сравниваем строку surname и поле FIO. 
                                                        //Запись Kodifs[i].FIO+2 говорит о том, что строка FIO начнёт читаться со второго символа, пропуская инициалы
                                                        //функция strcmp сравнивает две строки и возвращает 0, если они одинаковые
        {
            s[0] = '|'; s[1] = '\0';
            sprintf(slovo, "%3d", j); strcat(s, slovo); strcat(s, ". | ");
            strcat(s, Run->Inf.Num);		strcat(s, " | ");
            sprintf(slovo, "%5d", Run->Inf.Code); strcat(s, slovo); strcat(s, " | ");
            sprintf(slovo, "%02d", (Run->Inf.Birthday / 100) % 100); strcat(s, slovo); strcat(s, ".");
            sprintf(slovo, "%02d", Run->Inf.Birthday % 100); strcat(s, slovo); strcat(s, ".");
            sprintf(slovo, "%4d", Run->Inf.Birthday / 10000); strcat(s, slovo); strcat(s, " | ");           //формирование строки s
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
            WritelnString(s);                                                                               //печать строки s
            j++;                                                                                            
        }
        i++;
        Run = Run->Next;
    }
    if (j == 1)                                                                                             //если j ни разу не увеличивалось, значит совпадений не найдено
    {
        WritelnString(
            "|                    Заданной фамилии в архиве не обнаружено                   |");
    }
        WritelnString(
            "|______________________________________________________________________________|\n"); 

        DisposeDirectory(Lp, Rp);       //удаляем очередь
}

void WorkUpAge()
{
    DynDirectory* Lp, * Rp;
    DynDirectory* Run;
    int np, age, arch_age, j = 1;
    struct tm* current_date;            //используем тип tm*, описанный в библиотеке time.h. Он позволяет представить текущее время системы в виде структуры
    time_t It;                          //time_t из библиотеки time.h - это арифметический тип для представления времени
    It = time(NULL);
    current_date = localtime(&It);      //передаем в структуру current_date значения текущего системного времени
    int year, month, day;                   //определяем переменные: год, месяц и день системного времени
    year = current_date->tm_year + 1900;        //в структуре время хранится своеобразно - например, годы ведут счёт от 1900 года. Поэтому, чтобы получить реальный текущий 
    month = current_date->tm_mon + 1;           //месяцы в структуре нумеруются с нуля до 11
    day = current_date->tm_mday;                //дни месяца нумеруются с 1 до 31, что нам подходит
    char s[90], slovo[90];
    ReadFileOut(&np, &Lp, &Rp);                    //считываем бинарный файл архива и создаем очередь структур
    if (FlagAdd == 0)                                                               //для работы обработки желательно, чтобы архив уже был дополнен
    {
        printf("Перед обработкой архива должно произойти дополнение архива\n");
        return;
    }
    printf("Выбрана обработка архива от заданного возраста. Введите возраст:\n");   //приглашение ко вводу возраста
    age = (int)ceil(GetNumber(0, 120, 1, 0, 1, 0));                                 //ввод возраста с клавиатуры с проверкой диапазона
    
    Run = Lp;                                                                       //устанавливаем Run на Lp
    WritelnString("               AРХИВ СВЕДЕНИЙ ОТ ЗАДАННОГО ВОЗРАСТА");
    WritelnString(
        " ------------------------------------------------------------------------------ ");
    WritelnString(
        "|№п/п |  Номер |  Код  |   Дата     |      Улица     | Дом | № кв. |  Телефон  |");
    WritelnString(
        "|     | записи |  ФИО  |  рождения  |                |     |       |           |");        //печатаем шапку таблицы
    WritelnString(
        "|------------------------------------------------------------------------------|");
    while (Run != NULL)
    {
        arch_age = year - Run->Inf.Birthday / 10000;                //вычисляем возраст человека из текущей записи. вычитаем из текущего года год рождения
        if (month < Run->Inf.Birthday % 100)                        //мы подсчитываем количество полных лет. если день рождения человека в этом году еще не наступил - это учитывается
            arch_age = arch_age - 1;                                //проверяем, был ли в этом году месяц рождения, если не был - вычитаем один год
        else
            if ((month == Run->Inf.Birthday % 100) && (day < (Run->Inf.Birthday / 100) % 100))  //такую же проверку организовываем для дня рождения
                arch_age = arch_age - 1;
        if (arch_age >= age)                                                                            //сравниваем заданный возраст с рассчитанным возрастом человека
        {
            s[0] = '|'; s[1] = '\0';
            sprintf(slovo, "%3d", j); strcat(s, slovo); strcat(s, ". | ");                              //если он больше заданного, формируем строку s
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
            WritelnString(s);                                                                           //и печатаем её
            j++;
        }
        Run = Run->Next;
    }
    if (j == 1)                                                                                         //если j не увеличивался, значит людей заданного возраста в архиве нет
    {
        WritelnString(
        "|             Люди старше заданного возраста отсутствуют в справочнике         |");
    }
    WritelnString(
        "|______________________________________________________________________________|\n");

    DisposeDirectory(Lp, Rp);                   //удаляем очередь
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
    current_date = localtime(&It);                      //получаем системное время
    int year, month, day;
    year = current_date->tm_year + 1900;                //преобразовываем год к нужному виду
    month = current_date->tm_mon + 1;                   //преобразовываем месяц к нужному виду
    day = current_date->tm_mday;
    char s[90], slovo[90];
    ReadFileOut(&np, &Lp, &Rp);                         //считываем бинарный файл архива и формируем очередь структур
    if (FlagAdd == 0)                                                           //перед обработкой должно быть выполнено дополнение архива
    {
        printf("Перед обработкой архива должно произойти дополнение архива\n");
        return;
    }
    printf("Выбран вывод трех старейших жителей\n");

    for (Runi = Lp; Runi->Next != NULL; Runi = Runi->Next)                                              //производим сортировку полученной очереди по признаку возраста
    {
        arch_age_i = year - Runi->Inf.Birthday / 10000;
        if (month < Runi->Inf.Birthday % 100)
            arch_age_i = arch_age_i - 1;                                                                //рассчитываем возраст в Runi-ой записи с учетом текущего месяца
        else
            if ((month == Runi->Inf.Birthday % 100) && (day < (Runi->Inf.Birthday / 100) % 100))
                arch_age_i = arch_age_i - 1;
        for (Runj = Runi->Next; Runj != NULL; Runj = Runj->Next)
        {
            arch_age_j = year - Runj->Inf.Birthday / 10000;
            if (month < Runj->Inf.Birthday % 100)
                arch_age_j = arch_age_j - 1;                                                            //рассчитываем возраст в Runj-ой записи с учетом текущего месяца
            else
                if ((month == Runj->Inf.Birthday % 100) && (day < (Runj->Inf.Birthday / 100) % 100))
                    arch_age_j = arch_age_j - 1;
            if (arch_age_i < arch_age_j)                                                                //сравниваем возраст людей
            {
                buf = Runi->Inf;
                Runi->Inf = Runj->Inf;
                Runj->Inf = buf;                                                                        //запись с наибольшим возрастом поднимаем ввверх
                buf_age = arch_age_i;                                                                   //таким образом, происходит сортировка по убыванию
                arch_age_i = arch_age_j;
                arch_age_j = buf_age;
            }
        }
    }
        

    Runi = Lp;                                                  //устанавливаем Run на Lp                                                                           
    WritelnString("               ТРОЕ СТАРЕЙШИХ ЖИТЕЛЕЙ ");
    WritelnString(
        " ------------------------------------------------------------------------------ ");
    WritelnString(
        "|№п/п |  Номер |  Код  |   Дата     |      Улица     | Дом | № кв. |  Телефон  |");        //печать шапки таблицы
    WritelnString(
        "|     | записи |  ФИО  |  рождения  |                |     |       |           |");
    WritelnString(
        "|------------------------------------------------------------------------------|");
    while (Runi != NULL && j < 4)                                                                           //в цикле вывода устанавливаем ограничение на вывод только трёх записей
    {
        
            s[0] = '|'; s[1] = '\0';
            sprintf(slovo, "%3d", j); strcat(s, slovo); strcat(s, ". | ");
            strcat(s, Runi->Inf.Num);		strcat(s, " | ");
            sprintf(slovo, "%5d", Runi->Inf.Code); strcat(s, slovo); strcat(s, " | ");                      //формируем строку s
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
            WritelnString(s);                                                                               //печать строки s
            j++;
        
        Runi = Runi->Next;                      //переход к следующему элементу очереди
    }
    WritelnString(
        "|______________________________________________________________________________|\n");

    DisposeDirectory(Lp, Rp);                       //удаляем очередь
}
