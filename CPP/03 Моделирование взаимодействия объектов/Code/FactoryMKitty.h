#pragma once
#include "General.h"
#include "AbsFactoryCat.h"

class FactoryMKitty :FactoryCat
{
public:
	Cat createCat(Shelter* S) override;
};