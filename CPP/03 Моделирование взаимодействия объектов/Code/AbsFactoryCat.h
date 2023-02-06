#pragma once
#include "General.h"

class FactoryCat
{
	public:
		virtual Cat createCat(Shelter* S) = 0;
};
