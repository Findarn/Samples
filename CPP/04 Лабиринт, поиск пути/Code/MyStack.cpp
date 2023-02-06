#include "MyStack.h"

Stack::Stack()
{
	capacity = 0;		
	top = -1;
	arr = nullptr;
}

Stack::Stack(int size)
{
	delete[] arr;					// очищаем старый массив
	capacity = size;				// ёмкость стека определяем новым размером
	top = 0;						// устанавливаем индекс вершины стека
	arr = new Square[capacity];		// выделяем память
}

void Stack::Push(Square sq)
{
	top++;											// наращиваем вершину стека
	if (top >= capacity)							// если вершина стека за пределами выделенной памяти
	{
		capacity += 4;								// расширяем выделенную память (заранее на большее количество)
		Square* buf = new Square[capacity];			// выделяем память под увеличенный массив
		for (int i = 0; i < top; i++)				// обходим старый массив
			buf[i] = arr[i];						// копируем все элементы
		buf[top] = sq;								// на вершину помещаем новый элемент
		delete[] arr;								// освобождаем память старого массива
		arr = buf;									// передаем указатель на расширенный новый массив
	}
	else
	{
		arr[top] = sq;								// на вершину помещаем новый элемент
	}
}

Square Stack::Pop()
{
	if (Empty())							// проверка на пустоту
		throw "Stack is empty!";			// генерация исключения
	int oldtop = top;						// запоминаем старую вершину
	top--;									// уменьшаем вершину стека
	if (oldtop < capacity / 2)				// если вершина стека меньше ёмкости в два раза, уменьшим выделенную память под массив
	{
		capacity /= 2;						// уменьшаем ёмкость в два раза
		Square* buf = new Square[capacity];	// выделяем память под уменьшенный массив
		for (int i = 0; i <= oldtop; i++)	// обходим старый массив
			buf[i] = arr[i];				// переписываем элементы в уменьшенный массив
		delete[] arr;						// освобождаем память старого массива
		arr = buf;							// передаём указатель на уменьшенный новый массив
	}
	return arr[oldtop];						// возвращаем элемент, находившийся на вершине стека
}

Square Stack::Peek()
{
	if (Empty())							// проверка на пустоту
		throw "Stack is empty!";			// генерация исключения
	return arr[top];						// возвращаем элемент, находящийся на вершине стека (не меняя стек)
}

int Stack::Size()
{
	return top+1;		// получаем размер стека
}

bool Stack::Empty()
{
	if (top == -1)			// индекс вершины стека -1 указывает на пустоту стека
		return true;
	else
		return false;
}

void Stack::Clear()
{
	delete[] arr;		// освобождаем память
	arr = nullptr;		// явно задаем пустой указатель
	capacity = 0;		// обнуляем ёмкость стека
	top = -1;			// помечаем индекс вершины для пустого стека
}

void Stack::Display()
{
	if (Empty())	// если стек пуст
	{
		std::cout << std::endl;
		std::cout << "Выделенная память под стек: " << capacity << std::endl;
		std::cout << "Содержимое стека пусто!" << std::endl;
		return;
	}

	std::cout << std::endl;
	std::cout << "Выделенная память под стек: " << capacity << std::endl;
	std::cout << "Текущий размер стека:" << Size() << std::endl;
	std::cout << "Элементы стека: ";
	for (int i = 0; i < Size(); i++)
		std::cout << "[" << arr[i].X() << ":" << arr[i].Y() << "]" << " ";
	std::cout << std::endl;

}

void Stack::Reverse()
{
	if (Empty())							// проверка на пустоту
		return;								// выход
	Square* buf = new Square[capacity];		// буферный массив того же размера
	int i = 0; int j = top;
	while (i != Size())
	{
		buf[i] = arr[j];
		i++;
		j--;
	}
	delete[] arr;						// освобождаем память старого массива
	arr = buf;							// передаём указатель на уменьшенный новый массив
}