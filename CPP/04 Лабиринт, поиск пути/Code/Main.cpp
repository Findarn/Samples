#include "Functions.h"

int main()
{
	setlocale(LC_ALL, "rus");
	Labirint labirint;
	Stack Path;
	int mod = -1;

	do
	{
		std::cout << std::endl;
		std::cout << " МЕНЮ РАБОТЫ С ЛАБИРИНТОМ" << std::endl;
		std::cout << "0 - Выход" << std::endl;
		std::cout << "1 - Пошаговое создание лабиринта" << std::endl;
		std::cout << "2 - Автоматическое создание лабиринта" << std::endl;
		std::cout << "3 - Начало поиска пути" << std::endl;
		std::cout << "4 - Показать путь" << std::endl;
		std::cout << "5 - Отображение лабиринта" << std::endl;
		std::cout << "6 - Очистить лабиринт" << std::endl;
		std::cin >> mod;

		switch (mod)
		{
		case 0: break;
		case 1:
		{
			Path.Clear();
			labirint.ClearLab();						
			labirint.Create();
			labirint.Display(true, 0, "создание пустого лабиринта");
			labirint.Borders();			
			labirint.Display(true, 0, "генерация границ лабиринта");
			labirint.Generate();
			labirint.Display(true, 0, "генерация клеток лабиринта");
			labirint.SetExitSquare();
			labirint.Display(true, 0, "определение точки выхода");
			labirint.SetStartSquare();
			labirint.Display(true, 0, "определение точки старта");
			labirint.FinalSet();
			labirint.Display(true, 0, "прокладывание путей в лабиринте");
		} break;
		case 2:
		{
			Path.Clear();
			labirint.ClearLab();						
			labirint.Create();
			labirint.ComplexSet();
			labirint.Display(true, 0, "создание лабиринта по заданным параметрам");
		} break;

		case 3:
		{
			Path.Clear();
			PathFinder(labirint, Path);
		}break;
		case 4:
		{
			ShowPath(labirint, Path);
		}break;

		case 5:
		{
			int disp_index = -1;
			do
			{
				std::cout << std::endl;
				std::cout << " Режим показа координат" << std::endl;
				std::cout << "1 - Показывать координаты" << std::endl;
				std::cout << "2 - Скрыть координаты" << std::endl;

				std::cin >> disp_index;
			} while (disp_index > 2 && disp_index < 1);
			int disp_mode = -1;
			do
			{
				std::cout << std::endl;
				std::cout << " Режим отображения лабиринта" << std::endl;
				std::cout << "1 - Стандартное отображение" << std::endl;
				std::cout << "2 - Отображение волны" << std::endl;
				std::cout << "3 - Отображение пути" << std::endl;

				std::cin >> disp_mode;
			} while (disp_mode > 3 && disp_mode < 1);
			if (disp_index == 1)
				labirint.Display(true, disp_mode - 1, "");
			else
				labirint.Display(false, disp_mode - 1,"");
		}break;
		
		case 6:
		{
			Path.Clear();
			labirint.ClearLab();
		} break;
		}
	} while (mod != 0);

}