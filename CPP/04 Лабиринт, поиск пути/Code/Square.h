#pragma once
#include <iostream>
#include <sstream>
class Square		// клетка поля лабиринта
{
private:
	int x;			// номер строки
	int y;			// номер столбца
	bool open;		// признак открытой клетки
	bool start;		// признак старта
	bool end;		// признак выхода
	int sWave;		// состояние "волны" (0 - волна не касалась, 1 - источник, 2 - распространение, 3 - путь)
	int wave;		// вес "волны"

public:
	Square();				// конструктор по умолчанию
	Square(int x, int y);	// конструктор координат

	void SetX(int x);
	int X();

	void SetY(int y);
	int Y();

	void SetOpen(bool o);
	bool Open();

	void SetStart(bool s);
	bool Start();

	void SetEnd(bool e);
	bool End();

	void SetsWave(int s);
	int SWave();

	void SetWave(int w);
	int Wave();

	void CopyFrom(Square sq);	// скопировать значение другой клетки
	std::string Display(int mode);		// управляемое отображение содержимого клетки
	void Reset();				// сброс значений клетки к изначальным
};