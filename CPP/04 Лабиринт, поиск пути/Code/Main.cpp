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
		std::cout << " ���� ������ � ����������" << std::endl;
		std::cout << "0 - �����" << std::endl;
		std::cout << "1 - ��������� �������� ���������" << std::endl;
		std::cout << "2 - �������������� �������� ���������" << std::endl;
		std::cout << "3 - ������ ������ ����" << std::endl;
		std::cout << "4 - �������� ����" << std::endl;
		std::cout << "5 - ����������� ���������" << std::endl;
		std::cout << "6 - �������� ��������" << std::endl;
		std::cin >> mod;

		switch (mod)
		{
		case 0: break;
		case 1:
		{
			Path.Clear();
			labirint.ClearLab();						
			labirint.Create();
			labirint.Display(true, 0, "�������� ������� ���������");
			labirint.Borders();			
			labirint.Display(true, 0, "��������� ������ ���������");
			labirint.Generate();
			labirint.Display(true, 0, "��������� ������ ���������");
			labirint.SetExitSquare();
			labirint.Display(true, 0, "����������� ����� ������");
			labirint.SetStartSquare();
			labirint.Display(true, 0, "����������� ����� ������");
			labirint.FinalSet();
			labirint.Display(true, 0, "������������� ����� � ���������");
		} break;
		case 2:
		{
			Path.Clear();
			labirint.ClearLab();						
			labirint.Create();
			labirint.ComplexSet();
			labirint.Display(true, 0, "�������� ��������� �� �������� ����������");
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
				std::cout << " ����� ������ ���������" << std::endl;
				std::cout << "1 - ���������� ����������" << std::endl;
				std::cout << "2 - ������ ����������" << std::endl;

				std::cin >> disp_index;
			} while (disp_index > 2 && disp_index < 1);
			int disp_mode = -1;
			do
			{
				std::cout << std::endl;
				std::cout << " ����� ����������� ���������" << std::endl;
				std::cout << "1 - ����������� �����������" << std::endl;
				std::cout << "2 - ����������� �����" << std::endl;
				std::cout << "3 - ����������� ����" << std::endl;

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