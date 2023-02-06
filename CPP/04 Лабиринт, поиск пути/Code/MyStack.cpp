#include "MyStack.h"

Stack::Stack()
{
	capacity = 0;		
	top = -1;
	arr = nullptr;
}

Stack::Stack(int size)
{
	delete[] arr;					// ������� ������ ������
	capacity = size;				// ������� ����� ���������� ����� ��������
	top = 0;						// ������������� ������ ������� �����
	arr = new Square[capacity];		// �������� ������
}

void Stack::Push(Square sq)
{
	top++;											// ���������� ������� �����
	if (top >= capacity)							// ���� ������� ����� �� ��������� ���������� ������
	{
		capacity += 4;								// ��������� ���������� ������ (������� �� ������� ����������)
		Square* buf = new Square[capacity];			// �������� ������ ��� ����������� ������
		for (int i = 0; i < top; i++)				// ������� ������ ������
			buf[i] = arr[i];						// �������� ��� ��������
		buf[top] = sq;								// �� ������� �������� ����� �������
		delete[] arr;								// ����������� ������ ������� �������
		arr = buf;									// �������� ��������� �� ����������� ����� ������
	}
	else
	{
		arr[top] = sq;								// �� ������� �������� ����� �������
	}
}

Square Stack::Pop()
{
	if (Empty())							// �������� �� �������
		throw "Stack is empty!";			// ��������� ����������
	int oldtop = top;						// ���������� ������ �������
	top--;									// ��������� ������� �����
	if (oldtop < capacity / 2)				// ���� ������� ����� ������ ������� � ��� ����, �������� ���������� ������ ��� ������
	{
		capacity /= 2;						// ��������� ������� � ��� ����
		Square* buf = new Square[capacity];	// �������� ������ ��� ����������� ������
		for (int i = 0; i <= oldtop; i++)	// ������� ������ ������
			buf[i] = arr[i];				// ������������ �������� � ����������� ������
		delete[] arr;						// ����������� ������ ������� �������
		arr = buf;							// ������� ��������� �� ����������� ����� ������
	}
	return arr[oldtop];						// ���������� �������, ������������ �� ������� �����
}

Square Stack::Peek()
{
	if (Empty())							// �������� �� �������
		throw "Stack is empty!";			// ��������� ����������
	return arr[top];						// ���������� �������, ����������� �� ������� ����� (�� ����� ����)
}

int Stack::Size()
{
	return top+1;		// �������� ������ �����
}

bool Stack::Empty()
{
	if (top == -1)			// ������ ������� ����� -1 ��������� �� ������� �����
		return true;
	else
		return false;
}

void Stack::Clear()
{
	delete[] arr;		// ����������� ������
	arr = nullptr;		// ���� ������ ������ ���������
	capacity = 0;		// �������� ������� �����
	top = -1;			// �������� ������ ������� ��� ������� �����
}

void Stack::Display()
{
	if (Empty())	// ���� ���� ����
	{
		std::cout << std::endl;
		std::cout << "���������� ������ ��� ����: " << capacity << std::endl;
		std::cout << "���������� ����� �����!" << std::endl;
		return;
	}

	std::cout << std::endl;
	std::cout << "���������� ������ ��� ����: " << capacity << std::endl;
	std::cout << "������� ������ �����:" << Size() << std::endl;
	std::cout << "�������� �����: ";
	for (int i = 0; i < Size(); i++)
		std::cout << "[" << arr[i].X() << ":" << arr[i].Y() << "]" << " ";
	std::cout << std::endl;

}

void Stack::Reverse()
{
	if (Empty())							// �������� �� �������
		return;								// �����
	Square* buf = new Square[capacity];		// �������� ������ ���� �� �������
	int i = 0; int j = top;
	while (i != Size())
	{
		buf[i] = arr[j];
		i++;
		j--;
	}
	delete[] arr;						// ����������� ������ ������� �������
	arr = buf;							// ������� ��������� �� ����������� ����� ������
}