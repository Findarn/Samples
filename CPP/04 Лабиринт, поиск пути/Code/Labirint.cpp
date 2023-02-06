#include "Labirint.h"

Labirint::Labirint()
{
	field = std::vector<std::vector<Square>>();
	start.Reset();
	end.Reset();
}

Labirint::Labirint(int h, int w)
{
	field.resize(h);
	for (int i = 0; i < h; i++)
	{
		field.at(i).resize(w);
		for (int j = 0; j < w; j++)
		{
			Square s(i, j);
			field.at(i).at(j) = s;
		}
	}
}

//std::vector <std::vector<Square>> Labirint::Field()
//{
//	return field;
//}

Square Labirint::Start()
{
	return start;
}

Square Labirint::End()
{
	return end;
}

void Labirint::Create()
{
	int h;
	int w;
	// 30:30
	std::cout << "Введите высоту матрицы: ";
	std::cin >> h;
	std::cout << std::endl;
	std::cout << "Введите ширину матрицы: ";
	std::cin >> w;
	std::cout << std::endl;
	ClearLab();
	field.resize(h);
	for (int i = 0; i < h; i++)
	{
		field.at(i).resize(w);		
		for (int j = 0; j < w; j++)		
		{
			Square s(i, j);
			field.at(i).at(j) = s;
		}
	}
}

void Labirint::Borders()
{
	if (field.empty())
	{
		std::cout << "Не задан лабиринт!" << std::endl;
		return;
	}

	for (int i = 0; i < field.at(0).size(); i++)
	{
		field.at(0).at(i).SetOpen(false);
		field.at(field.size() - 1).at(i).SetOpen(false);
	}
	for (int i = 1; i < field.size() - 1; i++)
	{
		field.at(i).at(0).SetOpen(false);
		field.at(i).at(field.at(0).size() - 1).SetOpen(false);
	}
}

void Labirint::SetExitSquare()
{
	if (field.empty())
	{
		std::cout << "Не задан лабиринт!" << std::endl;
		return;
	}

	int xEnd;
	int yEnd;
	int r = rand() % 4;
	switch (r)
	{
	case 0:
	{
		yEnd = 0;
		xEnd = (rand() % (field.size() - 2)) + 1;
	} break;
	case 1:
	{
		xEnd = 0;
		yEnd = (rand() % (field.at(0).size() - 2)) + 1;
	} break;
	case 2:
	{
		yEnd = field.at(0).size() - 1;
		xEnd = (rand() % (field.size() - 2)) + 1;
	} break;
	case 3:
	{
		xEnd = field.size() - 1;
		yEnd = (rand() % (field.at(0).size() - 2)) + 1;
	} break;
	}
	field.at(xEnd).at(yEnd).SetEnd(true);
	end.SetX(xEnd);
	end.SetY(yEnd);
}

void Labirint::Generate()
{
	if (field.empty())
	{
		std::cout << "Не задан лабиринт!" << std::endl;
		return;
	}
	if (start.X() != -1 || start.Y() != -1)
	{
		field.at(start.X()).at(start.Y()).SetStart(false);
		start.Reset();
	}
	if (end.X() != -1 || end.Y() != -1)
	{
		field.at(end.X()).at(end.Y()).SetEnd(false);
		end.Reset();
	}
	for (int i = 1; i < field.size() - 1; i++)
	{
		for (int j = 1; j < field.at(0).size() - 1; j++)
		{
			int o = rand() % 2;
			if (o == 0)
			{
				field.at(i).at(j).SetOpen(true);
			}
			else
			{
				field.at(i).at(j).SetOpen(false);
			}
		}
	}
}

void Labirint::SetStartSquare()
{
	if (field.empty())
	{
		std::cout << "Не задан лабиринт!" << std::endl;
		return;
	}

	int xS, yS;

	xS = (rand() % (field.size() - 2)) + 1;
	yS = (rand() % (field.at(0).size() - 2)) + 1;
	field.at(xS).at(yS).SetOpen(true);
	field.at(xS).at(yS).SetStart(true);
	start.SetX(xS);
	start.SetY(yS);
}

