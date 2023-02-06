#pragma once
#include "Square.h"
#include "MyStack.h"
#include <vector>
#include <iostream>
#include <iomanip>

class Labirint		// лабиринт
{
private:
	//std::vector <std::vector<Square>> field;		// поле
	Square start;									// клетка начала
	Square end;										// клетка выхода
public:
	std::vector <std::vector<Square>> field;		// поле

	Labirint();						// конструктор по умолчанию
	Labirint(int h, int w);			// конструктор по высоте-ширине

	/*std::vector <std::vector<Square>> Field();*/
	Square Start();
	Square End();

	void Create();		// выделение памяти под поле
	void Borders();		// создание границ
	void SetExitSquare();		// установка выхода
	void Generate();	// случайное размещение проходов и препятствий
	void SetStartSquare();	// установка старта
	void FinalSet();	// увелчиение путей в лабиринте
	void ComplexSet();	// выполнение всех функций по созданию лабиринта
	void ClearLab();	// очистка лабиринта

	void Display(bool index, int mode, std::string msg);		// вывод на экран
};