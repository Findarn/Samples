#pragma once
#pragma once
#include "General.h"
#include "AbsFactoryCat.h"

class FactoryWKitty :FactoryCat
{
public:
	Cat createCat(Shelter* S) override;
};