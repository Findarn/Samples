#include "FactoryWCat.h"

Cat FactoryWCat::createCat(Shelter* S)
{
	Cat NewCat;
	bool G = true;
	bool correct = false;
	int buf;
	string BUF;

	while (correct != true)
	{
		correct = true;
		buf = 0;
		cout << "\nВведите возраст кошки (в месяцах): " << endl;
		cin >> buf;
		if (buf < 12)
		{
			cout << "\nНеверный возраст! Задайте возраст взрослой кошки!" << endl;
			correct = false;
		}
	}
	int A = buf;
	correct = false;

	while (correct != true)
	{
		correct = true;
		buf = 0;
		cout << "\nВведите затраты еды на кошку в неделю: " << endl;
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
		cout << "\nВведите затраты воды на кошку в неделю: " << endl;
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
		cout << "\nВведите имя кошки: " << endl;
		cin >> BUF;
		if (BUF == "")
		{
			cout << "\nНе задано имя кошки!" << endl;
			correct = false;
		}
	}
	string N = BUF;
	correct = false;

	while (correct != true)
	{
		correct = true;
		BUF = "";
		cout << "\nВведите породу кошки: " << endl;
		cin >> BUF;
		if (BUF == "")
		{
			cout << "\nНе задана порода кошки!" << endl;
			correct = false;
		}
	}
	string B = BUF;
	correct = false;

	while (correct != true)
	{
		correct = true;
		BUF = "";
		cout << "\nВведите окрас кошки: " << endl;
		cin >> BUF;
		if (BUF == "")
		{
			cout << "\nНе задан окрас кошки!" << endl;
			correct = false;
		}
	}
	string C = BUF;
	correct = false;
	NewCat.Create(G, A, F, W, N, B, C, S);
	return NewCat;
}