#include "FactoryShelter.h"

Shelter FactoryShelter::createShelter()
{
	Shelter NewShelter;
	int buf;
	double Buf;
	string BUF;
	bool correct = false;

	while (correct != true)
	{
		correct = true;
		buf = 0;
		cout << "\n������� ������ ��� � ���������: " << endl;
		cin >> buf;
		if (buf < 0)
		{
			cout << "\n�������� ���������� ������� ���!" << endl;
			correct = false;
		}
	}
	int F = buf;
	correct = false;

	while (correct != true)
	{
		correct = true;
		buf = 0;
		cout << "\n������� ������ ���� � ���������: " << endl;
		cin >> buf;
		if (buf < 0)
		{
			cout << "\n�������� ���������� ������� ����!" << endl;
			correct = false;
		}
	}
	int W = buf;
	correct = false;

	while (correct != true)
	{
		correct = true;
		Buf = 0;
		cout << "\n������� ������ ����� � ���������: " << endl;
		cin >> Buf;
		if (Buf < 0)
		{
			cout << "\n�������� ���������� �����!" << endl;
			correct = false;
		}
	}
	double M = Buf;
	correct = false;

	while (correct != true)
	{
		correct = true;
		BUF = "";
		cout << "\n������� �������� ���������: " << endl;
		cin >> BUF;
		if (BUF == "")
		{
			cout << "\n�������� ��������� �� ������!" << endl;
			correct = false;
		}
	}
	string N = BUF;
	correct = false;

	NewShelter.Create(F, W, M, N);
	return NewShelter;
}