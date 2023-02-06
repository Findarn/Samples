#pragma once
#include <iostream>
#include <sstream>
class Square		// ������ ���� ���������
{
private:
	int x;			// ����� ������
	int y;			// ����� �������
	bool open;		// ������� �������� ������
	bool start;		// ������� ������
	bool end;		// ������� ������
	int sWave;		// ��������� "�����" (0 - ����� �� ��������, 1 - ��������, 2 - ���������������, 3 - ����)
	int wave;		// ��� "�����"

public:
	Square();				// ����������� �� ���������
	Square(int x, int y);	// ����������� ���������

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

	void CopyFrom(Square sq);	// ����������� �������� ������ ������
	std::string Display(int mode);		// ����������� ����������� ����������� ������
	void Reset();				// ����� �������� ������ � �����������
};