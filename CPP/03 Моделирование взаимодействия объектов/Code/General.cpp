#include "General.h"
#include "FactoryMCat.h"
#include "FactoryWCat.h"
#include "FactoryMKitty.h"
#include "FactoryWKitty.h"

Cat::Cat()
{
	this->Gender = NULL;
	this->Satiety = false;
	this->Age = 0;
	this->FoodWeek = 0;
	this->WaterWeek = 0;
	this->Name = "";
	this->Breed = "";
	this->Color = "";
	this->BindShelter = NULL;
}	//����������� �� ���������

void Cat::Create(bool G, int A, int F, int W, string N, string B, string C, Shelter* S)
{
	this->Gender = G;
	this->Age = A;
	this->FoodWeek = F;
	this->WaterWeek = W;
	this->Name = N;
	this->Breed = B;
	this->Color = C;
	this->BindShelter = S;
}	//���������� ���������� � ������

bool Cat::Feed()
{
	if (this->Satiety == true)
	{
		cout << "������� �� ����!" << endl;
		return true;
	}

	int f = this->BindShelter->GetFood() - this->FoodWeek;
	int w = this->BindShelter->GetWater() - this->WaterWeek;

	if (f < 0 || w < 0)
	{
		return false;
	}
	else
	{
		this->BindShelter->SetFood(f);
		this->BindShelter->SetWater(w);
		this->Satiety = true;
		return true;
	}
}	//������� ��������� ������

void Cat::SetSatiety(bool S)
{
	this->Satiety = S;
}

string Cat::GetName()
{
	return this->Name;
}

void Cat::SetBinded(Shelter *BS)
{
	this->BindShelter = BS;
}

string Cat::GetInfo()
{
	string result = "";
	if (this->Gender == true)
	{
		result += "����� �� ������ ";
	}
	else
	{
		result += "��� �� ������ ";
	}
	result += "\"" + this->Name + "\" ";
	if (this->Age >= 12)
	{
		result += ", �������: " + std::to_string(this->Age/12);
		result += " ���.";
	}
	else
	{
		result += ", �������: " + std::to_string(this->Age);
		result += " �������.";
	}	
	result += " ������: " + this->Breed + ". ";
	result += " ���������: " + this->Color + ". ";
	if (this->Satiety == true)
	{
		result += "���.";
	}
	else
	{
		result += "�������!";
	}
	/*result += "\n";*/
	return result;
}

Shelter::Shelter()
{
	this->Food = 0;
	this->Water = 0;
	this->Money = 0;
	this->Name = "";
	ListOfCats.clear();
}

void Shelter::Create(int F, int W, double M, string N)
{
	this->Food = F;
	this->Water = W;
	this->Money = M;
	this->Name = N;
	ListOfCats.clear();
}

void Shelter::AddCat()
{
	Cat NewCat;
	
	FactoryMCat FMC;
	FactoryWCat FWC;
	FactoryMKitty FMK;
	FactoryWKitty FWK;

	int mode;
	cout << "������ ������ �� ������ �������� � �������� \"" << this->Name << "\"?" << endl;
	cout << "1 - ��������� �������� ����" << endl;
	cout << "2 - �������� ������� �����" << endl;
	cout << "3 - �������� �������� ������" << endl;
	cout << "4 - ������� ������� �������" << endl;
	do
	{
		cin >> mode;
	} while (mode < 0 && mode > 4);
	switch (mode)
	{
		case 1: NewCat = FMC.createCat(this); break;
		case 2: NewCat = FWC.createCat(this); break;
		case 3: NewCat = FMK.createCat(this); break;
		case 4: NewCat = FWK.createCat(this); break;
	}
	this->ListOfCats.push_back(NewCat);
	cout << NewCat.GetInfo() << endl;
}

void Shelter::BuyFood()
{
	double price = 3.5;
	int count;
	cout << "������� ���������� ���, ������� ������� ������: " << endl;
	bool correct = false;

	while (correct != true)
	{
		correct = true;
		cin >> count;
		if (count < 0)
		{
			correct = false;
		}
	}

	if (this->Money < (double)count * price)
	{
		cout << "������������ ����� ��� �������!" << endl;
		return;
	}
	else
	{
		this->Money = this->Money - (double)count * price;
		this->Food = this->Food + count;
		cout << "������� ���������� �����: " << this->Money << endl;
		cout << "������� ���������� ���: " << this->Food << endl;
		return;
	}
}

