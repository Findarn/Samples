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
		cout << "\nВведите запасы еды в питомнике: " << endl;
		cin >> buf;
		if (buf < 0)
		{
			cout << "\nНеверное количество запасов еды!" << endl;
			correct = false;
		}
	}
	int F = buf;
	correct = false;

	while (correct != true)
	{
		correct = true;
		buf = 0;
		cout << "\nВведите запасы воды в питомнике: " << endl;
		cin >> buf;
		if (buf < 0)
		{
			cout << "\nНеверное количество запасов воды!" << endl;
			correct = false;
		}
	}
	int W = buf;
	correct = false;

	while (correct != true)
	{
		correct = true;
		Buf = 0;
		cout << "\nВведите запасы денег в питомнике: " << endl;
		cin >> Buf;
		if (Buf < 0)
		{
			cout << "\nНеверное количество денег!" << endl;
			correct = false;
		}
	}
	double M = Buf;
	correct = false;

	while (correct != true)
	{
		correct = true;
		BUF = "";
		cout << "\nВведите название питомника: " << endl;
		cin >> BUF;
		if (BUF == "")
		{
			cout << "\nНазвание питомника не задано!" << endl;
			correct = false;
		}
	}
	string N = BUF;
	correct = false;

	NewShelter.Create(F, W, M, N);
	return NewShelter;
}