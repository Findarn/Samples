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
		bool Gender;		//����� - true, ��� - false
		bool Satiety;		//true - ���������, false - �� ���������
		int Age;			//� �������
		int FoodWeek;		//������� ��� �� ������
		int WaterWeek;		//������� ���� �� ������
		string Name;		//������
		string Breed;		//������
		string Color;		//�����
		Shelter *BindShelter;	//��������� �� ��������, � ������� ��������� �����	
	public:
		Cat();																					//������� �����������
		void Create(bool G, int A, int F, int W, string N, string B, string C, Shelter* S);		//������ ���������� � ������
		string GetInfo();																		//�������� ���������� � ������
		string GetName();
		void SetBinded(Shelter *BS);
		void SetSatiety(bool S);
		bool Feed();																			//��������� ������� �� ������ ������ �� ������

		friend bool operator== (const Cat& C1, const Cat& C2);
		friend bool operator!= (const Cat& C1, const Cat& C2);
};	//����� ������

class Shelter
{
	private:
		int Food;				//������ ���
		int Water;				//������ ����
		double Money;			//������ �����
		string Name;			//�������� ���������
		//list<Cat> ListOfCats;	//������ ����� � ���������	
	public:		
		list<Cat> ListOfCats;	//������ ����� � ���������	
		Shelter();										//������� �����������
		void Create(int F, int W, double M, string N);	//������ ���������� � ���������
		void AddCat();									//�������� ������ � ��������
		void BuyFood();									//������� ���
		void BuyWater();								//������� ����
		void Adoption();								//������ ������ �� ����
		list<Shelter> Transfer(list<Shelter> LoS);				//�������� ������ � ������ ��������
		string GetInfo();								//�������� ���������� � ���������
		void PrintCats();								//������ ������ ������� � ���������
		void SetFood(int f);							
		int GetFood();
		void SetWater(int w);
		int GetWater();
		string GetName();
		Shelter* Pointer();

		friend bool operator== (const Shelter& S1, const Shelter& S2);
		friend bool operator!= (const Shelter& S1, const Shelter& S2);

};	//����� ���������

