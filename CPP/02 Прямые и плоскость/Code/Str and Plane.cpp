//include
#include<stdlib.h>
#include<fstream>
#include<iostream>
#include<strstream>
#include<iomanip>
#include<math.h>
#include<windows.h>
#include<string>
#include<locale.h>
using namespace std;//Пространство имен std.

struct plane		//Коэффициенты уравненяи плоскости в пространстве 
{
	float A;
	float B;
	float C;
	float D;
};

struct points		//Пара точек в пространстве
{
	float px1;
	float py1;
	float pz1;
	float px2;
	float py2;
	float pz2;
};

struct vec			//Координаты направляющего вектора
{
	float x;
	float y;
	float z;
};

//прототипы
plane input_plane(float low_b, float high_b);									//ввод коэффициентов уравнения плоскости
points input_points(float low_b, float high_b);									//ввод пары точек
void input_random_points(float low_b, float high_b, int size, points *pr);		//генерация массива заданного размера со случайным значением координат точек
vec points_transform_to_vec(points *p);											//преобразование типа points в тип vec
vec plane_transform_to_vec(plane *pl);											//преобразование типа planes в тип vec
int get_number(int low_n, int high_n);											//ввод числа int с клавиатуры
float random(float low_n, float high_n);										//ввод числа float с клавиатуры
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void print_plane(plane *pl);													//печать уравнения плоскости
void print_points(points *p);													//печать пар точек
void print_vec(vec *v);															//печать координат вектора
void print_rez(int *mas, int kol);														//печать индексов перпендикулярных плоскости прямых

void main()
{
	plane Plane;				
	points *p, *pr;					
	int size;
	vec *v, *vr;
	vec vec_plane;
	int kol=0, kolr=0;
	int *index, *indexr;

	srand((unsigned int)time(0));

	cout << "Enter the coefficients of the equation of the plane in space (A, B, C, D)" << endl;
	Plane = input_plane(-10.0, 10.0);
	cout << "Enter the number of elements of the arrays of point pairs" << endl;
	size = get_number(1, 40);
	p = (points*)malloc(size * sizeof(points));			//выделение памяти для массива пар точек вводимых с клавиатуры
	pr = (points*)malloc(size * sizeof(points));		//выделение памяти для массива пар точек, заданных случайным генератором
	v = (vec*)malloc(size * sizeof(vec));				//выделение памяти для массива координат направляющих векторов (для точек, введённых с клавиатуры)
	vr = (vec*)malloc(size * sizeof(vec));				//выделение памяти для массива координат направляющих векторов (для точек, заданных случайным образом)
	index = (int*)malloc(size * sizeof(int));			//выделение памяти для массива индексов перпендикулярных прямых (точки заданы вручную)
	indexr = (int*)malloc(size * sizeof(int));			//выделение памяти для массива индексов перпендикулярных прямых (точки заданы случайно)

	input_random_points(-10.0, 10.0, size, pr);		//формирование массива пар точек с помощью генератора случайных чисел
	cout << "Enter the coordinates - T1.x T1.y T1.z T2.x T2.y T2.z" << endl;
	for (int i = 0; i < size; i++)						//формирование массива пар точек через ввод с клавиатуры
	{
		p[i] = input_points(-10.0, 10.0);
	}

	cout << "Print the equation of the plane with entered coefficients" << endl;
	print_plane(&Plane);					//выводим на экран уравнение плоскости
	cout << "Print the array of point pairs, that set manually:" << endl;
	for (int i = 0; i < size; i++)
	{
		print_points(&p[i]);				//выводим на экран массив пар точек, заданных вручную
	}
	cout << "Print the array of point pairs, that set randomly:" << endl;
	for (int i = 0; i < size; i++)
	{
		print_points(&pr[i]);				//выводим на экран массив пар точек, заданных случайно
	}

	vec_plane = plane_transform_to_vec(&Plane);		//преобразовываем к-эфы уравнения плоскости в нормальный вектор плоскости
	for (int i = 0; i < size; i++)
	{
		v[i] = points_transform_to_vec(&p[i]);		//преобразовываем массивы пар точек в массивы направляющих векторов
		vr[i] = points_transform_to_vec(&pr[i]);
	}

	cout << "Print the coordinates of normal plane vector" << endl;
	print_vec(&vec_plane);			//выводим на экран координаты нормального вектора плоскости
	cout << "Print the coordinates of directing straight vector (manually set points):" << endl;
	for (int i = 0; i < size; i++)
	{
		print_vec(&v[i]);			//выводим на экран массив координат направляющих векторов ( из точек, заданных вручную)
	}
	cout << "Print the coordinates of directing straight vector (randomly set points):" << endl;
	for (int i = 0; i < size; i++)
	{
		print_vec(&vr[i]);			//выводим на экран массив координат направляющих векторов (из точек, заданных случайно)
	}

	for (int i = 0; i < size; i++)									//проверяем на перпендикулярность данные, введённые вручную
	{
		if (((vec_plane.y * v[i].z) - (vec_plane.z * v[i].y)) == 0 &&
			((vec_plane.x * v[i].z) - (vec_plane.z * v[i].x)) == 0 &&		//условие коллинеарности векторов
			((vec_plane.x * v[i].y) - (vec_plane.y * v[i].x)) == 0)
		{
			index[kol] = i;											//записываем индексы в массив индексов
			kol++;													//подсчитываем количество
		}
	}
	for (int i = 0; i < size; i++)										//проверяем на перпендикулярность данные, заданные случайно
	{
		if (((vec_plane.y * vr[i].z) - (vec_plane.z * vr[i].y)) == 0 &&
			((vec_plane.x * vr[i].z) - (vec_plane.z * vr[i].x)) == 0 &&		//условие коллинеарности векторов
			((vec_plane.x * vr[i].y) - (vec_plane.y * vr[i].x)) == 0)
		{
			indexr[kolr] = i;											//записываем индексы в массив индексов
			kolr++;														//подсчитываем количество
		}
	}

	
	cout << "Index of straight, that perpendicular to the plane - manually points(" << kol << "):" << endl;
	print_rez(index, kol);
	cout << "Index of straight, that perpendicular to the plane - randomly points(" << kolr << "):" << endl;
	print_rez(indexr, kolr); 

	free(p); free(pr); free(v); free(vr); free(index); free(indexr);	//освобождаем выделенную память
	system("pause");
}

