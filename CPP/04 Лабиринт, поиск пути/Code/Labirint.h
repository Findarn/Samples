#pragma once
#include "Square.h"
#include "MyStack.h"
#include <vector>
#include <iostream>
#include <iomanip>

class Labirint		// ��������
{
private:
	//std::vector <std::vector<Square>> field;		// ����
	Square start;									// ������ ������
	Square end;										// ������ ������
public:
	std::vector <std::vector<Square>> field;		// ����

	Labirint();						// ����������� �� ���������
	Labirint(int h, int w);			// ����������� �� ������-������

	/*std::vector <std::vector<Square>> Field();*/
	Square Start();
	Square End();

	void Create();		// ��������� ������ ��� ����
	void Borders();		// �������� ������
	void SetExitSquare();		// ��������� ������
	void Generate();	// ��������� ���������� �������� � �����������
	void SetStartSquare();	// ��������� ������
	void FinalSet();	// ���������� ����� � ���������
	void ComplexSet();	// ���������� ���� ������� �� �������� ���������
	void ClearLab();	// ������� ���������

	void Display(bool index, int mode, std::string msg);		// ����� �� �����
};