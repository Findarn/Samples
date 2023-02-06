#include "Square.h"

Square::Square()
{
	x = -1; y = -1;
	open = true;
	start = false;
	end = false;
	sWave = 0;
	wave = -1;
}

Square::Square(int x, int y)
{
	this->x = x; this->y = y;
	open = true;
	start = false;
	end = false;
	sWave = 0;
	wave = -1;
}

void Square::SetX(int x)		{ this->x = x; }
int Square::X()					{ return x; }

void Square::SetY(int y)		{ this->y = y; }
int Square::Y()					{ return y; }

void Square::SetOpen(bool o)	{ open = o; }
bool Square::Open()				{ return open; }

void Square::SetStart(bool s)	{ start = s; }
bool Square::Start()			{ return start; }

void Square::SetEnd(bool e)		{ end = e; }
bool Square::End()				{ return end; }

void Square::SetsWave(int s)	{ sWave = s; }
int Square::SWave()				{ return sWave; }

void Square::SetWave(int w)		{ wave = w; }
int Square::Wave()				{ return wave; }

std::string Square::Display(int mode)
{
	switch (mode)
	{
	case 0:
	{
		if (start)
		{
			return "i";
		}
		if (end)
			return "F";
		if (open)
			return " ";
		else
			return "x";
	}break;
	case 1:
	{
		if (start)
		{
			return "i";
		}
		if (end)
			return "F";
		if (open)
		{
			if (sWave == 0)
			{
				return " ";
			}
			if (sWave == 1 || sWave == 3)
			{
				std::ostringstream oss;
				oss.clear();
				oss << wave;
				return oss.str();
			}
			if (sWave == 2)
				return "-";
		}
		else
		{
			return "x";
		}
	}break;
	case 2:
	{
		if (start)
		{
			return "i";
		}
		if (end)
			return "F";
		if (open)
		{
			if (sWave == 3)
				return "*";
			else
				return " ";
		}
		else
		{
			return "x";
		}
	}break;
	}
}

void Square::CopyFrom(Square sq)
{
	this->x = sq.x;
	this->y = sq.y;
	this->open = sq.open;
	this->start = sq.start;
	this->end = sq.end;
	this->sWave = sq.sWave;
	this->wave = sq.wave;
}

void Square::Reset()
{
	x = -1; y = -1;
	open = true;
	start = false;
	end = false;
	sWave = 0;
	wave = -1;
}