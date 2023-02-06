#include "Functions.h"


Square GetUpS(Square cur, Labirint labirint)
{
	Square Up;
	Up.CopyFrom(labirint.field.at(cur.X() - 1).at(cur.Y()));
	return Up;
}
Square GetDownS(Square cur, Labirint labirint)
{
	Square Down;
	Down.CopyFrom(labirint.field.at(cur.X() + 1).at(cur.Y()));
	return Down;
}
Square GetLeftS(Square cur, Labirint labirint)
{
	Square Left;
	Left.CopyFrom(labirint.field.at(cur.X()).at(cur.Y() - 1));
	return Left;
}
Square GetRightS(Square cur, Labirint labirint)
{
	Square Right;
	Right.CopyFrom(labirint.field.at(cur.X()).at(cur.Y() + 1));
	return Right;
}

void PathFinder(Labirint &labirint, Stack &P)
{
	
	Stack src;		// источники
	Stack prop;		// распространени€
	src.Push(labirint.field.at(labirint.Start().X()).at(labirint.Start().Y()));
	int wave = 0;
	bool ExitFound = false;
	Square PreExit;

	
	for (int i = 0; i < labirint.field.size(); i++)
	{
		for (int j = 0; j < labirint.field.at(0).size(); j++)
		{
			labirint.field.at(i).at(j).SetsWave(0);
			labirint.field.at(i).at(j).SetWave(-1);
		}
	}

	while (src.Size() != 0)
	{
		while (src.Size() != 0)
		{
			labirint.field.at(src.Peek().X()).at(src.Peek().Y()).SetsWave(1);
			labirint.field.at(src.Peek().X()).at(src.Peek().Y()).SetWave(wave);

			Square curr;			
			// €чейка сверху
			curr.CopyFrom(labirint.field.at(src.Peek().X()).at(src.Peek().Y()));
			curr = GetUpS(curr, labirint);
			if (curr.End() == true)
			{
				ExitFound = true;
				PreExit.CopyFrom(labirint.field.at(src.Peek().X()).at(src.Peek().Y()));
				break;
			}
			else
			{
				if (curr.Open() == true && curr.SWave() == 0)
				{
					labirint.field.at(curr.X()).at(curr.Y()).SetsWave(2);
					prop.Push(labirint.field.at(curr.X()).at(curr.Y()));
				}
			}
			// €чейка снизу
			curr.CopyFrom(labirint.field.at(src.Peek().X()).at(src.Peek().Y()));
			curr = GetDownS(curr, labirint);
			if (curr.End() == true)
			{
				ExitFound = true;
				PreExit.CopyFrom(labirint.field.at(src.Peek().X()).at(src.Peek().Y()));
				break;
			}
			else
			{
				if (curr.Open() == true && curr.SWave() == 0)
				{
					labirint.field.at(curr.X()).at(curr.Y()).SetsWave(2);
					prop.Push(labirint.field.at(curr.X()).at(curr.Y()));
				}
			}
			// €чейка слева
			curr.CopyFrom(labirint.field.at(src.Peek().X()).at(src.Peek().Y()));
			curr = GetLeftS(curr, labirint);
			if (curr.End() == true)
			{
				ExitFound = true;
				PreExit.CopyFrom(labirint.field.at(src.Peek().X()).at(src.Peek().Y()));
				break;
			}
			else
			{
				if (curr.Open() == true && curr.SWave() == 0)
				{
					labirint.field.at(curr.X()).at(curr.Y()).SetsWave(2);
					prop.Push(labirint.field.at(curr.X()).at(curr.Y()));
				}
			}
			// €чейка справа
			curr.CopyFrom(labirint.field.at(src.Peek().X()).at(src.Peek().Y()));
			curr = GetRightS(curr, labirint);
			if (curr.End() == true)
			{
				ExitFound = true;
				PreExit.CopyFrom(labirint.field.at(src.Peek().X()).at(src.Peek().Y()));
				break;
			}
			else
			{
				if (curr.Open() == true && curr.SWave() == 0)
				{
					labirint.field.at(curr.X()).at(curr.Y()).SetsWave(2);
					prop.Push(labirint.field.at(curr.X()).at(curr.Y()));
				}
			}	
			src.Pop();
		}
		// если выход был найден
		if (ExitFound == true)
		{
			break;		// прекращаем распространение волны
		}
		// переносим распространение в источники
		while (!prop.Empty())
		{
			src.Push(prop.Pop());
		}
		// наращиваем вес волны
		wave++;
		// очищаем список распространени€		
	}
	
	if (!ExitFound)
	{
		std::cout << "¬ыхода не существует!" << std::endl;
		return;
	}

	// если выход найден
	
	P.Push(PreExit);
	PreExit.SetsWave(3);
	labirint.field.at(PreExit.X()).at(PreExit.Y()).SetsWave(3);
	while (wave != 0)
	{
		if (GetUpS(PreExit, labirint).Wave() == wave - 1 && GetUpS(PreExit, labirint).Open())
		{
			PreExit = GetUpS(PreExit, labirint);
			PreExit.SetsWave(3);
			labirint.field.at(PreExit.X()).at(PreExit.Y()).SetsWave(3);
			wave--;
			P.Push(PreExit);
			continue;
		}
		if (GetDownS(PreExit, labirint).Wave() == wave - 1 && GetDownS(PreExit, labirint).Open())
		{
			PreExit = GetDownS(PreExit, labirint);
			PreExit.SetsWave(3);
			labirint.field.at(PreExit.X()).at(PreExit.Y()).SetsWave(3);
			wave--;
			P.Push(PreExit);
			continue;
		}
		if (GetLeftS(PreExit, labirint).Wave() == wave - 1 && GetLeftS(PreExit, labirint).Open())
		{
			PreExit = GetLeftS(PreExit, labirint);
			PreExit.SetsWave(3);
			labirint.field.at(PreExit.X()).at(PreExit.Y()).SetsWave(3);
			wave--;
			P.Push(PreExit);
			continue;
		}
		if (GetRightS(PreExit, labirint).Wave() == wave - 1 && GetRightS(PreExit, labirint).Open())
		{
			PreExit = GetRightS(PreExit, labirint);
			PreExit.SetsWave(3);
			labirint.field.at(PreExit.X()).at(PreExit.Y()).SetsWave(3);
			wave--;
			P.Push(PreExit);
			continue;
		}
	}
	std::cout << "ћаршрут построен, длина маршрута " << P.Size() << " клеток." << std::endl;
}

void ShowPath(Labirint labirint, Stack &P)
{
	if (P.Size() == 0)
	{
		std::cout << "¬ыхода из лабиринта нет!" << std::endl;
		return;
	}
	labirint.Display(true, 2, "");
	P.Reverse();
	P.Display();	
}