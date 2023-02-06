#include "FactoryMKitty.h"

Cat FactoryMKitty::createCat(Shelter* S)
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
		cout << "\nВведите возраст котёнка (в месяцах): " << endl;
		cin >> buf;
		if (buf >= 12 || buf < 0)
		{
			cout << "\nНеверный возраст! Задайте возраст детского котёнка!" << endl;
			correct = false;
		}
	}
	int A = buf;
	correct = false;

	while (correct != true)
	{
		correct = true;
		buf = 0;
		cout << "\nВведите затраты еды на котёнка в неделю: " << endl;
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
		cout << "\nВведите затраты воды на котёнка в неделю: " << endl;
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
		cout << "\nВведите имя котёнка: " << endl;
		cin >> BUF;
		if (BUF == "")
		{
			cout << "\nНе задано имя котёнка!" << endl;
			correct = false;
		}
	}
	string N = BUF;
	correct = false;

	while (correct != true)
	{
		correct = true;
		BUF = "";
		cout << "\nВведите породу котёнка: " << endl;
		cin >> BUF;
		if (BUF == "")
		{
			cout << "\nНе задана порода котёнка!" << endl;
			correct = false;
		}
	}
	string B = BUF;
	correct = false;

	while (correct != true)
	{
		correct = true;
		BUF = "";
		cout << "\nВведите окрас котёнка: " << endl;
		cin >> BUF;
		if (BUF == "")
		{
			cout << "\nНе задан окрас котёнка!" << endl;
			correct = false;
		}
	}
	string C = BUF;
	correct = false;
	NewCat.Create(G, A, F, W, N, B, C, S);
	return NewCat;
}