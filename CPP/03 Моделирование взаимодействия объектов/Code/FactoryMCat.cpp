#include "FactoryMCat.h"

Cat FactoryMCat::createCat(Shelter* S)
{
	Cat NewCat;
	bool G = false;
	bool correct = false;
	int buf;
	string BUF;

	while (correct != true)
	{
		correct = true;
		buf = 0;
		cout << "\n������� ������� ������ (� �������): " << endl;
		cin >> buf;
		if (buf < 12)
		{
			cout << "\n�������� �������! ������� ������� ��������� ����!" << endl;
			correct = false;
		}
	}
	int A = buf;
	correct = false;

	while (correct != true)
	{
		correct = true;
		buf = 0;
		cout << "\n������� ������� ��� �� ���� � ������: " << endl;
		cin >> buf;
		if (buf < 0)
		{
			cout << "\n�������� ������� ���!" << endl;
			correct = false;
		}
	}
	int F = buf;
	correct = false;

	while (correct != true)
	{
		correct = true;
		buf = 0;
		cout << "\n������� ������� ���� �� ���� � ������: " << endl;
		cin >> buf;
		if (buf < 0)
		{
			cout << "\n�������� ������� ����!" << endl;
			correct = false;
		}
	}
	int W = buf;
	correct = false;

	while (correct != true)
	{
		correct = true;
		BUF = "";
		cout << "\n������� ��� ����: " << endl;
		cin >> BUF;
		if (BUF == "")
		{
			cout << "\n�� ������ ��� ����!" << endl;
			correct = false;
		}
	}
	string N = BUF;
	correct = false;

	while (correct != true)
	{
		correct = true;
		BUF = "";
		cout << "\n������� ������ ����: " << endl;
		cin >> BUF;
		if (BUF == "")
		{
			cout << "\n�� ������ ������ ����!" << endl;
			correct = false;
		}
	}
	string B = BUF;
	correct = false;

	while (correct != true)
	{
		correct = true;
		BUF = "";
		cout << "\n������� ����� ����: " << endl;
		cin >> BUF;
		if (BUF == "")
		{
			cout << "\n�� ����� ����� ����!" << endl;
			correct = false;
		}
	}
	string C = BUF;
	correct = false;
	NewCat.Create(G, A, F, W, N, B, C, S);
	return NewCat;
}