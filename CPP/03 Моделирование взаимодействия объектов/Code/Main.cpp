#include "General.h"
#include "AbsFactoryCat.h"
#include "FactoryMCat.h"
#include "FactoryMKitty.h"
#include "FactoryWCat.h"
#include "FactoryWKitty.h"
#include "FactoryShelter.h"


void main()
{
	setlocale(LC_ALL, "Russian");
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	list<Shelter> ListOfShelters;
	FactoryShelter FS;
	bool correct = false;
	int mode_main;
	int mode_shelter;
	int num_shelter;
	int week_counter = 0;
	Shelter NewShelter;
	list<Shelter>::iterator Selected;
	do
	{
		cout << "������� ���������� ��������� �����������" << endl;
		cout << "\t0 - �����" << endl;
		cout << "\t1 - ������ ������ ����������" << endl;
		cout << "\t2 - �������� ��������" << endl;
		cout << "\t3 - ����� ���������" << endl;
		cout << "\t4 - ������� ������" << endl;

		correct = false;
		while (correct != true)
		{
			correct = true;
			cin >> mode_main;
			if (mode_main < 0 || mode_main > 4)
			{
				correct = false;
			}
		}

		switch (mode_main)
		{
		case 0: { break; }
		case 1:
		{
			if (ListOfShelters.empty() == true)
		{
			cout << "������ ���������� ����!" << endl;
			break;
		}
		else
		{
			for (list<Shelter>::iterator i = ListOfShelters.begin(); i != ListOfShelters.end(); ++i)
			{
				cout << i->GetInfo() << endl;
			}
			break;
		}
		}
		case 2:
		{
			NewShelter = FS.createShelter();
		bool cond = true;
		for (list<Shelter>::iterator i = ListOfShelters.begin(); i != ListOfShelters.end(); ++i)
		{
			if (i->GetName() == NewShelter.GetName())
			{
				cond = false;
				cout << "�������� � ����� ������ ��� ������������ � ������!" << endl; break;
			}
		}
		if (cond == true)
		{
			ListOfShelters.push_back(NewShelter); break;
		}
		else
		{
			break;
		}
		}
		case 3:
		{
			cout << "������� ����� ������������ ��������� (��������� ������ � ����)" << endl;
			correct = false;
			while (correct != true)
			{
				correct = true;
				cin >> num_shelter;
				if (num_shelter < 0 || num_shelter >= ListOfShelters.size())
				{
					correct = false;
				}
			}
			int a = 0;
			for (list<Shelter>::iterator i = ListOfShelters.begin(); i != ListOfShelters.end(); ++i)
			{
				if (a == num_shelter)
				{
					Selected = i;					
				}
				a++;
			}
			do
			{
				cout << "������ �������� " << Selected->GetName() << endl;
				cout << "\t0 - ����� � ������� ����" << endl;
				cout << "\t1 - ���������� � ��������� � ������������ �����" << endl;
				cout << "\t2 - �������� ���� � ��������" << endl;
				cout << "\t3 - ������ ���" << endl;
				cout << "\t4 - ������ ����" << endl;
				cout << "\t5 - ��������� �����" << endl;
				cout << "\t6 - ���� �������� � ������� ���� � ������ ������" << endl;
				cout << "\t7 - �������� ���� � ������ ��������" << endl;

				correct = false;
				while (correct != true)
				{
					correct = true;
					cin >> mode_shelter;
					if (mode_shelter < 0 || mode_shelter > 7)
					{
						correct = false;
					}
				}

				switch (mode_shelter)
				{
				case 0: {break; }
				case 1:
				{
					cout << Selected->GetInfo() << endl;
					Selected->PrintCats(); break;
				}
				case 2: {Selected->AddCat(); break; }
				case 3: {Selected->BuyFood(); break; }
				case 4: {Selected->BuyWater(); break; }
				case 5:
				{
					for (list<Cat>::iterator i = Selected->ListOfCats.begin(); i != Selected->ListOfCats.end(); ++i)
					{
						if (i->Feed() == false)
						{
							cout << "�� " << i->GetName() << "� ������ ������� ��� �� �������!" << endl; break;
						}
					}
					break;
				}
				case 6: {Selected->Adoption(); break; }
				case 7: {ListOfShelters = Selected->Transfer(ListOfShelters); mode_shelter = 0; break; }
				}

			} while (mode_shelter != 0); break;
		}
		case 4:		
		{
			week_counter++;
			cout << "������ ������ �" << week_counter << ". ���� �� ���� ���������� �������������." << endl;
			for (list<Shelter>::iterator i = ListOfShelters.begin(); i != ListOfShelters.end(); ++i)
			{
				for (list<Cat>::iterator j = i->ListOfCats.begin(); j != i->ListOfCats.end(); ++j)
				{
					j->SetSatiety(false);
				}
			}
			break;
		}		
		}

	} while (mode_main != 0);
	system("pause");
	return;
}