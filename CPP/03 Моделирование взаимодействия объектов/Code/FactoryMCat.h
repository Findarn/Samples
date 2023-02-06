#pragma once
#include "General.h"
#include "AbsFactoryCat.h"

class FactoryMCat:FactoryCat
{
	public:
		Cat createCat(Shelter* S) override;
};