void Labirint::FinalSet()
{
	if (field.empty())
	{
		std::cout << "Не задан лабиринт!" << std::endl;
		return;
	}
	// проход от выхода
	if (end.X() == 0)
	{
		for (int i = 1; i <= field.size() / 2; i++)
		{
			field.at(i).at(end.Y()).SetOpen(true);
		}
	}
	if (end.X() == field.size() - 1)
	{
		for (int i = field.size() - 2; i >= field.size() / 2; i--)
		{
			field.at(i).at(end.Y()).SetOpen(true);
		}
	}
	if (end.Y() == 0)
	{
		for (int j = 1; j <= field.at(0).size() / 2; j++)
		{
			field.at(end.X()).at(j).SetOpen(true);
		}
	}
	if (end.Y() == field.at(0).size() - 1)
	{
		for (int j = field.at(0).size() - 2; j >= field.at(0).size() / 2; j--)
		{
			field.at(end.X()).at(j).SetOpen(true);
		}
	}
	// проходы от клетки игрока
	bool u_rand = true;
	bool d_rand = true;
	bool l_rand = true;
	bool r_rand = true;
	int mx_d = field.size() - start.X() - 1;
	int mx_u = field.size() - mx_d - 1;
	int mx_r = field.at(0).size() - start.Y() - 1;
	int mx_l = field.at(0).size() - mx_r - 1;

	if (rand() % 2 == 0)
		u_rand = true;
	else
		u_rand = false;
	if (rand() % 2 == 0)
		d_rand = true;
	else
		d_rand = false;
	if (rand() % 2 == 0)
		l_rand = true;
	else
		l_rand = false;
	if (rand() % 2 == 0)
		r_rand = true;
	else
		r_rand = false;

	if (start.X() == 1) u_rand = false;
	if (start.X() == field.size() - 2) d_rand = false;
	if (start.Y() == field.at(0).size() - 2) r_rand = false;
	if (start.Y() == 1) l_rand = false;

	if (u_rand)
	{
		int s_u = rand() % mx_u + 1;
		for (int i = 1; i < s_u; i++)
		{
			field.at(start.X() - i).at(start.Y()).SetOpen(true);
		}
	}
	if (d_rand)
	{
		int s_d = rand() % mx_d + 1;
		for (int i = 1; i < s_d; i++)
		{
			field.at(start.X() + i).at(start.Y()).SetOpen(true);
		}
	}
	if (l_rand)
	{
		int s_l = rand() % mx_l + 1;
		for (int i = 1; i < s_l; i++)
		{
			field.at(start.X()).at(start.Y() - i).SetOpen(true);
		}
	}
	if (r_rand)
	{
		int s_r = rand() % mx_r + 1;
		for (int i = 1; i < s_r; i++)
		{
			field.at(start.X()).at(start.Y() + i).SetOpen(true);
		}
	}
}

void Labirint::ComplexSet()
{
	if (field.empty())
	{
		std::cout << "Не задан лабиринт!" << std::endl;
		return;
	}
	Borders();
	Generate();
	SetExitSquare();	
	SetStartSquare();
	FinalSet();
}

void Labirint::ClearLab()
{
	if (field.empty())
	{
		std::cout << "Лабиринт не задан!" << std::endl;
		return;
	}

	std::vector<std::vector<Square>>().swap(field);
	start.Reset();
	end.Reset();

	std::cout << "Лабиринт удалён!" << std::endl;
}

void Labirint::Display(bool index, int mode, std::string msg)
{
	if (field.empty())
	{
		std::cout << "Не задан лабиринт!" << std::endl;
		return;
	}
	if (msg.size() == 0)
	{
		std::cout << std::endl;
	}
	else
	{
		std::cout << "Действие: " << msg << "." << std::endl;
	}
	if (index)
	{
		for (int i = -1; i < (int)field.size(); i++)
		{
			if (i == -1)
				std::cout << std::setw(3) << std::left << "x\\y";
			for (int j = 0; j < field.at(0).size(); j++)
			{
				if (i == -1)
					std::cout << std::setw(3) << std::left << j;
				else
					if (j == 0)
					{
						std::cout << std::setw(3) << std::left << i;
						if (field.at(i).at(j).Display(mode) == "x")
							std::cout << '|' << field.at(i).at(j).Display(mode) << '|';
						else
							if (field.at(i).at(j).Display(mode) == " " || field.at(i).at(j).Display(mode) == "i"
								|| field.at(i).at(j).Display(mode) == "F" || field.at(i).at(j).Display(mode) == "-"
								|| field.at(i).at(j).Display(mode) == "*")
								std::cout << ' ' << field.at(i).at(j).Display(mode) << ' ';
							else
								std::cout << std::setw(3) << std::left << field.at(i).at(j).Display(mode);
					}
					else
						if (field.at(i).at(j).Display(mode) == "x")
							std::cout << '|' << field.at(i).at(j).Display(mode) << '|';
						else
							if (field.at(i).at(j).Display(mode) == " " || field.at(i).at(j).Display(mode) == "i"
								|| field.at(i).at(j).Display(mode) == "F" || field.at(i).at(j).Display(mode) == "-"
								|| field.at(i).at(j).Display(mode) == "*")
								std::cout << ' ' << field.at(i).at(j).Display(mode) << ' ';
							else
								std::cout << std::setw(3) << std::left << field.at(i).at(j).Display(mode);
			}
			std::cout << std::endl;
		}
	}
	else
	{
		for (int i = 0; i < (int)field.size(); i++)
		{
			for (int j = 0; j < field.at(0).size(); j++)
			{
				if (field.at(i).at(j).Display(mode) == "x")
					std::cout << '|' << field.at(i).at(j).Display(mode) << '|';
				else
					if (field.at(i).at(j).Display(mode) == " " || field.at(i).at(j).Display(mode) == "i"
						|| field.at(i).at(j).Display(mode) == "F" || field.at(i).at(j).Display(mode) == "-"
						|| field.at(i).at(j).Display(mode) == "*")
						std::cout << ' ' << field.at(i).at(j).Display(mode) << ' ';
					else
						std::cout << std::setw(3) << std::left << field.at(i).at(j).Display(mode);
			}
			std::cout << std::endl;
		}
	}
	std::cout << std::endl;
}