void Shelter::BuyWater()
{
	double price = 1.25;
	int count;
	cout << "������� ���������� ����, ������� ������� ������: " << endl;
	bool correct = false;

	while (correct != true)
	{
		correct = true;
		cin >> count;
		if (count < 0)
		{
			correct = false;
		}
	}

	if (this->Money < (double)count * price)
	{
		cout << "������������ ����� ��� �������!" << endl;
		return;
	}
	else
	{
		this->Money = this->Money - (double)count * price;
		this->Water = this->Water + count;
		cout << "������� ���������� �����: " << this->Money << endl;
		cout << "������� ���������� ����: " << this->Water << endl;
		return;
	}
}

void Shelter::Adoption()
{
	bool correct = false;
	int index = 0; double money = 0;
	list<Cat>::iterator p;
	if (this->ListOfCats.empty() == true)
	{
		cout << "� ��������� ��� �������!" << endl;
		return;
	}
	cout << "\t\t������ ������� � ���������" << endl;
	for (list<Cat>::iterator i = this->ListOfCats.begin(); i != this->ListOfCats.end(); ++i)
	{
		cout << i->GetInfo() << endl;
	}

	cout << "�������� ������, �������� �������� �� ���������: " << endl;
	while (correct != true)
	{
		correct = true;
		cin >> index;
		if (index < 0 || index >= this->ListOfCats.size())
		{
			correct = false;
		}
	}
	int a = 0;
	for (list<Cat>::iterator i = this->ListOfCats.begin(); i != this->ListOfCats.end(); ++i)
	{
		if (a == index)
		{
			p = i;
			break;
		}
		a++;
	}
	cout << "�����: " << p->GetInfo() << endl;
	cout << "������� ����� �������������, ����������� �� ������: " << endl;
	correct = false;
	while (correct != true)
	{
		correct = true;
		cin >> money;
		if (money < 0)
		{
			correct = false;
		}
	}
	this->Money += money;
	this->ListOfCats.erase(p);
}

list<Shelter> Shelter::Transfer(list<Shelter> LoS)
{
	bool correct = false;
	int indexS = 0; int indexC = 0; double money = 0;
	list<Cat>::iterator p;
	list<Shelter>::iterator source, dest;	//source - ���� ��������, dest - ������ ��������

	if (this->ListOfCats.empty() == true)
	{
		cout << "� ��������� ��� �������!"<< endl;
		return LoS;
	}

	if (LoS.begin() == LoS.end())
	{
		cout << "��� ������� ��������� ��� �������� ������!"<< endl;
		return LoS;
	}
	cout << "\t\t������ ������� � ���������" << endl;
	for (list<Cat>::iterator i = this->ListOfCats.begin(); i != this->ListOfCats.end(); ++i)
	{
		cout << i->GetInfo() << endl;
	}

	cout << "�������� ������, �������� �������� �� ���������: " << endl;
	while (correct != true)
	{
		correct = true;
		cin >> indexC;
		if (indexC < 0 || indexC >= this->ListOfCats.size())
		{
			correct = false;
		}
	}
	int a = 0;
	for (list<Cat>::iterator i = this->ListOfCats.begin(); i != this->ListOfCats.end(); ++i)
	{
		if (a == indexC)
		{
			p = i;
			break;
		}
		a++;
	}
	cout << "�����: " << p->GetInfo() << endl;
	
	for (list<Shelter>::iterator i = LoS.begin(); i != LoS.end(); ++i)
	{
		if (*i == *this)
		{
			source = i;
			break;
		}
	}

	cout << "\t\t������ ����������" << endl;
	for (list<Shelter>::iterator i = LoS.begin(); i != LoS.end(); ++i)	
	{
		cout << i->GetInfo() << endl;
	}

	cout << "�������� ��������, ���� ������� ������: " << endl;
	correct = false;
	while (correct != true)
	{
		correct = true;
		cin >> indexS;
		if (indexS < 0 || indexS >= LoS.size())
		{
			correct = false;
		}
	}
	a = 0;
	Shelter Dest;
	Cat TransferedCat = *p;
	for (list<Shelter>::iterator i = LoS.begin(); i != LoS.end(); ++i)
	{
		if (a == indexS)
		{
			TransferedCat.SetBinded(i->Pointer());
			i->ListOfCats.push_back(TransferedCat);			
			break;
		}
		a++;
	}	
	for (list<Shelter>::iterator i = LoS.begin(); i != LoS.end(); ++i)
	{
		if (*i == *source)
		{
			for (list<Cat>::iterator j = i->ListOfCats.begin(); j != i->ListOfCats.end(); ++j)
			{
				if (*j == *p)
				{
					i->ListOfCats.erase(j);
					break;
				}
			}
		}
	}	
	return LoS;
}

