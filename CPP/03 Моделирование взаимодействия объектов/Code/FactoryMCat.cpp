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
		cout << "\nВведите возраст котика (в месяцах): " << endl;
		cin >> buf;
		if (buf < 12)
		{
			cout << "\nНеверный возраст! Задайте возраст взрослого кота!" << endl;
			correct = false;
		}
	}
	int A = buf;
	correct = false;

	while (correct != true)
	{
		correct = true;
		buf = 0;
		cout << "\nВведите затраты еды на кота в неделю: " << endl;
		cin >> buf;
		if (buf < 0)
		{
			cout << "\nНеверные затраты еды!" << endl;
			correct = false;
		}
	}
	int F = buf;
	correct = false;

	while (correct != true)
	{
		correct = true;
		buf = 0;
		cout << "\nВведите затраты воды на кота в неделю: " << endl;
		cin >> buf;
		if (buf < 0)
		{
			cout << "\nНеверные затраты воды!" << endl;
			correct = false;
		}
	}
	int W = buf;
	correct = false;

	while (correct != true)
	{
		correct = true;
		BUF = "";
		cout << "\nВведите имя кота: " << endl;
		cin >> BUF;
		if (BUF == "")
		{
			cout << "\nНе задано имя кота!" << endl;
			correct = false;
		}
	}
	string N = BUF;
	correct = false;

	while (correct != true)
	{
		correct = true;
		BUF = "";
		cout << "\nВведите породу кота: " << endl;
		cin >> BUF;
		if (BUF == "")
		{
			cout << "\nНе задана порода кота!" << endl;
			correct = false;
		}
	}
	string B = BUF;
	correct = false;

	while (correct != true)
	{
		correct = true;
		BUF = "";
		cout << "\nВведите окрас кота: " << endl;
		cin >> BUF;
		if (BUF == "")
		{
			cout << "\nНе задан окрас кота!" << endl;
			correct = false;
		}
	}
	string C = BUF;
	correct = false;
	NewCat.Create(G, A, F, W, N, B, C, S);
	return NewCat;
}