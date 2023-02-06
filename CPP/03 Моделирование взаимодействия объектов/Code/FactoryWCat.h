#pragma once
#pragma once
#include "General.h"
#include "AbsFactoryCat.h"

class FactoryWCat :FactoryCat
{
public:
	Cat createCat(Shelter* S) override;
};