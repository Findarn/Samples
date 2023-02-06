#pragma once

#include <stdio.h>
#include <iostream>
#include <Windows.h>
#include <limits>
#include <list>
#include <string>


class Cat;
class Shelter;
using namespace std;



class Cat
{
	private:
		bool Gender;		//кошки - true, кот - false
		bool Satiety;		//true - накормлен, false - не накормлен
		int Age;			//в месяцах
		int FoodWeek;		//затраты еды на неделю
		int WaterWeek;		//затраты воды на неделю
		string Name;		//кличка
		string Breed;		//порода
		string Color;		//окрас
		Shelter *BindShelter;	//указатель на питомник, в котором находится котик	
	public:
		Cat();																					//базовый конструктор
		void Create(bool G, int A, int F, int W, string N, string B, string C, Shelter* S);		//задать информацию о котике
		string GetInfo();																		//получить информацию о котике
		string GetName();
		void SetBinded(Shelter *BS);
		void SetSatiety(bool S);
		bool Feed();																			//потратить ресурсы на покорм котика на неделю

		friend bool operator== (const Cat& C1, const Cat& C2);
		friend bool operator!= (const Cat& C1, const Cat& C2);
};	//класс котика

class Shelter
{
	private:
		int Food;				//запасы еды
		int Water;				//запасы воды
		double Money;			//запасы денег
		string Name;			//название питомника
		//list<Cat> ListOfCats;	//список котов в питомнике	
	public:		
		list<Cat> ListOfCats;	//список котов в питомнике	
		Shelter();										//базовый конструктор
		void Create(int F, int W, double M, string N);	//задать информацию о питомнике
		void AddCat();									//добавить котика в питомник
		void BuyFood();									//покупка еды
		void BuyWater();								//покупка воды
		void Adoption();								//выдача котика на руки
		list<Shelter> Transfer(list<Shelter> LoS);				//передача котика в другой питомник
		string GetInfo();								//получить информацию о питомнике
		void PrintCats();								//печать списка котиков в питомнике
		void SetFood(int f);							
		int GetFood();
		void SetWater(int w);
		int GetWater();
		string GetName();
		Shelter* Pointer();

		friend bool operator== (const Shelter& S1, const Shelter& S2);
		friend bool operator!= (const Shelter& S1, const Shelter& S2);

};	//класс питомника

