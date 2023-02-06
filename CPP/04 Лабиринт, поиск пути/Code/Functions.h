#pragma once
#include "Labirint.h"
#include "MyStack.h"

Square GetUpS(Square cur, Labirint labirint);
Square GetDownS(Square cur, Labirint labirint);
Square GetLeftS(Square cur, Labirint labirint);
Square GetRightS(Square cur, Labirint labirint);
void PathFinder(Labirint &labirint, Stack &P);
void ShowPath(Labirint labirint, Stack &P);