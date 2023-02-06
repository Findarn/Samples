#pragma once
#include"Square.h"
#include <iostream>
#include <new>

class Stack		// ���������������� ����
{
private:
	Square* arr;		// ���������, ����� ������� ����������� ���������� ������
	int capacity;		// ���������� ������ ��� ���������� ������
	int top;			// ������ ������� ������� �����

public:
	Stack();				// ����������� �� ���������
	Stack(int size);		// �����������, �������� ��������� ������

	void Push(Square Sq);	// ���������� �������� � �����
	Square Pop();			// ������ �������� ��������
	Square Peek();			// �������� �������� ��������
	
	int Size();				// �������� ������ �����
	bool Empty();			// ���������, ���� �� ����
	void Reverse();			// ������ �����
	void Clear();			// �������� ����
	void Display();			// ������� ���� �� �����
};