plane input_plane(float low_b, float high_b)
{
	plane pl;
	bool Cond = false;
	do
	{
		Cond = true;
		cin >> pl.A >> pl.B >> pl.C >> pl.D;
		if (pl.A < low_b || pl.A > high_b ||
			pl.B < low_b || pl.B > high_b ||
			pl.C < low_b || pl.C > high_b ||
			pl.D < low_b || pl.D > high_b)
		{
			cout << "Incorrect coefficients. Try again.." << endl;
			Cond = false;
		}
	} while (Cond == false);
		return pl;
}//ввод коэффициентов уравнения плоскости
points input_points(float low_b, float high_b)
{
	points p;
	bool Cond = false;
	do
	{
		Cond = true;
		cin >> p.px1 >> p.py1 >> p.pz1 >> p.px2 >> p.py2 >> p.pz2;
		if (p.px1 < low_b || p.px1 > high_b ||
			p.py1 < low_b || p.py1 > high_b ||
			p.pz1 < low_b || p.pz1 > high_b ||
			p.px2 < low_b || p.px2 > high_b ||
			p.py2 < low_b || p.py2 > high_b ||
			p.pz2 < low_b || p.pz2 > high_b)
		{
			cout << "Incorrect coordinates. Try again." << endl;
			Cond = false;
		}
	} while (Cond == false);
	return p;
}//ввод пары точек
void input_random_points(float low_b, float high_b, int size, points *pr)
{
	for (int i = 0; i < size; i++)
	{
		pr[i].px1 = random(low_b, high_b);
		pr[i].py1 = random(low_b, high_b);
		pr[i].pz1 = random(low_b, high_b);
		pr[i].px2 = random(low_b, high_b);
		pr[i].py2 = random(low_b, high_b);
		pr[i].pz2 = random(low_b, high_b);
	}	
}//генерация массива заданного размера со случайным значением координат точек
vec points_transform_to_vec(points* p)
{
	vec v;
	v.x = p->px2 - p->px1;
	v.y = p->py2 - p->py1;
	v.z = p->pz2 - p->pz1;
	return v;
}//преобразование типа points в тип vec
vec plane_transform_to_vec(plane* pl)
{
	vec v;
	v.x = pl->A;
	v.y = pl->B;
	v.z = pl->C;
	return v;
}//преобразование типа planes в тип vec
int get_number(int low_n, int high_n)
{
	int number;
	bool Cond = false;

	do
	{
		Cond = true;
		cin >> number;
		if (number < low_n || number > high_n)
		{
			cout << "Incorrect number. Try again." << endl;
			Cond = false;
		}
	} while (Cond == false);
	return number;
}//ввод числа int с клавиатуры
float random(float low_n, float high_n)
{
	return (float)(rand()) / RAND_MAX * (high_n - low_n) + low_n;
}//ввод числа float с клавиатуры
void print_plane(plane* pl)
{
	cout << pl->A << "x + " << pl->B << "y + " << pl->C << "z + " << pl->D << " = 0" << endl;
}//печать уравнения плоскости
void print_points(points* p)
{
	cout << "T1{" << p->px1 << ";" << p->py1 << ";" << p->pz1 << "}, ";
	cout << "T2{" << p->px2 << ";" << p->py2 << ";" << p->pz2 << "}" << endl;

}//печать пар точек
void print_vec(vec* v)
{
	cout << "(" << v->x << ";" << v->y << ";" << v->z << ")" << endl;
}//печать координат вектора
void print_rez(int* mas, int kol)
{
	for (int i = 0; i < kol; i++)
	{
		cout << mas[i] << " ";
	}
	cout << endl;
}//печать индексов перпендикулярных плоскости прямых