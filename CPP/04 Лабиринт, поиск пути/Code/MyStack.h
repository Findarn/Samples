#pragma once
#include"Square.h"
#include <iostream>
#include <new>

class Stack		// пользовательский стек
{
private:
	Square* arr;		// указатель, через который организован внутренний массив
	int capacity;		// выделенная память под внутренний массив
	int top;			// индекс текущей вершины стека

public:
	Stack();				// конструктор по умолчанию
	Stack(int size);		// конструктор, задающий начальный размер

	void Push(Square Sq);	// добавление элемента в конец
	Square Pop();			// выдача верхнего элемента
	Square Peek();			// просмотр верхнего элемента
	
	int Size();				// получить размер стека
	bool Empty();			// проверить, пуст ли стек
	void Reverse();			// реверс стека
	void Clear();			// очистить стек
	void Display();			// вывести стек на экран
};