string Shelter::GetInfo()
{
	string result = "";	
	result += "�������� ��� ��������� \"";
	result += this->Name;
	result += "\", �������� ";
	result += std::to_string(this->ListOfCats.size());
	result += " �������. ������ ��� - ";
	result += std::to_string(this->Food);
	result += ". ������ ���� - ";
	result += std::to_string(this->Water);
	result += ". ������� �������� ������� - ";
	result += std::to_string(this->Money);
	return result;
}

void Shelter::PrintCats()
{
	if (this->ListOfCats.empty() == true)
	{
		cout << "� ��������� ��� �������!" << endl;
		return;
	}
	int mode;
	bool correct = false;
	cout << "���������� ������ ������� � ���������?" << endl;
	cout << "\t 1 - ����������" << endl;
	cout << "\t 2 - �� ��������" << endl;
	while (correct != true)
	{
		correct = true;
		cin >> mode;
		if (mode != 1 && mode != 2)
		{
			correct = false;
		}
	}
	if (mode == 2)
	{
		return;
	}
	else
	{
		cout << "\t\t ������ ������� �������� \"" << this->Name << "\"" << endl;
		for (list<Cat>::iterator i = this->ListOfCats.begin(); i != this->ListOfCats.end(); ++i)
		{
			cout << i->GetInfo() << endl;
		}
	}
}

void Shelter::SetFood(int f)
{
	this->Food = f;
}

void Shelter::SetWater(int w)
{
	this->Water = w;
}

int Shelter::GetFood()
{
	return this->Food;
}

int Shelter::GetWater()
{
	return this->Water;
}

string Shelter::GetName()
{
	return this->Name;
}

Shelter* Shelter::Pointer()
{
	return this;
}

bool operator==(const Cat& C1, const Cat& C2)
{
	bool result;
	if (C1.Age == C2.Age && C1.Breed == C2.Breed && C1.Color == C2.Color && C1.FoodWeek == C2.FoodWeek &&
		C1.Gender == C2.Gender && C1.Name == C2.Name && C1.Satiety == C2.Satiety && C1.WaterWeek == C2.WaterWeek)
	{
		result = true;
	}
	else
	{
		result = false;
	}
	return result;
}

bool operator!=(const Cat& C1, const Cat& C2)
{
	bool result;
	if (C1.Age == C2.Age && C1.Breed == C2.Breed && C1.Color == C2.Color && C1.FoodWeek == C2.FoodWeek &&
		C1.Gender == C2.Gender && C1.Name == C2.Name && C1.Satiety == C2.Satiety && C1.WaterWeek == C2.WaterWeek)
	{
		result = false;
	}
	else
	{
		result = true;
	}
	return result;
}

bool operator== (const Shelter& S1, const Shelter& S2)
{
	bool result;
	if (S1.Food == S2.Food && S1.Money == S2.Money && S1.Name == S2.Name && S1.Water == S2.Water)
	{
		result = true;
	}
	else
	{
		result = false;		
	}
	return result;	
}

bool operator!= (const Shelter& S1, const Shelter& S2)
{
	bool result;
	if (S1.Food == S2.Food && S1.Money == S2.Money && S1.Name == S2.Name && S1.Water == S2.Water)
	{
		result = false;
	}
	else
	{
		result = true;
	}
	return result;
}